# lod-toybox  
作者历年练手项目的归档仓库，仅供技术回顾与参考。

## 项目定位  
本仓库汇总了 2015-2022 年间出于兴趣、课程或实验目的编写的微型工具/脚本/游戏原型。  
全部代码按“原样”(AS-IS) 提供，不做后续维护，亦不保证可编译、可运行或适用于生产环境。

## 目录结构  

| 目录 | 内容 | 语言/框架 | 备注 |
|---|---|---|---|
| app-dm-dotnet | 哔哩哔哩第三方 UWP 客户端 | C# / UWP | 旧版本，仅供学习 UWP 结构参考 |
| app-formfiller | OfficeFormFiller | C# | 简易 Office 表单批量填写工具 |
| app-happyhandingin | HappyHandingIn 桌面端+安卓端 | C# / Xamarin | 作业收集小工具，含后端 |
| app-impnonjs | impnonjs + 插件仓库 | C++ / DirectInput/XInput | 将手柄输入映射为键盘，目前无法编译 |
| app-updater | ppUpdator | C# | 增量更新器，支持压缩包解压与自启动 |
| app-videotogether | VideoTogether | C# | 同步观影小工具 |
| app-watermark-adder | Watermarker | C# | 图片/视频批量加水印 |
| app-web-utils | Web-Development-Utils | C# | Json→Form 等 ASP.NET 辅助脚本 |
| game-lastwitch1 | LastWitch.App | 未知 | 游戏《LastWitch》原型，代码缺失 |
| gameengine-st2d | stLib(st2d) | C++ | 2D 游戏引擎，已归档，重构中 |
| hack-ppt-thief | pppt | C# | 课件静默拷贝小工具，仅教学演示 |
| notes | Learning-Algorithm-DataStructure、Learning-Haskell | Markdown | 算法与函数式学习笔记 |
| script-server-monitor | Server.Monitor | C# | 服务器状态监控脚本 |
| script-sosdan-bots | SOSDanBots | 未知 | 弹幕机器人合集，无文档 |
| script-zst-automation | ZSTAutomation | Python / Airtest | 移动设备点击自动化脚本 |
| web-campus-toolbox | CampusToolbox 前端+后端 | Angular / ASP.NET Core | 校园工具箱实验项目，含前后端 |

## 使用须知  
1. 所有二进制文件已移除，需自行编译。  
2. 部分项目依赖旧版运行时（.NET Framework 4.6 / UWP 14393 等），建议用对应年代 Visual Studio 打开。  
3. 涉及“课件拷贝”“手柄映射”等可能触碰机房或游戏厂商策略的代码，**仅限本地合法测试**，禁止用于未授权场景。  
4. 不再接受功能请求，如要改进请 fork 后自行维护。  

## 许可证  
各子目录许可证以该项目当时声明为准，未指明者默认 WTFPL（Do What The Fuck You Want To Public License）。引用第三方库时请遵守其原许可。

---


# lod-toybox  
An archival repository of the author's past experimental projects.

## Purpose  
This repo collects mini tools, scripts and game prototypes written between 2015-2022 for learning or coursework.  
All code is provided “AS-IS” without warranty of any kind, and is **not** intended for production use.

## Catalogue  

| Folder | Description | Language / Stack | Notes |
|---|---|---|---|
| app-dm-dotnet | 3rd-party Bilibili UWP client | C# / UWP | Outdated; reference only |
| app-formfiller | OfficeFormFiller | C# | Bulk fill Office forms |
| app-happyhandingin | HappyHandingIn (Win & Android) | C# / Xamarin | Homework collection helper |
| app-impnonjs | impnonjs + plugins | C++ / DirectInput/XInput | Joystick→keyboard mapper; currently broken |
| app-updater | ppUpdator | C# | Differential updater with archive extraction |
| app-videotogether | VideoTogether | C# | Synchronized video watching |
| app-watermark-adder | Watermarker | C# | Batch watermark for images/videos |
| app-web-utils | Web-Development-Utils | C# | ASP.NET helpers (Json→Form, etc.) |
| game-lastwitch1 | LastWitch.App | unknown | Prototype; source missing |
| gameengine-st2d | stLib (st2d) | C++ | 2-D game engine; archived, being refactored |
| hack-ppt-thief | pppt | C# | Silent lecture-slide copier; demo only |
| notes | Learning-Algorithm-DataStructure, Learning-Haskell | Markdown | Personal reading notes |
| script-server-monitor | Server.Monitor | C# | Lightweight server monitoring |
| script-sosdan-bots | SOSDanBots | unknown | Danmaku bot collection; no docs |
| script-zst-automation | ZSTAutomation | Python / Airtest | Mobile click-automation scripts |
| web-campus-toolbox | CampusToolbox front & back | Angular / ASP.NET Core | Campus utility experiment |

## Important Notes  
1. No pre-built binaries are shipped; you must compile yourself.  
2. Some projects target obsolete runtimes (.NET Framework 4.6, UWP 14393, …). Use a period-appropriate Visual Studio to open.  
3. Tools such as “ppt-thief” or “impnonjs” may conflict with institutional or vendor policies. **Use only on machines you own and with explicit permission.**  
4. Feature requests are no longer accepted; fork and maintain on your own if you need changes.

## License  
Each subdirectory retains the license declared at the time of creation. Where none is specified, WTFPL applies. Respect third-party licenses when present.