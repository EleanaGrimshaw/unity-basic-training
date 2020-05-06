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
The for loop that we just wrote starts the iteration on the y dimension, then goes into the z dimension and finally into the x dimension. This means that the x dimension will be filled first, followed by the z and then followed byt the y. In other words, assuming the size is 3, our points will be created as follows:
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
  
    
