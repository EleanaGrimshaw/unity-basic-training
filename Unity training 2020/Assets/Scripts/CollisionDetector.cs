using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    int counter = 0;
    public List<Color> colors;

    // Start is called before the first frame update
    void Start()
    {

        Color white = Color.white;
        Color black = Color.black;


        // create a new class instance

        Dog new_dog = new Dog();

        // fill class properties

        new_dog.color = white;
        new_dog.color = black;
        new_dog.height = 0.4f;
        new_dog.length = 0.5f;
        new_dog.width = 0.25f;
        new_dog.name = "Bob";

        // call class method
        new_dog.SayYourName();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (colors != null && colors.Count > 0)
        {

            Debug.Log("collision " + counter.ToString());
            if (counter < colors.Count)
            {
                gameObject.GetComponent<MeshRenderer>().material.color = colors[counter];
            }
            else
            {
                gameObject.GetComponent<MeshRenderer>().material.color = colors[colors.Count-1];
            }
            counter++;
        }

        
    }
}
