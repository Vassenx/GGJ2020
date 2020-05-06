using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class portraitChanger : MonoBehaviour
{
    private bool fading;
    private Color fadeColor;
    private float fade;
    private Sprite holdSprite;

    public Sprite radinkaSprite;
    public Sprite jurgisSprite;
    public Sprite kazimirSprite;
    public Sprite pavelSprite;
    public Sprite sashaSprite;

    public GameObject leftPort;
    public GameObject rightPort;

    public GameObject speakerText;
    private SpriteRenderer portraitRender;

    public GameObject dialoguePanel;

    // Start is called before the first frame update
    void Start()
    {
        portraitRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialoguePanel.activeSelf)
        {
            if (!fading)
            {
                if (speakerText.GetComponent<Text>().text == "SASHA:")
                {
                    transform.position = rightPort.transform.position;
                    changeSprite(sashaSprite);
                }
                else
                {
                    transform.position = leftPort.transform.position;

                    if (speakerText.GetComponent<Text>().text == "RADINKA:")
                    {
                        changeSprite(radinkaSprite);
                    }
                    else if (speakerText.GetComponent<Text>().text == "JURGIS:")
                    {
                        changeSprite(jurgisSprite);
                    }
                    else if (speakerText.GetComponent<Text>().text == "KAZIMIR:")
                    {
                        changeSprite(kazimirSprite);
                    }
                    else if (speakerText.GetComponent<Text>().text == "PAVEL:")
                    {
                        changeSprite(pavelSprite);
                    }
                    else
                    {
                        portraitRender.sprite = null;
                        holdSprite = null;
                    }
                }
            }
            else
            {
                if (fade < 1)
                {
                    fade += 0.08f;
                    fadeColor = new Color(fade, fade, fade);
                    portraitRender.color = fadeColor;
                }
                else
                {
                    fade = 1;
                    fadeColor = new Color(1, 1, 1);
                    portraitRender.color = fadeColor;
                    fading = false;
                }
            }
        }
        else
        {
            portraitRender.sprite = null;
            holdSprite = null;
        }
    }

    void changeSprite(Sprite changeToSprite)
    {
        if (holdSprite != changeToSprite)
        {
            portraitRender.sprite = changeToSprite;
            holdSprite = changeToSprite;
            fade = 0;
            portraitRender.color = new Color(0, 0, 0);
            fading = true;
        }
    }
}
