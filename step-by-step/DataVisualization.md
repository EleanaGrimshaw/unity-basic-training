## Interactive Building Data

### description

This exercise will guide you through creating a city based Data visualization app. The building 3D geometries will be imported in Unity and their corresponding data will be read from a csv file. You will then learn how to create data holding classes in order to store the incoming building information and query them at any time during gametime. Finally you will create a user interface that binds everything together and provides an interactive app with layers and object information.

![Image](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/Image%20Links/CityViewer.gif?raw=true)

---

* #### step 1 - import 3D model in Unity
You can find and download the 3D model in the [exercise resources](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/Exercise%20Resources/Exercise_5/sorted_buildings.fbx). Import the 3D model into Unity by dragiing it into the previously created 3D models folder inside your Assets. AFter that you can place it in your Scene. Notice how there is a parent gameobject with nothing but a transform component that contains all the building geometries as children, similar to what we had in the [exercise 4](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/step-by-step/MyFirstManager.md).

* #### step 2 - import csv in StreamingAssets folder
The next step is to import the csv file with all the building data. We will go to the Assets in the Project Window and create a new folder called **StreamingAssets**, beware that the name is case-sensitive so make sure you copy the name correctly. [StreamingAssets](https://docs.unity3d.com/Manual/StreamingAssets.html) is a special kind of folder that is often used for loading resources that live in your Assets during runtime as we will see further along this exercise. 

* #### step 3 - create data storing classes
Before jumping into the script responsible for loading and reading the csv, we will first create two custom class that will be responsible for holding the data related to each building. These classes will be named "BuildingData" and "DataBounds" respectively. Our new classes will not inherit from the MonoBehaviour base class as is the default setting because we are not interested in them having any Unity-related functionality but instead we need them merely to store some data.

The first class will look like that:
```csharp
[System.Serializable]
public class BuildingData 
{
    public int ID;
    public float height;
    public int c_date;
    public string use;
}
```
And the second like that
```csharp
[System.Serializable]
public class DataBounds 
{
    public float max_height;
    public float min_height;
    public int max_age;
    public int min_age;
}
```
Since we did not inherit from Monobehaviour, We are using the [System.Serializable] [attribute](https://docs.unity3d.com/Manual/Attributes.html) in order to ensure [serialization](https://docs.unity3d.com/Manual/script-Serialization.html) for our classes. In general, serialization is the automatic process of transforming data structures or object states into a format that Unity can store and reconstruct later. In simple words, we need this attribute to be able to see these classes in the inspector as you find out further down this exercise. 

* #### step 4 - create a script for data reading
We are now ready to start writing the code that will handle reading the building data from the csv file. We will create a new script named "DataReader" and attach it on the parent gameobject that holds all building geometries. 
