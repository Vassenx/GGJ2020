using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToBlack : MonoBehaviour
{
    private SpriteRenderer sprite;
    private float transparency;
    private bool changing;
    public bool visible;

    public bool changeComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Vector4(sprite.color.r, sprite.color.g, sprite.color.b, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (changing)
        {
            if (visible)
            {
                if (transparency < 1)
                {
                    transparency += 0.01f;
                }
                else
                {
                    transparency = 1;
                    changing = false;
                }
            }
            else
            {
                if (transparency > 0)
                {
                    transparency -= 0.01f;
                }
                else
                {
                    transparency = 0;
                    changing = false;
                    changeComplete = true;
                }
            }
            sprite.color = new Vector4(sprite.color.r, sprite.color.g, sprite.color.b, transparency);
        }

    }

    public void FadeIn()
    {
        if (changing != true)
        {
            transparency = 1;
            changing = true;
            visible = false;
        }
    }

    public void FadeOut()
    {
        if (changing != true)
        {
            transparency = 0;
            changing = true;
            visible = true;
        }
    }
}
