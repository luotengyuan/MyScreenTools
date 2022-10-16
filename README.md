# 背景
你是不是每次要截图而需要打开微信或者QQ截图而感到麻烦，你是不是经常被类似某度文库不能复制文字而感到不爽，你是不是在需要获取屏幕上某个颜色而到处找工具，你是不是想将屏幕操作生成动图图分享给其他人~~~
最近在遇到以上需求时寻找很久还是未能找到合适的方便的工具，于是自己动手写了一个Windows屏幕工具，包括：屏幕截图、贴图、屏幕取色、截图文字、表格识别（需要申请百度OCR服务）、截图翻译、划词翻译（需要申请百度翻译服务）、GIF录屏等功能。并将源码开源，和提供安装程序，希望能够帮助有相同困扰的朋友。

 - 代码地址：[https://github.com/luotengyuan/MyScreenTools](https://github.com/luotengyuan/MyScreenTools)
 - 安装程序：[https://download.csdn.net/download/loutengyuan/85952364](https://download.csdn.net/download/loutengyuan/85952364)

# 功能介绍
## 主界面
![主界面](https://img-blog.csdnimg.cn/0318bc832d4b44e8889d499377dc6887.png)
## 开机启动设置
设置完开机启动后就不用每次手动打开，每次需要截图或文字识别等功能就可以直接使用。
![开机启动](https://img-blog.csdnimg.cn/37b939abfa8f445eafc2c3f770ebb224.png)
## 快捷键设置
可通过快捷键设置对截图、贴图、屏幕取色、文字识别、表格识别等功能进行快捷调用。
![快捷键设置](https://img-blog.csdnimg.cn/6b762c035c9041f0b3ad9fa9a58e419d.png)

## 百度云信息设置
文字识别和翻译是调用的百度云平台的接口，所以想使用这些功能的需要到百度云开放平台注册对于的Key，并设置到软件中才能正常使用。如何申请服务请参照这篇文章：[https://luotengyuan.notion.site/OCR-APIKey-SecretKey-a4ae1949601f44d1a5ef67065f56eb11](https://luotengyuan.notion.site/OCR-APIKey-SecretKey-a4ae1949601f44d1a5ef67065f56eb11)
![百度云设置](https://img-blog.csdnimg.cn/5104a6f4f5ce4465ad068b81f438a74f.png)
## 截图文字识别
通过截取屏幕中文字区域，将该区域中文字提取出来，并自动复制到剪切板，直可以直接粘贴到所需要的地方。
![截图文字识别](https://img-blog.csdnimg.cn/fc91ab6bc33545479443e459a54e6c90.gif)
## 截图文字翻译
识别图像中文字，并进行翻译成指定语言文字。
![截图文字翻译](https://img-blog.csdnimg.cn/9632752091584e51bebc79b7b8964ea1.gif)
## 屏幕取色器
屏幕取色器提取某个像素点的RGB、HSB、HSL、HSV、CMYK等颜色值。
![屏幕取色器](https://img-blog.csdnimg.cn/e1697fb844a44ebbb23bfb645783689f.gif)
## GIF录屏
将屏幕操作录制成GIF动图，包含全屏录制、自定义区域录制、捕获鼠标、保存文件或者复制到剪切板等功能。
![GIF录屏](https://img-blog.csdnimg.cn/394f03cdbe3c4aa2984ad487280a5605.gif)

