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
