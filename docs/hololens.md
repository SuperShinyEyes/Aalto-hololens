## [Specs](http://www.pcworld.com/article/3039822/consumer-electronics/we-found-7-critical-hololens-details-that-microsoft-hid-inside-its-developer-docs.html)
* HPU 1.0 + 1GB RAM
* 32-bit Intel chip + 2GB RAM
* 64GB flash
* 2MP camera
* 60FPS(actually, 60FPS x 4 for RGBG) / 30FPS when filming
* 720p per eye

## [Spatial Mapping](https://developer.microsoft.com/en-us/windows/holographic/Spatial_mapping_design.html#what_influences_spatial_mapping_quality.3f)
### Scanning Scope
* The camera used for scanning provides data within a 70-degree cone
* 0.8 ~ 3.1 meters from the camera
* Note that these values are subject to change in future versions.

### User Motion
* Surfaces tend to be scanned at a higher quality when they are viewed head-on rather than at a shallow angle.
* If the head-tracking system of the HoloLens fails momentarily (which may happen due to rapid user motion, poor lighting, featureless walls or the cameras becoming covered), this can introduce errors in the spatial mapping data. Any such errors will be corrected over time as the user continues to move around and scan their environment.

### Surface materials
* The materials found on real-world surfaces vary greatly. These impact the quality of spatial mapping data because they affect how infrared light is reflected.
* Dark surfaces may not scan until they come closer to the camera, because they reflect less light.
* Some surfaces may be so dark that they reflect too little light to be scanned from any distance, so they will introduce hole errors at the location of the surface and sometimes also behind the surface.
* Particularly shiny surfaces may only scan when viewed head-on, and not when viewed from a shallow angle.
* Mirrors, because they create illusory reflections of real spaces and surfaces, can cause both hole errors and hallucination errors.

### Scene motion
* Spatial mapping adapts rapidly to changes in the environment, such as moving people or opening and closing doors.
* However, spatial mapping can only adapt to changes in an area when that area is clearly visible to the camera that is used for scanning.
* Because of this, it is possible for this adaptation to lag behind reality, which can cause hole or hallucination errors.
* As an example, a user scans a friend and then turns around while the friend leaves the room. A 'ghost' representation of the friend (a hallucination error) will persist in the spatial mapping data, until the user turns back around and re-scans the space where the friend was standing.

### Lighting interference
* Ambient infrared light in the scene may interfere with scanning, for example strong sunlight coming through a window.
* Particularly shiny surfaces may interfere with the scanning of nearby surfaces, the light bouncing off them causing bias errors.
* Shiny surfaces reflecting light directly back into the camera may interfere with nearby space, either by causing floating mid-air hallucinations or by delaying adaptation to scene motion.
* Two HoloLens devices in the same room should not interfere with one another, but the presence of more than five HoloLens devices may cause interference.

### Scanning size
* 7 x 7 meters in [Young Conker](https://www.microsoft.com/microsoft-hololens/en-us/apps/young-conker)

## [Hologram render distances](https://developer.microsoft.com/en-us/windows/holographic/Hologram_stability.html#hologram_render_distances)
* Recommended clipping distance: 0.85m. => fade out of content starting at 1m.
* Due to [vergence-accommodation conflict](https://www.wired.com/2015/08/obscure-neuroscience-problem-thats-plaguing-vr/)

### Vergence-accommodation conflict
Users wearing HoloLens will always accommodate to 2.0m to maintain a clear image because the HoloLens displays are fixed at an optical distance approximately 2.0m away from the user(fixed accommodation). *However*, their eyes will converge according to the distance between a hologram and their eyes(free vergence). So while accommodation and vergence are coupled in natural environment, they are decoupled in VR/AR.
![vergence-accommodation conflict](/images/vergence-accommodation conflict.JPEG)
*< Image by HOFFMAN ET AL. JOURNAL OF VISION 2008 >*

## Benchmark
### [Drawing triangles](http://umbra3d.com/how-much-is-too-much-benchmarking-with-hololens/)
![frame_rate-kalmar](/images/frame_rate-kalmar.PNG)

![frame_rate-operahouse](/images/frame_rate-operahouse.PNG)
* Models below 200.000 triangles can run smoothly at 30 FPS, not perfect but valid for some applications.
* HoloLens is comfortable rendering 80K triangles simultaneously. Around this value it’s important to craft your shaders carefully because heavy calculation in the fragment shader will have a severe impact on performance.
* There’s no big impact using StandardFast (HoloToolkit) over the standard PBS shader provided by Unity
* Mirroring HoloLens screen decreases the performance.

## Hololens Opensource code
* [Holotoolkit](https://github.com/Microsoft/HoloToolkit)
* [HoloToolkit-Unity](https://github.com/Microsoft/HoloToolkit-Unity)
* [HolographicAcademy](https://github.com/Microsoft/HolographicAcademy)
* [HoloLensCompanionKit](https://github.com/Microsoft/HoloLensCompanionKit)
* []()
* []()
* []()
