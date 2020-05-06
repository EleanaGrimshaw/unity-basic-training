## User interaction through UI buttons

### description

In this exercise we will have a look into unity’s UI elements and how we can create User Intefaces. More specifically we will create two buttons that will activate two different functionalities. The first button will take the random cubes and position them onto grid defined positions. The second button will trigger the reshuffling method we wrote in the previous exercise. 

![Image](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/Image%20Links/UI_cubes_high.gif?raw=true)

---

* #### step 1 - create the Canvas
The first item that is needed when we want to create a user interface is the **Canvas**. The [Canvas](https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/UICanvas.html) is the area that all UI elements should be inside. It is a gameobject with a Canvas component on it, and all UI elements must be children of such a Canvas. We can create a new Canvas by right-clicking in the Hierarchy window and do UI>Canvas, or we can go to the Menu bar and do GameObject>Create>Canvas. 

You will notice that apart from the Canvas gameobject that we created, another gamobject appeared in the Hierarchy window as well named **EventSystem**. The [Event System](https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/EventSystem.html) is a gameobject that consists of a few components responsible for sending events. In other words the Event System provides way of sending events to objects in the application based on input, be it keyboard, mouse, touch, or custom input. If you wish to create a User interface in your application you need an Event System, otherwise the UI elements won't work. 

The Canvas appears on the Scene view as a a rectangle, making it easier to position UI elements without having to jump to the Game View. There are three different distinct ways of **rendering** a Canvas object as seen in the [documentation](https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/UICanvas.html). For the purposes of this exercise we will use the **Screen Space-Overlay**  mode which places UI elements on the screen rendered on top of the scene. 

![Image](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/Image%20Links/screen%20space.JPG?raw=true)

* #### step 2 - create UI Button elements
The next step is to create and place the actual UI elements which in our case will be two buttons. We want to make sure that they are **children** of the canvas gameobject as mentioned earlier. For that reason we create them by having the canvas gameobject selected, right-click and do UI>Button or from the Menu bar Gameobject>UI>Button. After creating our buttons we will go ahead and place them on the up left side of the canvas, making sure that we create an appealing spacing. In order to do that we will change their **pivot** and **position** from the **Anchor Presets** menu. By holding down the **shift** and **alt** keys we make sure that we affect both pivot and position when we select the option to dock the button on the top left of the canvas.

![Image](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/Image%20Links/Anchors-UI.gif?raw=true)

The button element now considers the top left of the canvas to be it's axis origin (0,0,0) and it's movement will now be referenced to this position. We can create spacing by typing into the relevant position fields of the Rect Transform (for accuracy), or simply using the transform gizmo from the toolbar. Let's place the first button to (20,-20,0) and the second at (20,-45,0).

![Image](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/Image%20Links/button%20placement.JPG?raw=true)

You can see that the Button gameobject itself has another gameobject as its child and that gameobject holds a **text** components and handles the text label that appears on top of the button. We will change the labels to the two buttons to "order cubes" and "randomize cubes" accordingly. You can also change the appearance of the button by editing the **image** components that is attached on it. In this example we have changed the color to a salmon pink. 

![Image](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/Image%20Links/button%20editing.jpg?raw=true)

* #### step 3 - create a method to calculate ordered positions
Now that our UI elements are aesthetically configured, we are ready to jump back into some code in order to add the functionality of ordering our cubes. We will reopen the CubesManager script and create a new method that will be called "FindOrderedPostions". This method will not be *void* as all our other methods were so far but insteadt it will *return* a list of Vector3 which will contain the ordered positions.
```csharp
public List<Vector3> FindOrderedPostions()
{
    // this method returns a list of Vector3
}

public void FindOrderedPostions()
{
    // this method does not return anything
}
```
This method will also require a *float* parameter named "spacing" and an *int* parameter named "size". The spacing parameter will define the distance between the grid-ordered positions we will create, whereas the size parameter will define the number of items in the x, y and z direction of our grid.
```csharp
public List<Vector3> FindOrderedPostions(float spacing, int size)
{
    // this method returns a list of Vector3
}
```
As mentioned, this method will create a list of ordered positions based on a grid like structure. In order to do that we will need a *nested for loop*. 
```csharp
public List<Vector3> FindOrderedPostions(float spacing, int size)
{
    //create and initlaize a List of Vector3 that will store the created positions and will be returned at the end of this method
    List<Vector3> positions = new List<Vector3>();
    //create a Vector3 variable that will store the current position
    Vector3 position;
      
    for(int y=0; y <size; y++) //iterating in the y dimension
    {
        for(int z=0; z<size; z++) //iterating in the z dimension
        {
            for(int x=0; x<size; x++) // iterating in the x dimension
            {
                position = new Vector3(x * spacing, y* spacing, z* spacing);
                positions.Add(position);
            }
        }
    }
    //return the filled List of odered positions
    return positions;
}
```
The for loop that we just wrote starts the iteration on the y dimension, then goes into the z dimension and finally into the x dimension. This means that the x dimension will be filled first, followed by the z and then followed byt the y. In other words, assuming the size is 3 (3x3x3 cells), our points will be created with the order they have in the following diagram:
```
filling z dimension for (y=0)
    filling x dimension for(y=0,z=0)
        0: (0,0,0)
        1: (1,0,0)
        2: (2,0,0)
    filling x dimension for(y=0,z=1)
        3: (0,1,0)
        4: (1,1,0)
        5: (2,1,0)
    filling x dimension for(y=0,z=2)
        6: (0,2,0)
        7: (1,2,0)
        8: (2,2,0)
filling z dimension for (y=1)
    filling x dimension for(y=1,z=0)
        9: (0,0,1)
        10: (1,0,1)
        11: (2,0,1)
    filling x dimension for (y=1,z=1)
        12: (0,1,1)
        13: (1,1,1)
        14: (2,1,1)
    filling x dimension for (y=1,z=2)
        15: (0,2,1)
        16: (1,2,1)
        17: (2,2,1)
 filling z dimension for (y=2)
    filling x dimension for(y=2,z=0)
        9: (0,0,2)
        10: (1,0,2)
        11: (2,0,2)
    filling x dimension for (y=2,z=1)
        12: (0,1,2)
        13: (1,1,2)
        14: (2,1,2)
    filling x dimension for (y=2,z=2)
        15: (0,2,2)
        16: (1,2,2)
        17: (2,2,2) 
```

* #### step 4 - create a method that will move the cubes to the ordered positions
We now need to write the method that will be responsible for grabbing our cubes from their current positions and moving them to the desired ordered positions. Let's create a new method and name it "MoveToPlace". Our method will not return anything but it will have three *float* parameters: count, speed and spacing and one *int* parameter: size.
```csharp
public void MoveToPlace(int count, float speed, float spacing, int size)
{
    // we will write our functionality here
}
```
Knowing that we will go to each cube and change its positionm, it is clear that we will need to write another for loop which will iterate through the cubes. The "count" float parameter we added to our method is responsible for passing the number of cubes. The "speed" float will define how quickly the cubes will move from their old(random) to their new(odered) position. Finally the "spacing" and "size" parameters will define the spacing between the ordered positions and the size of their respective 3D grid, as we will **call** the "FindOrderedPositions" method we just wrote which requires such a parameter. 
```csharp
public void MoveToPlace(int count, float speed, float spacing, int size)
{
    //create the list of ordered positions from the FindOrderedPosition method
    List<Vector3> new_positions = FindOrderedPostions(spacing,size);
    //public variables that will the current data for each iteration
    GameObject current_cube;
    Vector3 current_pos;
    Vector3 mover;

    for (int i = 0; i < count; i++)
    {
        //get the current child cube gameobject
        current_cube = transform.GetChild(i).gameObject;
        //store its position 
        current_pos = current_cube.transform.position;
        //calculate the cube's movement
        mover = Vector3.MoveTowards(current_pos, new_positions[i], speed);
        //assign new position to cube
        current_cube.transform.position = mover;
    }
}
```
When calculating the new position for our cube, we used one of the inherent Vector3 methods called "MoveTowards". The [MoveTowards](https://docs.unity3d.com/ScriptReference/Vector3.MoveTowards.html) method is responsible for smoothly moving and object from one position to another. It should be called within the Update() and it is responsible for calculating a new position in every frame that is a step closer to the target position. It will run for as many frames as it takes, until it reaches the target position and then it will stop. 

* #### step 6 - expose public variables
Before jumping into using our new methods to make things happen let's expose some of the variables we are using into the inspector. specifically we should expose variablesthat will handle: the speed, the spacing and the size. We do that by placing them as public variables inside our CubesManager class using the word *public*. The naming can be whatever we like.

```csharp
public class CubesManager : MonoBehaviour
{

    public GameObject cube_prefab;
    public Gradient color_range;

    public int cube_count;
    public float bounds_x;
    public float bounds_y;
    public float bounds_z;
    
    public float moving_speed;  //will define the speed of cube movement
    public float grid_spacing;  //will define the spacing of the ordered positions in the grid
    pubic int grid_size;        //will define the grid size in the three dimensions
    
}
```
* #### step 5 - connecting methods to UI elements
Connecting the UI elements with functionality is quire easy. We see in the inspector that when our UI button is selected there is a field in the **Button** component that says **"On Click()"** followed by the phrase "List is empty". We want to add the methods that we want to be executed in that list. Let's start with the method that randomizes the cubes' positions that is now activated with the "Space" key. we click on the "+" button on the bottom right of the On **Click()** field. Then an item appears in the List which requires a gameobject and a function, Essentially it asks for a method and we need to define which gameobject has the component that contains this method. So we go ahead and drag the Manager gamobject in the gameobject field. As soon as we do that we click the "NoFunction" dropdown which will now have become available and we select the component that holds our method and finally the method itself.

![Image](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/Image%20Links/add-method.gif?raw=true)

