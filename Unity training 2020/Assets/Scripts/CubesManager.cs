using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// responsible for generating a given number of cubes on random locations within given bounds
/// and changing their color according to proximity from an attractor
/// </summary>
public class CubesManager : MonoBehaviour
{

    public GameObject cube_prefab;
    public Gradient color_range;

    public int cube_count;
    public float bounds_x;
    public float bounds_y;
    public float bounds_z;

    public bool start_moving;
    public float grid_spacing;
    public float max_distance;
    public float moving_speed;
    public int grid_size;


    RaycastHit hit;
    Ray ray;
    GameObject attractor;
    float maximum;
    List<Vector3> ordered_positions;

    // Start is called before the first frame update
    void Start()
    {
        // ensure that the number of cubes matches the grid positions
        cube_count = grid_size * grid_size * grid_size;

        // call cube generating method
        GenerateRandomCubes();

        // calculate maximum distance
        maximum = maxDistance();
    }

    // Update is called once per frame
    void Update()
    {
        // Raycasting to interact with generated cubes and point out the attractor point
        if (Input.GetMouseButtonDown(0) == true)
        {
            //1. create ray from mouse position - transform scree position where our mouse is to a ray towards our scene
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            //2. perform the raycast and see if any collisons were detected
            if(Physics.Raycast(ray,out hit, Mathf.Infinity) == true)
            {
                // find out which object was hit, this cube will be our attractor
                attractor = hit.transform.gameObject;
                //print("hit "+ attractor.name);
                DistanceFromAttractor(attractor, max_distance);
                
            }
            else
            {
                //print("no objects were hit");
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReshufflePositions();
        }

        if (start_moving)
        {
            MoveToPlace(cube_count, moving_speed,grid_spacing,grid_size);
        }
    }

    public void GenerateRandomCubes()
    {
        // create the variables that will hold the random x, y, and z numbers for each position
        float _x;
        float _y;
        float _z;
        Vector3 new_position;

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
            new_cube.name = "cube_" + i.ToString();

            //5. make the new cube a child object (parenting constraint) of the Manager Gameobject
            new_cube.transform.SetParent(transform);

        }
    }

    /// <summary>
    /// Iterates through the existing cubes and calculates their distance from the attractor, based on that distance the cubes get colored through the PaintByDistance method.
    /// </summary>
    /// <param name="_attractor"></param>
    /// <param name="max_distance"></param>
    public void DistanceFromAttractor(GameObject _attractor, float max_distance)
    {
        // --- method variables
        GameObject current;
        Vector3 current_pos;
        Vector3 attractor_pos;
        Color current_color;

        float distance;
        float color_t;

        // --- method code

        //0. store attractor cube's position
        attractor_pos = _attractor.transform.position;

        //1. iterate all cube childer objects to find their distance from the attractor
        for(int i=0; i<cube_count; i++)
        {
            //2. get current gameobject from children
            current = transform.GetChild(i).gameObject;

            //3. make sure current cube is not the attractor
            if(current != _attractor)
            {
                //4. get the current cube's position
                current_pos = current.transform.position;
                distance = Vector3.Distance(current_pos, attractor_pos);

                //5. remap the distance value to go from 0 to 1 with the inverse.lerp function
                color_t = Mathf.InverseLerp(0, max_distance, distance);

                //6. evaluate the color range gradient based on distance t and extract cube's color
                current_color = color_range.Evaluate(color_t);

                //7. Call the PainByDistance Function of the cube and pass the calculated color
                transform.GetChild(i).GetComponent<CubeHandler>().PaintByDistance(current_color);

            }
            else
            {
                transform.GetChild(i).GetComponent<CubeHandler>().PaintByDistance(Color.red);
            }
        }
    }

    public void ReshufflePositions()
    {
        start_moving = false;
        // create the variables that will hold the random x, y, and z numbers for each position
        float _x;
        float _y;
        float _z;
        Vector3 new_position;

        // for loop to iteratate cube number and create random x,y and z values for each new cube's position;
        for (int i = 0; i < cube_count; i++)
        {
            _x = Random.Range(0, bounds_x);
            _y = Random.Range(0, bounds_y);
            _z = Random.Range(0, bounds_z);

            new_position = new Vector3(_x, _y, _z);

            // move cube to new posiion
            transform.GetChild(i).position = new_position;

            // make cube's color neutral white until a new attractor is selected
            transform.GetChild(i).GetComponent<CubeHandler>().PaintByDistance(Color.white);
        }
    }

    public float maxDistance()
    {
        Vector3 min = Vector3.zero;
        Vector3 max = new Vector3(bounds_x, bounds_y, bounds_z);
        return Vector3.Distance(min, max);
    }

    public List<Vector3> FindOrderedPostions(float spacing, int size)
    {
        List<Vector3> positions = new List<Vector3>();
        Vector3 position;
        for(int y=0; y < size; y++)
        {
            for(int z=0; z< size; z++)
            {
                for(int x=0; x< size; x++)
                {
                    position = new Vector3(x * spacing, y* spacing, z* spacing);
                    positions.Add(position);
                }
            }
        }

        return positions;
    }

    public void MoveToPlace(int count, float speed, float spacing, int size)
    {
        List<Vector3> new_positions = FindOrderedPostions(spacing, size);
        GameObject current_cube;
        Vector3 current_pos;
        Vector3 mover;


        for (int i = 0; i < count; i++)
        {
            current_cube = transform.GetChild(i).gameObject;
            current_pos = current_cube.transform.position;
            mover = Vector3.MoveTowards(current_pos, new_positions[i], speed);
            current_cube.transform.position = mover;
        }

    }

    public void EnableMover()
    {
        start_moving = true;
    }
}
