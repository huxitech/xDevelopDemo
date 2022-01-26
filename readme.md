## 编译

需要建立depends文件夹，内涵依赖文件（框架内核文件），包含：

depends:依赖的框架库文件,包含如下子目录
depends/Addins：基础库插件描述文件
depends/data ： 基础库数据文件(未来可能会被移除)
depends/Libraries: 基础库

这些文件会被ICSharpCode.App工程自动拷贝到生成目录

## 工程说明

1、ICSharpCode.App工程：
启动工程,可以基于此工程作为入口调试程序。



2、ICSharpCode.Demo工程：
一些demo代码：

---

step/DemoStep:

拓展Follow组件，支持建立一个自定义的Step供流程模块使用。

WorkPanel/DemoWorkPanel：

拓展WorkPanel，支持建立一个全新的工作页面。

