# 3D Modeling in Games

3D modeling has greatly influenced the gaming experience and has become an important aspect of game development. The possibilities are limitless — from modeling characters, props, and environments to entire virtual worlds.

---

## Modeling Tools Comparison

<details>
<summary>Blender</summary>

### Blender Modeling Process

In Blender, the workflow focused on modular construction, separating the barrel lid, body, and metal hoops for easier texturing and optimization.

**Steps**
1. Created base cylinder
2. Added loop cuts for shaping
3. Modeled individual wooden planks
4. Added metal hoops with Solidify Modifier
5. Applied materials and UV unwrapping
6. Optimized geometry with Limited Dissolve

**Screenshots**

![Blender Step](images/blender_step1.png)

**Export Settings**

- Format: FBX  
- Scale: 1.0  
- Triangulated: Yes  

**Full Modeling Documentation:** [Blender Detailed Workflow](Blender.md)

</details>

<details>
<summary>Dust3D</summary>

### Dust3D Modeling Process

Dust3D enables fast low-poly modeling using procedural skeleton-based mesh generation. The workflow included defining base nodes for the barrel, automatically generating the mesh, and fine-tuning proportions for proper scale in Unity.

**Steps**
1. Create barrel skeleton nodes
2. Auto-generate mesh
3. Adjust height, thickness, and curvature
4. Apply UV unwrapping and textures
5. Export FBX for Unity

**Full Modeling Documentation:** [Dust3D Detailed Workflow](Dust3D.md)

</details>

<details>
<summary>Wings3D</summary>

### Wings3D Modeling Process

Wings3D was used for low-poly construction of props, emphasizing clean topology and simplicity.

**Steps**
1. Base cylinder created
2. Extrude and shape planks manually
3. Separate and bevel edges
4. Apply materials manually
5. Export OBJ/FBX for Unity

**Full Modeling Documentation:** [Wings3D Detailed Workflow](Wings3D.md)

</details>

<details>
<summary>Maya</summary>

### Maya Modeling Process

Maya workflow focused on precise control and high-poly detailing for comparison purposes.

**Steps**
1. Base cylinder creation
2. Polygonal modeling of lid and planks
3. Adding hoops and bevels
4. Texturing and UV setup
5. Export FBX with triangulation

**Full Modeling Documentation:** [Maya Detailed Workflow](Maya.md)

</details>

---
