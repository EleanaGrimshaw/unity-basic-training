## Random Cubes

### description

This exercise will guide you through creating your first game manager. The manager will be responsible for generating a specified number of cubes, at random positions withing certain bounds. The user will be able to select any cube and set it as an attractor, the scene manager will then be responsible to color all of the other cubes according to their vicinity to the attractor. The color range will be defined by the user through a specified color gradient. Finally the manager will be responsible for reshuffling the cubes in new random positions with the hit of the "Space" key.

![Image](https://raw.githubusercontent.com/EleanaGrimshaw/unity-basic-training/master/Image%20Links/RandomCubes.gif)

---

* #### step 1 - create the Game Manager
Create an empty gameobject, place it at (0,0,0)and name it GameManager. Placing the manager gameobject at (0,0,0) is important for the parenting constraint as we will see in the following steps of this exercise. Create a custom C# script and name it "CubesManager". Attach the new component to your empty gameobject and open the script in Visual Studio for editing.

* #### step 2 - create public variables 
Our manager is going to need some user defined information that will set certain parameters of its functionality. These parameters refer to the number of generated cubes, the bounds in x, y and z dimension, as well as the cube prefab and the color range gradient. 
```csharp
public class CubesManager : MonoBehaviour
{

    public GameObject cube_prefab;
    public Gradient color_range;

    public int cube_count;
    public float bounds_x;
    public float bounds_y;
    public float bounds_z;
    
}
```
This variables will be set from the Inspector

![Image](https://raw.githubusercontent.com/EleanaGrimshaw/unity-basic-training/master/Image%20Links/public%20variables.JPG)

* #### step 3 - Create a method to generate cubes
As seen in the previous example, it is useful and tidy to enclose pieces of code responsible for performing certain actions in methods. In this case, we will create a method that will be responsible to spawn a number of cubes in random locations within the given bounds. Let's call this method "GenerateRandomCubes".

Because we will generate a number of cubes (=cube_count), we will need to write a **[for loop](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/for)**. Essentially what a for loop does is to execute a block of code for a specific number of times. I order to define the number of times (or else iterations) we need to define and initialization value, a condition that needs to be met and an iterator. In our case, the for loop will be written as follows.
```csharp
for(int i=0; i<cube_count; i++)
{

}
```

Our for loop states that it creates an integer "i" with an initial value equal to 0. It will check in every iteration if this integer is smaller that the desired number of cubes we have set (cube_count) and finally, in every iteration it will increase i by 1. 
```csharp
// i++ is equal to i = i + 1
```
Consequently, our for loop will perform a number of iterations equal to the cube_count.

After making sure that we create the desired loop, we need to actually write what we need to be executed in **each iteration**. We need:
1. to generate a random x value between 0 and bounds_x
2. to generate a random y value between 0 and bounds_y
3. to generate a random z value between 0 and bounds_z
4. to create a new cube gameobject
5. to place this new cube in the position (random x, random y, random z)

First we create some variables outside of our for loop that will hold the current x, y, z values in every iteration of the for loop as well as a Vector3 variable for the position.
```csharp
public void GenerateRandomCubes()
{
    // create the variables that will hold the random x, y, and z numbers for each position
    float _x;
    float _y;
    float _z;
    Vector3 new_position;
}
```

We continue by writting the code inside our for loof as follows:
```csharp
public void GenerateRandomCubes()
    {
        // create the variables that will hold the random x, y, and z numbers for each position
        float _x;
        float _y;
        float _z;
        Vector3 new_position;

        // for loop to iteratate cube number and create random x,y and z values for each new cube's position;

        for(int i=0; i<cube_count; i++)
        {
            _x = Random.Range(0, bounds_x);
            _y = Random.Range(0, bounds_y);
            _z = Random.Range(0, bounds_z);

            new_position = new Vector3(_x, _y, _z);

            //1. Instantiate a new cube from the referenced prefab
            GameObject new_cube = Instantiate(cube_prefab);

            //2. place the new cube in the random position that was juast created
            new_cube.transform.position = new_position;

            //3. set the new cube scale to one
            new_cube.transform.localScale = Vector3.one;

            //4. set the new cube's name
            new_cube.name = "cube_" + counter.ToString();

            //5. make the new cube a child object (parenting constraint) of the Manager Gameobject
            new_cube.transform.SetParent(transform);

        }
    }
```
First we creat the random values for x, y and z and created a Vector3 which would be the position of the new cube. Then we create a new instance of our cube [prefab](https://docs.unity3d.com/Manual/Prefabs.html) using the [Instantiate](https://docs.unity3d.com/ScriptReference/Object.Instantiate.html) method of the Object class. We set the Vector3 we created as the position of the new cube and we set its scale to a uniform (1,1,1). We name our new object using the value of our iterator i. Finally, we make the new cube gameobject a **child** of the current Transform which is the one attached to our manager gameObject.

![Image](https://raw.githubusercontent.com/EleanaGrimshaw/unity-basic-training/master/Image%20Links/hierarchy_parenting.jpg)

You can see in the Hierarchy view the difference between having the new cubes as children of the manager (left) or as standalone gameobjects (right).

We can now call our GenerateRandomCubes() method on Sart() and hit play. 
```csharp
void Start()
{
    // call cube generating method
    GenerateRandomCubes();
}
```

![Image](https://raw.githubusercontent.com/EleanaGrimshaw/unity-basic-training/master/Image%20Links/random%20cubes.JPG)

* #### step 4 - define attractor cube
The next step is to enable the player to **select** the attractor among all these random cubes. We will achieve this through a process called raycasting. [Raycasting](https://docs.unity3d.com/ScriptReference/Physics.Raycast.html) is part of the built in physics engine that unity has and it enables us to cast a ray from a given point in space, towards a given direction and check if this ray collided with any objects in the scene. 

In our random cubes example, we want to be able to tell which cube the player selected with his/her mouse. In order to be able to do that we will implement a very useful method available in the Camera class called [ScreenPointToRay](https://docs.unity3d.com/ScriptReference/Camera.ScreenPointToRay.html). This method creates a ray that starts from the camera and goes towards the 3D scene through a specific location in the screen. 

![Image](https://dpzbhybb2pdcj.cloudfront.net/hocking2/Figures/c03-2.png)

We will define this specific location on the screen to be the position that the mouse has when we click the mouse's left button. 

```csharp
// create Ray variable which will hold the ray from mouse position towards the scene on left-click
Ray ray;

void Update()
{
    // Raycasting to interact with generated cubes and point out the attractor point
    if (Input.GetMouseButtonDown(0) == true)
    {
        //1. create ray from mouse position - transform screen position where our mouse is to a ray towards our scene
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}
```
Similar to the way we detected if a key has been pressed, we check if the player has clicked the [left mouse button](https://docs.unity3d.com/ScriptReference/Input.GetMouseButtonDown.html). If this condition is met we move forward into creating a ray that begins from the mouse position and goes straight into the 3D space of our scene. 
The next step is to actually test if this ray hit an object. 
```csharp
// create Ray variable which will hold the ray from mouse position towards the scene on left-click
Ray ray;
// create RaycastHit variable that will hold the raycasting data from the collision with an object
RaycastHit hit;
// create a GameObject variable that will hold the selected attractor cube
GameObject attractor;

void Update()
{
    // Raycasting to interact with generated cubes and point out the attractor point
    if (Input.GetMouseButtonDown(0) == true)
    {
        //1. create ray from mouse position - transform screen position where our mouse is to a ray towards our scene
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out hit, Mathf.Infinity) == true)
        {
            // find out which object was hit, this cube will be our attractor
            attractor = hit.transform.gameObject;
            print("hit "+ attractor.name);
        }
        else
        {
            print("no objects were hit");
        }
    }
}
```
The Raycast method has many [overloads](https://www.geeksforgeeks.org/c-sharp-method-overloading/), the one which is more suitable for our case takes:
1. the ray that we constructed for the mouse position on the screen
2. a RaycastHit variable that will hold all the information in case of a collision with some object passed with the [out parameter](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/out-parameter-modifier)
3. the maximum distance this ray will travel

The code above, will store the selected gameobject inside the attractor variable if the ray collides with a cube and will print in the [console](https://docs.unity3d.com/Manual/Console.html) the name of the cube it collided with. Otherwise it will just print that the ray did not hit any objects.

![Image](https://raw.githubusercontent.com/EleanaGrimshaw/unity-basic-training/master/Image%20Links/raycasting.gif)

* #### step 5 - color cubes based on vicinity to attractor
This step requires two sub-steps, the first is to calculate the distance that each of the cubes has from the current attractor and the 
second is to change the color accordingly. We will do the first step inside out CubesManager script and we will do the second step inside our CubeHandler script that the cube prefab already has attached. 

![Image](https://raw.githubusercontent.com/EleanaGrimshaw/unity-basic-training/master/Image%20Links/prefab2.JPG)

We start by creating a new method in our CubesManager component that we will call "DistanceFromAttractor". This method will take two parameters:
1. a GameObject parameter which will be the current attractor gameobject
2. a float parameter which will be the maximum distance two cubes can have with each other. (we can calculate this, but for the moment we will just set it by approximation)

We will then create some variables that will store the data that we need during the iterations.
```
GameObject current;
Vector3 current_pos;
Vector3 attractor_pos;
Color current_color;

float distance;
float color_t;
```
