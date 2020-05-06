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

The button element now considers the top left of the canvas to be it's (0,0,0) and it's movement will now be referenced to this position. We can create spacing by typing into the relevant position fields of the Rect Transform (for accuracy), or simply using the transform gizmo from the toolbar. Let's play the first button to (20,-20,0) and the second at (20,-45,0).

![Image](https://github.com/EleanaGrimshaw/unity-basic-training/blob/master/Image%20Links/button%20placement.JPG?raw=true)
