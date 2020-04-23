# Unity basic training
**Author:** 

Eleana Polychronaki

**Platform:**

Unity 2019.3

**Resources:**
* [Unity Manual (2019.3)](https://docs.unity3d.com/Manual/index.html)
* [Unity Scripting API (2019.3)](https://docs.unity3d.com/ScriptReference/index.html)
* [Unity Learn](https://learn.unity.com/)
* [Microsoft .Net C# Documentation](https://docs.microsoft.com/en-us/dotnet/)
* [Geeks For Geeks](https://www.geeksforgeeks.org/)

**Excercises:**
1. My First Scene
2. MeshFilter & MeshRenderer
3. [My First Custom Component](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/step-by-step/MyFistCustomComponent.md)
4. [My First Game Manager](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/step-by-step/MyFirstManager.md)

## description
This repository provides a guide for the basics of Unity3D.

## contents
**introduction**
* [what is unity](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/README.md#what-is-unity)
* [getting started](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/README.md#getting-started)

**level 1 (exercises 1 & 2)**
* [basic elements](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/README.md#basic-elements)
* [the scene](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/README.md#the-scene)
* [geometry in Unity](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/README.md#geometry-in-unity)
* physics
* rendering

**level 2 (exercises 3 & 4)**
* [custom C# components](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/README.md#custom-c-components)

**level 3 (exercise 5)
* Unity UI

---
---



## what is Unity?
Unity is a cross-platform game engine created by Unity Technologies. It can be used to create both 2D and 3D games, as well as, simulations, immersive experiences and a variety of other apps. Although it is originally a tool to make games it is being used in a variety of other industries including film, engineering, architecture and construction.

## getting started

![Image](https://docs.unity3d.com/uploads/Main/Editor-Breakdown.png)

### - [User Interface](https://docs.unity3d.com/Manual/UsingTheEditor.html)

The first time you open Unity there is a list of things you need to look into. The first step will be to familiarize yourself with the user interface and more specifically what are the components that constitute it. Make sure you understand your distinct workspaces: the [project window](https://docs.unity3d.com/Manual/ProjectView.html), the [hierarchy window](https://docs.unity3d.com/Manual/Hierarchy.html), the [inspector window](https://docs.unity3d.com/Manual/UsingTheInspector.html), as well as the [scene view](https://docs.unity3d.com/Manual/UsingTheSceneView.html) and the [game view](https://docs.unity3d.com/Manual/GameView.html). 

### - [Build Settings](https://docs.unity3d.com/Manual/BuildSettings.html)

The next thing you need to remember is that Unity can produce applications that run in a variety of platforms. According to your desired target platform, you might need to pay special attention to some of the project settings. If you know what platform you are building for, make sure you set it as target at the begining of your project and then configure the corresponding settings.

### - [Project Settings](https://docs.unity3d.com/Manual/comp-ManagerGroup.html)

The project settings are a variety of settings that give you the opportunity to customize your project. When you select the target platform of your project the default settings that go with it are quite balanced to get you started, however you might wanna adjust a few things according to your specific needs. The most common settings to adjust are the [player settings](https://docs.unity3d.com/Manual/class-PlayerSettings.html), the [quality settings](https://docs.unity3d.com/Manual/class-QualitySettings.html) and the [physics settings](https://docs.unity3d.com/Manual/class-PhysicsManager.html).

### - [Unity Assets](https://docs.unity3d.com/Manual/AssetTypes.html)

An Asset is a representation of any item you can use in your Project. Such items can either be imported into Unity after having being created in another software/platform or they can be provided from or created within Unity.

## basic elements
### - [Gameobjects](https://docs.unity3d.com/Manual/class-GameObject.html)

The Gameobject is the most important concept in Unity as **all** objects in your game are gameobjects. However the gameobjects are nothing on their own. They need to be described by a set of properties that define what they are (characters, lights, UI elements) and what they can do. These properties are called **componets** and different combinations of them constitute discrete kinds of gameobjects. 

### - [Components](https://docs.unity3d.com/Manual/UsingComponents.html)

Componets are the functional pieces of Unity that make things happen. Every Gameobject is in essence a container for components that will define its being and behaviour. The most essential component is the [transform](https://docs.unity3d.com/Manual/Transforms.html) component. That is because this component defines the existence of a gameobject in space. It gives information about its location, rotation and scale, without such information the gameobject would not exist at all. For this reason every gameobject has a tranform component attached upon creation. Other than that, unity provides a wide variety of components that you can use, however it is quite common to create your own custom components using [scripts](https://docs.unity3d.com/Manual/CreatingAndUsingScripts.html).  

### - [Constraints](https://docs.unity3d.com/Manual/Constraints.html)

Sometimes it is useful to **link** different gameobjects together. The constraints are a set of components and methods that enable this linking. The most popular constraints are the [parent](https://docs.unity3d.com/Manual/class-ParentConstraint.html) and the [look at](https://docs.unity3d.com/Manual/class-LookAtConstraint.html).

### - [Prefabs](https://docs.unity3d.com/Manual/Prefabs.html)

When you have configured and customized a gameobject, adding components and properties according to the needs of your project, Unity gives you the opportunity to store that particular gameobject as an asset. This particular type of asset is called a Prefab. Prefabs are very useful because not only do they allow you to easily generate numerous instances of the same object, but also all of the instances hold a reference to the original prefab. In this way if you change something in the original, all instances will change accordingly.  

## the scene
The [scene](https://docs.unity3d.com/Manual/CreatingScenes.html) represents somewhat of a level in your game. It contains all the elements that define your project for this specific level: gameobjects, environments, UI elements, special effects etc. One Unity project can contain main scenes, but you only have one active scene at a time on which you can work. However, your built app can contain a sequence of scenes that the player/user movers through. 
Every scene has by default a camera and a light. These are the essential elements that you need to get started.

### - [Camera](https://docs.unity3d.com/Manual/class-Camera.html)

The camera is a gameobject that is responsible for what the player/user sees in the app. For this reason you need **at least one** active camera gameobject on your scene. You can have an unlimited number of cameras in one scene and you can set them to render various things. 

### - [Lights](https://docs.unity3d.com/Manual/Lighting.html)

In order to calculate the shading of a GameObject that is affected by lighting, Unity needs to know the intensity, direction, and color of the light that falls on it. Lights will be further explained in the rendering section of this document.

## geometry in Unity

![Image](https://brainfoolong.github.io/unity-procedural-mesh-bezier-curve/screenshot-1.jpg)

The main graphics primitive that Unity uses in order to render geometry is the **mesh**. In order to actually see a geometry in your game you need to attach two components to your gameobject, the [mesh filter](https://docs.unity3d.com/Manual/class-MeshFilter.html) and the [mesh renderer](https://docs.unity3d.com/Manual/class-MeshRenderer.html). The first is responsible for holding the mesh data of your model and provide it to the second, which will in turn be responsible for actually rendering the geometry in your screen. 
**[see more](https://learn.unity.com/tutorial/geometry-in-unity)**

### - [imported geometry](https://docs.unity3d.com/Manual/ImportingModelFiles.html)

When importing geometries from other software, depending on their format, Unity automatically creates an asset that holds the necessary information (mesh, materials, colors) and creates a gameobject that already has the corresponding mesh filter and mesh renderer components attached. You have the opportunity to change some of the geometry properties when importing it through the [import settings window](https://docs.unity3d.com/Manual/class-FBXImporter.html).

> Exercises 1 & 2

## custom C# components

### - [C# essentials](https://docs.microsoft.com/en-us/dotnet/csharp/)
* [Variables](https://docs.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/types-and-variables)
* [Methods](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/methods)
* [Classes](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/classes)
* [Loops](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/for)
* [Conditionals](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/if-else)

![Image](https://raw.githubusercontent.com/EleanaGrimshaw/unity-basic-training/master/Image%20Links/class2.jpg)

### - [Monobehaviour](https://docs.unity3d.com/ScriptReference/MonoBehaviour.html)
* [Start](https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html)
* [Update](https://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html)

### - [Input System](https://docs.unity3d.com/ScriptReference/Input.html)

Unity provides a series of methods through which you can easily check if various inputs of your computer (and other devices) have been interacted with. Such devices can be your [mouse position](https://docs.unity3d.com/ScriptReference/Input-mousePosition.html), the [mouse buttons](https://docs.unity3d.com/ScriptReference/Input.GetButtonDown.html) as well as any [key](https://docs.unity3d.com/ScriptReference/Input.GetKeyDown.html) in your keyboard.

### - Interact with Gameobjects

![Image](https://www.lucedigitale.com/blog/wp-content/uploads/2014/01/unity-raycasting.jpg)

Another popular way of triggering things in Unity is to detect the interaction of the user with the scene's gameobjects. This is possible through [raycasting](https://docs.unity3d.com/ScriptReference/Physics.Raycast.html). The way this works is by casting a ray from a certain position in space towards a certain direction and for a set distance and checking if this ray hit any collider objects. The raycast itself is a boolean which means it returns true or false depending on whether it found a collision, but it also allows access to other properties of the collison through the [Raycasthit](https://docs.unity3d.com/ScriptReference/RaycastHit.html) such as the hitting point, the distance form the origin etc.

### - Game Managers

It is very common in Unity projects to create one or more Game Managers. These are usually empty gameobjects that have custom components which hold and handle general game information and are responsible for performing some global actions.
[see more in excercise 4](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/step-by-step/MyFirstManager.md).
