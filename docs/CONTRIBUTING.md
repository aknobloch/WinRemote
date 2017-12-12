### Setup guidelines
```
Setting up Windows server dependencies:
* Prerequisites
	1. Visual Studio 2017 with the .NET desktop development package.
```
1. First, download the latest 32Feet.NET library from [here](https://32feet.codeplex.com/releases/view/88941) 
2. Run the setup files for the library. It will likely require you to install an older version of the .NET framework in the installer. The library (as of writing) runs on .NET 3.5, while our project is built with a later version. You need both, but they are intercompatible. 
* *warning* The installer may give you an error that the MS Help 2.X runtime is not installed. If you care about Help files, you can try to solve that. I don't, so I didn't and it was fine. 
3. Afterwards, open the project solution file. 

```
To set up the database in Visual Studio you will need to:
```

* Right-click References > Manage NuGET Packages > Browse > SQLite.Net-PCL > Install
* Download the 32-bit (x86) [SQLite3 DLL](http://www.sqlite.org/download.html) and copy it into bin/Debug folder.
* Select the BTConnectionService top-level folder in the Solution Explorer.
* Go to Project > Add Existing Item and then select the sqlite3.dll file
* Now, right click the .dll that is in the solution folder, and select Properties
* Ensure that Build Action is set to Content and Copy to Output is set to Copy if newer...

