using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class DataVisualizer : MonoBehaviour
{
    public string csv;
    public DataBounds bounds;
    public List<buildingData> Data = new List<buildingData>();
    
    // global class viariables
    buildingData current_data;
    string path;
    float h_max, h_min;
    int a_max, a_min;

    // Start is called before the first frame update
    void Start()
    {
        // initialize bounds values
        bounds.max_height = 0;
        bounds.min_height = 100000;
        bounds.max_age = 0;
        bounds.min_age = 100000;

        ReadDataFromFile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReadDataFromFile()
    {
        path = Path.Combine(Application.streamingAssetsPath, csv + ".csv");
        print(path);
        string[] file_data = File.ReadAllLines(path);
        int line_count = file_data.Length;
        for(int i=1; i<line_count; i++)
        {
            current_data = new buildingData();
            var line_data = file_data[i].Split(',');

            current_data.ID = int.Parse(line_data[0]);
            current_data.height = float.Parse(line_data[1]);
            current_data.c_date = int.Parse(line_data[2]);
            current_data.use = line_data[3];
            FindDataBounds(current_data);

            Data.Add(current_data);
        }

        //bounds.max_height = h_max;
        //bounds.min_height = h_min;
        ////bounds.max_age = a_max;
        //bounds.min_age = a_min;
    }

    void FindDataBounds(buildingData data_now)
    {
        /*
        if (h_max < data_now.height)
        {
            h_max = data_now.height;
        }
        if (h_min > data_now.height)
        {
            h_min = data_now.height;
        }
        if (a_max < data_now.c_date)
        {
            a_max = data_now.c_date;
        }
        if (a_min > data_now.c_date)
        {
            a_min = data_now.c_date;
        }
        */
        if (bounds.max_height < data_now.height)
        {
            bounds.max_height = data_now.height;
        }
        if (bounds.min_height > data_now.height)
        {
            bounds.min_height = data_now.height;
        }
        if (bounds.max_age < data_now.c_date)
        {
            bounds.max_age = data_now.c_date;
        }
        if (bounds.min_age > data_now.c_date)
        {
            bounds.min_age = data_now.c_date;
        }
    }
}
