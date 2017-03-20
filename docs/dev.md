# Visual Studio Tips

## Unity settings for HoloLens
### 1. Player settings
1. From the Build Settings... window, open Player Settings...
2. Select the Settings for Windows Store tab
3. Expand the Other Settings group
4. In the Rendering section, check the Virtual Reality Supported checkbox to add a new Virtual Reality Devices list and confirm "Windows Holographic" is listed as a supported device.

### 2. Build Settings
1. Select File > Build Settings...
2. Select Windows Store in the Platform list.
3. Set SDK to Universal 10
4. Set Build Type to D3D.

### 3. Performance settings
![UnityQualitySettings](/images/UnityQualitySettings.PNG)
1. Select Edit > Project Settings > Quality
2. Select the dropdown under the Windows Store logo and select Fastest. You'll know the setting is applied correctly when the box in the Windows Store column and Fastest row is green.

## Visual Studio settings
### Edit `Package.appxmanifest` in VS.
`TargetDeviceFamily Name` & `MaxVersion`.

Example:
```XML
<Dependencies>
    <TargetDeviceFamily Name="Windows.Holographic" MinVersion="10.0.10240.0" MaxVersionTested="10.0.10586.0" />
</Dependencies>
```

### VS Build settings
![build_settings](/images/VS_build_settings.PNG)


## Mirroring/Accessing HoloLens
1. [Hololens app on Windows 10](https://www.microsoft.com/en-ca/store/p/microsoft-hololens/9nblggh4qwnx)
2. From a web browser on your PC, go to https://<YOUR_HOLOLENS_IP_ADDRESS>
  * The browser will display the following message: "There’s a problem with this website’s security certificate". This happens because the certificate which is issued to the Device Portal is a test certificate. You can ignore this certificate error for now and proceed.


## "My cursor is not showing!" or "My C# scripts are not working" or VS fails to build/attach debugger.

![managers_inspector](/images/managers_inspector.PNG)
You MUST add-component your scripts to corresponding objects in Unity in order to let Unity use the scripts.

## Build fail in Unity
* Error: `missing path \UnionMetadata\Facade\Windows.winmd`
* [Install Windows 10 SDK](http://answers.unity3d.com/questions/1116443/windows-sdk-installed-but-get-error.html)

## Deploy fail in VS
* Error: `Metadata file '.dll' could not be found`
* [Solution](http://stackoverflow.com/a/17723774):
  1. Right click on the solution and click Properties.
  2. Click Configuration on the left.
  3. Make sure the check box under "Build" for the project it can't find is checked. If it is already checked, uncheck, hit apply and check the boxes again.
