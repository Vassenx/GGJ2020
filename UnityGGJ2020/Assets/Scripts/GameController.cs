using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Camera mainCamera;

    public FadeToBlack blackBlock;
    public FlashFlicker flashlight;

    public PlayerController player;
    public GameObject dialog1;

    public GameObject pointsOfInterest;

    void Start()
    {
        StartCoroutine(StartSequence());

        //If ever want a cut scene
        //CutTo(pointsOfInterest);
    }

    IEnumerator StartSequence()
    {
        player.frozen = true;
        flashlight.TurnOff();
        yield return new WaitForSeconds(2);
        blackBlock.FadeIn();
        yield return new WaitForSeconds(2);
        mainCamera.GetComponent<CameraShake>().ShakeCamera();
        yield return new WaitForSeconds(2);
        flashlight.TurnOn();
        yield return new WaitForSeconds(2);
        dialog1.transform.position = player.transform.position;
        player.frozen = false;
    }


    public void CutTo(GameObject destination)
    {
        if (!player.frozen)
        {
            player.frozen = true;
        }

        blackBlock.FadeOut();

        mainCamera.GetComponent<CameraController>().focusOnObject(destination);
    }
}
