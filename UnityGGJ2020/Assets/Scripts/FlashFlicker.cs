using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FlashFlicker : MonoBehaviour
{
    public GameObject furniLight;
    public GameObject floorLight;

    private float intensityHoldFurni;
    private float intensityHoldFloor;

    public float count;
    public bool lightsChange = false;
    public bool lightsOn = false;


    // Start is called before the first frame update
    void Start()
    {
        count = 5;

        intensityHoldFurni = furniLight.GetComponent<Light2D>().intensity;
        intensityHoldFloor = floorLight.GetComponent<Light2D>().intensity;
    }

    // Update is called once per frame
    void Update()
    {
        if (lightsChange)
        {
            count -= 0.3f;

            if (count > 4)
            {
                LightsOn();
            }
            else if (count > 3)
            {
                LightsOff();
            }
            else if (count > 2)
            {
                LightsOn();
            }
            else if (count < 0)
            {
                count = 0;
                lightsChange = false;
                lightsOn = true;
            }
        }
    }

    public void TurnOn()
    {
        lightsChange = true;
    }

    public void TurnOff()
    {
        LightsOff();
    }

    private void LightsOff()
    {
        furniLight.GetComponent<Light2D>().intensity = 0;
        floorLight.GetComponent<Light2D>().intensity = 0;
    }

    private void LightsOn()
    {
        furniLight.GetComponent<Light2D>().intensity = intensityHoldFurni;
        floorLight.GetComponent<Light2D>().intensity = intensityHoldFloor;
    }
}
