# 3D Modeling in Games – Bachelor's Thesis Documentation

## Chapter 1: Creating the Barrel Lid in Blender

The barrel lid (the top wooden cover) serves as the foundation for the entire barrel model. This chapter provides a complete, reproducible step-by-step guide to modeling, detailing, separating, and texturing the lid using Blender 4.x. The process focuses on clean topology, realistic plank structure, and professional PBR texturing.

All steps were performed with **Metric** units (millimeters) for game-ready scale.

### 1. Adding the Base Circle
In **Object Mode**, press **Shift + A** → **Mesh** → **Circle**.  
This creates a perfect circular base with 32 vertices – ideal starting topology for a round wooden lid.

![Step 1: Adding the base circle](Images/Blender_step1.png)

**Tip:** Switch to **Top Orthographic** view (Numpad 7) and enable **X-Ray** (Alt + Z) for better visibility during early modeling.

### 2. Entering Edit Mode and Selecting Vertices
Press **Tab** to enter **Edit Mode**.  
Press **1** to switch to **Vertex Select** mode.  
Select two adjacent vertices (hold **Shift** or drag with the selection tool).

![Step 2: Vertex selection](Images/Blender_step2.png)

### 3. Connecting the First Edge
With the two vertices selected, press **F** to create an edge. This forms the foundation of the plank pattern.

![Step 3: First edge connection](Images/Blender_step3.png)

### 4. Building the Plank Pattern
Repeat the edge-creation process (select two vertices → **F**) across the circle to form the desired radial plank layout typical for a wooden barrel lid.

![Step 4: Building the plank pattern](Images/Blender_step4.png)

### 5. Filling the Faces
Press **A** to select all vertices.  
Press **F** to fill the faces.

![Step 5: Filling the faces](Images/Blender_step5.png)

**Result:** A solid flat disc ready for thickness.

### 6. Adding the Solidify Modifier
In **Object Mode**, go to the **Modifier Properties** panel → **Add Modifier** → **Generate** → **Solidify**.

![Step 6: Adding Solidify modifier](Images/Blender_step6.png)

### 7. Setting Thickness
Set **Thickness** to **0.05 mm** (very thin for a realistic lid).  
Leave **Offset** at -1.000 and enable **Fill Rim**.

![Step 7: Solidify settings](Images/Blender_step7.png)

### 8. Applying the Modifier
Return to **Object Mode**.  
In the modifier panel, click the dropdown arrow next to **Solidify** → **Apply**.

![Step 8: Applying the Solidify modifier](Images/Blender_step8.png)

**Result:** The lid now has real geometry thickness.

![Step 9: Lid after Solidify](Images/Blender_step9.png)

### 9. Adding Bevel Detail (Edges)
Switch to **Edge Select** mode (**2**).  
Select all outer and inner radial edges you want to bevel.  
Press **Ctrl + B** (Bevel tool).

![Step 10: Activating Bevel tool](Images/Blender_step10.png)

Drag the yellow handle to create the bevel. Release and open the **Bevel** panel in the bottom-left corner.

Set:
- **Width Type**: Offset
- **Width**: 0.01 mm
- **Segments**: 1
- **Profile Shape**: 0.500
- **Profile Type**: Superellipse

![Step 11: Bevel applied](Images/Blender_step11.png)

![Step 12: Precise Bevel settings](Images/Blender_step12.png)

### 10. Removing Inner Faces
Switch to **Face Select** mode (**3**).  
Select all newly created inner faces from the bevel.  
Press **X** → **Faces**.

![Step 13: Deleting inner faces](Images/Blender_step13.png)

**Result:** Clean plank separation with beveled edges.

### 11. Separating Planks for Texturing
Select one plank section (face loop).  
Press **P** → **Selection** to separate into a new object.  
Repeat for every plank.

![Step 14: Separating by selection](Images/Blender_step14.png)

![Step 15: Multiple separated objects in Outliner](Images/Blender_step17.png)

### 12. Closing Missing Edges
In **Edit Mode** (per object), select the three missing edge pairs (top, middle, bottom) one by one and press **F**.  
Do **not** select everything at once – it would create incorrect faces.

![Step 16: Connecting missing edges](Images/Blender_step15.png)

### 13. Creating and Assigning the Wood Material
Select all lid objects (**A**).  
In the **Material Properties** panel, click **New** and rename the material to **Wood**.

![Step 17: Adding new material](Images/Blender_step23.png)

### 14. Preparing Node Wrangler Add-on
Go to **Edit** → **Preferences** → **Add-ons**.  
Search for **Node Wrangler** and enable it.

![Step 18: Enabling Node Wrangler](Images/Blender_step20.png)

**Tip:** This add-on is essential for fast PBR texture setup.

### 15. Switching to Shading Workspace
Change the workspace to **Shading** (top tab).

![Step 19: Shading workspace](Images/Blender_step19.png)

### 16. Importing PBR Textures (Wood035)
Select the **Principled BSDF** node.  
Press **Ctrl + Shift + T**.  
Navigate to the unpacked `Wood035` folder from [ambientcg.com](https://ambientcg.com/view?id=Wood035) and select all texture files.  
Click **Principled Texture Setup**.

![Step 20: Texture file selection](Images/Blender_step21.png)

![Step 21: Automatic node setup](Images/Blender_step22.png)

### 17. Material Preview
The lid should now appear brown (raw texture).

![Step 22: Material applied before UV fix](Images/Blender_step24.png)

### 18. Fixing UV Mapping
Select all objects → **Edit Mode**.  
Right-click → **UV** → **Unwrap Faces** → **Smart UV Project**.  
In the operator panel:
- **Angle Limit**: 89°
- **Rotation Method**: Axis-aligned (Horizontal)

![Step 23: Smart UV Project](Images/Blender_step25.png)

**Result:** Perfectly aligned wood grain.

![Step 24: Final textured lid](Images/Blender_step16.png)

### 19. Organizing the Project
Create a new Collection named **BarrelLid**.  
Move all lid objects into it.  
Hide the collection with the eye icon (we will use it later).

![Step 25: BarrelLid collection](Images/Blender_step27.png)

![Step 26: Final rendered view of the completed barrel lid](Images/Blender_step26.png)

**Chapter complete.** The barrel lid is now fully modeled, separated, UV-unwrapped, and textured with high-quality PBR wood material – ready for the barrel body in the next chapter.

---
