## Random Cubes

### description

This exercise will guide you through creating your first game manager. The manager will be responsible for generating a specified number of cubes, at random positions withing certain bounds. The user will be able to select any cube and set it as an attractor, the scene manager will then be responsible to color all of the other cubes according to their vicinity to the attractor. The color range will be defined by the user through a specified color gradient. Finally the manager will be responsible for reshuffling the cubes in new random positions with the hit of the "Space" key.

---

* #### step 1 - create the Game Manager
Create an empty gameobject, place it at (0,0,0)and name it GameManager. Placing the manager gameobject at (0,0,0) is important for the parenting constraint as we will see in the following steps of this exercise. Create a custom C# script and name it "CubesManager". Attach the new component to your empty gameobject and open the script in Visual Studio for editing.

* #### step 2 - create public variables 
Our manager is going to need some user defined information that will set certain parameters of its functionality. These parameters refer to the number of generated cubes, the bounds in x, y and z dimension, as well as the cube prefab and the color range gradient. 
```
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
```
for(int i=0; i<cube_count; i++)
{

}
```

Our for loop states that it creates an integer "i" with an initial value equal to 0. It will check in every iteration if this integer is smaller that the desired number of cubes we have set (cube_count) and finally, in every iteration it will increase i by 1. 
```
i++ is equal to i = i + 1
```
Consequently, our for loop will perform a number of iterations equal to the cube_count.

After making sure that we create the desired loop, we need to actually write what we need to be executed in **each iteration**. We need:
1. to generate a random x value between 0 and bounds_x
2. to generate a random y value between 0 and bounds_y
3. to generate a random z value between 0 and bounds_z
4. to create a new cube gameobject
5. to place this new cube in the position (random x, random y, random z)

First we create some variables outside of our for loop that will hold the current x, y, z values in every iteration of the for loop as well as a variable for the position and a counter for the cube naming.
```
public void GenerateRandomCubes()
{
    // create the variables that will hold the random x, y, and z numbers for each position
    float _x;
    float _y;
    float _z;
    Vector3 new_position;
    int counter = 0;
}
```

We continue by writting the code inside our for loof as follows:
```
public void GenerateRandomCubes()
    {
        // create the variables that will hold the random x, y, and z numbers for each position
        float _x;
        float _y;
        float _z;
        Vector3 new_position;
        int counter = 0;

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

            //4. ste the new cube's name
            new_cube.name = "cube_" + counter.ToString();

            //5. make the new cube a child object (parenting constraint) of the Manager Gameobject
            new_cube.transform.SetParent(transform);

            //6. increase counter by 1
            counter++;
        }
    }
```
