using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Camera mainCamera;

    public FadeToBlack blackBlock;
    public FlashFlicker flashlight;

    public int sequence;
    private bool cameraShook;

    public bool flashlightOn = false;
    public float count;
    public PlayerController player;

    public GameObject dialog1;

    public GameObject pointsOfInterest;

    // Start is called before the first frame update
    void Start()
    {
        count = 12;
        sequence = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (sequence == 0)
        {
            if (!player.frozen)
            {
                player.frozen = true;
                flashlight.TurnOff();
            }

            if (count > 0)
            {
                count -= 0.1f;
            }
            else
            {
                blackBlock.FadeIn();
                count = 6;
                sequence++;
            }
        }
        else if (sequence == 1)
        {
            if (count > 0)
            {
                count -= 0.1f;
            }
            else
            {
                count = 6;
                sequence++;
            }
        }
        else if (sequence == 2)
        {
            if (!cameraShook)
            {
                mainCamera.GetComponent<CameraShake>().ShakeCamera();
                cameraShook = true;
            }
            else
            {
                if (count > 0)
                {
                    count -= 0.1f;
                }
                else
                {
                    sequence++;
                }
            }
        }
        else if (sequence == 3)
        {
            if (!flashlight.lightsChange && blackBlock.changeComplete)
            {
                flashlight.TurnOn();
            }

            if (flashlight.lightsOn)
            {
                if (count > 0)
                {
                    count -= 0.1f;
                }
                else
                {
                    dialog1.transform.position = player.transform.position;
                    count = 6;
                    sequence++;
                }
            }
        }
        else if (sequence == 4)
        {
            if (count > 0)
            {
                count -= 0.1f;
            }
            else
            {
                if (player.frozen)
                {
                    player.frozen = false;
                    sequence++;
                }
            }
        }
        else if (sequence == 5)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                cutTo(pointsOfInterest);
            }
        }
    }

    public void cutTo(GameObject destination)
    {
        if (!player.frozen)
        {
            player.frozen = true;
        }

        blackBlock.FadeOut();

        mainCamera.GetComponent<CameraController>().focusOnObject(destination);
    }
}
