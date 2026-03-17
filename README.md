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
[Blender – Model Creation Documentation](./Blender/Blender_Model_Documentation.md)

## Testing in Unity

Placeholder text

**Detailed testing documentation:**  
[Unity – Model Import & Testing](./Blender/Blender_Testing_Documentation.md) *(placeholder – in preparation)*

# Dust3D

Placeholder text

## Model creation

Placeholder text

**Detailed step-by-step documentation:**  
[Dust3D – Model Creation Documentation](./Dust3D/Dust3D_Model_Documentation.md) *(placeholder – in preparation)*

## Testing in Unity

Placeholder text

**Detailed testing documentation:**  
[Unity – Model Import & Testing](./Dust3D/Dust3D_Testing_Documentation.md) *(placeholder – in preparation)*

# Wings3D

Placeholder text

## Model creation

Placeholder text

**Detailed step-by-step documentation:**  
[Wings3D – Model Creation Documentation](./Wings3D/Wings3D_Model_Documentation.md) *(placeholder – in preparation)*

## Testing in Unity

Placeholder text

**Detailed testing documentation:**  
[Unity – Model Import & Testing](./Wings3D/Wings3D_Testing_Documentation.md) *(placeholder – in preparation)*

# Maya

Placeholder text

## Model creation

Placeholder text

**Detailed step-by-step documentation:**  
[Maya – Model Creation Documentation](./Maya/Maya_Model_Documentation.md) *(placeholder – in preparation)*

## Testing in Unity

Placeholder text

**Detailed testing documentation:**  
[Unity – Model Import & Testing](./Maya/Maya_Testing_Documentation.md) *(placeholder – in preparation)*

# Comparison Summary

Placeholder text

| Aspect                          | Blender                          | Dust3D                           | Wings3D                          | Maya                             |
|---------------------------------|----------------------------------|----------------------------------|----------------------------------|----------------------------------|
| Price / License                 | Free & Open Source               | [TBD]                            | [TBD]                            | [TBD]                            |
| Learning Curve                  | Steep at first, then fast        | [TBD]                            | [TBD]                            | [TBD]                            |
| Modeling Workflow               | Intuitive and satisfying         | [TBD]                            | [TBD]                            | [TBD]                            |
| PBR Texturing Workflow          | Easy to work with, add-ons (Node Wrangler) | [TBD]                  | [TBD]                            | [TBD]                            |
| Polygon Reduction Tools         | Are available (Limited Dissolve, etc.) | [TBD]                    | [TBD]                            | [TBD]                            |
| Unity Import Experience         | Seamless                         | [TBD]                            | [TBD]                            | [TBD]                            |

**Final conclusions and recommendations** will be added once all tools are compared.

# Repository Structure

```
.
├── Blender/
│   ├── Images                              # Images included in the documentations
│   ├── Models                              # Exported FBX Model and the .blend file
│   ├── Textures                            # Textures used
│   ├── Blender_Model_Documentation.md      # Process of creating the model
│   └── Blender_Testing_Documentation.md    # Process of testing the model in Unity
├── Dust3D/
├── Maya/
├── Wings3D/
├── LICENSE                                 # The License
└── README.md                               # This File
```
