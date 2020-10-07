using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    public Material start_material;
    public Material new_material;

    Material current_material;

    public int counter = 0;

    

    


    // variable that will store the material of the cube at a given time


    // Start is called before the first frame update
    void Start()
    {
        start_material = gameObject.GetComponent<MeshRenderer>().sharedMaterial;


    }

    // Update is called once per frame
    void Update()
    {
        /*
       
        if(something)
        {
            then something happens
        }

        */


        #region material change without method
        /*
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            //print("pressed space bar");

            // get the current material when the space button is pressed
            current_material = gameObject.GetComponent<MeshRenderer>().sharedMaterial;

            // check if the current material is the new material
            if(current_material == new_material == true)
            {
                // this means we have already changed the cube's material form start to new and now we will change it back to the start material
                gameObject.GetComponent<MeshRenderer>().sharedMaterial = start_material;
            }
            else
            {
                // this will be true when the cube's current material is not equal to the new material and hence is equal to the start material
                // so we will change it to the new material
                gameObject.GetComponent<MeshRenderer>().sharedMaterial = new_material;
            }

            //gameObject.GetComponent<MeshRenderer>().sharedMaterial = new_material;
        }
        */
        #endregion

        

        if (Input.GetKeyDown("d"))
        {
            ChangeMaterial();
        }

        //counter++;
    }

    public void ChangeMaterial()
    {
        // get the current material the gameobject has
        current_material = gameObject.GetComponent<MeshRenderer>().sharedMaterial;

        // check if the current material is the new material
        if (current_material == new_material )
        {
            // this means we have already changed the cube's material form start to new and now we will change it back to the start material
            gameObject.GetComponent<MeshRenderer>().sharedMaterial = start_material;
        }
        else
        {
            // this will be true when the cube's current material is not equal to the new material and hence is equal to the start material
            // so we will change it to the new material
            gameObject.GetComponent<MeshRenderer>().sharedMaterial = new_material;
        }
       
    }

    public void PaintByDistance(Color color)
    {
        gameObject.GetComponent<MeshRenderer>().material.color = color;
    }
}
