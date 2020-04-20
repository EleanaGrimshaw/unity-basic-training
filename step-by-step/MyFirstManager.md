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
