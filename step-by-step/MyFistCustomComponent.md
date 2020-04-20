## My First C# Component

### description

This exercise will guide you through creating your first custom C# component. This component will be responsible for changing the material of the gameobject it is attached on with the hit of a key from your keyboard. You will be able to switch through the old and the new material by repeatedly hitting the same key.

>

* #### step 1
Create your C# component through Assets>Create>C# Script. Right click your newly created component and hit Edit to open it in Visual Studio. 

* #### step 2
Add two new public variables which will hold the start material and the new material. Name those variables accordingly and hit save. Notice how these two variables have appeared in the Inspector on your new custom component.
```
public class CubeHandler : MonoBehaviour
{
    public Material start_material;
    public Material new_material;
}
```

* #### step 3
The first thing you need to do, is read and store the material your gameobject already has when our app **starts**. For that reason we will write our first piece of code inside the Start() method which is executed **once** when the game begins. In order to access the material of our gameobject we need first to access that component that holds this material. This component is the **MeshRenderer**.

![Image](https://raw.githubusercontent.com/EleanaGrimshaw/unity-basic-training/master/Image%20Links/meshrenderer.JPG)
