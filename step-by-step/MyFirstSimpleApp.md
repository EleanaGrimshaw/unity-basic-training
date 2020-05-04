## Space Spheres

### description

This exercise will guide you through importing a geometry into Unity and creating a simple app with the available physics components. It will also focus on the basics of rendering including lights, materials and post-processing effects.

![Image](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/Image%20Links/FirstUnityGame.gif?raw=true)

---

* #### step 1 - import geometry
Create a new folder in your Assets named "3D models". This is where we will save all imported geometries. Drag and drop your desired 3D model inside the folder. Unity can import 3D geometry in a number of different [file formats](https://docs.unity3d.com/Manual/3D-formats.html), we will be importing an fbx file for this exercise as it is one of the most common ones. 

As soon as you import the geometry file, you will see that Unity automatically creates a prefab asset that holds all the relevant information for it. If you click on the asset you will see in your inspector the model [import settings](https://docs.unity3d.com/Manual/FBXImporter-Model.html).

![Image](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/Image%20Links/importingnew.JPG?raw=true)

The most important setting when importing external geometries it to make sure that the scale is correct. Unity's default unit system is in **meters** and it provides you with two options in order to adjust your model to the correct scale. You can either let unity automatically convert your file's units to the meter equivalent with the **Convert Units** option or manually perform a uniform scale on your model though the **Scale Factor** option.

Similarly important is to define whether your imported geometries will have colliders or not. As we will explain further down, **colliders** are very important components when it comes to using Unity's physics engine. We will enable the option **Generate Colliders** as we will be using physics for this exercise. 

When we clarify the desired import settings we click **Apply** on the bottom right of the import settings tab. We can then use our model either by dragging it into the hierarchy tab or straight into the scene. We can adjust the transform component and configured the desired position, rotation and scale.

* #### step 2 - parenting constraints
You will see in the Hierarchy tab that the gameobject with the imported model has some sort of nesting. This means that a **parent** gameobject contains all of the geometries contained in our imported file as **children** gameobjects. Parenting is a very important concept in Unity and the most common way to group gameobjects and create some global transform constraints. Essentially the children gameobjects are bound to the transform of the parent.This means that the transform components of the children gameobjects, now contain **local** values that refer to the parent gameobject and not the world system. 

* #### step 3 - adding physics components

