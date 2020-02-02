using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class flickerFlash : MonoBehaviour
{
    public bool flicker;
    public bool flash;
    public float flash_speed;
    public float flash_range;

    private float intensity_hold;

    private float count;

    private bool toggle1;
    private bool toggle2;

    Light2D lightScript;
    Color hold;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        lightScript = GetComponent<Light2D>();
        hold = lightScript.color;
        intensity_hold = lightScript.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        if (flash)
        {
            hold.a = (1/flash_range) + (1 - 1/flash_range) * Mathf.PingPong(Time.time * flash_speed, 1);
            lightScript.color = hold;
            lightScript.intensity = (intensity_hold - flash_range) + Mathf.PingPong(Time.time * flash_speed, flash_range);
        }
        else if (flicker)
        {
            if (count < 0)
            {
                if (!toggle1)
                {
                    hold.a = 0.2f;
                    lightScript.color = hold;
                    lightScript.intensity = 0.2f;
                }
                else
                {
                    hold.a = 1;
                    lightScript.color = hold;
                    lightScript.intensity = intensity_hold;
                }

                if (!toggle1 & !toggle2)
                {
                    toggle1 = !toggle1;
                    count = 0.1f;
                }
                else if (toggle1 & !toggle2)
                {
                    toggle1 = !toggle1;
                    toggle2 = !toggle2;
                    count = 0.1f;
                }
                else if (!toggle1 & toggle2)
                {
                    toggle1 = !toggle1;
                    toggle2 = !toggle2;
                    count = 1f;
                }
            }
            else
            {
                count -= Time.deltaTime;
            }
        }
        else
        {
            hold.a = 1;
            lightScript.intensity = intensity_hold;
        }
    }
}
