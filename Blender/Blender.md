# 3D Modeling in Games – Model Creation Documentation

## Chapter 1: Creating the Barrel Lid in Blender

The barrel lid (the top wooden cover) serves as the foundation for the entire barrel model. This chapter provides a complete, reproducible step-by-step guide to modeling, detailing, separating, and texturing the lid using Blender. The process focuses on clean topology, realistic plank structure, and professional PBR texturing.

All steps were performed with **Metric** units (millimeters) for game-ready scale.

### 1. Adding the Base Circle
In **Object Mode**, press **Shift + A** → **Mesh** → **Circle**.  
This creates a perfect circular base with 32 vertices – ideal starting topology for a round wooden lid.

<table>
<tr><th width="100%">Adding the base circle</th></tr>
<tr><td><img src="Images/Blender_step1.png" style="width:100%; height:auto;"></td></tr>
</table>

**Tip:** Switch to **Top Orthographic** view (Numpad 7) and enable **X-Ray** (Alt + Z) for better visibility during early modeling.

### 2. Entering Edit Mode and Selecting Vertices
Press **Tab** to enter **Edit Mode**.  
Press **1** to switch to **Vertex Select** mode.  
Select two adjacent vertices (hold **Shift** or drag with the selection tool).

<table>
<tr><th width="100%">Entering Edit Mode and selecting vertices</th></tr>
<tr><td><img src="Images/Blender_step2.png" style="width:100%; height:auto;"></td></tr>
</table>

### 3. Connecting the First Edge
With the two vertices selected, press **F** to create an edge. This forms the foundation of the plank pattern.

<table>
<tr><th width="100%">Connecting the first edge</th></tr>
<tr><td><img src="Images/Blender_step3.png" style="width:100%; height:auto;"></td></tr>
</table>

### 4. Building the Plank Pattern
Repeat the edge-creation process (select two vertices → **F**) across the circle to form the desired radial plank layout typical for a wooden barrel lid.

<table>
<tr><th width="100%">Building the plank pattern</th></tr>
<tr><td><img src="Images/Blender_step4.png" style="width:100%; height:auto;"></td></tr>
</table>

### 5. Filling the Faces
Press **A** to select all vertices.  
Press **F** to fill the faces.

<table>
<tr><th width="100%">Filling the faces</th></tr>
<tr><td><img src="Images/Blender_step5.png" style="width:100%; height:auto;"></td></tr>
</table>

**Result:** A solid flat disc ready for thickness.

### 6. Adding the Solidify Modifier
In **Object Mode**, go to the **Modifier Properties** panel → **Add Modifier** → **Generate** → **Solidify**.

<table>
<tr><th width="100%">Adding the Solidify modifier</th></tr>
<tr><td><img src="Images/Blender_step6.png" style="width:100%; height:auto;"></td></tr>
</table>

### 7. Setting Thickness
Set **Thickness** to **0.05 mm** (very thin for a realistic lid).  
Leave **Offset** at -1.000 and enable **Fill Rim**.

<table>
<tr><th width="100%">Solidify modifier settings</th></tr>
<tr><td><img src="Images/Blender_step7.png" style="width:100%; height:auto;"></td></tr>
</table>

### 8. Applying the Modifier
Return to **Object Mode**.  
In the modifier panel, click the dropdown arrow next to **Solidify** → **Apply**.

<table>
<tr><th width="100%">Applying the Solidify modifier</th></tr>
<tr><td><img src="Images/Blender_step8.png" style="width:100%; height:auto;"></td></tr>
</table>

**Result:** The lid now has real geometry thickness.

<table>
<tr><th width="100%">Lid after applying Solidify</th></tr>
<tr><td><img src="Images/Blender_step9.png" style="width:100%; height:auto;"></td></tr>
</table>

### 9. Adding Bevel Detail (Edges)
Switch to **Edge Select** mode (**2**).  
Select all outer and inner radial edges you want to bevel.  
Press **Ctrl + B** (Bevel tool).

<table>
<tr><th width="100%">Activating Bevel tool</th></tr>
<tr><td><img src="Images/Blender_step10.png" style="width:100%; height:auto;"></td></tr>
</table>

Drag the yellow handle to create the bevel. Release and open the **Bevel** panel in the bottom-left corner.

<table>
<tr><th width="100%">Bevel applied</th></tr>
<tr><td><img src="Images/Blender_step11.png" style="width:100%; height:auto;"></td></tr>
</table>

Set:
- **Width Type**: Offset
- **Width**: 0.01 mm
- **Segments**: 1
- **Profile Shape**: 0.500
- **Profile Type**: Superellipse

<table>
<tr><th width="100%">Precise Bevel settings</th></tr>
<tr><td><img src="Images/Blender_step12.png" style="width:100%; height:auto;"></td></tr>
</table>

### 10. Removing Inner Faces
Switch to **Face Select** mode (**3**).  
Select all newly created inner faces from the bevel.  
Press **X** → **Faces**.

<table>
<tr><th width="100%">Deleting inner faces</th></tr>
<tr><td><img src="Images/Blender_step13.png" style="width:100%; height:auto;"></td></tr>
</table>

**Result:** Clean plank separation with beveled edges.

### 11. Separating Planks for Texturing
Select one plank section (face loop).  
Press **P** → **Selection** to separate into a new object.  
Repeat for every plank.

<table>
<tr><th width="50%">Separating by selection</th><th width="50%">Multiple separated objects in Outliner</th></tr>
<tr>
<td><img src="Images/Blender_step14.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Blender_step18x.png" style="width:100%; height:auto;"></td>
</tr>
</table>

### 12. Closing Missing Edges
In **Edit Mode** (per object), select the three missing edge pairs (top, middle, bottom) one by one and press **F**.  
Do **not** select everything at once – it would create incorrect faces.

<table>
<tr><th width="100%">Connecting missing edges</th></tr>
<tr><td><img src="Images/Blender_step15.png" style="width:100%; height:auto;"></td></tr>
</table>

### 13. Creating the Wood Material (on one object only)
Select **one** lid object.  
In the **Material Properties** panel, click **New**.  
Rename the material to **Wood**.

<table>
<tr><th width="50%">Creating material slot</th><th width="50%">Renaming the material</th></tr>
<tr>
<td><img src="Images/Blender_step17.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Blender_step23.png" style="width:100%; height:auto;"></td>
</tr>
</table>

### 14. Preparing Node Wrangler Add-on
Go to **Edit** → **Preferences** → **Add-ons**.  
Search for **Node Wrangler** and enable it.

<table>
<tr><th width="100%">Enabling Node Wrangler</th></tr>
<tr><td><img src="Images/Blender_step20.png" style="width:100%; height:auto;"></td></tr>
</table>

**Tip:** This add-on is essential for fast PBR texture setup.

### 15. Switching to Shading Workspace
Change the workspace to **Shading** (top tab).

<table>
<tr><th width="100%">Switching to Shading workspace</th></tr>
<tr><td><img src="Images/Blender_step19.png" style="width:100%; height:auto;"></td></tr>
</table>

### 16. Importing PBR Textures (Wood035)
Select the **Principled BSDF** node.  
Press **Ctrl + Shift + T**.  
Navigate to the unpacked `Wood035` folder from [ambientcg.com](https://ambientcg.com/view?id=Wood035) and select all texture files.  
Click **Principled Texture Setup**.

<table>
<tr><th width="50%">Texture file selection</th><th width="50%">Automatic node setup</th></tr>
<tr>
<td><img src="Images/Blender_step21.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Blender_step22.png" style="width:100%; height:auto;"></td>
</tr>
</table>

### 17. Material Application to All Objects
Now apply the material to **all** lid objects:  
1. Select **all** lid objects (keep the original object with the material as **active** – orange outline).  
2. Press **Ctrl + L** → **Link Materials**.

<table>
<tr><th width="100%">Linking materials to all objects</th></tr>
<tr><td><img src="Images/Blender_step23x.png" style="width:100%; height:auto;"></td></tr>
</table>

The lid should now appear brown (raw texture).

<table>
<tr><th width="100%">Material applied – raw preview</th></tr>
<tr><td><img src="Images/Blender_step24.png" style="width:100%; height:auto;"></td></tr>
</table>

### 18. Fixing UV Mapping
Select all objects → **Edit Mode**.  
Right-click → **UV** → **Unwrap Faces** → **Smart UV Project**.

<table>
<tr><th width="100%">Choosing Smart UV Project</th></tr>
<tr><td><img src="Images/Blender_step25.png" style="width:100%; height:auto;"></td></tr>
</table>

Recommended settings:  
- **Angle Limit**: 89°  
- **Rotation Method**: Axis-aligned (Horizontal)  
- **Margin Method**: Scaled  
- **Island Margin**: 0.000  
- **Correct Aspect**: checked

<table>
<tr><th width="100%">Smart UV Project operator panel</th></tr>
<tr><td><img src="Images/Blender_step25x.png" style="width:100%; height:auto;"></td></tr>
</table>

Click **Unwrap**.

**Result:** Perfectly aligned wood grain.

<table>
<tr><th width="100%">Final textured lid</th></tr>
<tr><td><img src="Images/Blender_step26.png" style="width:100%; height:auto;"></td></tr>
</table>

### 19. Organizing the Project
Create a new Collection named **BarrelLid**.  
Move all lid objects into it.  
Hide the collection with the eye icon (we will use it later).

<table>
<tr><th width="100%">BarrelLid collection in Outliner</th></tr>
<tr><td><img src="Images/Blender_step27.png" style="width:100%; height:auto;"></td></tr>
</table>

**Chapter complete.**  
The barrel lid is now fully modeled, separated, UV-unwrapped, and textured with high-quality PBR wood material – ready for the barrel body in the next chapter.
