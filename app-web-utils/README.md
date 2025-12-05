# Web-Development-Utils
🌏 Web-Development-Utils - 自编写的Web开发工具

## 概览

* [Json2Form](#json2form)
* [raw](#raw)

## Json2Form
根据Json数据生成表单等文本

![json2form-img](https://raw.githubusercontent.com/cyf-gh/Web-Development-Utils/master/.res/json2form.jpg)

### 高级
#### 设置
```
{
  inputName: "$$$$",
  inputType: "^^^^",
  headTailSpliter: "%%%%%%%"
}
```
* inputName 替换json key值
* inputType 根据json value值类型替换表单type元素，见[这个源文件](https://github.com/cyf-gh/Web-Development-Utils/blob/master/src/WebUtils.Core/Json2Form.cs)的GetInputType成员函数。
* headTailSpliter 包裹字串头尾分割处

#### 预设
每一个预设方案有两个文件组成
```
*.j2f.raw
*.j2f.raw.wrapper
```

*.j2f.raw
```
$$$$:['', Validators.required],
```

*.j2f.raw.wrapper

```
this.formModel = this.fb.group ( {
  %%%%%%%
} );
```

则输入
```
{
  'description': 'A person',
  'type': 'object'
}
```
输出
```
this.formModel = this.fb.group ( {
description:['', Validators.required],
type:['', Validators.required],
} );
```



## raw

储存网络开发或是相关的一些文件。

* sh.json - host文件备份

