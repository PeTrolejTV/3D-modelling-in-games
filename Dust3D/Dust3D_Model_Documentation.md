# 3D Modeling in Games – Model Creation Documentation

## Chapter 1: Creating the Barrel in Dust3D

The barrel is a classic low-poly game prop consisting of a wooden body with metal hoops and subtle lid details. This chapter provides a complete, reproducible step-by-step guide to modeling the entire barrel using **Dust3D** (version 1.0.0-rc.9). Dust3D excels at rapid node-based creation of simple shapes but automatically merges all parts on FBX export, so we keep the workflow straightforward and focused on clean symmetry, basic texturing, and quick iteration.

All steps use the built-in node system for the barrel body, duplication for symmetry, and simple property adjustments. The reference image ensures the final model matches real-world proportions.

### 1. Launching Dust3D and Initial Workspace
Open Dust3D 1.0.0-rc.9. You will see the default dark workspace with an empty canvas and the **Parts** panel on the right.

<table>
<tr><th width="100%">Initial Dust3D workspace</th></tr>
<tr><td><img src="Images/Dust3D_step1.png" style="width:100%; height:auto;"></td></tr>
</table>

**Tip:** The interface is minimalistic – all modeling happens via nodes on the canvas and the Properties panel.

### 2. Importing the Reference Image
It is highly recommended to load a reference sheet showing the barrel from multiple angles. Go to **File** → **Change Background Image...**

<table>
<tr><th width="100%">Changing background image</th></tr>
<tr><td><img src="Images/Dust3D_step2.png" style="width:100%; height:auto;"></td></tr>
</table>

### 3. Selecting the Reference File
Browse to your reference image (`Barrel_Reference.jpg`) and click **Open**.

<table>
<tr><th width="100%">Selecting reference image</th></tr>
<tr><td><img src="Images/Dust3D_step3.png" style="width:100%; height:auto;"></td></tr>
</table>

### 4. Reference Image Loaded
The background now displays the barrel reference, helping us match proportions throughout the process.

<table>
<tr><th width="100%">Reference image loaded on canvas</th></tr>
<tr><td><img src="Images/Dust3D_step4.png" style="width:100%; height:auto;"></td></tr>
</table>

**Chapter 1 complete.**  
The workspace is ready. We will now build the wooden barrel body using nodes.

## Chapter 2: Modeling the Barrel Body

### 1. Adding the First Node
To start the barrel body, click the **+** icon (or press **A**, or right-click → **Add**).

<table>
<tr><th width="50%">Add... button</th><th width="50%">Add node to canvas tooltip</th></tr>
<tr>
<td><img src="Images/Dust3D_step5.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Dust3D_step6.png" style="width:100%; height:auto;"></td>
</tr>
</table>

### 2. Placing the Base Node
A circular node appears. Scroll the mouse wheel to resize it (this defines the diameter of that section). Left-click to place it.

<table>
<tr><th width="100%">Base circular node placed</th></tr>
<tr><td><img src="Images/Dust3D_step7.png" style="width:100%; height:auto;"></td></tr>
</table>

### 3. Building the Half-Barrel Shape
Continue adding and resizing nodes upward. Make upper nodes larger to create the classic barrel bulge. The model preview updates live.

<table>
<tr><th width="50%">Initial model forming (cube-like)</th><th width="50%">Half-barrel shape with bulge</th></tr>
<tr>
<td><img src="Images/Dust3D_step8.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Dust3D_step9.png" style="width:100%; height:auto;"></td>
</tr>
</table>

### 4. Axis Locking for Precise Movement
Use the axis lockers (X/Y/Z) in the top-left corner to constrain movement. This is especially useful when aligning nodes along a single axis.

<table>
<tr><th width="100%">Y axis locker</th></tr>
<tr><td><img src="Images/Dust3D_step10.png" style="width:100%; height:auto;"></td></tr>
</table>

**Navigation shortcuts (while no node is selected):**  
- Middle mouse button drag = rotate view  
- Mouse wheel = zoom  
- Shift + middle mouse drag = pan

### 5. Duplicating the Half for Symmetry
Select the current object using the **Select them on canvas** button (or click it directly). Press **Ctrl + C** then **Ctrl + V** to duplicate.

<table>
<tr><th width="50%">Selecting the object on canvas</th><th width="50%">Selected object</th></tr>
<tr>
<td><img src="Images/Dust3D_step11.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Dust3D_step12.png" style="width:100%; height:auto;"></td>
</tr>
</table>

### 6. Hiding One Half
To avoid accidental selection while working on the copy, select the original and click **Hide them on canvas**.

<table>
<tr><th width="100%">Hiding the original half</th></tr>
<tr><td><img src="Images/Dust3D_step13.png" style="width:100%; height:auto;"></td></tr>
</table>

### 7. V Flip on the Duplicate
Select the duplicate, right-click any node → **V Flip**.

<table>
<tr><th width="100%">V Flip context menu</th></tr>
<tr><td><img src="Images/Dust3D_step14.png" style="width:100%; height:auto;"></td></tr>
</table>

### 8. Aligning the Two Halves
Select the green nodes on the flipped half, disable Z-axis locking, and drag upward until the orange rings align at the barrel’s center (where hoops will sit).

<table>
<tr><th width="100%">Pulling the flipped half into position</th></tr>
<tr><td><img src="Images/Dust3D_step15.png" style="width:100%; height:auto;"></td></tr>
</table>

### 9. Showing the Hidden Half and Connecting
Show the hidden half again, then **Ctrl + left-click** the two nodes you want to join. Right-click one → **Connect**.

<table>
<tr><th width="50%">Showing the hidden half</th><th width="50%">Connecting the two halves</th></tr>
<tr>
<td><img src="Images/Dust3D_step16.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Dust3D_step17.png" style="width:100%; height:auto;"></td>
</tr>
</table>

The barrel body is now one connected piece (still cubic).

<table>
<tr><th width="100%">Fully connected barrel body (cubic shape)</th></tr>
<tr><td><img src="Images/Dust3D_step18.png" style="width:100%; height:auto;"></td></tr>
</table>

### 10. Configuring Properties
Select the object and click **Configure properties**.  

<table>
<tr><th width="100%">Opening Configure properties</th></tr>
<tr><td><img src="Images/Dust3D_step19.png" style="width:100%; height:auto;"></td></tr>
</table>

Initial default settings appear.

<table>
<tr><th width="100%">Default Deform settings (Thickness/Width 1.00)</th></tr>
<tr><td><img src="Images/Dust3D_step20.png" style="width:100%; height:auto;"></td></tr>
</table>

### 11. Shaping the Barrel
Change **Cut Face** to the hexagon icon, enable **Subdivided**, and set **Deform** → **Thickness** and **Width** to **1.75**.

<table>
<tr><th width="100%">Final barrel body settings (Thickness/Width 1.75)</th></tr>
<tr><td><img src="Images/Dust3D_step21.png" style="width:100%; height:auto;"></td></tr>
</table>

**Result:** Smooth, realistic barrel curvature.

**Chapter 2 complete.**  
The wooden barrel body is modeled and shaped.

## Chapter 3: Adding Metal Hoops, Texturing, and Details

### 1. Applying Wood Texture to the Body
Click the image icon next to the eraser icon to open **Texture Image**. Select the wood color texture.

<table>
<tr><th width="50%">Texture Image slot (empty)</th><th width="50%">Selecting wood color texture</th></tr>
<tr>
<td><img src="Images/Dust3D_step22.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Dust3D_step23.png" style="width:100%; height:auto;"></td>
</tr>
</table>

The texture may not appear immediately. Click **Exclude them from result generation** then **Include them in result generation** to force a refresh.

<table>
<tr><th width="50%">Exclude from generation</th><th width="50%">Include in generation</th></tr>
<tr>
<td><img src="Images/Dust3D_step24.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Dust3D_step25.png" style="width:100%; height:auto;"></td>
</tr>
</table>

Textured barrel body with a little adjustment to fit the reference image better:

<table>
<tr><th width="50%">Wood texture applied, refreshed and adjusted</th><th width="50%">Barrel body (wireframe toggle with W)</th></tr>
<tr>
<td><img src="Images/Dust3D_step26.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Dust3D_step27.png" style="width:100%; height:auto;"></td>
</tr>
</table>

### 2. Creating the First Metal Hoop
Create two nodes stacked vertically for the hoop base. Use the same **Cut Face** + **Subdivided** settings but switch the texture to metal.

<table>
<tr><th width="50%">Initial hoop creation</th><th width="50%">Changing the hoops settings</th></tr>
<tr>
<td><img src="Images/Dust3D_step28.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Dust3D_step29.png" style="width:100%; height:auto;"></td>
</tr>
</table>

### 3. Aligning the Hoop
Enlarge the hoop and use right-click → **Align To** → **Global Horizontal Center** (and the same for the green axis part).

<table>
<tr><th width="50%">Hoop centered on barrel</th><th width="50%">Align To → Global Horizontal Center</th></tr>
<tr>
<td><img src="Images/Dust3D_step30.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Dust3D_step31.png" style="width:100%; height:auto;"></td>
</tr>
</table>

### 4. Duplicating and Positioning Hoops
Duplicate the hoop (Ctrl + C / V), adjust position, height, and scale to match the reference. Repeat for all hoops.

<table>
<tr><th width="33%">Hoop placed and adjusted</th><th width="33%">Hoop adjusted to better match reference</th><th width="33%">Aligned barrel position to center</th></tr>
<tr>
<td><img src="Images/Dust3D_step32.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Dust3D_step33.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Dust3D_step34.png" style="width:100%; height:auto;"></td>
</tr>
</table>

### 5. Adding Lid-Like Detail (Inner Cut)
Duplicate one hoop, shrink it to fit inside the top/bottom opening, change its property to **Inversion**, and assign the wood texture.

<table>
<tr><th width="50%">Aligned hoop in top opening</th><th width="50%">Inversion property + wood texture for inner rim</th></tr>
<tr>
<td><img src="Images/Dust3D_step35.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Dust3D_step36.png" style="width:100%; height:auto;"></td>
</tr>
</table>

Repeat for the bottom. The barrel now has subtle lid rims.

<table>
<tr><th width="100%">Final barrel with hoops and inner rim details</th></tr>
<tr><td><img src="Images/Dust3D_step37.png" style="width:100%; height:auto;"></td></tr>
</table>

**Chapter 3 complete.**  
The barrel is fully modeled, textured, and detailed.

## Chapter 4: Final Adjustments and Export

### 1. Centering the Entire Model
Ensure the barrel is perfectly centered using **Align To** → **Global Center** if needed.

<table>
<tr><th width="100%">Final centered model</th></tr>
<tr>
<td><img src="Images/Dust3D_step38.png" style="width:100%; height:auto;"></td>
</tr>
</table>

### 2. Exporting as FBX
Go to **File** → **Export as FBX...**

<table>
<tr><th width="100%">Export as FBX menu</th></tr>
<tr><td><img src="Images/Dust3D_step39.png" style="width:100%; height:auto;"></td></tr>
</table>

Name the file (e.g. `Dust3D_Barrel.fbx`) and click **Save**. Dust3D automatically merges everything into a single object and embeds textures – no extra settings required.

<table>
<tr><th width="100%">FBX save dialog</th></tr>
<tr><td><img src="Images/Dust3D_step40.png" style="width:100%; height:auto;"></td></tr>
</table>

**Result:** A clean, game-ready FBX file ready for import into Unity, Unreal Engine, Godot, or any other engine.

**Chapter complete.**  
The barrel is fully modeled, textured with wood and metal PBR materials, and exported. It is production-ready for any game project.

**Documentation end.**  
All chapters are now complete. The full barrel model was created efficiently in Dust3D using its node-based workflow – perfect for quick props where high detail is not required.
