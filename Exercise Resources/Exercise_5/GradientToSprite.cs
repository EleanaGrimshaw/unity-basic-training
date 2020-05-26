using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradientToSprite 
{
    public Sprite MakeSprite(in Gradient gradient,in int res_x)
    {
        Sprite new_sprite;
        Texture2D tex = new Texture2D(res_x, 1);
        tex.wrapMode = TextureWrapMode.Clamp;
        tex.filterMode = FilterMode.Bilinear;
        for (int j = 0; j < res_x; j++)
        {
            tex.SetPixel(j, 0, gradient.Evaluate(j / (float)res_x ));
        }
        tex.Apply();

        new_sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        return new_sprite;
    }

    public Sprite MakeSprite(in List<Color> colors,in int res_x, in int step)
    {
        Sprite new_sprite;
        Texture2D tex = new Texture2D(res_x, 1);
        tex.wrapMode = TextureWrapMode.Clamp;
        tex.filterMode = FilterMode.Point;
        for (int j = 0; j < 12; j += step)
        {
            tex.SetPixel(j, 0, colors[j / step]);
            tex.SetPixel(j + 1, 0, colors[j / step]);
            tex.SetPixel(j + 2, 0, colors[j / step]);
        }
        tex.Apply();
        new_sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        return new_sprite;
    }
}
