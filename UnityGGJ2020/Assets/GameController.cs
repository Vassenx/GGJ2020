using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public FadeToBlack blackBlock;
    public FlashFlicker flashlight;
    public bool fadeIn = false;
    public bool flashlightOn = false;
    public float count;
    public PlayerController player;

    public NPCInteract startDialogue1;

    // Start is called before the first frame update
    void Start()
    {
        count = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (!fadeIn)
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
                fadeIn = true;
            }
        }
        else
        {
            if (!flashlight.lightsChange && blackBlock.changeComplete)
            {
                flashlight.TurnOn();
            }

            if (flashlight.lightsOn)
            {
                if (player.frozen)
                {
                    player.frozen = false;
                }


            }
        }
    }
}
