# 3D Modeling in Games – Comparison of Tools for Creating 3D Assets

3D modeling has greatly influenced the gaming experience and has become an essential aspect of game development. The possibilities are nearly limitless — from modeling characters, props, and environments to entire virtual worlds.

This repository documents the practical part of a work comparing selected 3D modeling tools used in game development. The goal is to create the **same asset** (a wooden barrel) in different software, test it in a game engine (Unity), and critically evaluate each tool's workflow, learning curve, advantages, disadvantages, and suitability for game-ready asset production.

## Practical Workflow – Barrel Asset Creation

All modeling was performed using **metric units (millimeters)** to ensure game-ready scale from the beginning.

### Model specifications
- Modeling
- PBR texturing
- UV unwrapping
- Optimization
- Final export

### Testing specifications
- Correct FBX import (scale, rotation, materials)
- Performance (polygon count, draw calls)
- PBR material appearance
- Physics/collider setup
- Visual quality in real-time

# Blender

Blender is a free, open-source 3D creation suite that supports the full pipeline from modeling, UV unwrapping, texturing, animation, rendering to simulation.  
For game asset creation it offers a powerful modifier stack (non-destructive workflow), excellent built-in PBR material editor (Principled BSDF + Node Wrangler add-on), robust UV tools (Smart UV Project, Cube Projection), optimization utilities (Limited Dissolve, Decimate, Shade Auto Smooth), and clean FBX/glTF export with transform application.

**Benefits**  
- Completely free with no licensing restrictions  
- Very active community, vast tutorial ecosystem, frequent updates  
- Highly customizable UI and hotkeys  
- Strong support for hard-surface modeling and game asset optimization  

**Limitations**  
- Steep initial learning curve (especially for absolute beginners) due to dense interface and shortcut-heavy workflow  
- Some advanced industry-specific features (e.g. high-end sculpting, complex rigging) are less polished than in paid specialized tools  
- Node-based shading can feel overwhelming at first compared to layer-based systems  

## Model creation

Working in Blender felt surprisingly intuitive after the first few hours of learning the core shortcuts and navigation. The Edit Mode + modifier-based workflow was rewarding — seeing the barrel take shape from a simple circle through extrusion, beveling, separation into planks, curvature via subdivision scaling, and finally texturing was very satisfying.  

The UI is clean, modern (especially in recent versions), and highly responsive. Add-ons like Node Wrangler dramatically sped up PBR texture setup, while the modifier stack (Solidify, Bevel, Subdivision Surface) allowed non-destructive experimentation. Limited Dissolve proved to be an excellent optimization tool, reducing polycount significantly without visible quality loss. Overall, the experience was enjoyable and productive once the basic hotkeys became muscle memory.

**Detailed step-by-step documentation:**  
[Blender – Model Creation](./Blender/Blender_Model_Documentation.md)

## Testing in Unity

Testing the Blender-created barrel in Unity focused on verifying correct import, visual fidelity, performance, and physics behavior in a real-time environment. The model was imported into a clean HDRP project, where textures and materials were properly extracted and configured. Initial visual issues (such as incorrect normal maps) were resolved, resulting in a significantly improved and realistic appearance.

Lighting and shadow settings were adjusted to better evaluate the model under different conditions, while the Unity Stats panel was used to monitor performance metrics such as FPS and triangle count. The barrel maintained stable performance (around 100–120 FPS) with approximately 21k triangles, confirming that the model is well-optimized for real-time use.

**Performance metrics:**  

- **SetPass Calls:** 29
- **Draw Calls:** 237
- **Batches:** 237
- **Triangles:** 21.1k
- **Vertices:** 23.7k
- **FPS:** 100+  

To further test interactivity, simple scripts were introduced to rotate the camera and lighting around the object, as well as to simulate physics-based behavior. The barrel was equipped with colliders and a rigidbody setup, allowing it to roll naturally and respond to the environment. Additionally, a custom script enabled the barrel to "explode" into separate parts either on impact or via input, demonstrating correct physics setup and object separation.

Overall, the testing confirmed that the Blender model is fully functional, visually accurate, and performance-efficient in Unity, making it suitable for direct use in a game environment.

**Detailed testing documentation:**  
[Unity – Model Import & Testing](./Blender/Blender_Testing_Documentation.md)

**In conclusion:**  

The Blender barrel proved to be a high-quality, production-ready game asset. Thanks to clean topology, properly separated planks, full PBR materials, excellent UVs, and effective optimization, it delivers great visual fidelity, full interactivity (physics + explosion effect), and solid performance. It is clearly the superior and most professional solution for game development.

# Dust3D
Dust3D is a free, open-source, node-based 3D modeling tool focused exclusively on rapid creation of very simple props using a parts-and-nodes workflow. It automatically generates basic UVs, supports only a single texture per part, and merges everything into one mesh on FBX export with embedded textures.

**Benefits**
- Extremely fast for very basic, low-poly models
- Lightweight, free, and simple interface
- Automatic UV generation and texture embedding
- Good for quick prototypes where detail is not required

**Limitations**
- Last major update was years ago – the community (and many users) heavily criticize the stagnation and lack of development
- Extremely limited feature set; the newest version (1.0.0-rc.9) removed even more tools and options compared to previous releases in a questionable attempt to "make it simpler"
- Only one texture slot per part – no proper PBR material layering or multi-texturing
- Top and bottom UVs are permanently broken and cannot be fixed inside the program
- Extremely unintuitive controls and node system that feel frustrating even for simple tasks
- Almost no quality tutorials exist; the few available ones are low-quality or outdated
- Realistically suitable only for the most basic shapes – any attempt at more detailed work quickly becomes painful and inefficient

## Model creation
Working in Dust3D felt extremely quick for the very simple barrel shape but rapidly highlighted the software's severe limitations. After importing a reference image, the node-based workflow allowed fast creation of the barrel body by placing and resizing circular nodes, duplicating the half-barrel, using V Flip, and connecting parts. Adjusting properties (Cut Face to hexagon + Subdivided, Deform Thickness/Width 1.75) gave the classic barrel curvature in seconds. Texturing was limited to a single wood color map that required manual "exclude/include" refresh to appear. Creating metal hoops followed the same simple node approach, with alignment tools and duplication used for the remaining bands and inner rim details.

The entire modeling process took only minutes, but the experience quickly turned frustrating due to the lack of proper documentation, unintuitive interface, and the program's deliberate simplification in the latest version (which removed features present in older builds). There is no support for separate objects on export, no advanced UV editing, and no way to create anything beyond the most basic geometry. Overall, Dust3D proved to be excellent for quick-and-dirty simple props, but any attempt at more detailed or professional work leads to immediate frustration.

**Detailed step-by-step documentation:**  
[Dust3D – Model Creation](./Dust3D/Dust3D_Model_Documentation.md)

## Testing in Unity
Testing the Dust3D-created barrel in Unity was straightforward for basic import. The FBX file imported without scale or rotation issues, and embedded textures were unpacked easily. However, the model initially appeared transparent because Dust3D packs materials in a non-standard way – the material had to be unpacked and manually adjusted in Unity to restore proper opacity.

Due to Dust3D's limitations, the top and bottom caps have completely broken UVs. In Unity they displayed only pure white instead of the wood texture. As a workaround, the generated texture was edited in a photo editor (white areas changed to brown/black) to better match the barrel. Because the entire model is exported as **one single mesh**, no per-part material or physics separation is possible.

**Performance metrics:**  

- **SetPass Calls:** 33  
- **Draw Calls:** 38  
- **Batches:** 38  
- **Triangles:** 3.6k  
- **Vertices:** 6.2k  
- **FPS:** 100+  

The model is significantly lighter than the Blender version, but the single-mesh limitation prevents advanced interactions such as exploding the barrel into individual planks or applying different effects to separate parts.

**Detailed testing documentation:**  
[Unity – Model Import & Testing](./Dust3D/Dust3D_Testing_Documentation.md)

**In conclusion:** 

Dust3D is ideal **only** for very simple, quick modeling tasks where it performs well and extremely fast. Anything beyond the most basic shapes is highly not recommended – the severe limitations, outdated development, lack of tutorials, and unintuitive workflow will leave you frustrated.

# Wings3D

Wings3D is a free, open-source subdivision polygon modeler focused primarily on mesh editing through a context-sensitive right-click workflow. It offers a clean and lightweight interface built around vertex, edge, and face selection modes, with tools for cutting, beveling, extruding, and UV unwrapping accessible entirely through its contextual menus.

**Benefits**
- Completely free with no licensing restrictions
- Lightweight and fast — no bloat, launches instantly
- Focused modeling toolset that covers the essentials cleanly
- Multi-part mesh workflow allows proper object separation, enabling physics and explosion effects in-engine
- UV unwrapping is functional and supports multiple projection and remapping methods

**Limitations**
- Development is largely stagnant — the last meaningful update was released roughly a year ago and the program still carries a number of long-standing unresolved issues
- FBX export is broken and unreliable; OBJ/Wavefront is the only dependable export format
- Some vertex and mesh manipulation operations feel unintuitive and frustrating compared to more mature tools
- Familiar to Blender users at first glance but has significantly fewer quality-of-life features and a shallower toolset overall
- UV unwrapping and texture application are functional but noticeably underpowered — the workflow is tedious and the available tools are only just sufficient
- Everything beyond pure modeling — texturing, material management, UV editing — has minimal support and feels like an afterthought

## Model creation

Wings3D initially appears sparse and almost empty, but it is capable of considerably more than it looks — which came as a genuine surprise. The polygon-based workflow using cylinder primitives, vertex cutting, edge loop operations, beveling, and careful per-section extraction allowed the barrel to be built as a properly separated multi-part mesh, something neither Dust3D nor simpler tools can achieve. The context-sensitive right-click menu keeps the interface uncluttered and the available modeling tools are well suited for hard-surface prop work at this level of complexity.

That said, the experience was not without frustration. The program's lack of active development is clearly felt — the FBX exporter is outright broken and forces a switch to OBJ, several vertex manipulation and modification operations behave unexpectedly, and the overall polish is well below what Blender offers. The interface will feel somewhat familiar to anyone coming from Blender, but the absence of many quality-of-life features makes the transition feel like a step backward rather than a lateral move. UV unwrapping and texture assignment work, but the workflow is cumbersome, poorly documented, and the available tooling is barely sufficient for PBR asset preparation. Wings3D occupies an interesting middle ground — more capable than Dust3D, but clearly less powerful and refined than Blender — and it shows.

**Detailed step-by-step documentation:**  
[Wings3D – Model Creation](./Wings3D/Wings3D_Model_Documentation.md)

## Testing in Unity

Testing the Wings3D-created barrel in Unity went smoothly once both the `.obj` and `.mtl` files were imported together. Unlike the single-mesh Dust3D export, the Wings3D barrel arrived in Unity as a properly structured multi-part hierarchy, with each plank and hoop as its own individual mesh object. This made it possible to assign separate colliders to every child object and attach a Barrel Explode script to the root, enabling a fully physics-driven plank-separation effect on impact — a significant gameplay advantage.

Initial material setup required manual adjustment: the extracted metal and wood materials needed their Metallic and Smoothness values set by hand, and Normal Maps had to be assigned manually, as OBJ export does not carry PBR data. Scale also required correction, as the imported model was significantly oversized and had to be uniformly scaled down to 0.3 to match the other barrels in the scene.

**Performance metrics:**

- **SetPass Calls:** 30
- **Draw Calls:** 236
- **Batches:** 236
- **Triangles:** 21.5k
- **Vertices:** 20.8k
- **FPS:** 100+

The model ran at a stable 100+ FPS throughout all tests. The draw call count is substantially higher than the Dust3D version due to each separated part being its own draw call, but this is the direct trade-off for enabling full per-plank physics and the explosion interaction. Triangle count is comparable to the Blender version, reflecting a similar level of geometric detail.

**Detailed testing documentation:**  
[Unity – Model Import & Testing](./Wings3D/Wings3D_Testing_Documentation.md)

**In conclusion:**

Wings3D sits comfortably in the middle of the compared tools. It is significantly more capable than Dust3D and produces a properly separated, interactive multi-part model that supports advanced physics behavior in Unity. However, it falls noticeably short of Blender in terms of workflow efficiency, quality-of-life features, PBR texturing support, and overall polish. It is a reasonable choice for straightforward hard-surface prop modeling when Blender is not an option, but its stagnant development, broken FBX export, and underpowered texturing pipeline make it difficult to recommend as a primary tool for serious game asset production.

**Here is the completed Comparison Summary section only:**

---

# Comparison Summary

After creating the same wooden barrel asset in all three tools and thoroughly testing them in Unity (HDRP), clear differences emerged in workflow efficiency, asset quality, and suitability for real game development.

| Aspect                           | Blender                                      | Dust3D                                              | Wings3D                                              |
|----------------------------------|----------------------------------------------|-----------------------------------------------------|------------------------------------------------------|
| Price / License                  | Free & Open Source                           | Free & Open Source                                  | Free & Open Source                                   |
| Learning Curve                   | Steep at first, then very fast               | Extremely steep and frustrating                     | Moderate (familiar to Blender users)                 |
| Modeling Workflow                | Excellent, intuitive, non-destructive        | Extremely fast for basic shapes, very limited       | Functional                                           |
| PBR Texturing Workflow           | Excellent (full node support + add-ons)      | Extremely limited (single texture only)             | Underpowered and tedious                             |
| UV Unwrapping                    | Powerful and flexible                        | Automatic but broken on top/bottom                  | Functional                                           |
| Polygon Reduction / Optimization | Strong tools (Decimate, Limited Dissolve)    | None                                                | Minimal                                              |
| Multi-part / Separated Mesh      | Excellent                                    | Not possible (single merged mesh only)              | Good                                                 |
| Export to Unity                  | Seamless FBX                                 | Problematic (transparency, broken UVs)              | Works via OBJ, (FBX broken)                          |
| Performance in Unity             | 21.1k tris, well optimized                   | 3.6k tris, lightest but very limited                | 21.5k tris, well optimized                           |
| Physics / Explosion Support      | Full support                                 | Not possible (single mesh)                          | Full support                                         |
| Overall Suitability for Games    | Excellent                                    | Only for very basic prototypes                      | Acceptable                                           |

### Final Conclusions and Recommendations

**Blender** is the clear winner in this comparison. It offers the best balance of power, flexibility, and professional-grade results. The workflow becomes highly efficient once the initial learning curve is overcome, and it produces clean, optimized, fully interactive game-ready assets with proper PBR materials. For anyone serious about game asset creation, **Blender is the strongest recommendation** — especially since it is completely free as well.

**Wings3D** sits in the middle. It successfully created a multi-part barrel that supports physics and explosion effects in Unity, making it noticeably more useful than Dust3D for gameplay purposes. However, its stagnant development, broken FBX export, and weak texturing tools make it feel outdated. It can be used as a secondary tool when you need a lightweight modeling experience, but it is not recommended as a primary tool for game development.

**Dust3D** performed the worst for this type of asset. While it is extremely fast for very crude, low-detail props, its severe limitations (single mesh, single texture, broken UVs, outdated development) make it unsuitable for anything beyond the most basic prototyping. The lack of proper PBR support and inability to create separated meshes severely limits its usefulness in real game projects.

**Final Recommendation:**

- **Best choice overall**: **Blender** — Use this for all serious game asset creation.
- **Only consider Wings3D** if you specifically need a very lightweight, right-click-focused modeling experience and can live with its limitations.
- **Avoid Dust3D** for barrel-style props or any detailed work.

For indie developers and students working on games like *Barrelbound*, **Blender** remains the best investment of time and produces the highest quality results.

# Repository Structure
```
.
├── Barrelbound/                  # Unity Game made to test the created game assets
|   ├── Assets
|   ├── Packages
|   ├── ProjectSettings
|   └── UserSettings
├── Blender/
│   ├── Images
│   ├── Project and Model         # Exported .FBX (without embedded textures) Model and the .blend file
│   ├── Blender_Model_Documentation.md
│   └── Blender_Testing_Documentation.md
├── Dust3D/
│   ├── Images
│   ├── Project and Model         # Exported .FBX Model and the .ds3 file
│   ├── Dust3D_Model_Documentation.md
│   └── Dust3D_Testing_Documentation.md
├── Textures/                     # Textures used in all models
|   ├── Metal
|   └── Wood
├── UnityTesting/                 # Testing Scene, Models, Scripts etc.
|   ├── Assets
|   ├── Packages
|   ├── ProjectSettings
|   └── UserSettings
├── Wings3D/
│   ├── Images
│   ├── Project and Model         # Exported .OBJ with .MTL Model and the .wings file
│   ├── Wings3D_Model_Documentation.md
│   └── Wings3D_Testing_Documentation.md
├── LICENSE
└── README.md
```
