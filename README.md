# 3D-modelling-in-games
3D modeling has greatly influenced the gaming experience and has become an important aspect of game development. The possibilities of 3D modeling are limitless, from modeling characters, objects, environments to models of entire universes.

Game Object Model: Barrel

Blender

Start with the Barrels Lids.

(Shift + A -> Mesh -> Circle)

Open Edit Mode and Select Mode: Vertex.

(Tab -> 1)

Select 2 Vertices using the Select Tool and connect them.

Hold Shift Or just drag the select tool trough both Verticies -> Press F to connect them.

Now using this method we create a foundation for the barrels lid.

We connect the other vertices to create a desired lid looking pattern.

Select everything and fill it.

Press A to select everything -> press F to fill in the faces.

Now we have a filled circle and need to give it some volume.

We do that by applying the Solidify Modifier.

We add some thickness to it.

In order to apply the modifier we have to make sure we are in the Object Mode and then we can apply it.

Now we have a lid looking model but we need to add some details.

We do that by Changing the Select Mode to Edges and selecing all the Edges we want to modify and add detail to.

Then we select the Tool Bevel and make our desired depth of detail by dragging the yellow handle up or down.

If we want to modify the lenght more precisely we open the Bevel menu that poped up in the corner once we let go of the handle.

We set the Width to a desired one and we just click else where.

Now that we have it we just remove the faces by changing the mode to Select Mode Face, select all the parts we just created and remove them.

Press X and select Faces.

Now we Separate each section of the lid into separate parts in order later to apply texture correctly.

We do that by selecting a section we want to make into a separate part and pressing P -> Separate by Selection.

Now that we have the whole Lid separated into separate pieces, we can select all the parts and everything in edit mode and hit F to connect the holes automatically and easily.

Now we can add the textures.

I downloaded and used these free textures:
https://ambientcg.com/view?id=Wood035
https://ambientcg.com/view?id=Metal052C

We select all the parts and add a new Material.

We can rename the newly added material.

We switch to the Shading workspace.

We make sure we have the add-on Node Wrangler in Edit -> Preferances -> Add-ons -> Node Wrangler and we check it.

We select the Principled BSDF and click Ctrl + Shift + T.

In the menu we select everything that was inside the zip that we unpacked and click Principled texture setup.

It will automatically do everything and we can switch then later to the Layout workspace.

If the material wasn't already on all our object we will add it.

Now we see it's brown but not really wood looking, thats because we need to fix the UV Unwraping.

We do it by selecting all the objects, going to Edit mode and right clicking on the object and selecting UV Unwraping Faces and selecting Smart UV Project.

We change Angle Limit and Rotation Method into our desired values, I found the 89 degrees and Axis-aligned (Horizontal) to be the best looking, then we click Unwrap.

Now our lid looks much better.

We can create a new Collection and put our object into it, making the project more organized.

We can also hide the new collection with the eye icon as we won't be needing it and would be in our way.

Now we go for making the body of the barrel.

It's fairly simple and pretty much the same as creating the lid just vertically.

We start by adding a new Circle.

Shift + A -> Mesh -> Circle.

We go in edit mode, select mode edges, select all (A) and press E to extrude it to a desired hight of the barrel.

We add the modifier Solidify and set our desired Thickness, we change the offset to 0 and check Even Thickness.

Objects: 
Vertices: 
Edges: 
Faces: 
Triangles: 
