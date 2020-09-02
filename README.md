
# VSLIB.NET
Ackie様のvslibのC#ラッバーです。


## 概要
VocalShifterの音声解析・音声合成機能を利用できるvslib、というライブラリをC#から呼び出すプログラムです。  

vslibは音声波形に対して、ピッチシフト、フォルマントシフト、ダイナミクス操作、タイムストレッチ、イコライザーなどの各種操作を、高速かつ高品質に実行するライブラリです。  
内部的には[森勢先生](https://github.com/mmorise)の[World](http://www.kki.yamanashi.ac.jp/~mmorise/world/)の機能を含むようですが、スペクトル包絡や非周期性指標を操作することはできません(vslib ver1.51)。  
32bit/64bit両方に対応していますので、bit数を気にせずご利用できます。  

ほとんど、Ackie様のvslibの説明になってしまいましたが、VSLIB.NETはC#からvslibを呼び出せるラッバーです。  
音声の信号処理にご興味のある方は、是非お試しください。  

## 使い方

### １．vslib.dllの入手
本リポジトリに含まれるvslib.dllはダミーのテキストファイルなので、
本物のライブラリはAckie Sound様から入手して、「VSLIB.NET/vslib.dll」と「VSLIB.NET/vslib_x64.dll」を置き換えてください。  

[Ackie Sound 倉庫](http://ackiesound.ifdef.jp/soko.html)

### ２．Visual Studio からサンプルの起動
VocalShifterLibraryTest.sln をVisual Studioで開いて実行すればサンプルプログラムが起動します。  

### ３．他のソリューションからの呼び出し
VSLIB.NETプロジェクトをそのまま他のソリューションに読み込むか、ビルドされたVSLIB.NET.dllを参照に追加するなどしてご利用ください。

## 主要ファイル説明


### VSLIB.NET
vslib.dllのラッパーです。  


### vslib.dll, vslib_x64.dll
Ackie Sound様が公開している、[VocalShifter](http://ackiesound.ifdef.jp/index.html)の音声解析・音声合成機能を利用できるライブラリです。  
本リポジトリに含まれるのはダミーのテキストファイルなので、
本物のライブラリはAckie Sound様から入手してご利用ください。  
また、vslibの仕様書も同梱されていますので、機能についてもそちらが参考になると思います。

[Ackie Sound 倉庫](http://ackiesound.ifdef.jp/soko.html)


### VocalShifterLibraryTest
簡単なものですが、ライブラリを呼び出すサンプルプログラムです。  
全ての機能を試すことはできませんが、参考までに置いておきます。


## ライセンスについて

本リポジトリのソースコードはMITにしてありますが、  
2020年9月現在、vslib.dllは個人開発のフリーソフトに利用が限定されているので、ご注意ください。


## 作った人
[ビス](https://biss-git.github.io/Portfolio/)と申します。  
何かあればご連絡ください。
