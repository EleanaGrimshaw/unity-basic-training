using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public bool start_moving;

    // Start is called before the first frame update
    void Start()
    {
        start_moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToPlace(List<GameObject> objects, List<Vector3> new_positions, float speed) 
    {
        int count;
        Vector3 current_pos;
        Vector3 mover;

        count = objects.Count;

        for(int i=0; i<count; i++)
        {
            current_pos = objects[i].transform.position;
            mover = Vector3.MoveTowards(current_pos, new_positions[i], speed);
            objects[i].transform.position = mover;
        }

    }

    public void EnableMover()
    {
        start_moving = true;
    }
}
