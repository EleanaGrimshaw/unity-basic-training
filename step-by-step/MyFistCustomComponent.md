## My First C# Component

### description

This exercise will guide you through creating your first custom C# component. This component will be responsible for changing the material of the gameobject it is attached on with the hit of a key from your keyboard. You will be able to switch through the old and the new material by repeatedly hitting the same key.

>

* #### step 1
Create your C# component through Assets>Create>C# Script. Right click your newly created component and hit Edit to open it in Visual Studio. 

* #### step 2
Add two new public variables which hols the start material and the new material. Name those variables accordingly
```
public class CubeHandler : MonoBehaviour
{
    public Material start_material;
    public Material new_material;
}
```
