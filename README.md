#KeyboardStatus 

##功能
在任务栏显示 键盘大小写锁定 和 数字键盘锁定状态

##说明
* 可设置开启或关闭某个状态显示
* 可设置开机自启动（默认不开启）  

>以上设置需要以管理员身份运行(配置通过在注册表中添加记录的方式实现)    

发现一个有趣的现象，钩子程序在.net4.0等较高版本可能出现找不到指定模块的错误，  
将项目修改为2.0版本即可。但这个错误并不总是发生。有待进一步研究。  

##参考文献：
* [How can I find the state of NumLock, CapsLock and ScrollLock in .net?](http://stackoverflow.com/questions/577411/how-can-i-find-the-state-of-numlock-capslock-and-scrolllock-in-net)  
* [C# 全局键盘监视（全局键盘钩子）](http://www.wxzzz.com/215.html)  
* [创建一个不显示窗口的程序](http://ly4cn.cnblogs.com/archive/2006/03/16/351205.html?Pending=true#Post)  
