using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject camera;

    public FadeToBlack blackBlock;
    public FlashFlicker flashlight;

    public int sequence;
    private bool cameraShook;

    public bool flashlightOn = false;
    public float count;
    public PlayerController player;

    public GameObject Dialog1;

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
                count = 12;
                sequence++;
            }
        }
        else if (sequence == 2)
        {
            if (!cameraShook)
            {
                camera.GetComponent<CameraShake>().ShakeCamera();
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
                    Dialog1.transform.position = player.transform.position;
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
    }
}
