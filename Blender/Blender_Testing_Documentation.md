# 3D Modeling in Games - Model Import & Testing Documentation

## Chapter 5: Importing and Testing the Barrel Model in Unity

This chapter focuses on importing the previously created barrel model into Unity, setting up the project environment, fixing materials, configuring lighting and shadows, and performing both visual and physics-based testing. The goal is to evaluate the model’s performance and readiness for real-time applications in a game engine.

### 1. Creating a New Unity Project

Open Unity Hub and create a new project.
Select the **High Definition 3D (HDRP)** template and choose the latest available editor version for optimal compatibility and rendering quality.
Name the project (e.g., *ModelTesting*), select a save location, and click **Create Project**. Wait for Unity to finish building the project.

<table>
<tr><th width="50%">Creating a new HDRP project</th><th width="50%">Project building process</th></tr>
<tr>
<td><img src="Images/Unity_step1.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Unity_step2.png" style="width:100%; height:auto;"></td>
</tr>
</table>

### 2. Initial Project Setup

After the project opens, the **HDRP Wizard** window appears.
Review and enable any recommended settings if necessary, then close the wizard.

<table>
<tr><th width="100%">Initial project view with HDRP Wizard</th></tr>
<tr><td><img src="Images/Unity_step3.png" style="width:100%; height:auto;"></td></tr>
</table>

Unity may also include tutorial assets such as a README. These are not required for this workflow, so they can be safely removed.

<table>
<tr><th width="100%">Removing default tutorial assets</th></tr>
<tr><td><img src="Images/Unity_step4.png" style="width:100%; height:auto;"></td></tr>
</table>

### 3. Organizing the Project Structure

Before importing assets, create a clean folder structure inside the **Project** window.
Recommended folders:

* Models
* Textures
* Materials
* Scripts
* Prefabs
* Scenes

<table>
<tr><th width="100%">Creating organized project folders</th></tr>
<tr><td><img src="Images/Unity_step5.png" style="width:100%; height:auto;"></td></tr>
</table>

### 4. Importing the Model

Import the `.fbx` model by dragging and dropping it directly into the **Models** folder.

<table>
<tr><th width="100%">Importing the FBX model</th></tr>
<tr><td><img src="Images/Unity_step6.png" style="width:100%; height:auto;"></td></tr>
</table>

Select the model and navigate to the **Materials** tab.
Use **Extract Textures** and **Extract Materials** to place them into the appropriate folders.

<table>
<tr>
    <th width="50%">Extracting textures</th>
    <th width="50%">Selecting textures folder</th>
</tr>
<tr>
    <td><img src="Images/Unity_step7.png" style="width:100%; height:auto;"></td>
    <td><img src="Images/Unity_step8.png" style="width:100%; height:auto;"></td>
</tr>

<tr>
    <th width="50%">Extracting materials</th>
    <th width="50%">Selecting materials folder</th>
</tr>
<tr>
    <td><img src="Images/Unity_step9.png" style="width:100%; height:auto;"></td>
    <td><img src="Images/Unity_step10.png" style="width:100%; height:auto;"></td>
</tr>
</table>

### 5. Scene Preparation

Rename the current scene and move it into the **Scenes** folder for better organization.

<table>
<tr><th width="100%">Renaming and organizing the scene</th></tr>
<tr><td><img src="Images/Unity_step11.png" style="width:100%; height:auto;"></td></tr>
</table>

Set the desired screen resolution and enable the **Stats** panel to monitor performance metrics.

<table>
<tr><th width="50%">Setting resolution</th><th width="50%">Enabling stats panel</th></tr>
<tr>
<td><img src="Images/Unity_step12.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Unity_step14.png" style="width:100%; height:auto;"></td>
</tr>
</table>

### 6. Placing the Model in the Scene

Drag the model into the scene and reset its position to `(0, 0, 0)`.

<table>
<tr><th width="100%">Placing the model in the scene</th></tr>
<tr><td><img src="Images/Unity_step15.png" style="width:100%; height:auto;"></td></tr>
</table>

Adjust the camera to properly frame the model.

<table>
<tr><th width="100%">Adjusting the camera view</th></tr>
<tr><td><img src="Images/Unity_step16.png" style="width:100%; height:auto;"></td></tr>
</table>

### 7. Fixing Material Appearance

Initially, the model may appear visually incorrect due to missing normal map settings.

Navigate to the **Textures** folder:

* Select the normal texture
* Set **Texture Type → Normal Map**
* Enable **Create from Grayscale**
* Click **Apply**

<table>
<tr><th width="100%">Fixing normal map settings</th></tr>
<tr><td><img src="Images/Unity_step17.png" style="width:100%; height:auto;"></td></tr>
</table>

<table>
<tr><th width="100%">Model appearance after metal normal fix</th></tr>
<tr><td><img src="Images/Unity_step18.png" style="width:100%; height:auto;"></td></tr>
</table>

Repeat the same process for the wood normal texture.

<table>
<tr><th width="100%">Applying normal map to wood texture</th></tr>
<tr><td><img src="Images/Unity_step19.png" style="width:100%; height:auto;"></td></tr>
</table>

<table>
<tr><th width="100%">Improved model after applying all normals</th></tr>
<tr><td><img src="Images/Unity_step20.png" style="width:100%; height:auto;"></td></tr>
</table>

Further improve realism by adjusting the metal material:

* Set **Metallic = 1**

<table>
<tr><th width="100%">Adjusting metallic material</th></tr>
<tr><td><img src="Images/Unity_step21.png" style="width:100%; height:auto;"></td></tr>
</table>

### 8. Lighting and Shadows

To achieve high-quality shadows, select the main directional light (sun) and increase shadow resolution.

<table>
<tr><th width="100%">Improving shadow quality</th></tr>
<tr><td><img src="Images/Unity_step22.png" style="width:100%; height:auto;"></td></tr>
</table>

For testing, the highest setting (**Ultra**) was used.

Add a plane to receive shadows:
**GameObject → 3D Object → Plane**

<table>
<tr><th width="100%">Adding a plane for shadows</th></tr>
<tr><td><img src="Images/Unity_step23.png" style="width:100%; height:auto;"></td></tr>
</table>

### 9. Basic Performance Test

Rotate the light slightly to observe shadows and gather initial performance data.

<table>
<tr><th width="100%">Initial lighting test</th></tr>
<tr><td><img src="Images/Unity_step24.png" style="width:100%; height:auto;"></td></tr>
</table>

Typical observed values:

* ~120 FPS
* ~21k triangles

### 10. Adding Interactivity with Scripts

To create a more dynamic test environment, two scripts are introduced:

* **RotateAround** (rotates objects around the barrel)
* **BarrelExplode** (adds interactive physics behavior)

Create them in the **Scripts** folder via:
**Right-click → Create → MonoBehaviour Script**

<table>
<tr><th width="50%">Creating scripts</th><th width="50%">Created scripts in project</th></tr>
<tr>
<td><img src="Images/Unity_step25.png" style="width:100%; height:auto;"></td>
<td><img src="Images/Unity_step26.png" style="width:100%; height:auto;"></td>
</tr>
</table>

Attach the rotation script to the light and assign the barrel as the target.

<table>
<tr><th width="100%">Applying rotation to light</th></tr>
<tr><td><img src="Images/Unity_step27.png" style="width:100%; height:auto;"></td></tr>
</table>

Apply a similar rotation setup to the camera for a more cinematic effect.

<table>
<tr>
    <th width="100%">Camera rotating script added</th>
</tr>
<tr>
    <td><img src="Images/Unity_step29.png" style="width:100%; height:auto;"></td>
</tr>

<tr>
    <th width="100%">Camera rotating around the barrel</th>
</tr>
<tr>
    <td><img src="Images/Unity_step28.png" style="width:100%; height:auto;"></td>
</tr>
</table>

### 11. Preparing Physics Setup

To enable physics interactions:

* Add **Mesh Colliders** to all barrel parts (except the root object)
* Enable **Convex**

<table>
<tr><th width="100%">Adding convex mesh colliders</th></tr>
<tr><td><img src="Images/Unity_step34.png" style="width:100%; height:auto;"></td></tr>
</table>

If needed, unpack the prefab completely:

<table>
<tr><th width="100%">Unpacking prefab</th></tr>
<tr><td><img src="Images/Unity_step30.png" style="width:100%; height:auto;"></td></tr>
</table>

Then recreate it as a new prefab:

<table>
<tr><th width="100%">Creating new prefab</th></tr>
<tr><td><img src="Images/Unity_step31.png" style="width:100%; height:auto;"></td></tr>
</table>

### 12. Physics Materials

Create a **Physics Material** and assign it to all colliders.

<table>
<tr><th width="100%">Creating physics material</th></tr>
<tr><td><img src="Images/Unity_step32.png" style="width:100%; height:auto;"></td></tr>
</table>

Adjust its properties (friction, bounciness) as needed.

<table>
<tr><th width="100%">Adjusting physics material properties</th></tr>
<tr><td><img src="Images/Unity_step33.png" style="width:100%; height:auto;"></td></tr>
</table>

Assign the material to all mesh colliders.

<table>
<tr><th width="100%">Assigning physics material</th></tr>
<tr><td><img src="Images/Unity_step35.png" style="width:100%; height:auto;"></td></tr>
</table>

### 13. Rigidbody Configuration

Attach a **Rigidbody** to the parent object only.
Set:

* Collision Detection → Continuous Dynamic

<table>
<tr><th width="100%">Configuring Rigidbody</th></tr>
<tr><td><img src="Images/Unity_step36.png" style="width:100%; height:auto;"></td></tr>
</table>

For the plane:

* Enable **Convex**
* Set **Y Scale = 0.001**

<table>
<tr><th width="100%">Fixing plane collider</th></tr>
<tr><td><img src="Images/Unity_step37.png" style="width:100%; height:auto;"></td></tr>
</table>

### 14. Physics Testing

Tilt the plane slightly to allow the barrel to roll.

<table>
<tr><th width="100%">Testing rolling behavior</th></tr>
<tr><td><img src="Images/Unity_step38.png" style="width:100%; height:auto;"></td></tr>
</table>

Create a more advanced scenario by adding a cube below the platform.

<table>
<tr><th width="100%">Creating impact test setup</th></tr>
<tr><td><img src="Images/Unity_step39.png" style="width:100%; height:auto;"></td></tr>
</table>

Attach the **BarrelExplode** script and test the behavior.

<table>
<tr><th width="100%">Adding BarrelExplode script</th></tr>
<tr><td><img src="Images/Unity_step40.png" style="width:100%; height:auto;"></td></tr>
</table>

**Physics testing:** The barrel is tested under real-time physics conditions, including rolling behavior and falling from height to simulate impact-based explosion and fragmentation into individual pieces.

<table>
<tr>
    <th width="33%">Barrel rolling test</th>
    <th width="33%">Falling from height</th>
    <th width="33%">Explosion and shattering</th>
</tr>
<tr>
    <td><img src="Images/Unity_step41.png" style="width:100%; height:auto;"></td>
    <td><img src="Images/Unity_step42.png" style="width:100%; height:auto;"></td>
    <td><img src="Images/Unity_step43.png" style="width:100%; height:auto;"></td>
</tr>
</table>

### 15. Final Testing and Evaluation

The barrel can now:

* Roll using physics
* Explode on high-impact collision
* Explode on key press (**E**)

The test results show:

* Stable performance (~100–120 FPS)
* Dynamic triangle count based on camera distance
* Smooth physics interactions

**Conclusion:**
The model performs efficiently in real-time conditions and is fully suitable for game integration. It includes optimized geometry, correct material setup, and interactive physics behavior, making it a production-ready asset.

**Documentation end.**
