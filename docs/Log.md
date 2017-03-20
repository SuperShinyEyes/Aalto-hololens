## 2017 March 6th Mon.
### What
* [Holograms tutorial 100](https://developer.microsoft.com/en-us/windows/mixed-reality/holograms_100)

### Problems & Solutions
#### 1. Build fail in Unity
* Error: `missing path \UnionMetadata\Facade\Windows.winmd`
* [Install Windows 10 SDK](http://answers.unity3d.com/questions/1116443/windows-sdk-installed-but-get-error.html)

#### 2. Deploy fail in VS
* Error: `Metadata file '.dll' could not be found`
* [Solution](http://stackoverflow.com/a/17723774):
  1. Right click on the solution and click Properties.
  2. Click Configuration on the left.
  3. Make sure the check box under "Build" for the project it can't find is checked. If it is already checked, uncheck, hit apply and check the boxes again.

### To-Dos
