LOD Toybox

一个汇集了各种实用小程序、工具、脚本和游戏项目的综合仓库。这些项目涵盖了日常办公、学习、娱乐和开发等多个领域，旨在提高效率、简化流程或纯粹带来乐趣。
📂 目录结构

lod-toybox/
├── app-dm-dotnet/ # .NET磁盘管理应用（已弃用）
├── app-formfiller/ # 表单自动填写工具
├── app-happyhandingin/ # 作业提交辅助工具
├── app-impnonjs/ # 非手柄游戏手柄支持工具（已弃用）
├── app-updater/ # 应用自动更新器
├── app-videotogether/ # 多人同步观影工具
├── app-watermark-adder/ # 水印添加软件
├── app-web-utils/ # Web开发实用工具集
├── game-lastwitch1/ # 《最后的女巫》游戏
├── gameengine-st2d/ # 2D游戏引擎
├── hack-ppt-thief/ # PPT自动拷贝工具
├── notes/ # 学习笔记（算法、Haskell等）
├── script-server-monitor/ # 服务器状态监控脚本
├── script-sosdan-bots/ # 机器人脚本
├── script-zst-automation/ # 掌上通自动化脚本（已弃用）
└── web-campus-toolbox/ # 校园工具箱
🛠️ 应用与工具概览
🎮 游戏相关
LastWitch - 一款独立游戏项目，包含完整的游戏逻辑和资源
impnonjs - 让你的手柄可以在不支持手柄的游戏中使用，兼容DirectInput和XInput
gameengine-st2d - 轻量级2D游戏引擎，适用于小型游戏开发
💼 办公辅助
HappyHandingIn - 简化作业提交流程，让收作业从未如此轻松（提供桌面版和Android版）
OfficeFormFiller - 自动填充Office表单，节省重复工作时间
WatermarkAdder - 便捷添加水印到文档或图片
ppUpdator - 通用应用更新器，可配置化更新流程，支持自动下载、解压和重启应用
💻 开发工具
Web-Development-Utils - Web开发实用工具集，包括：
Json2Form：根据JSON数据自动生成表单代码
各种开发配置文件和模板
Server.Monitor - 服务器状态监控工具，实时追踪服务器性能指标
🔧 实用脚本
ZSTAutomation - 掌上通自动化脚本，支持工作日志、工作计划自动填写，基于Airtest
SOSDanBots - 自动化机器人脚本集
PPT Thief - 专治不分享PPT的老师，自动复制演示文稿到指定位置
🌐 Web应用
CampusToolbox - 校园综合工具箱
前端：Angular框架构建的响应式界面
后端：.NET Core API服务
支持XSS防护和前后端数据验证
产品分析文档
📚 学习资料
Algorithm & DataStructure - 算法与数据结构学习笔记，包括排序算法、递归与迭代等核心概念
Haskell Learning - 函数式编程语言Haskell学习笔记
🚀 使用说明

大多数应用都提供了独立的README文件，包含详细的使用指南。通用建议：

1. 编译要求：
.NET项目：需要.NET Framework或.NET Core SDK
Angular项目：需要Node.js和npm
游戏项目：可能需要特定的游戏引擎

1. 运行方式：
桌面应用：通常可直接运行编译后的exe文件
Web应用：需要先安装依赖，然后构建并部署
脚本：按照各自目录中的说明执行

1. 配置：
许多工具需要配置文件才能正常工作
请参考各项目目录中的示例配置文件和说明文档
⚠️ 注意事项
部分工具（如PPT Thief）用于特定场景，请合法合规使用
某些项目年久失修，可能存在兼容性问题（如impnonjs标注"年久失修目前无法正常编译"）
代码质量参差不齐，部分早期项目可能包含不规范的代码实现
使用前请仔细阅读各个子项目的许可证信息
🤝 贡献指南

欢迎提交issue和pull request！贡献前请：
1. 阅读具体项目的贡献指南（如果有的话）
2. 确保代码风格与原项目保持一致
3. 添加必要的文档和注释
4. 测试你的更改是否影响现有功能
📄 许可证

各子项目可能有不同的许可证，请查看各项目目录中的LICENSE文件获取详细信息。主要许可证包括：
MIT License
WTFPL (Do What The Fuck You Want To Public License)
其他开源许可证