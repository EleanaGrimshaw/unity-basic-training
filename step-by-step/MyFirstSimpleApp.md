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

* #### step 3 - creating a new gameObject
The next step is to create a new gameobject in our Hierarchy using one of unity's primitive gameobjects, the sphere. We can create it either by right-clicking in an empty space on our hierarchy window and do 3D Object>Sphere or through the Menu Bar GameObject>3D Object>Sphere. Make sure that you place your sphere gameobject somewhere above the imported geometry.

* #### step 4 - adding the physics components
We want to add a **behaviour** in our sphere gameobject that will be responsible for making it responsive to gravity. In this way when we play our game, the sphere will **drop** and **collide** with the imported gameobject that lies below it. 

![Image](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/Image%20Links/rollingSphere.gif?raw=true)

In order to achive this behaviour we will need two components the **Rigidbody** and the **Collider**. Thi first is responsible for enabling physical behaviour for a GameObject, meaning that with a Rigidbody attached, the object will immediately respond to gravity.

We can add any new component to a selected gameobject by clicking the "Add Component" button at the bottom of the Inspector window and typing its name. For this exercise we will search and add the **Rigidbody** component. As you can see this component has some properties that will define the physical behaviour of the gameobject, such as it's mass and if it will react to gravity. We don't need to change any of the default values for our example.

![Image](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/Image%20Links/rigid.JPG?raw=true)

The next component that we need is a **Collider**. Collider components define the shape of a GameObject for the purposes of physical collisions. A collider, which is invisible, does not need to be the exact same shape as the GameObject’s mesh. The simplest colliders are primitive collider types. In 3D, these are the Box Collider, Sphere Collider and Capsule Collider. Since we created a Sphere primitive gameobjects, it has by default a **Sphere Collider** component attached so we won't need to add a collider manually.

Apart from the primitive colliders, we also have the **Mesh Collider**. Upon importing geometry, if we enable the **Generate Colliders** option (as we did in the previous step), we make sure that the geometry will come with colliders that reflect the mesh geometry. You can see a gameobject's collider, as alight green wireframe, by turning off its Mesh Renderer component. 

![Image](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/Image%20Links/colliders.JPG?raw=true)

* #### step 5 - add physics material
In order to be able to enhance the reaction of a gameobject to collisions we can also add a **[Physics Material](https://docs.unity3d.com/Manual/class-PhysicMaterial.html)**. The physics materials are responsible for adjusting the friction and bouncing effects of colliding objects. 

We will create a new folder inside our Assets, in the project window named "Materials", where we will store all the materials of this project. Inside this folder we will create a new physics material, either by right clicking on aan empty space inside the project window and do Create>Physic Material, or through the Menu Bar Asset>Create>Physic Material. Because we want our sphere to be quite bouncy we will adjust the new material as follows.

![Image](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/Image%20Links/physicmat.JPG?raw=true)

After creating the material we will add it to the **Material** property of the **Sphere Collider** component. We do this by dragging the material to the empty field next to the Material property.

![Image](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/Image%20Links/Bounce-ball.gif?raw=true)

* #### step 6 - create prefab & generate instances
Now that we have configured our sphere gameobject to have all the desired behaviours we can "save" it as a template and reuse it to create multiple instances. In other words we will turn our shpere gameobject into a [prefab](https://docs.unity3d.com/Manual/Prefabs.html). Create a folder in your Assets named "Prefabs" and drag the sphere gameObject from the Hierarchy window in that folder. You will see that the gameobject will automatically turn blue on your Hierarchy. Now let's add twelve instances of the prefab to our Scene by draging the prefab from the Assets back to the Hierarchy. 

![Image](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/Image%20Links/Add-prefabs.gif?raw=true)

* #### step 7 - adjust color space (optional)
Before jumping into rendering, lights and materials, we should change the project's colorspace from Gamma to Linear. Working in linear color space gives more accurate rendering than working in gamma color space. This option lies in the projects settings which you can access from Menu Bar>Edit>Project Settings. In the window that pops up you should go to the **Player** settings look for the tab tha says **Other Settings**. If for some reason the Linear option is greayed out in the **Color Space** dropdown you can bypass this step.

![Image](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/Image%20Links/colorSpace.JPG?raw=true)

* #### step 8 - create custom skybox
In this step, we will learn how to create a custom skybox from an HDRI image and use it to replace Unity's default skybox. 
