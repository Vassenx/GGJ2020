using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FlashlightController : MonoBehaviour
{
    public GameObject furniLight;
    public GameObject floorLight;

    [SerializeField] private float intensityHoldFurni = 4;
    [SerializeField] private float intensityHoldFloor = 5;

    IEnumerator FlickerLights()
    {
        LightsOn();
        yield return new WaitForSeconds(0.1f);
        LightsOff();
        yield return new WaitForSeconds(0.06f);
        LightsOn();
    }

    public void TurnOn()
    {
        StartCoroutine(FlickerLights());
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
