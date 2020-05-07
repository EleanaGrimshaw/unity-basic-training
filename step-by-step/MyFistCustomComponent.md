## My First C# Component

### description

This exercise will guide you through creating your first custom C# component. This component will be responsible for changing the material of the gameobject it is attached on with the hit of a key from your keyboard. You will be able to switch through the old and the new material by repeatedly hitting the same key.

![Image](https://raw.githubusercontent.com/EleanaGrimshaw/unity-basic-training/master/Image%20Links/FirstComponent.gif)

---

* #### step 1 - create script
Create a new cube gameobject in your scene. Create your C# component through Assets>Create>C# Script. Attach your new component on the cube gameobject. Right click your newly created component and hit Edit to open it in Visual Studio. 

* #### step 2 - add custom variables
Add two new public variables which will hold the start material and the new material. Name those variables accordingly and hit save. Notice how these two variables have appeared in the Inspector on your new custom component.
```csharp
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
```csharp
void Start()
    {
       start_material = gameObject.GetComponent<MeshRenderer>().sharedMaterial;
    }
```
Notice how we use the word "gameObject" to access the MeshRenderer component. The "gameObject" word refers to the current gameObject instance that our CubeHandler script is attached on. 

* #### step 4 - check user input/first conditional
We said that this component will change the gameobject's material with a hit of a key. Consequently, the next thing we need to do is to check **if** this key has been pressed. We need to be able to perform this check at any point during our game. For that reason we are now going to write inside the Update() method of our gameobject which is executed **once every frame** for as long as our game is running. 
```csharp
 void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            
        }
    }
```
   
This is our first "if" statement. Its job is to check if a condition is met and perform a corresponfing specified action. Its syntax and logic behind it is the following:
```csharp
/// logic behind if statement -- not actual code

if(my condition is TRUE)
{
    do something
}
```
for example we could test
```csharp
int number = 5;

if(number<9)
{
    print("my number is smaller than nine");
}
```

the **else** statement will define what will happen if the condition is not met.
```csharp
int number = 5;

if(number<9)
{
    print("my number is smaller than nine");
}
else
{
    print("my namber is not smaller than nine);
}
```

you can also test multiple cinditions by using the **else if** statement 
```csharp
int number = 5;

if(number<9)
{
    print("my number is smaller than nine");
}
else if(number==9)
{
    print("my number is equal to nine");
}
else
{
    print("my namber larger than nine);
}
```

In our CubeHandler component case, we are testing if the Key "D" was pressed by the user.

   [- see more for Unity Input System](https://docs.unity3d.com/ScriptReference/Input.html)
   
* #### step 5 - change cube material if key was pressed
Similarly to how we stored the cube's existing material inside a Material variable during Start(), we are now going to **set** the cube's material instead. We are going to set it to the new_material.
```csharp
 void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            gameObject.GetComponent<MeshRenderer>().sharedMaterial = new_material;
        }
    }
```
   *Be sure to fill the new_material variable with your desired material in the Inspector window. If the new_material is empty, you will     get an error.*
   
* #### step 6 - interchange between the two materials - second conditional
You will notice that if you play the game, you will be in fact able to change the cube's material to the new_material. However nothing will happen if you keep pressing the "D" key. The next step is to be able to interchange between the two materials. 
We will create a new Material variable called "current_material"
```csharp
public class CubeHandler : MonoBehaviour
{
    public Material start_material;
    public Material new_material;

    Material current_material;
}
```

This variable will be responsible for storing the current material our cobe gameobject has. We adjust our previous code as follows
```csharp
 void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            // get the material the gameobject has now
            current_material = gameObject.GetComponent<MeshRenderer>().sharedMaterial;

            // check if the current material is the new material
            if(current_material == new_material)
            {
                // if it is, we will change the material back to the start_material
                gameObject.GetComponent<MeshRenderer>().sharedMaterial = start_material;
            }
            else
            {
                // if it isn't, we will change the material to the new material
                gameObject.GetComponent<MeshRenderer>().sharedMaterial = new_material;
            }
        }
    }
```
We used an "if...else" statement this time. This means that we defined an action to be executed when our conditional is met and an action to be executed if our conditional is not met. If you save and play the game now you will be able to interchange between the two materials by hitting "D".

* #### step 7 - create a method 
Methods are bits of code that are responsible for performing some action. They can either return a value back or they can be void. We will now enclose our previous code of interchaning materials inside a method. Let's call this method "ChangeMaterial"
```csharp
 public void ChangeMaterial()
 {
     // get the material the gameobject has now
     current_material = gameObject.GetComponent<MeshRenderer>().sharedMaterial;

     // check if the current material is the new material
     if (current_material == new_material )
     {
         // if it is, we will change the material back to the start_material
         gameObject.GetComponent<MeshRenderer>().sharedMaterial = start_material;
     }
     else
     {
         // if it isn't, we will change the material to the new material
         gameObject.GetComponent<MeshRenderer>().sharedMaterial = new_material;
     }
       
 }
 ```
 
 Now we can replace all the code in our Update method that was responsible for the material handling with our new method:
 ```csharp
 void Update()
 {
    if (Input.GetKeyDown(KeyCode.D))
    {
        ChangeMaterial();
    }
 }
```
Methods are very useful for enclosing bits of code that can be reused in various ocasions in our project. This will be further explained in future exercises.
