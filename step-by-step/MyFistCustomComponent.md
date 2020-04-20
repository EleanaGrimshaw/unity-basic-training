## My First C# Component

### description

This exercise will guide you through creating your first custom C# component. This component will be responsible for changing the material of the gameobject it is attached on with the hit of a key from your keyboard. You will be able to switch through the old and the new material by repeatedly hitting the same key.

>

* #### step 1 - create script
Create your C# component through Assets>Create>C# Script. Right click your newly created component and hit Edit to open it in Visual Studio. 

* #### step 2 - add custom variables
Add two new public variables which will hold the start material and the new material. Name those variables accordingly and hit save. Notice how these two variables have appeared in the Inspector on your new custom component.
```
public class CubeHandler : MonoBehaviour
{
    public Material start_material;
    public Material new_material;
}
```

* #### step 3 - read and store existing material
The first thing you need to do, is read and store the material your gameobject already has when our app **starts**. For that reason we will write our first piece of code inside the Start() method which is executed **once** when the game begins. In order to access the material of our gameobject we need first to access that component that holds this material. This component is the **MeshRenderer**.

![Image](https://raw.githubusercontent.com/EleanaGrimshaw/unity-basic-training/master/Image%20Links/meshrenderer.JPG)

We can get and store the material of the current gameobject like that:
```
void Start()
    {
       start_material = gameObject.GetComponent<MeshRenderer>().sharedMaterial;
    }
```
Notice how we use the word "gameObject" to access the MeshRenderer component. The "gameObject" word refers to the current gameObject instance that our CubeHandler script is attached on. 

* #### step 4 - check user input/first conditional
We said that this component will change the gameobject's material with a hit of a key. Consequently, the next thing we need to do is to check **if** this key has been pressed. We need to be able to perform this check at any point during our game. For that reason we are now going to write inside the Update() method of our gameobject which is executed **once every frame** for as long as our game is running. 
```
 void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            
        }
    }
```
   [- see more for Unity Input System](https://docs.unity3d.com/ScriptReference/Input.html)
   
This is our first "if" statement. Its job is to check if a condition is met and perform a corresponfing specific action. Its syntax and logic behind it is the following:
```
if(my condition)
{
    do something
}
```
for example we could test
```
int number = 5;
if(number<9)
{
    print("my number is smaller than nine");
}
