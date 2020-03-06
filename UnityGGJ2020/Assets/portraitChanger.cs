using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class portraitChanger : MonoBehaviour
{
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
            if (speakerText.GetComponent<Text>().text == "SASHA:")
            {
                transform.position = rightPort.transform.position;
                portraitRender.sprite = sashaSprite;
            }
            else
            {
                transform.position = leftPort.transform.position;

                if (speakerText.GetComponent<Text>().text == "RADINKA:")
                {
                    portraitRender.sprite = radinkaSprite;
                }
                if (speakerText.GetComponent<Text>().text == "JURGIS:")
                {
                    portraitRender.sprite = jurgisSprite;
                }
                else if (speakerText.GetComponent<Text>().text == "KAZIMIR:")
                {
                    portraitRender.sprite = kazimirSprite;
                }
                else if (speakerText.GetComponent<Text>().text == "PAVEL:")
                {
                    portraitRender.sprite = pavelSprite;
                }
                else
                {
                    portraitRender.sprite = null;
                }
            }
        }
        else
        {
            portraitRender.sprite = null;
        }
    }
}
