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

To further test interactivity, simple scripts were introduced to rotate the camera and lighting around the object, as well as to simulate physics-based behavior. The barrel was equipped with colliders and a rigidbody setup, allowing it to roll naturally and respond to the environment. Additionally, a custom script enabled the barrel to “explode” into separate parts either on impact or via input, demonstrating correct physics setup and object separation.

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
- Extremely limited feature set; the newest version (1.0.0-rc.9) removed even more tools and options compared to previous releases in a questionable attempt to “make it simpler”
- Only one texture slot per part – no proper PBR material layering or multi-texturing
- Top and bottom UVs are permanently broken and cannot be fixed inside the program
- Extremely unintuitive controls and node system that feel frustrating even for simple tasks
- Almost no quality tutorials exist; the few available ones are low-quality or outdated
- Realistically suitable only for the most basic shapes – any attempt at more detailed work quickly becomes painful and inefficient

## Model creation
Working in Dust3D felt extremely quick for the very simple barrel shape but rapidly highlighted the software’s severe limitations. After importing a reference image, the node-based workflow allowed fast creation of the barrel body by placing and resizing circular nodes, duplicating the half-barrel, using V Flip, and connecting parts. Adjusting properties (Cut Face to hexagon + Subdivided, Deform Thickness/Width 1.75) gave the classic barrel curvature in seconds. Texturing was limited to a single wood color map that required manual “exclude/include” refresh to appear. Creating metal hoops followed the same simple node approach, with alignment tools and duplication used for the remaining bands and inner rim details.

The entire modeling process took only minutes, but the experience quickly turned frustrating due to the lack of proper documentation, unintuitive interface, and the program’s deliberate simplification in the latest version (which removed features present in older builds). There is no support for separate objects on export, no advanced UV editing, and no way to create anything beyond the most basic geometry. Overall, Dust3D proved to be excellent for quick-and-dirty simple props, but any attempt at more detailed or professional work leads to immediate frustration.

**Detailed step-by-step documentation:**  
[Dust3D – Model Creation](./Dust3D/Dust3D_Model_Documentation.md)

## Testing in Unity
Testing the Dust3D-created barrel in Unity was straightforward for basic import. The FBX file imported without scale or rotation issues, and embedded textures were unpacked easily. However, the model initially appeared transparent because Dust3D packs materials in a non-standard way – the material had to be unpacked and manually adjusted in Unity to restore proper opacity.

Due to Dust3D’s limitations, the top and bottom caps have completely broken UVs. In Unity they displayed only pure white instead of the wood texture. As a workaround, the generated texture was edited in a photo editor (white areas changed to brown/black) to better match the barrel. Because the entire model is exported as **one single mesh**, no per-part material or physics separation is possible.

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

Placeholder text

## Model creation

Placeholder text

**Detailed step-by-step documentation:**  
[Wings3D – Model Creation](./Wings3D/Wings3D_Model_Documentation.md) *(placeholder – in preparation)*

## Testing in Unity

Placeholder text

**Detailed testing documentation:**  
[Unity – Model Import & Testing](./Wings3D/Wings3D_Testing_Documentation.md) *(placeholder – in preparation)*

# Maya

Placeholder text

## Model creation

Placeholder text

**Detailed step-by-step documentation:**  
[Maya – Model Creation](./Maya/Maya_Model_Documentation.md) *(placeholder – in preparation)*

## Testing in Unity

Placeholder text

**Detailed testing documentation:**  
[Unity – Model Import & Testing](./Maya/Maya_Testing_Documentation.md) *(placeholder – in preparation)*

# Comparison Summary

Placeholder text

| Aspect                    | Blender                                      | Dust3D                                                                 | Wings3D | Maya |
|---------------------------|----------------------------------------------|------------------------------------------------------------------------|---------|------|
| Price / License           | Free & Open Source                           | Free & Open Source                                                     | [TBD]   | [TBD] |
| Learning Curve            | Steep at first, then fast                    | Extremely steep and frustrating (unintuitive node system)             | [TBD]   | [TBD] |
| Modeling Workflow         | Intuitive and satisfying                     | Extremely fast for simple shapes, but very limited                     | [TBD]   | [TBD] |
| PBR Texturing Workflow    | Easy to work with, add-ons (Node Wrangler)   | Extremely limited (only one texture per part, no real PBR)            | [TBD]   | [TBD] |
| Polygon Reduction Tools   | Are available (Limited Dissolve, etc.)       | None (automatic merging only)                                          | [TBD]   | [TBD] |
| Unity Import Experience   | Seamless                                     | Works but problematic (transparency fix needed, broken UVs on top/bottom, single mesh only) | [TBD]   | [TBD] |

**Final conclusions and recommendations** will be added once all tools are compared.

# Repository Structure

```
.
├── Blender/
│   ├── Images                              # Images included in the documentations
│   ├── Project and Model                   # Exported FBX Model and the .blend file
│   ├── Blender_Model_Documentation.md      # Process of creating the model
│   └── Blender_Testing_Documentation.md    # Process of testing the model in Unity
├── Dust3D/
│   ├── Images                              # Images included in the documentations
│   ├── Project and Model                   # Exported FBX Model and the .ds3 file
│   ├── Dust3D_Model_Documentation.md       # Process of creating the model
│   └── Dust3D_Testing_Documentation.md     # Process of testing the model in Unity
├── Maya/
├── Textures/                               # Textures used in all models
|   ├── Metal
|   └── Wood
├── UnityTesting/                           # Testing Scene, scripts etc.
|   ├── Assets/
|       ├── Models                          # Only .meta file (Import needed)
|       └── Textures                        # Only .meta files (Import needed)
|   ├── Packages
|   └── ProjectSettings
├── Wings3D/
├── LICENSE
└── README.md
```
