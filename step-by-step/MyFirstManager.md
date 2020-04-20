## Random Cubes

### description

This exercise will guide you through creating your first game manager. The manager will be responsible for generating a specified number of cubes, at random positions withing certain bounds. The user will be able to select any cube and set it as an attractor, the scene manager will then be responsible to color all of the other cubes according to their vicinity to the attractor. The color range will be defined by the user through a specified color gradient. Finally the manager will be responsible for reshuffling the cubes in new random positions with the hit of the "Space" key.

---

* #### step 1 - create the Game Manager
Create an empty gameobject, place it at (0,0,0)and name it GameManager. Placing the manager gameobject at (0,0,0) is important for the parenting constraint as we will see in the following steps of this exercise. Create a custom C# script and name it "CubesManager". Attach the new script to the GameManager gameobject and open the script in Visual Studio for editing.

* #### step 2 - 
