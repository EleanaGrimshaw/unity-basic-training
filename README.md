# Unity basic training
Author: Eleana Polychronaki

## description
This repository provides a guide for the basics of Unity3D.

## what is Unity?
Unity is a cross-platform game engine created by Unity Technologies. It can be used to create both 2D and 3D games, as well as, simulations, immersive experiences and a variety of other apps. Although it is originally a tool to make games it is being used in a variety of other industries including film, engineering, architecture and construction.

## getting started
### - [User Interface](https://docs.unity3d.com/Manual/UsingTheEditor.html)

The first time you open Unity there is a list of things you need to look into. The first step will be to familiarize yourself with the user interface and more specifically what are the components that constitute it. Make sure you understand your distinct workspaces: the [project window](https://docs.unity3d.com/Manual/ProjectView.html), the [hierarchy window](https://docs.unity3d.com/Manual/Hierarchy.html), the [inspector window](https://docs.unity3d.com/Manual/UsingTheInspector.html), as well as the [scene view](https://docs.unity3d.com/Manual/UsingTheSceneView.html) and the [game view](https://docs.unity3d.com/Manual/GameView.html). 

### - [Build Settings](https://docs.unity3d.com/Manual/BuildSettings.html)

The next thing you need to remember is that Unity can produce applications that run in a variety of platforms. According to your desired target platform, you might need to pay special attention to some of the project settings. If you know what platform you are building for, make sure you set it as target at the begining of your project and then configure the corresponding settings.

### - [Project Settings](https://docs.unity3d.com/Manual/comp-ManagerGroup.html)

The project settings are a variety of settings that give you the opportunity to customize your project. When you select the target platform of your project the default settings that go with it are quite balanced to get you started, however you might wanna adjust a few things according to your specific needs. The most common settings to adjust are the [player settings](https://docs.unity3d.com/Manual/class-PlayerSettings.html), the [quality settings](https://docs.unity3d.com/Manual/class-QualitySettings.html) and the [physics settings](https://docs.unity3d.com/Manual/class-PhysicsManager.html).

## the basics
### - [Gameobjects](https://docs.unity3d.com/Manual/class-GameObject.html)

The Gameobject is the most important concept in Unity as **all** objects in your game are gameobjects. However the gameobjects are nothing on their own. They need to be described by a set of properties that define what they are (characters, lights, UI elements) and what they can do. These properties are called **componets** and different combinations of them constitute discrete kinds of gameobjects. 

### - [Components](https://docs.unity3d.com/Manual/UsingComponents.html)

Componets are the functional pieces of Unity that makes things happen. Every Gameobject is in essence a container for components that will define its being and behaviour. The most essential component is the [transform](https://docs.unity3d.com/Manual/class-Transform.html) component. That is because this component defines the existence of a gameobject in space. It gives information about its location, rotation and scale, without such information the gameobject would not exist at all. For this reason every gameobject has a tranform component attached upon creation. 

