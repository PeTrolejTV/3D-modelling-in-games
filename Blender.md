# Game Object Modeling: Barrel

## Blender Workflow

<details>
<summary>1️⃣ Barrel Lid</summary>

### Creating the Lid Base
- Add a circle:

Shift + A -> Mesh -> Circle

![Lid Base](SCREENSHOT_INSERT)

- Enter Edit Mode and Vertex Select:

Tab -> 1

![Edit Mode](SCREENSHOT_INSERT)

- Connect vertices to form edges:  
  - Select vertices (Shift or drag select)  
  - Press **F** to connect  
![Connect Vertices](SCREENSHOT_INSERT)

- Complete lid shape by connecting remaining vertices  
![Lid Foundation](SCREENSHOT_INSERT)

- Fill all faces:

A -> F

![Filled Lid](SCREENSHOT_INSERT)

- Apply **Solidify Modifier** for thickness  
![Solidify Lid](SCREENSHOT_INSERT)

### Adding Details
- Switch to Edge Select, select edges to bevel  
![Select Edges](SCREENSHOT_INSERT)

- Bevel tool: drag yellow handle or set Width in the menu  
![Bevel Edges](SCREENSHOT_INSERT)

- Remove unnecessary faces:  

X -> Faces

![Remove Faces](SCREENSHOT_INSERT)

- Separate sections for texturing:

P -> Separate by Selection

![Separate Sections](SCREENSHOT_INSERT)

- Connect missing edges individually (F) to avoid unwanted connections  
![Connect Edges](SCREENSHOT_INSERT)

</details>

<details>
<summary>2️⃣ Barrel Body</summary>

- Add circle for base:

Shift + A -> Mesh -> Circle

![Barrel Base](SCREENSHOT_INSERT)

- Extrude vertically for barrel height:

Select edges -> E -> extrude

![Extrude Body](SCREENSHOT_INSERT)

- Apply **Solidify Modifier** and set thickness  
![Solidify Body](SCREENSHOT_INSERT)

- Bevel every second edge (outer + inner)  
![Bevel Body](SCREENSHOT_INSERT)

- Delete unnecessary faces:

X -> Faces

![Delete Faces](SCREENSHOT_INSERT)

- Separate each plank as individual objects and organize into a collection `BarrelBody`  
![Separate Pieces](SCREENSHOT_INSERT)

- Connect edges individually  
![Connect Body Edges](SCREENSHOT_INSERT)

</details>

<details>
<summary>3️⃣ Hoops</summary>

- Add circle mesh, move to desired position, resize with **S**, extrude **E**  
![Hoop Creation](SCREENSHOT_INSERT)

- Duplicate and position additional hoops  
![Duplicate Hoops](SCREENSHOT_INSERT)

- Apply **Solidify Modifier** (Offset = 1) and adjust thickness, then apply  
![Solidify Hoop](SCREENSHOT_INSERT)

- Apply metal material with Principled BSDF workflow  
![Metal Material](SCREENSHOT_INSERT)

- UV unwrap with Cube Projection  
![Hoop UV](SCREENSHOT_INSERT)

</details>

<details>
<summary>4️⃣ Materials & Textures</summary>

- Wood Texture: [Wood035](https://ambientcg.com/view?id=Wood035)  
- Metal Texture: [Metal052C](https://ambientcg.com/view?id=Metal052C)

- Add new material to all parts, rename it  
![Add Material](SCREENSHOT_INSERT)

- Enable **Node Wrangler** addon:  

Edit -> Preferences -> Add-ons -> Node Wrangler

![Node Wrangler](SCREENSHOT_INSERT)

- Principled BSDF -> **Ctrl + Shift + T** -> load textures -> Principled Texture Setup  
![Texture Setup](SCREENSHOT_INSERT)

- UV unwrap all objects (Smart UV Project)  
![UV Unwrap](SCREENSHOT_INSERT)

- Adjust top/bottom faces projection to Vertical  
![UV Adjustment](SCREENSHOT_INSERT)

- Organize objects into collections for clean project structure  
![Organize Collections](SCREENSHOT_INSERT)

</details>

<details>
<summary>5️⃣ Final Adjustments & Optimization</summary>

- Apply **Shade Auto Smooth** to all objects  
![Shade Smooth](SCREENSHOT_INSERT)

- Set origin to **Center of Geometry**  
![Set Origin](SCREENSHOT_INSERT)

- Check object stats:

Objects: 34
Vertices: 5,712
Edges: 10,392
Faces: 4,740
Triangles: 11,304

![Stats Before Optimization](SCREENSHOT_INSERT)

- Optimize geometry:  

Mesh -> Clean Up -> Limited Dissolve

- Set Max Angle ~4.5-5°  
![Limited Dissolve](SCREENSHOT_INSERT)

- Final optimized stats:

Objects: 34
Vertices: 1,712
Edges: 2,736
Faces: 1,084
Triangles: 3,304

![Optimized Barrel](SCREENSHOT_INSERT)

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

![Check Dimensions](SCREENSHOT_INSERT)

If the model is not the correct size, we can scale it using the **Scale tool**.

Press:

S → adjust the scale until the height reaches approximately **900 mm**.

![Scaling Barrel](SCREENSHOT_INSERT)

### Applying Transformations

After scaling the model, we need to apply the transformations so the game engine reads the correct values.

1. Select all barrel objects (`A`).
2. Press:

Ctrl + A → Apply → **All Transforms**

This resets the transform values while keeping the model at the correct size.

![Apply Transformations](SCREENSHOT_INSERT)

### Exporting the Model

Once the model has the correct scale and transformations applied, it can be exported for use in a game engine.

1. Go to:

File → Export → **FBX (.fbx)**

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

![FBX Export Settings](SCREENSHOT_INSERT)

The barrel model is now correctly scaled and exported as a **game-ready asset**.

</details>
