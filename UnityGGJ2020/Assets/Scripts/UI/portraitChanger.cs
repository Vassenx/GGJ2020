using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public TextMeshProUGUI speakerText;
    private SpriteRenderer portraitRender;

    public GameObject dialoguePanel;

    void Start()
    {
        portraitRender = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (dialoguePanel.activeSelf)
        {
            if (!fading)
            {
                if (speakerText.text.Equals("SASHA"))
                {
                    transform.position = rightPort.transform.position;
                    changeSprite(sashaSprite);
                }
                else
                {
                    transform.position = leftPort.transform.position;

                    switch (speakerText.text)
                    {
                        case "RADINKA":
                            changeSprite(radinkaSprite);
                            break;
                        case "JURGIS":
                            changeSprite(jurgisSprite);
                            break;
                        case "KAZIMIR":
                            changeSprite(kazimirSprite);
                            break;
                        case "PAVEL":
                            changeSprite(pavelSprite);
                            break;
                        default:
                            portraitRender.sprite = null;
                            holdSprite = null;
                            break;
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
