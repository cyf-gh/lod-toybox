# CampusToolbox 后端

## 快速开始

### 快速打开工作区域

```bash
$ . workspace.bash
```

### .shortcuts文件夹

存放开发常用的快捷方式或者软件。



## Model设计

Model被设计为Front和Back，分别对应前端model与后端model，这样做可能有助于model验证。

你将会看见这两个命名空间

```c#
using CampusToolbox.Model.Back;
using CampusToolbox.Model.Front;
```

分别代表前端与后端model。

### Front

前端被设计为View和Data

#### View

```c#
using CampusToolbox.Model.Front.View;
```

其中的model均为将会在前端被渲染在html页面上的信息，需要进行有效的XSS攻击防范。

