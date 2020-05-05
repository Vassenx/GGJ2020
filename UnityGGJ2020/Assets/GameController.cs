using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public FadeToBlack blackBlock;
    public FlashFlicker flashlight;

    public bool sequence1;
    public bool sequence2;
    public bool sequence3;

    public bool flashlightOn = false;
    public float count;
    public PlayerController player;

    public GameObject Dialog1;

    // Start is called before the first frame update
    void Start()
    {
        count = 10;
        sequence1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (sequence1)
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
                sequence1 = false;
                sequence2 = true;
                count = 6;
            }
        }
        else if (sequence2)
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
                    sequence2 = false;
                    sequence3 = true;
                    count = 6;
                }
            }
        }
        else if (sequence3)
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
                    sequence3 = false;
                }
            }
        }
    }
}
