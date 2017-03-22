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

## [Holoscanner project summary](https://holoscanner.github.io/)
<div class="sketchfab-embed-wrapper"><iframe width="640" height="480" src="https://sketchfab.com/models/5b8de5a267ae416a85a78f75e0260d8a/embed" frameborder="0" allowvr allowfullscreen mozallowfullscreen="true" webkitallowfullscreen="true" onmousewheel=""></iframe>
</div>

### [Mesh Processing](https://holoscanner.github.io/2016/04/21/week-3-technical-framework.html)
We anticipate that most of our mesh processing approaches will be based on volumetric integration methods, based on the methods introduced by [VRIP](https://graphics.stanford.edu/papers/volrange/) (Curless & Levoy 1996) and refined in [KinectFusion](https://www.microsoft.com/en-us/research/project/kinectfusion-project-page/?from=http%3A%2F%2Fresearch.microsoft.com%2Fen-us%2Fprojects%2Fsurfacerecon%2F) (Newcombe et al. 2011).

### Mesh Alignment Approaches
For mesh alignment, we will start with the rough alignment of coordinate systems between Hololens devices provided by the HoloToolkit Sharing code. If this proves to be insufficient, we can refine alignments relative either to a global volumetric model (similar to KinectFusion) or relative to one of the Hololens meshes. Fine scale alignment can be done by using ICP.

Larger scale misalignments (e.g. subtle warping when walls do not quite line up or bend) coulld be aligned by taking advantage of the Manhattan World assumption of the large planes in the world. We could use an alignment method that forces large planes to be parallel or coplanar.

### Mesh Refinement Approaches
In terms of mesh refinement, we will begin with the problem of effectively integrating multiple meshes. This will provide a single, clean mesh rather than the several overlapping noisy meshes in the raw input. We will also implement a signed distance function-based approach as in VRIP and KinectFusion, which will average out the noise. We also imagine that aligning the volume with the dominant directions of the walls will let us smooth the volume and provide even cleaner reconstructions for these surfaces.

Another challenge is dealing with dynamic objects. In our global volume, it is possible that dynamic objects will be reconstructed as scene geometry. However, for any new mesh captured from a particular viewpoint, we can render a depth map of the global volume and compare it to the new mesh. If there is a surface in the global map that is closer than a surface in the new observation, then we know that the data in the global map is in error and those voxels should be cleared. Note that this does not work for detecting dynamic objects in new scans that are not in the global volume, since these are just as likely to be new unscanned data that should be in the scene. In this case, we just integrate the (possibly) dynamic object into the volume, and when another device views the space again, the above algorithm should then detect and remove the dynamic object.

This framework does not handle other refinement issues we’d like to address, such as using the color images to inform occlusion boundaries. However we probably won’t have time to address this type of issue.

### [No low-level(SDFs or depth maps) API](https://holoscanner.github.io/2016/04/21/week-3-technical-framework.html)
Hololens team suggested that the finest resolution mesh that the API provides is of equivalent resolution to the depth maps (so we suspect this is just the raw marching cubes mesh on the SDF they use for reconstruction). We also heard rumors of some side channel or internal tool that could be used to get the raw data, but it is unclear if we will be able to use this.


## Vergence-accommodation conflict
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
