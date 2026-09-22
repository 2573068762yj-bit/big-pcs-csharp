using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PcDebuger
{
    /// <summary>
    /// 解析 ELF 文件中的普通符号和 DWARF 调试类型。
    /// 解析结果最终转换为现有上位机能够直接使用的 VarOnline 列表。
    /// </summary>
    public class ElfDwarfParser
    {
        // ELF 符号类型 STT_OBJECT 表示一个数据对象，例如全局变量或静态变量。
        private const byte ELF_SYMBOL_TYPE_OBJECT = 0x01;

        // DWARF 标签定义，数值来自 DWARF 标准。
        private const ulong DW_TAG_ARRAY_TYPE = 0x01;
        private const ulong DW_TAG_ENUMERATION_TYPE = 0x04;
        private const ulong DW_TAG_MEMBER = 0x0D;
        private const ulong DW_TAG_POINTER_TYPE = 0x0F;
        private const ulong DW_TAG_STRUCTURE_TYPE = 0x13;
        private const ulong DW_TAG_TYPEDEF = 0x16;
        private const ulong DW_TAG_UNION_TYPE = 0x17;
        private const ulong DW_TAG_SUBRANGE_TYPE = 0x21;
        private const ulong DW_TAG_BASE_TYPE = 0x24;
        private const ulong DW_TAG_CONST_TYPE = 0x26;
        private const ulong DW_TAG_VARIABLE = 0x34;
        private const ulong DW_TAG_VOLATILE_TYPE = 0x35;
        private const ulong DW_TAG_RESTRICT_TYPE = 0x37;

        // DWARF 属性定义，解析变量名称、类型、大小和成员偏移时会使用这些属性。
        private const ulong DW_AT_LOCATION = 0x02;
        private const ulong DW_AT_NAME = 0x03;
        private const ulong DW_AT_BYTE_SIZE = 0x0B;
        private const ulong DW_AT_BIT_SIZE = 0x0D;
        private const ulong DW_AT_LOWER_BOUND = 0x22;
        private const ulong DW_AT_UPPER_BOUND = 0x2F;
        private const ulong DW_AT_ABSTRACT_ORIGIN = 0x31;
        private const ulong DW_AT_COUNT = 0x37;
        private const ulong DW_AT_DATA_MEMBER_LOCATION = 0x38;
        private const ulong DW_AT_ENCODING = 0x3E;
        private const ulong DW_AT_SPECIFICATION = 0x47;
        private const ulong DW_AT_TYPE = 0x49;
        private const ulong DW_AT_DATA_BIT_OFFSET = 0x6B;

        // DWARF 数据格式定义，格式决定属性值在文件中占用的字节数和解释方法。
        private const ulong DW_FORM_ADDR = 0x01;
        private const ulong DW_FORM_BLOCK2 = 0x03;
        private const ulong DW_FORM_BLOCK4 = 0x04;
        private const ulong DW_FORM_DATA2 = 0x05;
        private const ulong DW_FORM_DATA4 = 0x06;
        private const ulong DW_FORM_DATA8 = 0x07;
        private const ulong DW_FORM_STRING = 0x08;
        private const ulong DW_FORM_BLOCK = 0x09;
        private const ulong DW_FORM_BLOCK1 = 0x0A;
        private const ulong DW_FORM_DATA1 = 0x0B;
        private const ulong DW_FORM_FLAG = 0x0C;
        private const ulong DW_FORM_SDATA = 0x0D;
        private const ulong DW_FORM_STRP = 0x0E;
        private const ulong DW_FORM_UDATA = 0x0F;
        private const ulong DW_FORM_REF_ADDR = 0x10;
        private const ulong DW_FORM_REF1 = 0x11;
        private const ulong DW_FORM_REF2 = 0x12;
        private const ulong DW_FORM_REF4 = 0x13;
        private const ulong DW_FORM_REF8 = 0x14;
        private const ulong DW_FORM_REF_UDATA = 0x15;
        private const ulong DW_FORM_INDIRECT = 0x16;
        private const ulong DW_FORM_SEC_OFFSET = 0x17;
        private const ulong DW_FORM_EXPRLOC = 0x18;
        private const ulong DW_FORM_FLAG_PRESENT = 0x19;
        private const ulong DW_FORM_IMPLICIT_CONST = 0x21;

        // DW_OP_addr 表示表达式中直接保存了变量的绝对地址。
        private const byte DW_OP_ADDR = 0x03;

        // DW_OP_plus_uconst 表示在当前对象地址上增加一个无符号偏移。
        private const byte DW_OP_PLUS_UCONST = 0x23;

        // 防止异常类型递归或自引用类型导致无限递归。
        private const int MAX_EXPAND_DEPTH = 8;

        // 防止超大数组一次生成过多界面行。
        private const uint MAX_ARRAY_ITEMS = 4096;

        // 防止单个根变量展开出过多成员而阻塞界面。
        private const int MAX_LEAVES_PER_ROOT = 8192;

        /// <summary>
        /// 保存最近一次解析时的非致命警告。
        /// 当 DWARF 不存在或暂不支持时，仍可回退到 ELF 普通符号。
        /// </summary>
        public static string LastWarning = string.Empty;

        /// <summary>
        /// 读取一个 ELF 文件，并返回可以在在线变量界面中选择的变量。
        /// </summary>
        public static List<VarOnline> AnalysisElfFile(string path)
        {
            // 每次开始解析时先清除上一次留下的警告。
            LastWarning = string.Empty;

            // 空路径没有办法定位 ELF 文件，因此直接给出明确错误。
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("ELF文件路径为空！");
            }

            // 在读取文件前先检查文件是否存在，便于用户区分路径错误和格式错误。
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("没有找到ELF文件！", path);
            }

            // ELF 是二进制文件，所以必须按字节读取，不能使用文本读取函数。
            byte[] fileData = File.ReadAllBytes(path);

            // 第一层先解析 ELF 头、段表和符号表。
            ElfFile elfFile = AnalysisElf(fileData);

            try
            {
                // 第二层解析 ELF 内部的 DWARF 调试信息。
                DwarfDatabase dwarfDatabase = AnalysisDwarf(fileData, elfFile);

                // 将符号地址与 DWARF 类型关联，并展开结构体成员和数组元素。
                return MakeVarList(elfFile, dwarfDatabase);
            }
            catch (Exception ex)
            {
                // 没有 DWARF 时仍然保留普通的 2 字节和 4 字节 ELF 数据符号。
                LastWarning = "DWARF类型解析失败，已回退到普通ELF符号：" + ex.Message;

                // 回退结果不包含结构体子成员，但仍可以用于选择普通标量变量。
                return MakeFallbackVarList(elfFile);
            }
        }

        /// <summary>
        /// 解析 ELF 文件头、Section Header 和符号表。
        /// </summary>
        private static ElfFile AnalysisElf(byte[] fileData)
        {
            // 32 位 ELF 文件头至少需要 52 字节。
            if (fileData == null || fileData.Length < 52)
            {
                throw new InvalidDataException("文件长度不足，不是有效的ELF文件！");
            }

            // ELF 固定以 0x7F、E、L、F 四个字节开头。
            if (fileData[0] != 0x7F || fileData[1] != (byte)'E' ||
                fileData[2] != (byte)'L' || fileData[3] != (byte)'F')
            {
                throw new InvalidDataException("文件头不是有效的ELF格式！");
            }

            // EI_CLASS 为 1 表示 ELF32，为 2 表示 ELF64。
            bool is64Bit = fileData[4] == 2;

            // 当前解析器只接受标准 ELF32 或 ELF64 标记。
            if (fileData[4] != 1 && fileData[4] != 2)
            {
                throw new InvalidDataException("ELF位数标记无效！");
            }

            // EI_DATA 为 1 表示小端，为 2 表示大端。
            bool isLittleEndian = fileData[5] == 1;

            // 未知字节序无法可靠读取后续整数。
            if (fileData[5] != 1 && fileData[5] != 2)
            {
                throw new InvalidDataException("ELF字节序标记无效！");
            }

            // ELF64 文件头至少需要 64 字节。
            if (is64Bit && fileData.Length < 64)
            {
                throw new InvalidDataException("ELF64文件头不完整！");
            }

            // 创建带边界检查的二进制读取器，后续读取都通过它完成。
            ElfBinaryReader reader = new ElfBinaryReader(fileData, isLittleEndian);

            // 不同 ELF 位数的 Section Header 表偏移字段位置不同。
            ulong sectionHeaderOffset = is64Bit ? reader.ReadUInt64(40) : reader.ReadUInt32(32);

            // 不同 ELF 位数的 Section Header 单项大小字段位置不同。
            ushort sectionHeaderSize = is64Bit ? reader.ReadUInt16(58) : reader.ReadUInt16(46);

            // 不同 ELF 位数的 Section Header 数量字段位置不同。
            ushort sectionCount = is64Bit ? reader.ReadUInt16(60) : reader.ReadUInt16(48);

            // 该索引指向保存 Section 名称的字符串表。
            ushort sectionNameIndex = is64Bit ? reader.ReadUInt16(62) : reader.ReadUInt16(50);

            // 本版本暂不处理使用第零段保存扩展段数量的极少见 ELF 文件。
            if (sectionHeaderOffset == 0 || sectionHeaderSize == 0 || sectionCount == 0)
            {
                throw new InvalidDataException("ELF Section Header缺失！");
            }

            // 先验证整个 Section Header 表都位于文件范围内。
            ValidateRange(fileData, sectionHeaderOffset, (ulong)sectionHeaderSize * sectionCount,
                "ELF Section Header越界！");

            // 字符串表索引必须指向一个存在的 Section。
            if (sectionNameIndex >= sectionCount)
            {
                throw new InvalidDataException("ELF Section名称表索引无效！");
            }

            // 创建 ELF 解析结果对象。
            ElfFile elfFile = new ElfFile();

            // 记录 ELF 位数，DWARF 没有明确地址宽度时会使用它。
            elfFile.elfClass = is64Bit ? 64 : 32;

            // 记录字节序，DWARF 属性和表达式也沿用相同字节序。
            elfFile.isLittleEndian = isLittleEndian;

            // 逐项读取原始 Section Header。
            for (int index = 0; index < sectionCount; index++)
            {
                // 计算当前 Section Header 在文件中的绝对偏移。
                ulong itemOffset = sectionHeaderOffset + (ulong)index * sectionHeaderSize;

                // 创建当前 Section 对象。
                ElfSection section = new ElfSection();

                // 保存 Section 索引，符号表会通过索引关联所属 Section。
                section.index = index;

                // Section 名称目前只是字符串表偏移，稍后再转换成字符串。
                section.nameOffset = reader.ReadUInt32(ToInt32(itemOffset));

                // Section 类型用于识别符号表、字符串表和 DWARF 数据段。
                section.type = reader.ReadUInt32(ToInt32(itemOffset + 4));

                if (is64Bit)
                {
                    // ELF64 的虚拟地址位于 Section Header 的第 16 字节。
                    section.address = reader.ReadUInt64(ToInt32(itemOffset + 16));

                    // ELF64 的文件偏移位于 Section Header 的第 24 字节。
                    section.offset = reader.ReadUInt64(ToInt32(itemOffset + 24));

                    // ELF64 的数据长度位于 Section Header 的第 32 字节。
                    section.size = reader.ReadUInt64(ToInt32(itemOffset + 32));

                    // link 通常指向与当前段配套的字符串表。
                    section.link = reader.ReadUInt32(ToInt32(itemOffset + 40));

                    // entrySize 表示符号表等定长表格中每一项的大小。
                    section.entrySize = reader.ReadUInt64(ToInt32(itemOffset + 56));
                }
                else
                {
                    // ELF32 的虚拟地址位于 Section Header 的第 12 字节。
                    section.address = reader.ReadUInt32(ToInt32(itemOffset + 12));

                    // ELF32 的文件偏移位于 Section Header 的第 16 字节。
                    section.offset = reader.ReadUInt32(ToInt32(itemOffset + 16));

                    // ELF32 的数据长度位于 Section Header 的第 20 字节。
                    section.size = reader.ReadUInt32(ToInt32(itemOffset + 20));

                    // ELF32 的 link 位于 Section Header 的第 24 字节。
                    section.link = reader.ReadUInt32(ToInt32(itemOffset + 24));

                    // ELF32 的 entrySize 位于 Section Header 的第 36 字节。
                    section.entrySize = reader.ReadUInt32(ToInt32(itemOffset + 36));
                }

                // NOBITS 段在文件中没有实际数据，因此只验证真正占用文件空间的段。
                if (section.type != 8 && section.size > 0)
                {
                    ValidateRange(fileData, section.offset, section.size, "ELF Section数据越界！");
                }

                // 将 Section 保存起来，后面再统一解析名称。
                elfFile.sectionList.Add(section);
            }

            // 找到保存 Section 名称的字符串表。
            ElfSection sectionNameTable = elfFile.sectionList[sectionNameIndex];

            // 将每个 Section 的名称偏移转换为可读名称。
            foreach (ElfSection section in elfFile.sectionList)
            {
                section.name = ReadString(fileData, sectionNameTable, section.nameOffset);
            }

            // 用名称和地址去重，避免 .symtab 与 .dynsym 产生重复项。
            Dictionary<string, ElfSymbol> uniqueSymbolMap = new Dictionary<string, ElfSymbol>();

            // ELF 的 SHT_SYMTAB 为 2，SHT_DYNSYM 为 11。
            foreach (ElfSection section in elfFile.sectionList)
            {
                // 普通数据段不包含符号记录，因此直接跳过。
                if (section.type != 2 && section.type != 11)
                {
                    continue;
                }

                // link 必须指向对应的字符串表。
                if (section.link >= elfFile.sectionList.Count)
                {
                    continue;
                }

                // 取得当前符号表配套的字符串表。
                ElfSection symbolStringTable = elfFile.sectionList[(int)section.link];

                // 某些文件没有填写 entrySize，因此使用 ELF 标准默认大小。
                ulong entrySize = section.entrySize;

                // ELF64 每个符号为 24 字节，ELF32 每个符号为 16 字节。
                if (entrySize == 0)
                {
                    entrySize = is64Bit ? 24UL : 16UL;
                }

                // 无效项大小无法安全遍历符号表。
                if (entrySize == 0)
                {
                    continue;
                }

                // 根据段大小计算符号记录数量。
                ulong symbolCount = section.size / entrySize;

                // 逐项读取符号记录。
                for (ulong symbolIndex = 0; symbolIndex < symbolCount; symbolIndex++)
                {
                    // 计算当前符号记录的文件偏移。
                    ulong symbolOffset = section.offset + symbolIndex * entrySize;

                    // 防止异常 entrySize 导致最后一项越过文件尾部。
                    if (symbolOffset + entrySize > (ulong)fileData.Length)
                    {
                        break;
                    }

                    // st_name 保存符号名称在字符串表中的偏移。
                    uint nameOffset = reader.ReadUInt32(ToInt32(symbolOffset));

                    // 根据 ELF 位数读取 st_info。
                    byte info = reader.ReadByte(ToInt32(symbolOffset + (is64Bit ? 4UL : 12UL)));

                    // 根据 ELF 位数读取符号所属 Section 索引。
                    ushort ownerSectionIndex = reader.ReadUInt16(
                        ToInt32(symbolOffset + (is64Bit ? 6UL : 14UL)));

                    // 根据 ELF 位数读取符号地址。
                    ulong symbolAddress = is64Bit
                        ? reader.ReadUInt64(ToInt32(symbolOffset + 8))
                        : reader.ReadUInt32(ToInt32(symbolOffset + 4));

                    // 根据 ELF 位数读取符号大小。
                    ulong symbolSize = is64Bit
                        ? reader.ReadUInt64(ToInt32(symbolOffset + 16))
                        : reader.ReadUInt32(ToInt32(symbolOffset + 8));

                    // st_info 的低四位表示符号类型。
                    byte symbolType = (byte)(info & 0x0F);

                    // 从配套字符串表中取得符号名称。
                    string symbolName = ReadString(fileData, symbolStringTable, nameOffset);

                    // 只接受变量对象，避免把函数、段标签和编译器内部标签当作变量。
                    if (symbolType != ELF_SYMBOL_TYPE_OBJECT || string.IsNullOrEmpty(symbolName))
                    {
                        continue;
                    }

                    // 地址零不是可供上位机在线读取的有效 MCU 变量地址。
                    if (symbolAddress == 0 || symbolAddress > UInt32.MaxValue)
                    {
                        continue;
                    }

                    // 过滤 GCC 生成的局部标签和特殊标签。
                    if (symbolName.StartsWith("$") || symbolName.StartsWith(".L"))
                    {
                        continue;
                    }

                    // 创建一个普通 ELF 数据符号。
                    ElfSymbol symbol = new ElfSymbol();

                    // 保存符号原始名称。
                    symbol.name = symbolName;

                    // MCU 在线变量协议使用 32 位地址，因此转换为 UInt32。
                    symbol.addr = (uint)symbolAddress;

                    // 超过 UInt32 的异常大小按零处理，避免溢出。
                    symbol.size = symbolSize <= UInt32.MaxValue ? (uint)symbolSize : 0;

                    // 保存符号所属段名称，便于后续调试和扩展。
                    symbol.section = ownerSectionIndex < elfFile.sectionList.Count
                        ? elfFile.sectionList[ownerSectionIndex].name
                        : string.Empty;

                    // 名称与地址共同组成符号唯一键。
                    string symbolKey = symbol.name + "@" + symbol.addr.ToString("X8");

                    // 同名同地址符号重复时保留大小信息更完整的一项。
                    if (!uniqueSymbolMap.ContainsKey(symbolKey) ||
                        uniqueSymbolMap[symbolKey].size < symbol.size)
                    {
                        uniqueSymbolMap[symbolKey] = symbol;
                    }
                }
            }

            // 将去重后的符号复制到 ELF 对象中。
            foreach (ElfSymbol symbol in uniqueSymbolMap.Values)
            {
                elfFile.symbolList.Add(symbol);
            }

            // 按变量名称排序，使每次载入后的显示顺序稳定。
            elfFile.symbolList.Sort(delegate(ElfSymbol left, ElfSymbol right)
            {
                return string.Compare(left.name, right.name, StringComparison.CurrentCulture);
            });

            // 返回完整的 ELF 基础解析结果。
            return elfFile;
        }

        /// <summary>
        /// 解析 .debug_info、.debug_abbrev 和 .debug_str。
        /// </summary>
        private static DwarfDatabase AnalysisDwarf(byte[] fileData, ElfFile elfFile)
        {
            // DWARF 的核心 DIE 数据保存在 .debug_info 中。
            ElfSection infoSection = elfFile.FindSection(".debug_info");

            // DIE 使用的缩写表保存在 .debug_abbrev 中。
            ElfSection abbrevSection = elfFile.FindSection(".debug_abbrev");

            // 大部分较长字符串保存在 .debug_str 中，该段允许不存在。
            ElfSection stringSection = elfFile.FindSection(".debug_str");

            // 没有核心 DWARF 段就无法取得结构体成员信息。
            if (infoSection == null || abbrevSection == null)
            {
                throw new InvalidDataException(
                    "ELF中没有.debug_info或.debug_abbrev，请使用带调试信息的Debug版本固件！");
            }

            // 创建 DWARF 数据库，所有 DIE 和变量索引都会保存到这里。
            DwarfDatabase database = new DwarfDatabase();

            // 记录 ELF 字节序，地址表达式也必须按照该字节序解析。
            database.isLittleEndian = elfFile.isLittleEndian;

            // ELF32 默认使用 4 字节地址，ELF64 默认使用 8 字节地址。
            database.defaultAddressSize = elfFile.elfClass == 32 ? 4 : 8;

            // 创建通用二进制读取器。
            ElfBinaryReader reader = new ElfBinaryReader(fileData, elfFile.isLittleEndian);

            // 同一个缩写表可能被多个编译单元共用，因此使用缓存避免重复解析。
            Dictionary<ulong, Dictionary<ulong, DwarfAbbrev>> abbrevCache =
                new Dictionary<ulong, Dictionary<ulong, DwarfAbbrev>>();

            // 从 .debug_info 的起点开始解析编译单元。
            ulong position = infoSection.offset;

            // 计算 .debug_info 的结束位置。
            ulong infoEnd = infoSection.offset + infoSection.size;

            // 一个 ELF 可以包含多个源文件，因此需要循环读取多个编译单元。
            while (position < infoEnd)
            {
                // 剩余空间不足 4 字节时，不可能再包含合法编译单元长度。
                if (position + 4 > infoEnd)
                {
                    break;
                }

                // DWARF 引用使用相对于 .debug_info 起点的偏移。
                ulong compileUnitStart = position - infoSection.offset;

                // 先读取 32 位编译单元长度。
                ulong unitLength = reader.ReadUInt32(ToInt32(position));

                // 跳过长度字段。
                position += 4;

                // 普通 DWARF 引用和段偏移默认为 4 字节。
                int offsetSize = 4;

                // 长度为零表示一个空填充单元。
                if (unitLength == 0)
                {
                    continue;
                }

                // 0xFFFFFFFF 表示后续使用 DWARF64 的 8 字节长度。
                if (unitLength == UInt32.MaxValue)
                {
                    // DWARF64 长度字段必须完整存在。
                    if (position + 8 > infoEnd)
                    {
                        throw new InvalidDataException("DWARF64编译单元长度不完整！");
                    }

                    // 读取真正的 64 位长度。
                    unitLength = reader.ReadUInt64(ToInt32(position));

                    // 跳过 8 字节长度字段。
                    position += 8;

                    // DWARF64 的引用和段偏移使用 8 字节。
                    offsetSize = 8;
                }

                // unitLength 从长度字段之后开始计算。
                ulong unitEnd = position + unitLength;

                // 编译单元不能越过 .debug_info 末尾。
                if (unitEnd > infoEnd)
                {
                    throw new InvalidDataException("DWARF编译单元越界！");
                }

                // 每个编译单元头部都首先保存 DWARF 版本。
                ushort dwarfVersion = reader.ReadUInt16(ToInt32(position));

                // 跳过版本字段。
                position += 2;

                // 当前实现覆盖参考工程使用的 DWARF 2、3、4 和基础 DWARF 5 格式。
                if (dwarfVersion < 2 || dwarfVersion > 5)
                {
                    throw new NotSupportedException("暂不支持DWARF版本：" + dwarfVersion.ToString());
                }

                // 记录编译单元数量，便于判断 ELF 是否真正包含调试信息。
                database.compileUnitCount++;

                // abbrevOffset 指向当前编译单元使用的缩写表。
                ulong abbrevOffset;

                // addressSize 表示当前目标地址占用的字节数。
                byte addressSize;

                if (dwarfVersion >= 5)
                {
                    // DWARF 5 在版本字段之后增加了 unit_type。
                    byte unitType = reader.ReadByte(ToInt32(position));

                    // 跳过 unit_type。
                    position++;

                    // DWARF 5 接下来直接保存地址宽度。
                    addressSize = reader.ReadByte(ToInt32(position));

                    // 跳过地址宽度字段。
                    position++;

                    // 读取缩写表偏移。
                    abbrevOffset = reader.ReadUnsigned(ToInt32(position), offsetSize);

                    // 跳过缩写表偏移字段。
                    position += (ulong)offsetSize;

                    // 目前只解析普通编译单元和 partial unit。
                    if (unitType != 1 && unitType != 3)
                    {
                        position = unitEnd;
                        continue;
                    }
                }
                else
                {
                    // DWARF 2 到 4 先保存缩写表偏移。
                    abbrevOffset = reader.ReadUnsigned(ToInt32(position), offsetSize);

                    // 跳过缩写表偏移字段。
                    position += (ulong)offsetSize;

                    // DWARF 2 到 4 随后保存地址宽度。
                    addressSize = reader.ReadByte(ToInt32(position));

                    // 跳过地址宽度字段。
                    position++;
                }

                // 某些异常文件会写零，此时使用 ELF 位数推导默认地址宽度。
                if (addressSize == 0)
                {
                    addressSize = (byte)database.defaultAddressSize;
                }

                // 取得或解析当前编译单元使用的缩写表。
                Dictionary<ulong, DwarfAbbrev> abbrevTable = GetAbbrevTable(
                    fileData, reader, abbrevSection, abbrevOffset, abbrevCache);

                // parents 保存当前 DIE 层级，用于建立结构体与成员、数组与范围的父子关系。
                List<DwarfDie> parents = new List<DwarfDie>();

                // 编译单元头之后连续保存 DIE，直到 unitEnd。
                while (position < unitEnd)
                {
                    // DIE 自身的偏移必须记录在读取缩写码之前。
                    ulong dieOffset = position - infoSection.offset;

                    // 每个 DIE 首先保存一个 ULEB128 缩写码。
                    ulong abbrevCode = ReadUleb128(fileData, ref position, unitEnd);

                    // 缩写码零表示当前父节点的子节点列表结束。
                    if (abbrevCode == 0)
                    {
                        if (parents.Count > 0)
                        {
                            parents.RemoveAt(parents.Count - 1);
                        }

                        continue;
                    }

                    // 当前缩写码必须能在缩写表中找到定义。
                    if (!abbrevTable.ContainsKey(abbrevCode))
                    {
                        throw new InvalidDataException(
                            "找不到DWARF缩写定义：" + abbrevCode.ToString());
                    }

                    // 取得 DIE 的标签和属性格式列表。
                    DwarfAbbrev abbrev = abbrevTable[abbrevCode];

                    // 创建当前 DIE 对象。
                    DwarfDie die = new DwarfDie();

                    // 保存 DIE 在 .debug_info 内的相对偏移，其他 DIE 会通过该值引用它。
                    die.offset = dieOffset;

                    // 保存 DIE 标签，例如变量、结构体、成员或基础类型。
                    die.tag = abbrev.tag;

                    // 保存当前编译单元地址宽度。
                    die.addressSize = addressSize;

                    // 逐项读取缩写定义中声明的属性。
                    foreach (DwarfAttributeSpec attributeSpec in abbrev.attributeList)
                    {
                        // ReadDwarfForm 会按照 form 读取值并同步推进 position。
                        object attributeValue = ReadDwarfForm(
                            fileData,
                            reader,
                            stringSection,
                            attributeSpec,
                            ref position,
                            unitEnd,
                            compileUnitStart,
                            addressSize,
                            offsetSize,
                            dwarfVersion);

                        // 保存属性编号和解析后的属性值。
                        die.attributeMap[attributeSpec.attribute] = attributeValue;
                    }

                    // 如果当前 DIE 有父节点，就把它加入父节点的 children 列表。
                    if (parents.Count > 0)
                    {
                        parents[parents.Count - 1].childList.Add(die.offset);
                    }

                    // 将 DIE 加入全局数据库，便于后续按偏移查找类型。
                    database.dieMap[die.offset] = die;

                    // hasChildren 为真时，后续 DIE 属于当前 DIE 的子节点。
                    if (abbrev.hasChildren)
                    {
                        parents.Add(die);
                    }
                }

                // 强制定位到编译单元末尾，避免填充字节影响下一个单元。
                position = unitEnd;
            }

            // 建立“变量名到变量 DIE”的索引，后续匹配 ELF 符号时不需要遍历全部 DIE。
            database.BuildVariableIndex();

            // 没有任何编译单元通常说明调试段为空或已经损坏。
            if (database.compileUnitCount == 0)
            {
                throw new InvalidDataException("ELF中的DWARF调试信息为空！");
            }

            // 返回完整 DWARF 数据库。
            return database;
        }

        /// <summary>
        /// 取得一个缩写表；同一偏移只解析一次。
        /// </summary>
        private static Dictionary<ulong, DwarfAbbrev> GetAbbrevTable(
            byte[] fileData,
            ElfBinaryReader reader,
            ElfSection abbrevSection,
            ulong abbrevOffset,
            Dictionary<ulong, Dictionary<ulong, DwarfAbbrev>> abbrevCache)
        {
            // 优先返回已经解析过的缩写表。
            if (abbrevCache.ContainsKey(abbrevOffset))
            {
                return abbrevCache[abbrevOffset];
            }

            // 缩写表偏移是相对于 .debug_abbrev 起点的偏移。
            ulong position = abbrevSection.offset + abbrevOffset;

            // 计算 .debug_abbrev 末尾位置。
            ulong abbrevEnd = abbrevSection.offset + abbrevSection.size;

            // 起点必须位于 .debug_abbrev 内部。
            if (position < abbrevSection.offset || position >= abbrevEnd)
            {
                throw new InvalidDataException("DWARF缩写表偏移越界！");
            }

            // 创建缩写码到缩写定义的映射。
            Dictionary<ulong, DwarfAbbrev> table = new Dictionary<ulong, DwarfAbbrev>();

            // 缩写表由多条变长记录组成。
            while (position < abbrevEnd)
            {
                // 每条记录首先保存非零缩写码。
                ulong abbrevCode = ReadUleb128(fileData, ref position, abbrevEnd);

                // 缩写码零表示当前缩写表结束。
                if (abbrevCode == 0)
                {
                    break;
                }

                // 接下来保存该缩写代表的 DWARF 标签。
                ulong tag = ReadUleb128(fileData, ref position, abbrevEnd);

                // 标签之后的一字节表示该 DIE 是否拥有子节点。
                bool hasChildren = reader.ReadByte(ToInt32(position)) != 0;

                // 跳过 has_children 字节。
                position++;

                // 创建缩写定义对象。
                DwarfAbbrev abbrev = new DwarfAbbrev();

                // 保存 DWARF 标签。
                abbrev.tag = tag;

                // 保存子节点标记。
                abbrev.hasChildren = hasChildren;

                // 属性列表以 attribute=0、form=0 结束。
                while (position < abbrevEnd)
                {
                    // 读取属性编号。
                    ulong attribute = ReadUleb128(fileData, ref position, abbrevEnd);

                    // 读取属性数据格式。
                    ulong form = ReadUleb128(fileData, ref position, abbrevEnd);

                    // 两者同时为零表示属性列表结束。
                    if (attribute == 0 && form == 0)
                    {
                        break;
                    }

                    // 创建属性格式描述。
                    DwarfAttributeSpec attributeSpec = new DwarfAttributeSpec();

                    // 保存属性编号。
                    attributeSpec.attribute = attribute;

                    // 保存数据格式编号。
                    attributeSpec.form = form;

                    // implicit_const 的实际数值直接保存在缩写表中。
                    if (form == DW_FORM_IMPLICIT_CONST)
                    {
                        attributeSpec.implicitConstant =
                            ReadSleb128(fileData, ref position, abbrevEnd);
                    }

                    // 将属性格式加入当前缩写定义。
                    abbrev.attributeList.Add(attributeSpec);
                }

                // 按缩写码保存定义。
                table[abbrevCode] = abbrev;
            }

            // 将解析结果加入缓存。
            abbrevCache[abbrevOffset] = table;

            // 返回当前缩写表。
            return table;
        }

        /// <summary>
        /// 按 DWARF form 读取一个属性值。
        /// </summary>
        private static object ReadDwarfForm(
            byte[] fileData,
            ElfBinaryReader reader,
            ElfSection stringSection,
            DwarfAttributeSpec attributeSpec,
            ref ulong position,
            ulong unitEnd,
            ulong compileUnitStart,
            byte addressSize,
            int offsetSize,
            ushort dwarfVersion)
        {
            // 先取得当前属性声明的数据格式。
            ulong form = attributeSpec.form;

            // indirect 会在数据中再次声明真正的 form。
            if (form == DW_FORM_INDIRECT)
            {
                // 从 DIE 数据中读取真正的数据格式。
                form = ReadUleb128(fileData, ref position, unitEnd);

                // 创建临时属性描述，以复用当前读取函数。
                DwarfAttributeSpec indirectSpec = new DwarfAttributeSpec();

                // 保存真正的数据格式。
                indirectSpec.form = form;

                // 递归读取真正的属性数据。
                return ReadDwarfForm(fileData, reader, stringSection, indirectSpec,
                    ref position, unitEnd, compileUnitStart, addressSize,
                    offsetSize, dwarfVersion);
            }

            // addr 按当前编译单元声明的地址宽度读取。
            if (form == DW_FORM_ADDR)
            {
                ulong value = reader.ReadUnsigned(ToInt32(position), addressSize);
                position += addressSize;
                return value;
            }

            // data1 是一个 1 字节无符号数。
            if (form == DW_FORM_DATA1)
            {
                byte value = reader.ReadByte(ToInt32(position));
                position += 1;
                return (ulong)value;
            }

            // data2 是一个 2 字节无符号数。
            if (form == DW_FORM_DATA2)
            {
                ushort value = reader.ReadUInt16(ToInt32(position));
                position += 2;
                return (ulong)value;
            }

            // data4 是一个 4 字节无符号数。
            if (form == DW_FORM_DATA4)
            {
                uint value = reader.ReadUInt32(ToInt32(position));
                position += 4;
                return (ulong)value;
            }

            // data8 是一个 8 字节无符号数。
            if (form == DW_FORM_DATA8)
            {
                ulong value = reader.ReadUInt64(ToInt32(position));
                position += 8;
                return value;
            }

            // udata 使用无符号 LEB128 编码。
            if (form == DW_FORM_UDATA)
            {
                return ReadUleb128(fileData, ref position, unitEnd);
            }

            // sdata 使用有符号 LEB128 编码。
            if (form == DW_FORM_SDATA)
            {
                return ReadSleb128(fileData, ref position, unitEnd);
            }

            // flag 使用一个字节表示真假。
            if (form == DW_FORM_FLAG)
            {
                bool value = reader.ReadByte(ToInt32(position)) != 0;
                position += 1;
                return value;
            }

            // flag_present 不占用 DIE 数据，其出现本身就表示真。
            if (form == DW_FORM_FLAG_PRESENT)
            {
                return true;
            }

            // implicit_const 的值已经在缩写表中解析完成。
            if (form == DW_FORM_IMPLICIT_CONST)
            {
                return attributeSpec.implicitConstant;
            }

            // string 表示字符串直接跟在当前 DIE 属性位置。
            if (form == DW_FORM_STRING)
            {
                return ReadInlineString(fileData, ref position, unitEnd);
            }

            // strp 保存一个指向 .debug_str 的偏移。
            if (form == DW_FORM_STRP)
            {
                ulong stringOffset = reader.ReadUnsigned(ToInt32(position), offsetSize);
                position += (ulong)offsetSize;

                if (stringSection == null)
                {
                    return string.Empty;
                }

                return ReadString(fileData, stringSection, stringOffset);
            }

            // ref1 保存相对于当前编译单元起点的 1 字节引用。
            if (form == DW_FORM_REF1)
            {
                ulong value = compileUnitStart + reader.ReadByte(ToInt32(position));
                position += 1;
                return value;
            }

            // ref2 保存相对于当前编译单元起点的 2 字节引用。
            if (form == DW_FORM_REF2)
            {
                ulong value = compileUnitStart + reader.ReadUInt16(ToInt32(position));
                position += 2;
                return value;
            }

            // ref4 保存相对于当前编译单元起点的 4 字节引用。
            if (form == DW_FORM_REF4)
            {
                ulong value = compileUnitStart + reader.ReadUInt32(ToInt32(position));
                position += 4;
                return value;
            }

            // ref8 保存相对于当前编译单元起点的 8 字节引用。
            if (form == DW_FORM_REF8)
            {
                ulong value = compileUnitStart + reader.ReadUInt64(ToInt32(position));
                position += 8;
                return value;
            }

            // ref_udata 保存相对于当前编译单元起点的 ULEB128 引用。
            if (form == DW_FORM_REF_UDATA)
            {
                ulong value = ReadUleb128(fileData, ref position, unitEnd);
                return compileUnitStart + value;
            }

            // ref_addr 在 DWARF 2 使用地址宽度，在后续版本使用 offsetSize。
            if (form == DW_FORM_REF_ADDR)
            {
                int referenceSize = dwarfVersion == 2 ? addressSize : offsetSize;
                ulong value = reader.ReadUnsigned(ToInt32(position), referenceSize);
                position += (ulong)referenceSize;
                return value;
            }

            // sec_offset 是相对于某个 DWARF 段起点的偏移。
            if (form == DW_FORM_SEC_OFFSET)
            {
                ulong value = reader.ReadUnsigned(ToInt32(position), offsetSize);
                position += (ulong)offsetSize;
                return value;
            }

            // exprloc 先保存 ULEB128 长度，再保存表达式字节。
            if (form == DW_FORM_EXPRLOC)
            {
                ulong blockLength = ReadUleb128(fileData, ref position, unitEnd);
                return ReadBlock(fileData, ref position, unitEnd, blockLength);
            }

            // block1 使用 1 字节保存数据块长度。
            if (form == DW_FORM_BLOCK1)
            {
                ulong blockLength = reader.ReadByte(ToInt32(position));
                position += 1;
                return ReadBlock(fileData, ref position, unitEnd, blockLength);
            }

            // block2 使用 2 字节保存数据块长度。
            if (form == DW_FORM_BLOCK2)
            {
                ulong blockLength = reader.ReadUInt16(ToInt32(position));
                position += 2;
                return ReadBlock(fileData, ref position, unitEnd, blockLength);
            }

            // block4 使用 4 字节保存数据块长度。
            if (form == DW_FORM_BLOCK4)
            {
                ulong blockLength = reader.ReadUInt32(ToInt32(position));
                position += 4;
                return ReadBlock(fileData, ref position, unitEnd, blockLength);
            }

            // block 使用 ULEB128 保存数据块长度。
            if (form == DW_FORM_BLOCK)
            {
                ulong blockLength = ReadUleb128(fileData, ref position, unitEnd);
                return ReadBlock(fileData, ref position, unitEnd, blockLength);
            }

            // 不认识的 form 无法计算下一属性位置，所以必须停止当前 DWARF 解析。
            throw new NotSupportedException(
                "暂不支持DWARF form 0x" + form.ToString("X") +
                "，建议使用-gdwarf-4重新生成ELF文件。");
        }

        /// <summary>
        /// 把 ELF 数据符号和 DWARF 变量类型对应起来，并展开为叶子变量。
        /// </summary>
        private static List<VarOnline> MakeVarList(
            ElfFile elfFile,
            DwarfDatabase database)
        {
            // 创建最终返回给界面的变量列表。
            List<VarOnline> varList = new List<VarOnline>();

            // 逐个处理 ELF 中真实分配了地址的数据对象。
            foreach (ElfSymbol symbol in elfFile.symbolList)
            {
                // 同名变量可能在多个编译单元出现，因此需要按地址和大小评分选择。
                DwarfVariableChoice choice = ChooseVariable(database, symbol);

                // 找不到可靠类型时，仅把普通 2 字节或 4 字节符号加入列表。
                if (choice == null || choice.typeInfo == null ||
                    choice.typeInfo.kind == DwarfTypeKind.Unknown)
                {
                    AddFallbackSymbol(varList, symbol);
                    continue;
                }

                // 记录当前根变量已经生成的叶子数量。
                int emittedCount = 0;

                // 从根变量类型开始递归展开结构体和数组。
                ExpandVariable(
                    varList,
                    database,
                    choice.typeInfo,
                    symbol.addr,
                    symbol.name,
                    0,
                    false,
                    ref emittedCount);

                // 某些不支持的类型不会产生叶子，此时保留可用的普通符号回退项。
                if (emittedCount == 0)
                {
                    AddFallbackSymbol(varList, symbol);
                }
            }

            // 按完整变量路径排序，方便在选择窗口中查找结构体成员。
            varList.Sort(delegate(VarOnline left, VarOnline right)
            {
                return string.Compare(left.name, right.name, StringComparison.CurrentCulture);
            });

            // 返回展开后的变量列表。
            return varList;
        }

        /// <summary>
        /// DWARF 不可用时，仅根据 ELF 符号大小生成普通变量。
        /// </summary>
        private static List<VarOnline> MakeFallbackVarList(ElfFile elfFile)
        {
            // 创建回退列表。
            List<VarOnline> varList = new List<VarOnline>();

            // 逐个处理 ELF 数据符号。
            foreach (ElfSymbol symbol in elfFile.symbolList)
            {
                AddFallbackSymbol(varList, symbol);
            }

            // 按名称排序，保持显示稳定。
            varList.Sort(delegate(VarOnline left, VarOnline right)
            {
                return string.Compare(left.name, right.name, StringComparison.CurrentCulture);
            });

            // 返回普通符号列表。
            return varList;
        }

        /// <summary>
        /// 将一个没有可靠 DWARF 类型的 ELF 符号加入列表。
        /// </summary>
        private static void AddFallbackSymbol(List<VarOnline> varList, ElfSymbol symbol)
        {
            // 现有在线变量协议只支持 2 字节和 4 字节数据。
            if (symbol.size != 2 && symbol.size != 4)
            {
                return;
            }

            // 创建普通变量对象。
            VarOnline varItem = new VarOnline();

            // 保存符号名称。
            varItem.name = symbol.name;

            // 地址统一显示为 8 位十六进制，保持与原 MAP 地址格式兼容。
            varItem.addr = "0x" + symbol.addr.ToString("X8");

            // ELF 符号表没有符号正负信息，因此默认选择无符号类型。
            varItem.type = symbol.size == 2 ? "Uint16" : "Uint32";

            // 保存变量字节数。
            varItem.size = symbol.size;

            // 普通 ELF 符号不按位域处理。
            varItem.isBitField = false;

            // 将变量加入结果列表。
            varList.Add(varItem);
        }

        /// <summary>
        /// 在同名 DWARF 变量中选择与 ELF 符号最匹配的一项。
        /// </summary>
        private static DwarfVariableChoice ChooseVariable(
            DwarfDatabase database,
            ElfSymbol symbol)
        {
            // 没有同名 DWARF 变量时无法建立类型关联。
            if (!database.variableMap.ContainsKey(symbol.name))
            {
                return null;
            }

            // 保存当前评分最高的候选项。
            DwarfVariableChoice bestChoice = null;

            // 逐项计算同名变量候选的可信度。
            foreach (DwarfDie variableDie in database.variableMap[symbol.name])
            {
                // 变量必须通过 DW_AT_type 指向一个类型 DIE。
                ulong? typeOffset = database.GetNumber(variableDie, DW_AT_TYPE);

                // 没有类型引用的声明无法展开结构体。
                if (!typeOffset.HasValue)
                {
                    continue;
                }

                // 将 DWARF 类型链转换为便于展开的类型对象。
                DwarfTypeInfo typeInfo = DescribeType(
                    database, typeOffset.Value, new HashSet<ulong>());

                // 读取变量位置表达式中的绝对地址。
                uint? dwarfAddress = GetVariableAddress(database, variableDie);

                // 创建候选项。
                DwarfVariableChoice choice = new DwarfVariableChoice();

                // 保存变量 DIE。
                choice.variableDie = variableDie;

                // 保存解析后的类型。
                choice.typeInfo = typeInfo;

                // 只要存在类型引用就提供基础分数。
                choice.score = 100;

                // DWARF 中存在明确地址时增加可信度。
                if (dwarfAddress.HasValue)
                {
                    choice.score += 30;
                }

                // DWARF 地址与 ELF 符号地址一致时优先级最高。
                if (dwarfAddress.HasValue && dwarfAddress.Value == symbol.addr)
                {
                    choice.score += 80;
                }

                // 类型大小与 ELF 符号大小一致时进一步提高可信度。
                if (symbol.size > 0 && typeInfo != null && typeInfo.size == symbol.size)
                {
                    choice.score += 50;
                }

                // 保存当前评分更高的候选项。
                if (bestChoice == null || choice.score > bestChoice.score)
                {
                    bestChoice = choice;
                }
            }

            // 返回评分最高的匹配结果。
            return bestChoice;
        }

        /// <summary>
        /// 递归展开结构体、联合体和数组，最终只输出协议能够读取的标量叶子。
        /// </summary>
        private static void ExpandVariable(
            List<VarOnline> varList,
            DwarfDatabase database,
            DwarfTypeInfo typeInfo,
            uint baseAddr,
            string varPath,
            int depth,
            bool inheritedBitField,
            ref int emittedCount)
        {
            // 类型不存在时没有可展开内容。
            if (typeInfo == null)
            {
                return;
            }

            // 超过最大递归深度时停止，防止异常或自引用类型无限递归。
            if (depth > MAX_EXPAND_DEPTH)
            {
                return;
            }

            // 单个根变量达到叶子上限后停止继续生成界面项。
            if (emittedCount >= MAX_LEAVES_PER_ROOT)
            {
                return;
            }

            // 数组需要为每个元素计算独立地址和完整路径。
            if (typeInfo.kind == DwarfTypeKind.Array)
            {
                // 没有元素类型就无法计算数组元素地址。
                if (typeInfo.elementType == null || typeInfo.elementType.size == 0)
                {
                    return;
                }

                // 没有维度信息的柔性数组不能安全展开。
                if (typeInfo.dimensionList.Count == 0)
                {
                    return;
                }

                // 计算多维数组的总元素数量。
                ulong totalCount = 1;

                // 逐维累乘数组长度。
                foreach (uint dimension in typeInfo.dimensionList)
                {
                    // 未知维度不能安全计算后续元素地址。
                    if (dimension == 0)
                    {
                        return;
                    }

                    // 提前限制数量，避免乘法溢出和超大展开。
                    if (totalCount > MAX_ARRAY_ITEMS / dimension)
                    {
                        totalCount = MAX_ARRAY_ITEMS;
                        break;
                    }

                    // 累加当前维度。
                    totalCount *= dimension;
                }

                // 最多展开 MAX_ARRAY_ITEMS 个元素。
                uint expandCount = (uint)Math.Min(totalCount, MAX_ARRAY_ITEMS);

                // 按线性内存顺序展开每个数组元素。
                for (uint linearIndex = 0; linearIndex < expandCount; linearIndex++)
                {
                    // 把线性索引转换为类似 [1][2] 的多维索引后缀。
                    string indexSuffix = MakeArrayIndexSuffix(
                        linearIndex, typeInfo.dimensionList);

                    // 使用 64 位中间值计算地址，避免 UInt32 静默溢出。
                    ulong elementAddress = (ulong)baseAddr +
                        (ulong)linearIndex * typeInfo.elementType.size;

                    // 超过 32 位 MCU 地址范围时停止展开。
                    if (elementAddress > UInt32.MaxValue)
                    {
                        return;
                    }

                    // 递归处理数组元素，元素本身仍可能是结构体。
                    ExpandVariable(
                        varList,
                        database,
                        typeInfo.elementType,
                        (uint)elementAddress,
                        varPath + indexSuffix,
                        depth + 1,
                        inheritedBitField,
                        ref emittedCount);
                }

                return;
            }

            // 结构体和联合体都通过成员 DIE 继续展开。
            if (typeInfo.kind == DwarfTypeKind.Struct ||
                typeInfo.kind == DwarfTypeKind.Union)
            {
                // 类型对象必须能够定位到原始结构体 DIE。
                if (!database.dieMap.ContainsKey(typeInfo.aggregateOffset))
                {
                    return;
                }

                // 取得原始结构体或联合体 DIE。
                DwarfDie aggregateDie = database.dieMap[typeInfo.aggregateOffset];

                // 按编译器声明顺序处理每个成员。
                foreach (ulong childOffset in aggregateDie.childList)
                {
                    // 无效子节点引用直接跳过。
                    if (!database.dieMap.ContainsKey(childOffset))
                    {
                        continue;
                    }

                    // 取得成员 DIE。
                    DwarfDie memberDie = database.dieMap[childOffset];

                    // 结构体可能还有其他子 DIE，只处理 DW_TAG_member。
                    if (memberDie.tag != DW_TAG_MEMBER)
                    {
                        continue;
                    }

                    // 取得成员类型引用。
                    ulong? memberTypeOffset = database.GetNumber(memberDie, DW_AT_TYPE);

                    // 没有类型信息的成员无法转换为协议类型。
                    if (!memberTypeOffset.HasValue)
                    {
                        continue;
                    }

                    // 解析成员类型。
                    DwarfTypeInfo memberType = DescribeType(
                        database, memberTypeOffset.Value, new HashSet<ulong>());

                    // 取得成员名称；匿名成员使用明确占位名称。
                    string memberName = database.GetString(memberDie, DW_AT_NAME);

                    // 保证最终路径始终可读。
                    if (string.IsNullOrEmpty(memberName))
                    {
                        memberName = "<anonymous>";
                    }

                    // DW_AT_data_bit_offset 表示成员或位域相对于对象起点的位偏移。
                    ulong? dataBitOffset = database.GetNumber(memberDie, DW_AT_DATA_BIT_OFFSET);

                    // DW_AT_bit_size 存在时说明当前成员是位域。
                    bool isBitField = database.GetNumber(memberDie, DW_AT_BIT_SIZE).HasValue ||
                        dataBitOffset.HasValue;

                    // 联合体所有成员都从同一地址开始。
                    ulong memberOffset = 0;

                    // 普通结构体成员需要读取编译器给出的实际内存偏移。
                    if (typeInfo.kind == DwarfTypeKind.Struct)
                    {
                        memberOffset = dataBitOffset.HasValue
                            ? dataBitOffset.Value / 8
                            : GetMemberOffset(database, memberDie);
                    }

                    // 使用 64 位中间值计算成员地址。
                    ulong memberAddress = (ulong)baseAddr + memberOffset;

                    // 超过在线变量协议的 32 位地址范围时跳过该成员。
                    if (memberAddress > UInt32.MaxValue)
                    {
                        continue;
                    }

                    // 递归展开成员，嵌套结构体会继续生成更深层路径。
                    ExpandVariable(
                        varList,
                        database,
                        memberType,
                        (uint)memberAddress,
                        varPath + "." + memberName,
                        depth + 1,
                        inheritedBitField || isBitField,
                        ref emittedCount);
                }

                return;
            }

            // 将 DWARF 基础类型映射为当前固件协议支持的类型名称。
            string protocolType = GetProtocolType(typeInfo);

            // 1 字节、8 字节等当前协议不支持的类型不加入选择列表。
            if (string.IsNullOrEmpty(protocolType))
            {
                return;
            }

            // 创建最终显示在变量选择窗口中的叶子成员。
            VarOnline varItem = new VarOnline();

            // 使用完整路径显示根变量、结构体成员和数组索引。
            varItem.name = varPath;

            // 统一使用 8 位大写十六进制地址字符串。
            varItem.addr = "0x" + baseAddr.ToString("X8");

            // 自动带出 DWARF 识别到的数据类型。
            varItem.type = protocolType;

            // 保存该叶子变量占用的字节数。
            varItem.size = typeInfo.size;

            // 位域不能使用现有 address + type 协议直接读写。
            varItem.isBitField = inheritedBitField;

            // 将叶子变量加入结果列表。
            varList.Add(varItem);

            // 更新当前根变量已生成的叶子数量。
            emittedCount++;
        }

        /// <summary>
        /// 将 DWARF 类型链转换为统一的类型描述。
        /// </summary>
        private static DwarfTypeInfo DescribeType(
            DwarfDatabase database,
            ulong typeOffset,
            HashSet<ulong> visitedOffsetSet)
        {
            // 类型引用不存在时返回未知类型。
            if (!database.dieMap.ContainsKey(typeOffset))
            {
                return MakeUnknownType(typeOffset);
            }

            // typedef 循环或异常自引用类型会再次访问同一偏移。
            if (visitedOffsetSet.Contains(typeOffset))
            {
                return MakeUnknownType(typeOffset);
            }

            // 将当前类型加入已访问集合。
            visitedOffsetSet.Add(typeOffset);

            // 取得原始类型 DIE。
            DwarfDie die = database.dieMap[typeOffset];

            // 读取类型名称。
            string typeName = database.GetString(die, DW_AT_NAME);

            // 读取类型大小；部分包装类型没有自己的大小。
            uint typeSize = ToUInt32(database.GetNumber(die, DW_AT_BYTE_SIZE));

            // 读取被包装或被指向的下一级类型。
            ulong? nextTypeOffset = database.GetNumber(die, DW_AT_TYPE);

            // 基础类型直接包含大小和 DW_ATE 编码。
            if (die.tag == DW_TAG_BASE_TYPE)
            {
                DwarfTypeInfo typeInfo = new DwarfTypeInfo();
                typeInfo.kind = DwarfTypeKind.Base;
                typeInfo.name = string.IsNullOrEmpty(typeName) ? "base" : typeName;
                typeInfo.size = typeSize;
                typeInfo.encoding = ToUInt32(database.GetNumber(die, DW_AT_ENCODING));
                typeInfo.dieOffset = typeOffset;
                return typeInfo;
            }

            // 结构体和联合体的成员列表保存在当前 DIE 的 children 中。
            if (die.tag == DW_TAG_STRUCTURE_TYPE || die.tag == DW_TAG_UNION_TYPE)
            {
                DwarfTypeInfo typeInfo = new DwarfTypeInfo();
                typeInfo.kind = die.tag == DW_TAG_STRUCTURE_TYPE
                    ? DwarfTypeKind.Struct
                    : DwarfTypeKind.Union;
                typeInfo.name = string.IsNullOrEmpty(typeName)
                    ? (die.tag == DW_TAG_STRUCTURE_TYPE ? "匿名struct" : "匿名union")
                    : (die.tag == DW_TAG_STRUCTURE_TYPE ? "struct " : "union ") + typeName;
                typeInfo.size = typeSize;
                typeInfo.dieOffset = typeOffset;
                typeInfo.aggregateOffset = typeOffset;
                return typeInfo;
            }

            // 枚举在协议中按有符号整数处理。
            if (die.tag == DW_TAG_ENUMERATION_TYPE)
            {
                DwarfTypeInfo enumType = new DwarfTypeInfo();
                enumType.kind = DwarfTypeKind.Enum;
                enumType.name = string.IsNullOrEmpty(typeName) ? "enum" : "enum " + typeName;
                enumType.size = typeSize;
                enumType.encoding = 5;
                enumType.dieOffset = typeOffset;

                if (enumType.size == 0 && nextTypeOffset.HasValue)
                {
                    DwarfTypeInfo targetType = DescribeType(
                        database, nextTypeOffset.Value, new HashSet<ulong>(visitedOffsetSet));
                    enumType.size = targetType.size;
                    enumType.encoding = targetType.encoding;
                }

                if (enumType.size == 0)
                {
                    enumType.size = 4;
                }

                return enumType;
            }

            // typedef、const、volatile 和 restrict 只包装另一个真实类型。
            if (die.tag == DW_TAG_TYPEDEF || die.tag == DW_TAG_CONST_TYPE ||
                die.tag == DW_TAG_VOLATILE_TYPE || die.tag == DW_TAG_RESTRICT_TYPE)
            {
                if (!nextTypeOffset.HasValue)
                {
                    return MakeUnknownType(typeOffset);
                }

                DwarfTypeInfo targetType = DescribeType(
                    database, nextTypeOffset.Value, new HashSet<ulong>(visitedOffsetSet));

                if (!string.IsNullOrEmpty(typeName))
                {
                    targetType.name = typeName;
                }

                return targetType;
            }

            // 指针本身是一个地址值，不继续展开它指向的内存。
            if (die.tag == DW_TAG_POINTER_TYPE)
            {
                DwarfTypeInfo pointerType = new DwarfTypeInfo();
                pointerType.kind = DwarfTypeKind.Pointer;
                pointerType.name = "pointer";
                pointerType.size = typeSize == 0 ? (uint)die.addressSize : typeSize;
                pointerType.encoding = 7;
                pointerType.dieOffset = typeOffset;
                return pointerType;
            }

            // 数组保存元素类型，并通过 subrange 子节点保存各维长度。
            if (die.tag == DW_TAG_ARRAY_TYPE)
            {
                if (!nextTypeOffset.HasValue)
                {
                    return MakeUnknownType(typeOffset);
                }

                DwarfTypeInfo arrayType = new DwarfTypeInfo();
                arrayType.kind = DwarfTypeKind.Array;
                arrayType.name = string.IsNullOrEmpty(typeName) ? "array" : typeName;
                arrayType.size = typeSize;
                arrayType.dieOffset = typeOffset;
                arrayType.elementType = DescribeType(
                    database, nextTypeOffset.Value, new HashSet<ulong>(visitedOffsetSet));

                foreach (ulong childOffset in die.childList)
                {
                    if (!database.dieMap.ContainsKey(childOffset))
                    {
                        continue;
                    }

                    DwarfDie childDie = database.dieMap[childOffset];

                    if (childDie.tag != DW_TAG_SUBRANGE_TYPE)
                    {
                        continue;
                    }

                    ulong? count = database.GetNumber(childDie, DW_AT_COUNT);
                    ulong lowerBound = database.GetNumber(childDie, DW_AT_LOWER_BOUND) ?? 0;
                    ulong? upperBound = database.GetNumber(childDie, DW_AT_UPPER_BOUND);
                    ulong dimension = 0;

                    if (count.HasValue)
                    {
                        dimension = count.Value;
                    }
                    else if (upperBound.HasValue && upperBound.Value >= lowerBound)
                    {
                        dimension = upperBound.Value - lowerBound + 1;
                    }

                    arrayType.dimensionList.Add(
                        dimension <= UInt32.MaxValue ? (uint)dimension : 0);
                }

                if (arrayType.size == 0 && arrayType.elementType.size > 0)
                {
                    ulong totalCount = 1;

                    foreach (uint dimension in arrayType.dimensionList)
                    {
                        totalCount *= dimension;
                    }

                    ulong calculatedSize = totalCount * arrayType.elementType.size;
                    arrayType.size = calculatedSize <= UInt32.MaxValue
                        ? (uint)calculatedSize
                        : 0;
                }

                return arrayType;
            }

            // 其余尚未支持的类型统一标记为未知类型。
            return MakeUnknownType(typeOffset);
        }

        /// <summary>
        /// 将 DWARF 基础类型映射为现有在线变量协议类型。
        /// </summary>
        private static string GetProtocolType(DwarfTypeInfo typeInfo)
        {
            // 32 位指针可以按无符号 32 位地址读取。
            if (typeInfo.kind == DwarfTypeKind.Pointer && typeInfo.size == 4)
            {
                return "Uint32";
            }

            // 枚举按有符号整数显示，与参考工程保持一致。
            if (typeInfo.kind == DwarfTypeKind.Enum)
            {
                if (typeInfo.size == 2)
                {
                    return "Int16";
                }

                if (typeInfo.size == 4)
                {
                    return "Int32";
                }

                return string.Empty;
            }

            // 除基础类型、枚举和指针外，其余类型必须先展开。
            if (typeInfo.kind != DwarfTypeKind.Base)
            {
                return string.Empty;
            }

            // DW_ATE_float 的编码为 4，当前协议名称沿用原工程的 Float。
            if (typeInfo.encoding == 4 && typeInfo.size == 4)
            {
                return "Float";
            }

            // unsigned、unsigned_char 和 boolean 按无符号类型处理。
            bool isUnsigned = typeInfo.encoding == 7 ||
                typeInfo.encoding == 8 || typeInfo.encoding == 2;

            // 部分编译器类型编码不完整时，再根据类型名称辅助判断。
            string lowerName = string.IsNullOrEmpty(typeInfo.name)
                ? string.Empty
                : typeInfo.name.ToLowerInvariant();

            // 名称包含 uint 或 unsigned 时也按无符号类型处理。
            if (lowerName.Contains("uint") || lowerName.Contains("unsigned"))
            {
                isUnsigned = true;
            }

            // 2 字节基础类型映射为 Int16 或 Uint16。
            if (typeInfo.size == 2)
            {
                return isUnsigned ? "Uint16" : "Int16";
            }

            // 4 字节基础类型映射为 Int32 或 Uint32。
            if (typeInfo.size == 4)
            {
                return isUnsigned ? "Uint32" : "Int32";
            }

            // 当前固件协议不支持其他字节宽度。
            return string.Empty;
        }

        /// <summary>
        /// 从 DW_AT_location 的 DW_OP_addr 表达式中取得变量绝对地址。
        /// </summary>
        private static uint? GetVariableAddress(DwarfDatabase database, DwarfDie die)
        {
            // 取得原始 location 属性。
            object locationValue = database.GetAttribute(die, DW_AT_LOCATION);

            // 当前只处理直接地址表达式。
            byte[] expression = locationValue as byte[];

            // 表达式至少要包含操作码和完整地址。
            if (expression == null || expression.Length < 1 + die.addressSize)
            {
                return null;
            }

            // 第一个操作码必须是 DW_OP_addr。
            if (expression[0] != DW_OP_ADDR)
            {
                return null;
            }

            // 从表达式第二字节开始读取地址。
            ulong address = ReadUnsignedFromBuffer(
                expression, 1, die.addressSize, database.isLittleEndian);

            // 当前在线变量协议只接受 32 位地址。
            if (address > UInt32.MaxValue)
            {
                return null;
            }

            // 返回有效的 32 位地址。
            return (uint)address;
        }

        /// <summary>
        /// 读取结构体成员相对于结构体起点的字节偏移。
        /// </summary>
        private static ulong GetMemberOffset(DwarfDatabase database, DwarfDie memberDie)
        {
            // 取得成员位置属性。
            object memberLocation = database.GetAttribute(
                memberDie, DW_AT_DATA_MEMBER_LOCATION);

            // 大多数编译器直接使用无符号整数保存成员偏移。
            ulong? numericOffset = ConvertToUnsigned(memberLocation);

            // 数字格式可直接返回。
            if (numericOffset.HasValue)
            {
                return numericOffset.Value;
            }

            // 旧版 DWARF 也可能使用 DW_OP_plus_uconst 表达式保存偏移。
            byte[] expression = memberLocation as byte[];

            // 检查表达式操作码。
            if (expression == null || expression.Length < 2 ||
                expression[0] != DW_OP_PLUS_UCONST)
            {
                return 0;
            }

            // 从操作码之后读取 ULEB128 偏移。
            ulong value = 0;

            // 当前已经累积的位数。
            int shift = 0;

            // 逐字节读取表达式参数。
            for (int index = 1; index < expression.Length; index++)
            {
                // 取得当前 LEB128 字节。
                byte item = expression[index];

                // 将低七位合并到最终数值。
                value |= (ulong)(item & 0x7F) << shift;

                // 最高位为零表示当前数值结束。
                if ((item & 0x80) == 0)
                {
                    return value;
                }

                // 每个字节提供七位有效数据。
                shift += 7;
            }

            // 表达式不完整时按零偏移处理。
            return 0;
        }

        /// <summary>
        /// 将线性数组索引转换成多维索引字符串。
        /// </summary>
        private static string MakeArrayIndexSuffix(
            uint linearIndex,
            List<uint> dimensionList)
        {
            // 使用临时列表从最后一维向前计算索引。
            List<uint> indexList = new List<uint>();

            // 保存尚未分解的线性索引。
            uint remaining = linearIndex;

            // 从最后一维开始做除法和取余。
            for (int dimensionIndex = dimensionList.Count - 1;
                dimensionIndex >= 0;
                dimensionIndex--)
            {
                // 取得当前维度长度。
                uint dimension = dimensionList[dimensionIndex];

                // 零维度前面已经被过滤，这里仅做保护。
                uint itemIndex = dimension == 0 ? 0 : remaining % dimension;

                // 保存当前维度索引。
                indexList.Insert(0, itemIndex);

                // 去掉当前维度已使用的部分。
                remaining = dimension == 0 ? 0 : remaining / dimension;
            }

            // 拼接最终的 [x][y] 字符串。
            StringBuilder suffix = new StringBuilder();

            // 逐维添加索引。
            foreach (uint itemIndex in indexList)
            {
                suffix.Append("[");
                suffix.Append(itemIndex.ToString());
                suffix.Append("]");
            }

            // 返回完整后缀。
            return suffix.ToString();
        }

        /// <summary>
        /// 创建一个统一的未知类型对象。
        /// </summary>
        private static DwarfTypeInfo MakeUnknownType(ulong dieOffset)
        {
            // 创建类型对象。
            DwarfTypeInfo typeInfo = new DwarfTypeInfo();

            // 未知类型不能直接加入在线变量列表。
            typeInfo.kind = DwarfTypeKind.Unknown;

            // 使用明确名称便于调试。
            typeInfo.name = "<unknown>";

            // 保存原始 DIE 偏移。
            typeInfo.dieOffset = dieOffset;

            // 返回未知类型。
            return typeInfo;
        }

        /// <summary>
        /// 读取一个 DWARF 数据块。
        /// </summary>
        private static byte[] ReadBlock(
            byte[] fileData,
            ref ulong position,
            ulong end,
            ulong blockLength)
        {
            // 数据块不能越过当前编译单元末尾。
            if (position + blockLength > end || position + blockLength > (ulong)fileData.Length)
            {
                throw new InvalidDataException("DWARF数据块越界！");
            }

            // .NET 数组长度使用 Int32，因此先检查转换范围。
            if (blockLength > Int32.MaxValue)
            {
                throw new InvalidDataException("DWARF数据块过大！");
            }

            // 创建结果数组。
            byte[] result = new byte[(int)blockLength];

            // 复制数据块内容。
            Buffer.BlockCopy(fileData, ToInt32(position), result, 0, result.Length);

            // 推进到数据块末尾。
            position += blockLength;

            // 返回独立的数据块副本。
            return result;
        }

        /// <summary>
        /// 读取 DIE 内联的零结尾 UTF-8 字符串。
        /// </summary>
        private static string ReadInlineString(
            byte[] fileData,
            ref ulong position,
            ulong end)
        {
            // 记录字符串起点。
            ulong start = position;

            // 查找零结尾字节。
            while (position < end && position < (ulong)fileData.Length &&
                fileData[ToInt32(position)] != 0)
            {
                position++;
            }

            // 没有找到结束零字节说明字符串已经损坏。
            if (position >= end || position >= (ulong)fileData.Length)
            {
                throw new InvalidDataException("DWARF字符串没有结束符！");
            }

            // 计算字符串字节长度。
            int length = ToInt32(position - start);

            // 使用 UTF-8 解码 GCC 生成的名称。
            string value = Encoding.UTF8.GetString(fileData, ToInt32(start), length);

            // 跳过字符串末尾零字节。
            position++;

            // 返回字符串。
            return value;
        }

        /// <summary>
        /// 从 ELF 字符串表中读取零结尾 UTF-8 字符串。
        /// </summary>
        private static string ReadString(
            byte[] fileData,
            ElfSection stringSection,
            ulong stringOffset)
        {
            // 字符串表不存在或偏移越界时返回空字符串。
            if (stringSection == null || stringOffset >= stringSection.size)
            {
                return string.Empty;
            }

            // 计算字符串在文件中的绝对起点。
            ulong start = stringSection.offset + stringOffset;

            // 计算字符串表末尾，同时不能超过文件末尾。
            ulong end = Math.Min(
                stringSection.offset + stringSection.size,
                (ulong)fileData.Length);

            // 从起点开始查找零结尾字节。
            ulong position = start;

            // 字符串必须完全位于字符串表内。
            while (position < end && fileData[ToInt32(position)] != 0)
            {
                position++;
            }

            // 使用 UTF-8 解码字符串。
            return Encoding.UTF8.GetString(
                fileData,
                ToInt32(start),
                ToInt32(position - start));
        }

        /// <summary>
        /// 读取无符号 LEB128 数值。
        /// </summary>
        private static ulong ReadUleb128(
            byte[] fileData,
            ref ulong position,
            ulong end)
        {
            // 保存最终数值。
            ulong value = 0;

            // 保存下一字节需要左移的位数。
            int shift = 0;

            // LEB128 是不定长编码，因此循环到最高位为零。
            while (position < end && position < (ulong)fileData.Length)
            {
                // 读取当前字节并推进位置。
                byte item = fileData[ToInt32(position++)];

                // 超过 UInt64 能表示的范围时拒绝继续移位。
                if (shift >= 64)
                {
                    throw new InvalidDataException("DWARF ULEB128数值过大！");
                }

                // 把低七位合并到最终数值。
                value |= (ulong)(item & 0x7F) << shift;

                // 最高位为零表示编码结束。
                if ((item & 0x80) == 0)
                {
                    return value;
                }

                // 每个字节包含七位有效数据。
                shift += 7;
            }

            // 到达边界仍未结束说明数据损坏。
            throw new InvalidDataException("DWARF ULEB128越界！");
        }

        /// <summary>
        /// 读取有符号 LEB128 数值。
        /// </summary>
        private static long ReadSleb128(
            byte[] fileData,
            ref ulong position,
            ulong end)
        {
            // 保存最终数值。
            long value = 0;

            // 保存下一字节需要左移的位数。
            int shift = 0;

            // 保存最后读取的字节，用于符号扩展。
            byte item = 0;

            // 循环读取变长编码。
            while (position < end && position < (ulong)fileData.Length)
            {
                // 读取当前字节并推进位置。
                item = fileData[ToInt32(position++)];

                // 把低七位合并到最终数值。
                value |= (long)(item & 0x7F) << shift;

                // 当前字节已经提供七位数据。
                shift += 7;

                // 最高位为零表示编码结束。
                if ((item & 0x80) == 0)
                {
                    break;
                }

                // Int64 最多容纳 64 位。
                if (shift >= 64)
                {
                    throw new InvalidDataException("DWARF SLEB128数值过大！");
                }
            }

            // 如果符号位为一，就对高位执行符号扩展。
            if (shift < 64 && (item & 0x40) != 0)
            {
                value |= -1L << shift;
            }

            // 返回有符号结果。
            return value;
        }

        /// <summary>
        /// 从独立字节缓冲区读取指定字节序的无符号整数。
        /// </summary>
        private static ulong ReadUnsignedFromBuffer(
            byte[] data,
            int offset,
            int size,
            bool isLittleEndian)
        {
            // 检查读取范围。
            if (data == null || offset < 0 || size < 1 || size > 8 ||
                offset + size > data.Length)
            {
                throw new InvalidDataException("整数读取范围无效！");
            }

            // 保存最终数值。
            ulong value = 0;

            // 小端序低字节位于低地址。
            if (isLittleEndian)
            {
                for (int index = 0; index < size; index++)
                {
                    value |= (ulong)data[offset + index] << (index * 8);
                }
            }
            else
            {
                // 大端序高字节位于低地址。
                for (int index = 0; index < size; index++)
                {
                    value = (value << 8) | data[offset + index];
                }
            }

            // 返回整数结果。
            return value;
        }

        /// <summary>
        /// 验证文件内的一段范围是否合法。
        /// </summary>
        private static void ValidateRange(
            byte[] fileData,
            ulong offset,
            ulong size,
            string errorMessage)
        {
            // 使用减法形式判断，避免 offset + size 自身溢出。
            if (offset > (ulong)fileData.Length ||
                size > (ulong)fileData.Length - offset)
            {
                throw new InvalidDataException(errorMessage);
            }
        }

        /// <summary>
        /// 将文件偏移安全转换为数组索引。
        /// </summary>
        private static int ToInt32(ulong value)
        {
            // .NET Framework 4.5 的字节数组索引使用 Int32。
            if (value > Int32.MaxValue)
            {
                throw new InvalidDataException("文件偏移超过当前解析器支持范围！");
            }

            // 返回安全转换后的索引。
            return (int)value;
        }

        /// <summary>
        /// 将可空的 DWARF 数值安全转换为 UInt32。
        /// </summary>
        private static uint ToUInt32(ulong? value)
        {
            // 空值或超出范围都按零处理。
            if (!value.HasValue || value.Value > UInt32.MaxValue)
            {
                return 0;
            }

            // 返回有效的 UInt32 数值。
            return (uint)value.Value;
        }

        /// <summary>
        /// 将 DWARF 属性对象转换为无符号数。
        /// </summary>
        private static ulong? ConvertToUnsigned(object value)
        {
            // 空属性没有数值。
            if (value == null)
            {
                return null;
            }

            // 解析器的大多数无符号属性直接使用 UInt64 保存。
            if (value is ulong)
            {
                return (ulong)value;
            }

            // implicit_const 和 sdata 使用 Int64 保存。
            if (value is long && (long)value >= 0)
            {
                return (ulong)(long)value;
            }

            // 其他对象不是可用的无符号 DWARF 数值。
            return null;
        }

        /// <summary>
        /// 带字节序和边界检查的 ELF 二进制读取器。
        /// </summary>
        private class ElfBinaryReader
        {
            // 保存完整文件字节。
            private byte[] mData;

            // 保存文件字节序。
            private bool mIsLittleEndian;

            public ElfBinaryReader(byte[] data, bool isLittleEndian)
            {
                // 保存读取源。
                mData = data;

                // 保存字节序。
                mIsLittleEndian = isLittleEndian;
            }

            public byte ReadByte(int offset)
            {
                // 单字节读取也必须检查边界。
                CheckRange(offset, 1);

                // 返回目标字节。
                return mData[offset];
            }

            public ushort ReadUInt16(int offset)
            {
                // 检查两个字节是否完整存在。
                CheckRange(offset, 2);

                // 复用通用无符号整数读取函数。
                return (ushort)ReadUnsigned(offset, 2);
            }

            public uint ReadUInt32(int offset)
            {
                // 检查四个字节是否完整存在。
                CheckRange(offset, 4);

                // 复用通用无符号整数读取函数。
                return (uint)ReadUnsigned(offset, 4);
            }

            public ulong ReadUInt64(int offset)
            {
                // 检查八个字节是否完整存在。
                CheckRange(offset, 8);

                // 复用通用无符号整数读取函数。
                return ReadUnsigned(offset, 8);
            }

            public ulong ReadUnsigned(int offset, int size)
            {
                // DWARF 地址和偏移只允许 1、2、4 或 8 字节宽度。
                if (size != 1 && size != 2 && size != 4 && size != 8)
                {
                    throw new InvalidDataException("不支持的整数宽度：" + size.ToString());
                }

                // 检查读取范围。
                CheckRange(offset, size);

                // 使用统一函数处理字节序。
                return ReadUnsignedFromBuffer(mData, offset, size, mIsLittleEndian);
            }

            private void CheckRange(int offset, int size)
            {
                // 使用减法判断可以避免 offset + size 溢出。
                if (offset < 0 || size < 0 || offset > mData.Length ||
                    size > mData.Length - offset)
                {
                    throw new InvalidDataException("二进制文件读取越界！");
                }
            }
        }

        /// <summary>
        /// ELF 基础解析结果。
        /// </summary>
        private class ElfFile
        {
            public int elfClass;
            public bool isLittleEndian;
            public List<ElfSection> sectionList = new List<ElfSection>();
            public List<ElfSymbol> symbolList = new List<ElfSymbol>();

            public ElfSection FindSection(string sectionName)
            {
                // 按标准 Section 名称查找调试段。
                foreach (ElfSection section in sectionList)
                {
                    if (section.name == sectionName)
                    {
                        return section;
                    }
                }

                // 没有找到时返回 null。
                return null;
            }
        }

        /// <summary>
        /// ELF Section Header 的必要字段。
        /// </summary>
        private class ElfSection
        {
            public int index;
            public uint nameOffset;
            public string name;
            public uint type;
            public ulong address;
            public ulong offset;
            public ulong size;
            public uint link;
            public ulong entrySize;
        }

        /// <summary>
        /// ELF 符号表中的数据对象。
        /// </summary>
        private class ElfSymbol
        {
            public string name;
            public uint addr;
            public uint size;
            public string section;
        }

        /// <summary>
        /// 一个 DWARF 缩写定义。
        /// </summary>
        private class DwarfAbbrev
        {
            public ulong tag;
            public bool hasChildren;
            public List<DwarfAttributeSpec> attributeList =
                new List<DwarfAttributeSpec>();
        }

        /// <summary>
        /// 缩写定义中的一个属性和数据格式。
        /// </summary>
        private class DwarfAttributeSpec
        {
            public ulong attribute;
            public ulong form;
            public long implicitConstant;
        }

        /// <summary>
        /// DWARF Debugging Information Entry。
        /// </summary>
        private class DwarfDie
        {
            public ulong offset;
            public ulong tag;
            public byte addressSize;
            public Dictionary<ulong, object> attributeMap =
                new Dictionary<ulong, object>();
            public List<ulong> childList = new List<ulong>();
        }

        /// <summary>
        /// DWARF 数据库，负责 DIE 查找和继承属性读取。
        /// </summary>
        private class DwarfDatabase
        {
            public bool isLittleEndian;
            public int defaultAddressSize;
            public int compileUnitCount;
            public Dictionary<ulong, DwarfDie> dieMap =
                new Dictionary<ulong, DwarfDie>();
            public Dictionary<string, List<DwarfDie>> variableMap =
                new Dictionary<string, List<DwarfDie>>();

            public void BuildVariableIndex()
            {
                // 遍历全部 DIE，只为变量节点建立名称索引。
                foreach (DwarfDie die in dieMap.Values)
                {
                    // 非变量 DIE 不加入变量索引。
                    if (die.tag != DW_TAG_VARIABLE)
                    {
                        continue;
                    }

                    // 变量名称可能通过 specification 或 abstract_origin 继承。
                    string name = GetString(die, DW_AT_NAME);

                    // 无名变量无法与 ELF 符号对应。
                    if (string.IsNullOrEmpty(name))
                    {
                        continue;
                    }

                    // 第一次遇到该名称时创建候选列表。
                    if (!variableMap.ContainsKey(name))
                    {
                        variableMap[name] = new List<DwarfDie>();
                    }

                    // 保存当前变量声明。
                    variableMap[name].Add(die);
                }
            }

            public object GetAttribute(DwarfDie die, ulong attribute)
            {
                // 使用集合防止继承引用形成循环。
                return GetAttribute(die, attribute, new HashSet<ulong>());
            }

            private object GetAttribute(
                DwarfDie die,
                ulong attribute,
                HashSet<ulong> visitedOffsetSet)
            {
                // 空 DIE 没有属性。
                if (die == null)
                {
                    return null;
                }

                // 重复访问说明继承关系存在循环。
                if (visitedOffsetSet.Contains(die.offset))
                {
                    return null;
                }

                // 记录当前 DIE 已经访问。
                visitedOffsetSet.Add(die.offset);

                // 当前 DIE 直接声明该属性时立即返回。
                if (die.attributeMap.ContainsKey(attribute))
                {
                    return die.attributeMap[attribute];
                }

                // specification 和 abstract_origin 可以提供继承属性。
                ulong[] inheritedAttributeList = new ulong[]
                {
                    DW_AT_SPECIFICATION,
                    DW_AT_ABSTRACT_ORIGIN
                };

                // 依次检查两种继承来源。
                foreach (ulong inheritedAttribute in inheritedAttributeList)
                {
                    // 继承引用本身必须直接存在于当前 DIE。
                    if (!die.attributeMap.ContainsKey(inheritedAttribute))
                    {
                        continue;
                    }

                    // 将继承引用转换为 DIE 偏移。
                    ulong? inheritedOffset = ConvertToUnsigned(
                        die.attributeMap[inheritedAttribute]);

                    // 引用必须指向已解析的 DIE。
                    if (!inheritedOffset.HasValue ||
                        !dieMap.ContainsKey(inheritedOffset.Value))
                    {
                        continue;
                    }

                    // 从继承来源继续查找目标属性。
                    object inheritedValue = GetAttribute(
                        dieMap[inheritedOffset.Value],
                        attribute,
                        visitedOffsetSet);

                    // 找到属性后立即返回。
                    if (inheritedValue != null)
                    {
                        return inheritedValue;
                    }
                }

                // 当前 DIE 和继承来源都没有该属性。
                return null;
            }

            public ulong? GetNumber(DwarfDie die, ulong attribute)
            {
                // 先取得原始属性对象，再转换为无符号数。
                return ConvertToUnsigned(GetAttribute(die, attribute));
            }

            public string GetString(DwarfDie die, ulong attribute)
            {
                // 取得原始属性对象。
                object value = GetAttribute(die, attribute);

                // 字符串属性不是字符串时返回空字符串。
                return value as string ?? string.Empty;
            }
        }

        /// <summary>
        /// 统一后的 DWARF 类型类别。
        /// </summary>
        private enum DwarfTypeKind
        {
            Unknown,
            Base,
            Struct,
            Union,
            Array,
            Enum,
            Pointer,
        }

        /// <summary>
        /// 便于递归展开的 DWARF 类型描述。
        /// </summary>
        private class DwarfTypeInfo
        {
            public DwarfTypeKind kind;
            public string name;
            public uint size;
            public uint encoding;
            public ulong dieOffset;
            public ulong aggregateOffset;
            public DwarfTypeInfo elementType;
            public List<uint> dimensionList = new List<uint>();
        }

        /// <summary>
        /// ELF 符号与 DWARF 变量声明的一次匹配结果。
        /// </summary>
        private class DwarfVariableChoice
        {
            public DwarfDie variableDie;
            public DwarfTypeInfo typeInfo;
            public int score;
        }
    }
}
