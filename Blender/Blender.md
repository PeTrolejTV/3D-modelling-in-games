# Game Object Modeling: Barrel

## Blender Workflow

<details>
<summary>1️⃣ Barrel Lid</summary>

### Creating the Lid Base
- Add a circle:

Shift + A -> Mesh -> Circle

![Lid Base](Images/Blender_step1.png)

- Enter Edit Mode and Vertex Select:

Tab -> 1

![Edit Mode](Images/Blender_step2.png)

- Connect vertices to form edges:  
  - Select vertices (Shift or drag select)  
  - Press **F** to connect  
![Connect Vertices](Images/Blender_step3.png)

- Complete lid shape by connecting remaining vertices  
![Lid Foundation](Images/Blender_step4.png)

- Fill all faces:

A -> F

![Filled Lid](Images/Blender_step5.png)

- Apply **Solidify Modifier** for thickness  
![Solidify Lid](Images/Blender_step6.png)
![Solidify Lid](Images/Blender_step7.png)
![Solidify Lid](Images/Blender_step8.png)

![Solidified Lid](Images/Blender_step9.png)

### Adding Details
- Switch to Edge Select, select edges to bevel  
![Select Edges](Images/Blender_step10.png)

- Bevel tool: drag yellow handle or set Width in the menu  
![Bevel Edges](Images/Blender_step11.png)
![Bevel Edges](Images/Blender_step12.png)

- Remove unnecessary faces:  

X -> Faces

![Remove Faces](Images/Blender_step13.png)

- Separate sections for texturing:

P -> Separate by Selection

![Separate Sections](Images/Blender_step14.png)

- Connect missing edges individually (F) to avoid unwanted connections  
![Connect Edges](Images/Blender_step15.png)
![Connected Edges](Images/Blender_step16.png)

</details>

<details>
<summary>2️⃣ Barrel Body</summary>

- Add circle for base:

Shift + A -> Mesh -> Circle

![Barrel Base](Images/Blender_step1.png)

- Extrude vertically for barrel height:

Select edges -> E -> extrude

![Extrude Body](Images/Blender_step28.png)

- Apply **Solidify Modifier** and set thickness  
![Solidify Body](Images/Blender_step29.png)

- Bevel every second edge (outer + inner)  
![Bevel Body](Images/Blender_step30.png)

- Delete unnecessary faces:

X -> Faces

![Delete Faces](Images/Blender_step31.png)

- Separate each plank as individual objects and organize into a collection `BarrelBody`  
![Separate Pieces](Images/Blender_step32.png)

- Connect edges individually  
![Connect Body Edges](Images/Blender_step34.png)
![Connected Body Edges](Images/Blender_step35.png)

- Add Details to change shape:

Right click -> Subdivide

![Subdivide_Body](Images/Blender_step43.png)
![Subdivide_Body](Images/Blender_step44.png)

- Select the horizontal lines and Scale:

S -> 1.1

![Scale_Body_Edges](Images/Blender_step45.png)

S -> 1.05

![Scale_Body_Edges](Images/Blender_step46.png)

- Barrel Body
![Barrel_Body](Images/Blender_step47.png)
![Barrel_Body](Images/Blender_step48.png)
![Barrel_Body](Images/Blender_step49.png)

</details>

<details>
<summary>3️⃣ Hoops</summary>

- Add circle mesh, move to desired position, resize with **S**, extrude **E**  
![Hoop Creation](Images/Blender_step51.png)
![Hoop Creation](Images/Blender_step52.png)
![Hoop Creation](Images/Blender_step53.png)
![Hoop Creation](Images/Blender_step54.png)

- Apply **Solidify Modifier** (Offset = 1) and adjust thickness, then apply  
![Solidify Hoop](Images/Blender_step55.png)

- Duplicate and position additional hoops  
![Duplicate Hoops](Images/Blender_step56.png)
![Rotate Hoops](Images/Blender_step57.png)
![Duplicate Hoops](Images/Blender_step58.png)

- Apply metal material with Principled BSDF workflow  
![Metal Material](Images/Blender_step59.png)
![Metal Material](Images/Blender_step60.png)
![Metal Material](Images/Blender_step61.png)

- UV unwrap with Cube Projection  
![Hoop UV](Images/Blender_step62.png)
![Hoop UV](Images/Blender_step63.png)

</details>

<details>
<summary>4️⃣ Materials & Textures</summary>

- Wood Texture: [Wood035](https://ambientcg.com/view?id=Wood035)  
- Metal Texture: [Metal052C](https://ambientcg.com/view?id=Metal052C)

- Add new material to all parts, rename it  
![Add Material](Images/Blender_step17.png)
![Add Material](Images/Blender_step18.png)
![Add Material](Images/Blender_step23.png)
![Add Material](Images/Blender_step24.png)
![Shading_Workspace](Images/Blender_step19.png)

![Add Material](Images/Blender_step36.png)
![Add Material](Images/Blender_step37.png)

- Enable **Node Wrangler** addon:  

Edit -> Preferences -> Add-ons -> Node Wrangler

![Node Wrangler](Images/Blender_step20.png)

- Principled BSDF -> **Ctrl + Shift + T** -> load textures -> Principled Texture Setup  
![Texture Setup](Images/Blender_step21.png)
![Texture Setup](Images/Blender_step22.png)

- UV unwrap all objects (Smart UV Project)  
![UV Unwrap](Images/Blender_step25.png)
![UV Unwrap](Images/Blender_step26.png)

![UV Unwrap](Images/Blender_step38.png)
![UV Unwrap](Images/Blender_step39.png)

![UV Unwrap](Images/Blender_step40.png)

- Adjust top/bottom faces projection to Vertical
![UV Adjustment](Images/Blender_step41.png)
![UV Adjustment](Images/Blender_step42.png)

- Organize objects into collections for clean project structure  
![Organize Collections](Images/Blender_step27.png)
![Organize Collections](Images/Blender_step33.png)
![Organize Collections](Images/Blender_step50.png)
![Organize Collections](Images/Blender_step64.png)

</details>

<details>
<summary>5️⃣ Final Adjustments & Optimization</summary>

- Apply **Shade Auto Smooth** to all objects  
![Shade Smooth](Images/Blender_step65.png)

- Set origin to **Center of Geometry**  
![Set Origin](Images/Blender_step67.png)

- Check object stats:

Objects: 34
Vertices: 5,712
Edges: 10,392
Faces: 4,740
Triangles: 11,304

![Stats Before Optimization](Images/Blender_step66.png)

- Optimize geometry:  

Mesh -> Clean Up -> Limited Dissolve

- Set Max Angle ~4.5-5°  
![Limited Dissolve](Images/Blender_step68.png)
![Limited Dissolve](Images/Blender_step69.png)

- Final optimized stats:

Objects: 34
Vertices: 1,712
Edges: 2,736
Faces: 1,084
Triangles: 3,304

![Optimized Barrel](Images/Blender_step70.png)

> Model is now ready for Unity testing and documentation.

</details>

<details>
<summary>6️⃣ Scaling & Export</summary>

### Setting the Correct Scale

Before exporting the model to a game engine, it is important to ensure that the object has a realistic and consistent scale.

In Blender, the default unit scale is:

1 Blender Unit = 1 meter

The barrel should have an approximate real-world size.

Typical barrel dimensions used in games:

- Height: **~0.9 m (900 mm)**
- Diameter: **~0.6 m**

To check the current size of the object:

1. Select the barrel.
2. Open the **Item panel** (`N` key).
3. Check the **Dimensions** values.

![Check Dimensions](Images/Blender_step71.png)

If the model is not the correct size, we can scale it using the **Scale tool**.

Press:

S → adjust the scale until the height reaches approximately **900 mm**.

### Applying Transformations

After scaling the model, we need to apply the transformations so the game engine reads the correct values.

1. Select all barrel objects (`A`).
2. Press:

Ctrl + A → Apply → **All Transforms**

This resets the transform values while keeping the model at the correct size.

![Apply Transformations](Images/Blender_step72.png)

### Exporting the Model

Once the model has the correct scale and transformations applied, it can be exported for use in a game engine.

1. Go to:

File → Export → **FBX (.fbx)**

![FBX Export](Images/Blender_step73.png)

2. In the export settings use the following configuration:

Include

- **Selected Objects** enabled
- **Object Types: Mesh**

Transform

- Scale: **1.00**
- Apply Unit: **Enabled**
- Apply Transform: **Enabled**

Geometry

- Apply Modifiers: **Enabled**
- Smoothing: **Normals Only**

These settings ensure that only the barrel mesh is exported and that the model keeps the correct orientation and scale when imported into a game engine such as Unity.

![FBX Export Settings](Images/Blender_step74.png)

> The barrel model is now correctly scaled and exported as a **game-ready asset**.

</details>
