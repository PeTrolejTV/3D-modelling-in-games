# 3D Modeling in Games – Model Creation Documentation

## Chapter 1: Setting Up the Wings3D Workspace

Wings3D is a subdivision modeler that provides a straightforward interface for polygon-based
modeling. This chapter covers the initial workspace setup required before any modeling begins. We will be using the latest version of Wings3D (version 2.4.1).

### 1. Launching Wings3D
Open Wings3D. You will be greeted by a clean but feature-rich interface with a viewport in
the center and a menu bar at the top.

<table>
<tr><th width="100%">Initial Wings3D interface</th></tr>
<tr><td><img src="Images/Wings3D_step1.png" style="width:100%; height:auto;"></td></tr>
</table>

**Tip:** Wings3D uses a context-sensitive right-click menu for most modeling operations —
get comfortable with it early.

### 2. Adding the Outliner
The Outliner allows us to manage materials and object visibility. Go to **Window** → **Outliner**.

<table>
<tr><th width="100%">Window → Outliner menu</th></tr>
<tr><td><img src="Images/Wings3D_step2.png" style="width:100%; height:auto;"></td></tr>
</table>

The Outliner window will appear as a floating panel. Dock it to the side of your workspace
for easy access.

<table>
<tr><th width="100%">Outliner panel docked to the workspace</th></tr>
<tr><td><img src="Images/Wings3D_step3.png" style="width:100%; height:auto;"></td></tr>
</table>

### 3. Adding the Geometry Graph
The Geometry Graph displays all mesh objects in the scene and is essential for organizing a
multi-part model. Go to **Window** → **Geometry Graph**.

<table>
<tr><th width="100%">Window → Geometry Graph menu</th></tr>
<tr><td><img src="Images/Wings3D_step4.png" style="width:100%; height:auto;"></td></tr>
</table>

Drag and dock the Geometry Graph panel alongside the Outliner.

<table>
<tr><th width="100%">Geometry Graph panel docked to the workspace</th></tr>
<tr><td><img src="Images/Wings3D_step5.png" style="width:100%; height:auto;"></td></tr>
</table>

**Chapter 1 complete.**  
The workspace is prepared with both essential panels visible. We will now begin modeling
the barrel lid.

---

## Chapter 2: Modeling the Barrel Lid

### 1. Creating the Lid Cylinder
Right-click in the viewport and choose **Cylinder**, then click the **gear icon** to open
the detailed settings dialog.

<table>
<tr><th width="100%">Right-click → Cylinder → gear icon for detailed settings</th></tr>
<tr><td><img src="Images/Wings3D_step6.png" style="width:100%; height:auto;"></td></tr>
</table>

Set the following values: **Sections: 32**, **Height: 0.05**, and check **Put on Ground**
to place it flush with the ground plane. Confirm with OK.

<table>
<tr><th width="100%">Lid cylinder settings (Sections: 32, Height: 0.05, Put on Ground checked)</th></tr>
<tr><td><img src="Images/Wings3D_step7.png" style="width:100%; height:auto;"></td></tr>
</table>

### 2. Switching to Top View and Vertex Mode
Press **Y** to switch to the top-down orthographic view. Then select **Vertex Selection Mode**
from the toolbar icons at the top of the viewport.

<table>
<tr><th width="100%">Top view (Y) with Vertex Selection Mode active</th></tr>
<tr><td><img src="Images/Wings3D_step8.png" style="width:100%; height:auto;"></td></tr>
</table>

### 3. Selecting and Connecting the First Pair of Vertices
Click and drag to rubber-band select two vertices on opposite sides of the lid.

<table>
<tr><th width="100%">Two vertices selected by dragging</th></tr>
<tr><td><img src="Images/Wings3D_step9.png" style="width:100%; height:auto;"></td></tr>
</table>

Press **C** to **Connect** these two vertices with a new edge.

<table>
<tr><th width="100%">Vertices connected with C</th></tr>
<tr><td><img src="Images/Wings3D_step10.png" style="width:100%; height:auto;"></td></tr>
</table>

### 4. Building the Full Vertex Pattern
Continue selecting pairs of vertices and pressing **C** to connect them, building out the
complete spoke-and-ring pattern across the lid face. After each connection press **Space**
to deselect before picking the next pair — failing to do so will cause unintended vertices
to be joined.

<table>
<tr><th width="100%">Completed vertex connection pattern on the lid</th></tr>
<tr><td><img src="Images/Wings3D_step11.png" style="width:100%; height:auto;"></td></tr>
</table>

### 5. Selecting the Created Edges
Switch to **Edge Selection Mode** using the toolbar. Click and drag the mouse across the
top of the lines you created to select all of the newly added edges.

<table>
<tr><th width="100%">Edge Selection Mode — dragging to select all lid edges</th></tr>
<tr><td><img src="Images/Wings3D_step12.png" style="width:100%; height:auto;"></td></tr>
</table>

Press **I** to automatically extend the selection to all similar edges across the entire mesh.

<table>
<tr><th width="100%">I key extends selection to all similar edges</th></tr>
<tr><td><img src="Images/Wings3D_step13.png" style="width:100%; height:auto;"></td></tr>
</table>

### 6. Beveling the Selected Edges
With all edges selected, right-click and choose **Bevel**.

<table>
<tr><th width="100%">Right-click → Bevel</th></tr>
<tr><td><img src="Images/Wings3D_step14.png" style="width:100%; height:auto;"></td></tr>
</table>

Press **Tab** to enter a precise value and set the bevel size to **0.01**.

<table>
<tr><th width="100%">TAB → enter bevel size 0.01</th></tr>
<tr><td><img src="Images/Wings3D_step15.png" style="width:100%; height:auto;"></td></tr>
</table>

### 7. Creating Holes in the Lid
With the beveled pattern in place, right-click and choose **Hole**, then confirm with a
**left-click**.

<table>
<tr><th width="100%">Right-click → Hole → left-click to confirm</th></tr>
<tr><td><img src="Images/Wings3D_step16.png" style="width:100%; height:auto;"></td></tr>
</table>

The holes are punched through the lid face, creating the decorative perforated barrel lid.

<table>
<tr><th width="100%">Completed perforated barrel lid with holes</th></tr>
<tr><td><img src="Images/Wings3D_step17.png" style="width:100%; height:auto;"></td></tr>
</table>

### 8. Separating the Lid into Individual Parts
Press **Y** to return to the top view. Switch to **Face Selection Mode** and select the faces
of the first section you want to isolate as its own object.

<table>
<tr><th width="100%">Face Selection Mode — first lid section selected</th></tr>
<tr><td><img src="Images/Wings3D_step18.png" style="width:100%; height:auto;"></td></tr>
</table>

Right-click and choose **Extract**.

<table>
<tr><th width="100%">Right-click → Extract</th></tr>
<tr><td><img src="Images/Wings3D_step19.png" style="width:100%; height:auto;"></td></tr>
</table>

A dialog will appear asking how to extract. Select **Free** — the exact option does not
matter here since we only want a duplicate placed at the exact same position without any
offset.

<table>
<tr><th width="100%">Extract dialog — selecting Free</th></tr>
<tr><td><img src="Images/Wings3D_step20.png" style="width:100%; height:auto;"></td></tr>
</table>

**Without moving the mouse**, simply click to confirm. This duplicates the selected section
in place.

<table>
<tr><th width="100%">Section duplicated in place without moving the mouse</th></tr>
<tr><td><img src="Images/Wings3D_step21.png" style="width:100%; height:auto;"></td></tr>
</table>

Repeat this process for every remaining section of the lid until all parts exist as
individual objects. Then delete the original combined object.

<table>
<tr><th width="100%">All lid sections separated as individual objects; original deleted</th></tr>
<tr><td><img src="Images/Wings3D_step22.png" style="width:100%; height:auto;"></td></tr>
</table>

### 9. Removing Incorrectly Added Faces
During the extraction process, Wings3D may automatically add unwanted cap faces. Select
these incorrect faces and delete them.

<table>
<tr><th width="100%">Selecting and removing the incorrectly added faces</th></tr>
<tr><td><img src="Images/Wings3D_step23.png" style="width:100%; height:auto;"></td></tr>
</table>

### 10. Reconnecting Open Seam Vertices Manually
Press **Z** to switch to the side view. In **Vertex Selection Mode**, select the two open
seam vertices that need to be joined between adjacent sections.

<table>
<tr><th width="100%">Side view (Z) — two open seam vertices selected</th></tr>
<tr><td><img src="Images/Wings3D_step24.png" style="width:100%; height:auto;"></td></tr>
</table>

Press **I** to automatically select all equivalent vertices across the object, then press
**C** to connect them all.

<table>
<tr><th width="100%">All equivalent seam vertices selected with I — connected with C</th></tr>
<tr><td><img src="Images/Wings3D_step25.png" style="width:100%; height:auto;"></td></tr>
</table>

### 11. Closing the Remaining Open Boundaries
Switch to **Face Selection Mode** and select the entire object. Right-click and choose
**Hole** — but this time **right-click** on the Hole option rather than left-clicking.
This tells Wings3D to close open boundary edges rather than create new holes.

<table>
<tr><th width="100%">Right-click → Hole → right-click on Hole to close open boundaries</th></tr>
<tr><td><img src="Images/Wings3D_step26.png" style="width:100%; height:auto;"></td></tr>
</table>

Hide the other objects to inspect the lid in isolation. The edges and borders of the lid
should now be clean and properly closed.

<table>
<tr><th width="100%">Isolated lid with clean edges and fully closed boundaries</th></tr>
<tr><td><img src="Images/Wings3D_step27.png" style="width:100%; height:auto;"></td></tr>
</table>

### 12. Duplicating the Lid for the Top
The lid model is complete. Select the entire lid, then go to **Extract** → **Y** axis,
press **Tab**, and enter **2.7** to position the duplicated top lid.

<table>
<tr><th width="100%">Extract → Y → TAB → 2.7 to place the top lid</th></tr>
<tr><td><img src="Images/Wings3D_step28.png" style="width:100%; height:auto;"></td></tr>
</table>

### 13. Positioning the Bottom Lid
Select the bottom lid, right-click → **Move** → **Y** axis, and move it into its correct
position at the base of the barrel.

<table>
<tr><th width="50%">Selecting Move → Y for the bottom lid</th><th width="50%">Moving the bottom lid to position 0.3</th></tr>
<tr>
<td><img src="Images/Wings3D_step29.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step30.png" style="width:100%; height:auto;"></td>
</tr>
</table>

**Chapter 2 complete.**  
Both barrel lids are modeled, separated into individual parts, and correctly positioned.

---

## Chapter 3: Modeling the Barrel Body

### 1. Creating the Body Cylinder
Right-click in the viewport, choose **Cylinder**, and click the gear icon. Set the following
values: **Sections: 32**, **Height: 3**, **Cylinder Type: Tube**, **Thickness: 0.05**, and
check **Put on Ground**. Confirm with OK.

<table>
<tr><th width="100%">Barrel body cylinder settings (Sections: 32, Height: 3, Type: Tube, Thickness: 0.05)</th></tr>
<tr><td><img src="Images/Wings3D_step31.png" style="width:100%; height:auto;"></td></tr>
</table>

### 2. Selecting the Side Wall Edges
Press **X** to switch to the side view. Switch to **Edge Selection Mode** and select all
the vertical side wall edges of the cylinder.

<table>
<tr><th width="100%">Side view (X) — all side wall edges selected</th></tr>
<tr><td><img src="Images/Wings3D_step32.png" style="width:100%; height:auto;"></td></tr>
</table>

### 3. Cutting Edge Loops into the Walls
Right-click and choose **Cut**, then select **5** to add five cuts along all the selected
edges simultaneously.

<table>
<tr><th width="50%">Right-click → Cut</th><th width="50%">Selecting 5 cuts</th></tr>
<tr>
<td><img src="Images/Wings3D_step33.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step34.png" style="width:100%; height:auto;"></td>
</tr>
</table>

The cuts produce new vertices that form four unconnected lines around the cylinder. Press
**C** to connect them into continuous closed edge loops.

<table>
<tr><th width="50%">Unconnected vertex lines after cutting</th><th width="50%">Vertices connected into full edge loops with C</th></tr>
<tr>
<td><img src="Images/Wings3D_step35.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step36.png" style="width:100%; height:auto;"></td>
</tr>
</table>

### 4. Selecting Every Other Edge Loop
Select the outer and inner wall edges of the tube, then navigate to
**Select** → **Edge Loop** → **Every Nth Right** → **Second** to retain only every
alternate edge loop in the selection.

<table>
<tr><th width="33%">Outer and inner wall edges selected</th><th width="33%">Select → Edge Loop → Every Nth → Second</th><th width="33%">Result after Every Second applied</th></tr>
<tr>
<td><img src="Images/Wings3D_step37.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step38.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step39.png" style="width:100%; height:auto;"></td>
</tr>
</table>

### 5. Beveling and Creating Holes in the Body
With the alternate edge loops selected, right-click → **Bevel**, press **Tab**, and set
the bevel value to **0.01**.

<table>
<tr><th width="50%">Right-click → Bevel</th><th width="50%">TAB → 0.01 bevel value</th></tr>
<tr>
<td><img src="Images/Wings3D_step40.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step41.png" style="width:100%; height:auto;"></td>
</tr>
</table>

Apply the **Hole** operation (right-click → Hole → left-click) to punch the holes through
the beveled faces of the barrel body.

<table>
<tr><th width="100%">Holes punched through the beveled faces of the barrel body</th></tr>
<tr><td><img src="Images/Wings3D_step42.png" style="width:100%; height:auto;"></td></tr>
</table>

### 6. Splitting the Body into Individual Sections
Select one section of the barrel body, right-click → **Extract**, then click without moving
the mouse to duplicate it in place. Repeat this for every individual section until all parts
are separate objects.

<table>
<tr><th width="50%">Extracting one body section in place</th><th width="50%">All body sections extracted as individual objects</th></tr>
<tr>
<td><img src="Images/Wings3D_step43.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step44.png" style="width:100%; height:auto;"></td>
</tr>
</table>

Remove any unwanted connecting geometry that Wings3D created automatically during the
extraction process.

<table>
<tr><th width="100%">Removing unwanted connections left over from extraction</th></tr>
<tr><td><img src="Images/Wings3D_step45.png" style="width:100%; height:auto;"></td></tr>
</table>

### 7. Reconnecting the Body Section Seams
Switch to the top view. In **Vertex Selection Mode**, select two seam vertices, press **I**
to select all equivalent vertices across the object, and press **C** to connect them.
Then in **Face Selection Mode**, select all, right-click → **Hole** → right-click on the
Hole option to close any remaining open boundaries.

<table>
<tr><th width="33%">Two seam vertices selected in top view</th><th width="33%">I extends selection to all equivalent vertices</th><th width="33%">All equivalent vertices connected with C</th></tr>
<tr>
<td><img src="Images/Wings3D_step46.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step47.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step48.png" style="width:100%; height:auto;"></td>
</tr>
</table>

<table>
<tr><th width="50%">Right-click → Hole → right-click to close open boundaries</th><th width="50%">Clean, properly closed corner of the barrel wall</th></tr>
<tr>
<td><img src="Images/Wings3D_step49.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step50.png" style="width:100%; height:auto;"></td>
</tr>
</table>

### 8. Fixing the Connections Between Adjacent Sections
The edges running along the borders between neighbouring sections also need to be connected.
Select a border edge and press **I** to select all equivalent border edges across the model.

<table>
<tr><th width="50%">Border edge selected between two adjacent sections</th><th width="50%">I key selects all equivalent border edges</th></tr>
<tr>
<td><img src="Images/Wings3D_step51.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step52.png" style="width:100%; height:auto;"></td>
</tr>
</table>

Right-click → **Cut** → select **5** to cut these border edges and introduce matching
vertex positions.

<table>
<tr><th width="50%">Right-click → Cut</th><th width="50%">Selecting 5 cuts</th></tr>
<tr>
<td><img src="Images/Wings3D_step53.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step54.png" style="width:100%; height:auto;"></td>
</tr>
</table>

Select the four outermost edges at each seam, press **I** to extend the selection to all
similar edges around the model, then press **C** to connect them.

<table>
<tr><th width="50%">Outermost seam edges selected</th><th width="50%">All similar edges connected with C</th></tr>
<tr>
<td><img src="Images/Wings3D_step55.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step56.png" style="width:100%; height:auto;"></td>
</tr>
</table>

### 9. Shaping the Barrel Curvature
Switch to **Vertex Selection Mode** and press **X** for the side view. Select all the
vertices in the rings that need to be pushed outward to produce the barrel's characteristic
bulge.

<table>
<tr><th width="50%">Selecting outer ring vertices to scale outward</th><th width="50%">All target ring vertices selected</th></tr>
<tr>
<td><img src="Images/Wings3D_step57.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step58.png" style="width:100%; height:auto;"></td>
</tr>
</table>

Right-click → **Scale Uniform**, press **Tab**, and enter **110%** to push the outer rings
outward and create the bulge.

<table>
<tr><th width="50%">Right-click → Scale Uniform</th><th width="50%">Entering 110% for the outer rings</th></tr>
<tr>
<td><img src="Images/Wings3D_step59.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step60.png" style="width:100%; height:auto;"></td>
</tr>
</table>

Repeat the same **Scale Uniform** operation for the middle ring section, entering **105%**
for a subtler bulge at the barrel's center.

<table>
<tr><th width="100%">Middle ring scaled to 105% for a subtler central bulge</th></tr>
<tr><td><img src="Images/Wings3D_step61.png" style="width:100%; height:auto;"></td></tr>
</table>

**Chapter 3 complete.**  
The barrel body is fully modeled with its classic wooden curvature.

---

## Chapter 4: Adding the Metal Hoops

### 1. Creating the First Hoop
Right-click → **Cylinder** → gear icon. Set: **Sections: 32**, **Height: 0.1**,
**Cylinder Type: Tube**, **Thickness: 0.025**, and check **Put on Ground**. Confirm with OK.

<table>
<tr><th width="100%">Hoop cylinder settings (Sections: 32, Height: 0.1, Type: Tube, Thickness: 0.025)</th></tr>
<tr><td><img src="Images/Wings3D_step62.png" style="width:100%; height:auto;"></td></tr>
</table>

### 2. Lifting the Hoop into Position
Select the hoop, right-click → **Move** → **Y** axis, press **Tab**, and enter **0.5** to
raise it to the correct height on the barrel.

<table>
<tr><th width="100%">Moving the hoop along the Y axis to 0.5</th></tr>
<tr><td><img src="Images/Wings3D_step63.png" style="width:100%; height:auto;"></td></tr>
</table>

### 3. Scaling the Hoop to Fit Around the Barrel
Right-click → **Scale Uniform**, press **Tab**, and enter **113.7%** to scale the hoop so
that it wraps snugly around the barrel body.

<table>
<tr><th width="100%">Scale Uniform → 113.7% to fit the hoop around the barrel</th></tr>
<tr><td><img src="Images/Wings3D_step64.png" style="width:100%; height:auto;"></td></tr>
</table>

### 4. Tapering the Bottom of the Hoop
Select only the bottom vertices of the hoop. Apply **Scale Uniform** and set the value to
**99%** to slightly taper the bottom edge so the hoop conforms better to the barrel's
curvature.

<table>
<tr><th width="100%">Bottom vertices of the hoop scaled to 99% for curvature fit</th></tr>
<tr><td><img src="Images/Wings3D_step65.png" style="width:100%; height:auto;"></td></tr>
</table>

### 5. Extracting and Placing the Top Hoop
Switch to **Face Selection Mode**, right-click → **Extract** → **Y** axis, press **Tab**,
and enter **1.883** to position the extracted top hoop copy.

<table>
<tr><th width="100%">Extract → Y → TAB → 1.883 to place the top hoop</th></tr>
<tr><td><img src="Images/Wings3D_step66.png" style="width:100%; height:auto;"></td></tr>
</table>

Right-click → **Rotate** → **X** axis, press **Tab**, and enter **180** to flip the top
hoop to match the correct orientation.

<table>
<tr><th width="100%">Rotate → X → TAB → 180 to flip the top hoop</th></tr>
<tr><td><img src="Images/Wings3D_step67.png" style="width:100%; height:auto;"></td></tr>
</table>

### 6. Creating the Middle Hoops
Create a new cylinder hoop using the same settings as before. Move it along the **Y** axis
to **1.15**, then scale it uniformly to **121.7%** to fit the barrel's widest midpoint.

<table>
<tr><th width="33%">New middle hoop cylinder created</th><th width="33%">Moved to Y = 1.15</th><th width="33%">Scaled uniformly to 121.7%</th></tr>
<tr>
<td><img src="Images/Wings3D_step68.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step69.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step70.png" style="width:100%; height:auto;"></td>
</tr>
</table>

Extract the middle hoop along the **Y** axis: press **Tab** and enter **0.6** to position
the second middle hoop symmetrically on the other side of the barrel's center.

<table>
<tr><th width="100%">Extract → Y → TAB → 0.6 for the second middle hoop</th></tr>
<tr><td><img src="Images/Wings3D_step71.png" style="width:100%; height:auto;"></td></tr>
</table>

The barrel model is now fully assembled with all four metal hoops in place.

<table>
<tr><th width="100%">Complete barrel model with all hoops positioned</th></tr>
<tr><td><img src="Images/Wings3D_step72.png" style="width:100%; height:auto;"></td></tr>
</table>

**Chapter 4 complete.**  
All metal hoops have been created, scaled, and positioned around the barrel.

---

## Chapter 5: UV Unwrapping and Texturing

### 1. UV Unwrapping the First Object
Switch to **Body Selection Mode**, select one object, right-click, and choose **UV Mapping**.

<table>
<tr><th width="100%">Body Selection Mode → right-click → UV Mapping</th></tr>
<tr><td><img src="Images/Wings3D_step73.png" style="width:100%; height:auto;"></td></tr>
</table>

The UV editor window opens. Right-click inside it and choose **Select By** — a secondary
submenu will appear offering projection methods.

<table>
<tr><th width="50%">Right-click → Select By in the UV editor</th><th width="50%">Projection option in the Select By submenu</th></tr>
<tr>
<td><img src="Images/Wings3D_step74.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step75.png" style="width:100%; height:auto;"></td>
</tr>
</table>

The faces of the object will be colored in different colors, indicating how the unwrap will
be segmented. Right-click again and choose **Continue**, then select **Projection Normal**
to finalize the unwrap.

<table>
<tr><th width="50%">Right-click → Continue to proceed with the unwrap</th><th width="50%">Selecting Projection Normal to finalize</th></tr>
<tr>
<td><img src="Images/Wings3D_step76.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step77.png" style="width:100%; height:auto;"></td>
</tr>
</table>

The object is now UV unwrapped. Close the UV editor window.

<table>
<tr><th width="100%">Object UV unwrapped — close the UV editor</th></tr>
<tr><td><img src="Images/Wings3D_step78.png" style="width:100%; height:auto;"></td></tr>
</table>

A new material entry and an image file are automatically added to the scene's material and
image list.

<table>
<tr><th width="100%">New material and image file added automatically after UV unwrapping</th></tr>
<tr><td><img src="Images/Wings3D_step79.png" style="width:100%; height:auto;"></td></tr>
</table>

### 2. Creating the Wood Material
Right-click in the Outliner, choose **Material**, and give it a descriptive name such as
**Wood**. Click **OK**, then accept the default values in the Material Properties dialog
and click **OK** again.

<table>
<tr><th width="33%">Right-click → Material in the Outliner</th><th width="33%">Naming the material "Wood"</th><th width="33%">Material Properties dialog (leave as default)</th></tr>
<tr>
<td><img src="Images/Wings3D_step80.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step81.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step82.png" style="width:100%; height:auto;"></td>
</tr>
</table>

The Wood material now appears in the Outliner.

<table>
<tr><th width="100%">Wood material added and visible in the Outliner</th></tr>
<tr><td><img src="Images/Wings3D_step83.png" style="width:100%; height:auto;"></td></tr>
</table>

### 3. Loading the Wood Texture Files
Locate the wood PBR texture files on your system and drag and drop them into the Outliner.

<table>
<tr><th width="50%">Selecting the wood texture files</th><th width="50%">Texture files dropped into the Outliner</th></tr>
<tr>
<td><img src="Images/Wings3D_step84.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step85.png" style="width:100%; height:auto;"></td>
</tr>
</table>

### 4. Assigning Texture Maps to the Correct Material Slots
Drag and drop each texture file from the Outliner onto the Wood material and assign it to
the correct slot:

- **Normal map** → **Bump Normal Map**
- **Roughness map** → **Roughness** (a grayscale conversion dialog may appear — click OK)
- **Color / Albedo map** → **Base Color**
- **Displacement map** → **Bump Height Map**

<table>
<tr><th width="33%">Normal map → Bump Normal Map slot</th><th width="33%">Roughness → Roughness slot</th><th width="33%">Grayscale conversion confirmation dialog</th></tr>
<tr>
<td><img src="Images/Wings3D_step86.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step87.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step88.png" style="width:100%; height:auto;"></td>
</tr>
</table>

<table>
<tr><th width="50%">Color map → Base Color slot</th><th width="50%">Displacement map → Bump Height Map slot</th></tr>
<tr>
<td><img src="Images/Wings3D_step89.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step90.png" style="width:100%; height:auto;"></td>
</tr>
</table>

### 5. Applying the Wood Material to the Object
The Wood material is now fully configured. Select the target object using **Body Selection
Mode**, then right-click the Wood material in the Outliner and choose **Assign to Selection**.

<table>
<tr><th width="50%">Fully configured Wood material in the Outliner</th><th width="50%">Right-click → Assign Material to Selection</th></tr>
<tr>
<td><img src="Images/Wings3D_step91.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step92.png" style="width:100%; height:auto;"></td>
</tr>
</table>

The wood texture is now visibly applied to the object in the viewport.

<table>
<tr><th width="100%">Wood material successfully applied to the object</th></tr>
<tr><td><img src="Images/Wings3D_step93.png" style="width:100%; height:auto;"></td></tr>
</table>

### 6. Applying the Wood Material to All Remaining Wooden Parts
UV unwrap each remaining wooden part using the same procedure. Once all wooden parts are
unwrapped, select them all via **Body Selection Mode** and assign the existing Wood material
to all of them at once.

<table>
<tr><th width="50%">All wooden parts selected — assigning Wood material to selection</th><th width="50%">Wood texture applied to every wooden piece</th></tr>
<tr>
<td><img src="Images/Wings3D_step94.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step95.png" style="width:100%; height:auto;"></td>
</tr>
</table>

### 7. UV Unwrapping the Metal Hoops
For the hoops, use **Feature Detection** instead of **Projection** in the **Select By**
submenu, as it produces a more accurate segmentation for cylindrical metal surfaces.

<table>
<tr><th width="100%">Select By → Feature Detection for hoops (better segmentation result)</th></tr>
<tr><td><img src="Images/Wings3D_step96.png" style="width:100%; height:auto;"></td></tr>
</table>

### 8. Creating the Metal Material
Create a new material named **Metal** following the same steps used for the Wood material.
The key difference is that the metal PBR texture set includes a **Metalness** map, which
should be assigned to the **Metallic** slot. If a grayscale conversion dialog appears,
click OK.

<table>
<tr><th width="33%">Metal texture files selected</th><th width="33%">Metalness map → Metallic slot</th><th width="33%">Grayscale conversion confirmation</th></tr>
<tr>
<td><img src="Images/Wings3D_step97.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step98.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step99.png" style="width:100%; height:auto;"></td>
</tr>
</table>

### 9. Improving the Hoop UV Layout with Unfold
After the initial unwrap, the hoop may display a poor or irregular UV layout. To improve it,
select the hoop object via **Body Selection Mode**, right-click → **UV Mapping** to reopen
the UV editor, then right-click inside and choose **Remap UV** → **Unfold**.

<table>
<tr><th width="33%">Irregular UV layout</th><th width="33%">Body Selection Mode → right-click → UV Mapping</th><th width="33%">Right-click → Remap UV inside the UV editor</th></tr>
<tr>
<td><img src="Images/Wings3D_step100.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step101.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step102.png" style="width:100%; height:auto;"></td>
</tr>
</table>

<table>
<tr><th width="50%">Clicking the Unfold Option</th><th width="50%">Improved UV layout after Unfold remapping</th></tr>
<tr>
<td><img src="Images/Wings3D_step103.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step104.png" style="width:100%; height:auto;"></td>
</tr>
</table>

The Unfold method produces a noticeably cleaner and more even UV layout for the hoop.

Apply the same **Unfold** remapping (or any other suitable method) to the remaining three
hoops, then assign the Metal material to all of them. The barrel is now fully textured.

<table>
<tr><th width="100%">Completed barrel model with all textures applied</th></tr>
<tr><td><img src="Images/Wings3D_step104x.png" style="width:100%; height:auto;"></td></tr>
</table>

**Chapter 5 complete.**  
All wooden and metal parts have been UV unwrapped and textured with PBR materials.

---

## Chapter 6: Scene Organization and Export

### 1. Cleaning Up Auto-Generated Materials
Remove any unnecessary materials that were created automatically during the UV unwrapping
process, keeping only the **Wood** and **Metal** materials in the scene.

### 2. Renaming and Organizing Objects
Rename each object in the Geometry Graph to a clear, descriptive name for easy
identification (e.g. `Barrel_Body`, `Lid_Top`, `Lid_Bottom`, `Hoop_Top`, `Hoop_Middle`,
etc.).

### 3. Creating an Organization Folder in the Geometry Graph
Right-click inside the **Geometry Graph** panel and choose **Create Folder**, then give
the folder a descriptive name.

<table>
<tr><th width="50%">Right-click → Create Folder in the Geometry Graph</th><th width="50%">Naming the new folder</th></tr>
<tr>
<td><img src="Images/Wings3D_step105.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step106.png" style="width:100%; height:auto;"></td>
</tr>
</table>

### 4. Moving Objects into the Folder
Click on each object entry in the Geometry Graph and drag it into the folder to build a
clean scene hierarchy.

<table>
<tr><th width="50%">Scene objects before organizing into the folder</th><th width="50%">Scene objects neatly organized inside the folder</th></tr>
<tr>
<td><img src="Images/Wings3D_step107.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Wings3D_step108.png" style="width:100%; height:auto;"></td>
</tr>
</table>

### 5. Exporting as Wavefront OBJ
Wings3D's FBX exporter has known issues and is not recommended. The preferred export format
is **Wavefront (.obj)**. Go to **File** → **Export** and select **Wavefront (.obj)**.

<table>
<tr><th width="100%">File → Export → Wavefront (.obj)</th></tr>
<tr><td><img src="Images/Wings3D_step109.png" style="width:100%; height:auto;"></td></tr>
</table>

In the export settings dialog, leave all options at their defaults **except** for
**Texture Type**, which should be changed to **JPG**. Confirm and save the file.

<table>
<tr><th width="100%">Export settings — Texture Type changed to JPG</th></tr>
<tr><td><img src="Images/Wings3D_step110.png" style="width:100%; height:auto;"></td></tr>
</table>

**Result:** A clean `.obj` file with accompanying `.mtl` material definition and JPG
texture files, ready for direct import into Unity, Unreal Engine, Godot, or any other
game engine.

**Chapter 6 complete.**  
The barrel model is fully organized and exported.

---

**Documentation end.**  
All chapters are now complete. The full barrel model was created in Wings3D using its
polygon-based workflow — cylinder primitives, precise vertex and edge operations, PBR
UV unwrapping, and material assignment — making it well suited for game-ready asset
production where clean topology and efficient texturing are the priority.
