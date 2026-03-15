# 3D-modelling-in-games
3D modeling has greatly influenced the gaming experience and has become an important aspect of game development. The possibilities of 3D modeling are limitless, from modeling characters, objects, environments to models of entire universes.

Game Object Model: Barrel

Blender

Start with the Barrels Lids.

(Shift + A -> Mesh -> Circle)
(SCREENSHOT_INSERT)

Open Edit Mode and Select Mode: Vertex.

(Tab -> 1)

Select 2 Vertices using the Select Tool and connect them.
(SCREENSHOT_INSERT)

Hold Shift Or just drag the select tool trough both Verticies -> Press F to connect them.
(SCREENSHOT_INSERT)

Now using this method we create a foundation for the barrels lid.

We connect the other vertices to create a desired lid looking pattern.
(SCREENSHOT_INSERT)

Select everything and fill it.

Press A to select everything -> press F to fill in the faces.
(SCREENSHOT_INSERT)

Now we have a filled circle and need to give it some volume.

We do that by applying the Solidify Modifier.
(SCREENSHOT_INSERT)

We add some thickness to it.
(SCREENSHOT_INSERT)

In order to apply the modifier we have to make sure we are in the Object Mode and then we can apply it.
(SCREENSHOT_INSERT)

Now we have a lid looking model but we need to add some details.
(SCREENSHOT_INSERT)

We do that by Changing the Select Mode to Edges and selecing all the Edges we want to modify and add detail to.
(SCREENSHOT_INSERT)

Then we select the Tool Bevel and make our desired depth of detail by dragging the yellow handle up or down.
(SCREENSHOT_INSERT)

If we want to modify the lenght more precisely we open the Bevel menu that poped up in the corner once we let go of the handle.

We set the Width to a desired one and we just click else where.
(SCREENSHOT_INSERT)

Now that we have it we just remove the faces by changing the mode to Select Mode Face, select all the parts we just created and remove them.

Press X and select Faces.
(SCREENSHOT_INSERT)

Now we Separate each section of the lid into separate parts in order later to apply texture correctly.

We do that by selecting a section we want to make into a separate part and pressing P -> Separate by Selection.
(SCREENSHOT_INSERT)

Now that we have the whole Lid separated into separate pieces, we can connect the missing edges selecting only one at a time and then pressing F (All three edges, top, middle, bottom).
(SCREENSHOT_INSERT)

We select them one by one because if we select everything and press F it connects them undesirably.
(SCREENSHOT_INSERT)

Now we can add the textures.

I downloaded and used these free textures:
https://ambientcg.com/view?id=Wood035
https://ambientcg.com/view?id=Metal052C

We select all the parts and add a new Material.
(SCREENSHOT_INSERT)

We can rename the newly added material.
(SCREENSHOT_INSERT)

We switch to the Shading workspace.
(SCREENSHOT_INSERT)

We make sure we have the add-on Node Wrangler in Edit -> Preferances -> Add-ons -> Node Wrangler and we check it.
(SCREENSHOT_INSERT)

We select the Principled BSDF and click Ctrl + Shift + T.

In the menu we select everything that was inside the zip that we unpacked and click Principled texture setup.
(SCREENSHOT_INSERT)

It will automatically do everything and we can switch then later to the Layout workspace.
(SCREENSHOT_INSERT)

If the material wasn't already on all our object we will add it.
(SCREENSHOT_INSERT)

Now we see it's brown but not really wood looking, thats because we need to fix the UV Unwraping.
(SCREENSHOT_INSERT)

We do it by selecting all the objects, going to Edit mode and right clicking on the object and selecting UV Unwraping Faces and selecting Smart UV Project.
(SCREENSHOT_INSERT)

We change Angle Limit and Rotation Method into our desired values, I found the 89 degrees and Axis-aligned (Horizontal) to be the best looking, then we click Unwrap.

Now our lid looks much better.
(SCREENSHOT_INSERT)

We can create a new Collection and put our object into it, making the project more organized.
(SCREENSHOT_INSERT)

We can also hide the new collection with the eye icon as we won't be needing it and would be in our way.

Now we go for making the body of the barrel.

It's fairly simple and pretty much the same as creating the lid just vertically.

We start by adding a new Circle.

Shift + A -> Mesh -> Circle.

We go in edit mode, select mode edges, select all (A) and press E to extrude it to a desired hight of the barrel.
(SCREENSHOT_INSERT)

We add the modifier Solidify and set our desired Thickness, go back in object mode and then apply.
(SCREENSHOT_INSERT)

Now we select every second edge both outside and inside and use the same Bevel Tool mechanic as we did with the lid.
(SCREENSHOT_INSERT)

We delete (X) the already selected faces we have.
(SCREENSHOT_INSERT)

And the same way we separeted the lid pieces we separate the body pieces one by one.
(SCREENSHOT_INSERT)

Now that we have separated all the pieces we can put it into a collection and call it BarrelBody.
(SCREENSHOT_INSERT)

We do the same thing as with the lid, connect edges one by one (All three edges, top, middle, bottom) until we have done it for all the pieces.
(SCREENSHOT_INSERT)
(SCREENSHOT_INSERT)

Now we can apply the wood Material on all of the objects, we can do this easily by applying the material on the first one and then selecing all other pieces (A) and then Pressing Ctrl + L and selecting Link Materials, our main object that is highlighted in orange has to be the one having the material in order to use this Link Material trick.
(SCREENSHOT_INSERT)
(SCREENSHOT_INSERT)

We go to Edit mode, select all (A), right click -> UV Unwrap Faces -> Smart UV Project.
(SCREENSHOT_INSERT)

Now if we look at the top parts of the planks they don't look right, we can fix it by selecting the top and bottom Faces of the Barrel and changing the UV Unwrap method to be Vertical.
(SCREENSHOT_INSERT)
(SCREENSHOT_INSERT)

Now when we check it looks much better.
(SCREENSHOT_INSERT)

To Make the barrel a bit less straight and more Barrel like we can use a trick to add it some detail.

Select all the pieces, go Edit mode and right click and select Subdivide.
(SCREENSHOT_INSERT)

We can change the number of cuts to our desired number.
(SCREENSHOT_INSERT)

I chose 4 to have 4 horizontal lines to easily bend the barrels walls.

Now we select all the horizontal lines and press S to scale them to our desired form.
(SCREENSHOT_INSERT)

We can repeat this action with the center 2 again to get a more desired look.
(SCREENSHOT_INSERT)

Now the barrel looks a lot more, well barrel shaped.
(SCREENSHOT_INSERT)

We can bring the barrel lid back and slide it a bit higher for better look.
(SCREENSHOT_INSERT)

We have only on the bottom the lid now so lets duplicate the bottom lid and close the top of the barrel as well.

Shift + D and we move it along the Z-Axis to a desired height.
(SCREENSHOT_INSERT)

Again we can organize it a bit to have it clean.
(SCREENSHOT_INSERT)

Lastly we create the hoops for the barrel.

Again adding the circle mesh and moving it to the desire position.
(SCREENSHOT_INSERT)

We resize it to fit around the barrel with S.
(SCREENSHOT_INSERT)

We use E and extrude it to our desired size.
(SCREENSHOT_INSERT)

Then again resize it with S the top edge to fit around the barrel.
(SCREENSHOT_INSERT)

We add the modifier Solidify but now we set the offset to 1 so it goes outwards and our desired thickness then click apply.
(SCREENSHOT_INSERT)

We duplicate it and move it upwards.
(SCREENSHOT_INSERT)

We press R and rotate it on the Y-Axis 180 degrees.
(SCREENSHOT_INSERT)

Now we do the same things to the next two middle hoops, we can even out their tilted edge to better fit the barrel.
(SCREENSHOT_INSERT)

Now we apply the textures, same method as with the wood.
(SCREENSHOT_INSERT)

Lets call it Steel.

Open the Shading workspace, select the BSDF, press Ctrl + Shift + T, select all the materials inside the zip, press the Principled Texture Setup button.
(SCREENSHOT_INSERT)
(SCREENSHOT_INSERT)

We go back to Layout, select the hoops and fix the UV Unwraping Faces, we have to be in Edit mode and in Select Mode: Face.
(SCREENSHOT_INSERT)

This time we select Cube Projection, because it looks better.
(SCREENSHOT_INSERT)

Once again we can sort it out a little.
(SCREENSHOT_INSERT)

We now select everything (A) and apply Shade Auto Smooth.
(SCREENSHOT_INSERT)
(SCREENSHOT_INSERT)

We set the Origin of all objects to their center of geometry.
(SCREENSHOT_INSERT)

Now the object has these Valuse:

Objects: 34
Vertices: 5,712
Edges: 10,392
Faces: 4,740
Triangles: 11,304

Which is unnecesarly high and we can reduce and optimize this model by a few techniques without reducing the quallity or its shape.

First we go to Mesh -> Clean Up -> Limited Dissolve
(SCREENSHOT_INSERT)

We set our desired Max Angle degree which dictates how much will it be reduced.
(SCREENSHOT_INSERT)

I found the ideal degree is around 4.5 - 5 degrees without distorting the model to a noticable digree while reducing a lot of data.

Now with this we have a significant reduction.

Our new Values are:

Objects: 34
Vertices: 1,712
Edges: 2,736
Faces: 1,084
Triangles: 3,304

That is a significant reduction while the barrel looks unchanged.
(SCREENSHOT_INSERT)

This will be sufficient for testing purposes.

## Modeling Tools Comparison

<details>
<summary>Blender</summary>

### Blender Modeling Process

Description of the workflow used in Blender.

**Steps**
1. Created base cylinder
2. Added loop cuts
3. Modeled wooden planks
4. Added metal hoops

**Screenshots**

![Blender Step](images/blender_step1.png)

**Export Settings**

- Format: FBX
- Scale: 1.0
- Triangulated: Yes

</details>

<details>
<summary>Dust3D</summary>

### Dust3D Modeling Process

Description of the workflow used in Dust3D.

</details>

<details>
<summary>Wings3D</summary>

### Wings3D Modeling Process

Description of the workflow used in Wings3D.

</details>

<details>
<summary>Maya</summary>

### Maya Modeling Process

Description of the workflow used in Maya.

</details>

[Blender](Blender.md)
