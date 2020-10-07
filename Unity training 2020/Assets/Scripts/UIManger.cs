using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManger : MonoBehaviour
{
    [Header("Referenced Elements")]
    public GameObject city;
    public LayerMask layer;

    [Header("UI Referenced Elements")]
    public TMP_Text id_value;
    public TMP_Text height_value;
    public TMP_Text age_value;
    public TMP_Text use_value;
    public Image legend_image;
    public TMP_Text legend_min;
    public TMP_Text legend_max;


    [Header("Visualization Elements")]
    public Color default_color;
    public Gradient height_colors;
    public Gradient age_colors;
    public List<Color> use_colors;


    // Script Global Variables

    List<buildingData> imported_data;
    int building_count;
    public DataBounds incoming_bounds;
    Ray ray;
    RaycastHit hit;
    GameObject selected;
    int selected_id;
    buildingData selected_data;
    List<Texture2D> legends = new List<Texture2D>();
    List<Sprite> legend_sprites = new List<Sprite>();

    // Start is called before the first frame update
    void Start()
    {
        imported_data = city.GetComponent<DataVisualizer>().Data;
        incoming_bounds = city.GetComponent<DataVisualizer>().bounds;  
        CreateLegendSprites();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit, Mathf.Infinity,layer))
            {
                selected = hit.transform.gameObject;
                selected_id = selected.transform.GetSiblingIndex();
                selected_data = imported_data[selected_id];

                //assign values
                id_value.text = selected_data.ID.ToString();
                height_value.text = selected_data.height.ToString();
                age_value.text = selected_data.c_date.ToString();
                use_value.text = selected_data.use.ToString();
            }
            else
            {
                //assign empty values
                id_value.text = "--";
                height_value.text = "--";
                age_value.text = "--";
                use_value.text = "--";
            }
        }
    }  

    public void ColorDefault(bool set_default)
    {
        if (set_default)
        {
            AssignUIvalues(null, "", "");

            building_count = imported_data.Count;
            //print("Setting default color");
            for (int i = 0; i < building_count; i++)
            {
                city.transform.GetChild(i).GetComponent<MeshRenderer>().material.color = default_color;
            }
        }
    }

    public void ColorHeights(bool set_by_height)
    {
        float color_t;
        GameObject current_building;
        buildingData current_data;
        Color gradient_color;

        if (set_by_height)
        {
            AssignUIvalues(legend_sprites[0], incoming_bounds.min_height.ToString(), incoming_bounds.max_height.ToString());

            building_count = imported_data.Count;
            //print("set by height");
            for (int i = 0; i < building_count; i++)
            {
                current_building = city.transform.GetChild(i).gameObject;
                current_data = imported_data[i];
                color_t = Mathf.InverseLerp(incoming_bounds.min_height, incoming_bounds.max_height, current_data.height);
                gradient_color = height_colors.Evaluate(color_t);
                current_building.GetComponent<MeshRenderer>().material.color = gradient_color;
            }
        }
    }

    public void ColorAges(bool set_by_age)
    {
        float color_t;
        GameObject current_building;
        buildingData current_data;
        Color gradient_color;

        if (set_by_age)
        {
            AssignUIvalues(legend_sprites[1], incoming_bounds.min_age.ToString(), incoming_bounds.min_age.ToString());

            building_count = imported_data.Count;
            //print("set by height");
            for (int i = 0; i < building_count; i++)
            {
                current_building = city.transform.GetChild(i).gameObject;
                current_data = imported_data[i];
                color_t = Mathf.InverseLerp(incoming_bounds.min_age, incoming_bounds.max_age, current_data.c_date);
                gradient_color = age_colors.Evaluate(color_t);
                current_building.GetComponent<MeshRenderer>().material.color = gradient_color;
            }
        }
    }

    public void ColorUses(bool set_by_use)
    {
        GameObject current_building;
        buildingData current_data;
        string current_use;

        if (set_by_use)
        {
            AssignUIvalues(legend_sprites[2], "", "");

            building_count = imported_data.Count;
            for (int i = 0; i < building_count; i++)
            {
                current_building = city.transform.GetChild(i).gameObject;
                current_data = imported_data[i];
                current_use = current_data.use;
                switch (current_use)
                {
                    case "office":
                        current_building.GetComponent<MeshRenderer>().material.color = use_colors[0];
                        break;
                    case "retail":
                        current_building.GetComponent<MeshRenderer>().material.color = use_colors[1];
                        break;
                    case "housing":
                        current_building.GetComponent<MeshRenderer>().material.color = use_colors[2];
                        break;
                    case "other":
                        current_building.GetComponent<MeshRenderer>().material.color = use_colors[3];
                        break;
                }
            }
        }
    }

    private void AssignUIvalues(Sprite sprite, string min, string max)
    {
        legend_min.text = min;
        legend_max.text = max;
        legend_image.sprite = sprite;
    }

    private void CreateLegendSprites()
    {
        GradientToSprite gs = new GradientToSprite();
        legend_sprites.Add(gs.MakeSprite(height_colors, 12));
        legend_sprites.Add(gs.MakeSprite(age_colors, 12));
        legend_sprites.Add(gs.MakeSprite(use_colors, 12, 3));
    }

    private void CreateLegendTextures()
    {
        for (int i = 0; i < 3; i++)
        {
            Texture2D tex = new Texture2D(12, 1);
            tex.wrapMode = TextureWrapMode.Clamp;


            switch (i)
            {
                case 0:
                    tex.filterMode = FilterMode.Bilinear;
                    for (int j = 0; j < 12; j++)
                    {
                        tex.SetPixel(j, 0, height_colors.Evaluate(j / 12.0f));
                    }
                    tex.Apply();
                    legends.Add(tex);
                    break;
                case 1:
                    tex.filterMode = FilterMode.Bilinear;
                    for (int j = 0; j < 12; j++)
                    {
                        tex.SetPixel(j, 0, age_colors.Evaluate(j / 12.0f));
                    }
                    tex.Apply();
                    legends.Add(tex);
                    break;
                case 2:
                    tex.filterMode = FilterMode.Point;
                    for (int j = 0; j < 12; j += 3)
                    {
                        tex.SetPixel(j, 0, use_colors[j / 3]);
                        tex.SetPixel(j + 1, 0, use_colors[j / 3]);
                        tex.SetPixel(j + 2, 0, use_colors[j / 3]);
                    }
                    tex.Apply();
                    legends.Add(tex);
                    break;
            }
        }
    }

}
