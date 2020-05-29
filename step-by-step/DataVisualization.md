## Interactive Building Data

### description

This exercise will guide you through creating a city based Data visualization app. The building 3D geometries will be imported in Unity and their corresponding data will be read from a [csv](https://en.wikipedia.org/wiki/Comma-separated_values) file. You will then learn how to create data holding classes in order to store the incoming building information and query them at any time during gametime. Finally you will create a user interface that binds everything together and provides an interactive app with layers and object information.

![Image](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/Image%20Links/CityViewer.gif?raw=true)

---

* #### step 1 - import 3D model in Unity
You can find and download the 3D model in the [exercise resources](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/Exercise%20Resources/Exercise_5/sorted_buildings.fbx). Import the 3D model into Unity by dragiing it into the previously created 3D models folder inside your Assets. AFter that you can place it in your Scene. Notice how there is a parent gameobject with nothing but a transform component that contains all the building geometries as children, similar to what we had in the [exercise 4](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/step-by-step/MyFirstManager.md).

* #### step 2 - import csv in StreamingAssets folder
The next step is to import the csv file with all the building data. You can find and download the file from the [exercise resources](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/Exercise%20Resources/Exercise_5/Data_1.csv) We will go to the Assets in the Project Window and create a new folder called **StreamingAssets**, beware that the name is case-sensitive so make sure you copy the name correctly. [StreamingAssets](https://docs.unity3d.com/Manual/StreamingAssets.html) is a special kind of folder that is often used for loading resources that live in your Assets during runtime as we will see further along this exercise. Drag and drop the csv file inside the "StreamingAssets" folder.

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
We are now ready to start writing the code that will handle reading the building data from the csv file. We will create a new c# component named "DataReader" and attach it on the parent gameobject that holds all building geometries. Let's introduce some public variables.

```csharp
public class DataReader : MonoBehaviour
{
    public string csv_name;
    public DataBounds bounds;
    public List<buildingData> Data = new List<buildingData>();
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
```
The first variable is the name of our csv file which we will have to provide to the component from the inspector. The other two variables will diplay the incoming data when we read our csv.

* #### step 5 - include additional libraries
in order to write the method that will be responsible for parsing the csv file, we need to include two additional libraries to our script first. These are "System.IO" and "System.Linq". We do that with the "using" keyword at the top of our script.

it should go from:
```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataReader : MonoBehaviour
{
    public string csv_name;
    public DataBounds bounds;
    public List<buildingData> Data = new List<buildingData>();
    
.....
```
To:
```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// -----> added libraries
using System.IO;
using System.Linq;

public class DataReader : MonoBehaviour
{
    public string csv_name;
    public DataBounds bounds;
    public List<buildingData> Data = new List<buildingData>();
    
.....
```

* #### step 6 - create the csv reader method
We will now start writing the csv reader method. Let's name it "ReadDataFromFile" and defin a few local variables. 
```csharp
void ReadDataFromFile()
{
    buildingData current_data;
    string path;
}
```
In this method we will read the csv as seperate **lines** and then we will iterate through the lines and **split** at the commas ',' to extract the specific data. The **current_data** variable will be used to create new instances of the "BuildingData" class, one for each new line of the csv and then store the instances in the "Data" list of BuildingData we created at the begining of the script. In order to read the csv file first we need to provide the path directory where it is located. We create and store the path in a string variable.
```csharp
void ReadDataFromFile()
{
    buildingData current_data;
    string path;
    
    path = Path.Combine(Application.streamingAssetsPath, csv + ".csv");
}
```
The [Path.Combine()](https://docs.microsoft.com/en-us/dotnet/api/system.io.path.combine?view=netcore-3.1) method essentially combines different string segments and creates a directory path. In our case, we are taking advantage the StreamingAssets folder by extracting its path automatically through the method [Application.streamingAssetsPath](https://docs.unity3d.com/ScriptReference/Application-streamingAssetsPath.html). After that we combine it with tha name of our csv file and the filetype specification ".csv". We are now read to read the selected file. 
```csharp
void ReadDataFromFile()
{
    buildingData current_data;
    string path;
    
    path = Path.Combine(Application.streamingAssetsPath, csv + ".csv");
    string[] file_data = File.ReadAllLines(path);
}
```
The [File.ReadAllLines()](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.readalllines?view=netcore-3.1) method will read the file in the specified directory and will **return** an array of strings as large as the amount of seperate lines in the csv file. We store the resulting array in a local string array variable named file_data. The next step will be to iterate through the lines of csv data and split wherever we find a comma ','.
```csharp
void ReadDataFromFile()
{
    buildingData current_data;
    string path;
    
    path = Path.Combine(Application.streamingAssetsPath, csv + ".csv");
    string[] file_data = File.ReadAllLines(path);
    
    // store the amount of items inside the file_data array
    int line_count = file_data.Length;
    // iterate the items of the file_data array
    for(int i=1; i<line_count; i++)
    {
        // create a new instance of the BuildingData class for each line
        current_data = new BuildingData();
        // split the current string item at every ','
        string[] line_data = file_data[i].Split(',');

        // fille the corresponding values of the current BuildingData instance
        current_data.ID = int.Parse(line_data[0]);
        current_data.height = float.Parse(line_data[1]);
        current_data.c_date = int.Parse(line_data[2]);
        current_data.use = line_data[3];
        // add the completed BuildingData instance to the designated list of BuildingData
        Data.Add(current_data);
    }
}
```
