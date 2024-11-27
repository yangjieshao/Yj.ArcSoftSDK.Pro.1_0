sdk验证地址的域名是as.arcsoftai.com 对应的DNS是114.114.114.114（http请求）

# 硬件要求
最低配置：Intel® CoreTM i5-2300@2.80GHz 或者同级别芯片<br/>
推荐配置：Intel® CoreTM i7-4600U@2.1GHz 或者同级别芯片<br/>

Linux aarch64系统；
GLIBC 2.17及以上；
GLIBCXX 3.4.19及以上；
GCC 4.8.2及以上；
cmake 3.0及以上；

安装依赖环境：
yum install libicu
yum install glibc 

设置虹软库文件软连接

cp -Rf /usr/Projects/ArcLib/Pro.1.0/* /usr/lib64
cp -Rf /usr/Projects/ArcLib/Pro.1.0/* /usr/lib

NET8 AOT 支持 (AOT后 要手动将虹软 dll 复制到根目录)

后台静默持续运行 且丢弃命令行输出数据
 nohup ./FaceCheck.Server >/dev/null &

商用授权 离线激活 将激活验证文件更名为 ArcFace64.dat ArcFace32.dat 

## 初始化虹软人脸sdk
````csharp
string proActiveKeySo64 = Ini.ReadIniData("ArcFace", "ProActiveKeySo64", string.Empty);

string appId = Ini.ReadIniData("ArcFace", "APPID", string.Empty);
string keySo64 = Ini.ReadIniData("ArcFace", "KEYSo64", string.Empty);

_ = ASFFunctions.Activation(appId, keySo64, proActiveKeySo64);
````
## 初始化人脸引擎
````csharp

_ = ASFFunctions.InitEngine(pEngine: ref engine, isImgMode: isImgMode, faceMaxNum: maxFaceNum,
    isAngleZeroOnly: false, needFaceInfo: true, needRgbLive: needRgbLive, needIrLive: false,
    needFaceFeature: true,needImageQuality: needImageQuality);
````
## 分析人脸照片
````csharp
List<FaceInfo> result = null;

if (engine != IntPtr.Zero)
{
    try
    {
        Image image = Converter.BuffToImage(imageBuffer);
        if(needCheckImage)
        {
            Converter.CleanImagePropertyItems(ref image);
        }

        result = ASFFunctions.DetectFacesEx(engine, image, faceMinWith: minWidth,
                    needCheckImage: needCheckImage, needFaceInfo: needFaceInfo, needRgbLive: needRgbLive,
                    needIrLive: false, needFeatures: needFeatures, needImageQuality: needImageQuality);
        image.Dispose();
    }
    catch (Exception ex)
    {
        Log.Instance.LogWrite(ex);
    }
}
            
````
## 特征值对比
````csharp
var similarity = ASFFunctions.FaceFeatureCompare(_DetectFacesEngine, feature1, feature2, ASFFunctions.IsPro && isIdcardCompare);
var similarity = ASFFunctions.FaceFeatureCompare(_DetectFacesEngine, featureIntptr1, featureIntptr2, ASFFunctions.IsPro && isIdcardCompare);
````
## 特征值转指针对比
````csharp 
var featureIntptr=ASFFunctions.Feature2IntPtr(feature)
````