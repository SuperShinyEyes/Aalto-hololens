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


# Mirroring/Accessing HoloLens
1. [Hololens app on Windows 10](https://www.microsoft.com/en-ca/store/p/microsoft-hololens/9nblggh4qwnx)
2. From a web browser on your PC, go to https://<YOUR_HOLOLENS_IP_ADDRESS>
  * The browser will display the following message: "There’s a problem with this website’s security certificate". This happens because the certificate which is issued to the Device Portal is a test certificate. You can ignore this certificate error for now and proceed.
