# Home

在这里测试一些针对WPF来说的一些Hook问题。



## MouseKeyHook

**NuGet:**  [NuGet Gallery | MouseKeyHook 5.6.0](https://www.nuget.org/packages/MouseKeyHook/)

**GitHub: ** [gmamaladze/globalmousekeyhook: This library allows you to tap keyboard and mouse, detect and record their activity even when an application is inactive and runs in background. (github.com)](https://github.com/gmamaladze/globalmousekeyhook)

**MIT**



源码里面有测试用例，有类式于快速退出等等。显示界面，等等一系列的操作。



此Hook主要分为两种形式

```c#
public static class Hook
{
    public static IKeyboardMouseEvents AppEvents();
    public static IKeyboardMouseEvents GlobalEvents();
}
```

全局Hook和应用级别的Hook