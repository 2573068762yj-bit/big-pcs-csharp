# 大储 PCS 旧版 C# 上位机

这是旧版大储 PCS WinForms 上位机的独立云端构建仓库，保留 C# / .NET Framework 技术路线。

## 构建环境

- Visual Studio 2022 Windows Runner
- MSBuild
- NuGet
- .NET Framework 4.5 参考程序集（通过 NuGet 固定提供）
- Microsoft Office Excel Interop（通过 NuGet 提供编译依赖）

## 云端构建

推送到 `main` 后，GitHub Actions 自动执行 Release 构建。也可以在 Actions 页面手工运行“构建旧版 C# 上位机”。

成功后下载产物：

```text
BigPcs-Debuger-CSharp-win32
├─ PcDebuger.exe
├─ PcDebuger.exe.config
└─ ControlCANFD.dll
```

程序保留 `AnyCPU + Prefer 32-bit`，以兼容现有 32 位 `ControlCANFD.dll`。运行电脑仍需安装对应 USB-CANFD 硬件驱动；Excel 导出功能需要安装 Microsoft Excel。

## 本地构建

```powershell
nuget restore PcDebuger.sln
msbuild PcDebuger.sln /m /p:Configuration=Release /p:Platform="Any CPU"
```

