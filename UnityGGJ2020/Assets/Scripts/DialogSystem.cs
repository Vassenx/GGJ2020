using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    //UI
    [SerializeField] private Dialog curDialog = null;
    [SerializeField] private Image dialogWindow = null;
    [SerializeField] private Text dialogText = null;
    [SerializeField] private Text speakerText = null;
    [SerializeField] private Image choicePrefabHighlight = null;
    [SerializeField] private GameObject choiceParentPrefab = null;

    private bool doneDialog = true;
    private bool doneDescription = true;
    private Choice curChoice;
    private List<GameObject> choiceObjects;

    private int pickedChoiceIndex = 0;

    void Start()
    {
        choiceObjects = new List<GameObject>();
        InventorySystem.OnOpenInventory += InventoryInterrupt;
        dialogWindow.gameObject.SetActive(false);

        ActSystem.OnActChange += SwitchActDialog;
    }

    void SwitchActDialog(int actNum)
    {

    }

    void Update()
    {
        //TEST ONLY
        if (Input.GetKeyDown(KeyCode.T) && curDialog != null)
        {
            StartDialog(curDialog);
        }

        if (curDialog == null)
            return;

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            pickedChoiceIndex++;
            pickedChoiceIndex %= curChoice.children.Length;

            //for response, when pick a choice, background appears (highlight)
            ChangeHighlight();
        }
        else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) && pickedChoiceIndex > 0)
        {
            pickedChoiceIndex--;
            pickedChoiceIndex %= curChoice.children.Length;

            ChangeHighlight();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (doneDescription)
            {
                foreach (var choiceObject in choiceObjects)
                {
                    Destroy(choiceObject);
                }

                //now iterate through child
                curChoice = curChoice.children[pickedChoiceIndex];
                pickedChoiceIndex = 0; //reset
                StartCoroutine(DisplayDescription());
            }
            else
            {
                doneDescription = true;
            }
        }
    }

    public void SkipDescriptionScroll()
    {
        //skip slow text, write full sentence right away
        dialogText.text = curChoice.sentences;
        doneDescription = true;

        if (curChoice.children.Length == 0)
        {
            EndDialog();
        }
        else if (curChoice.children.Length > 1)
        {
            DisplayOptions(curChoice.children);
        }
    }

    public void StartDialog(Dialog dialog)
    {
        if (!doneDialog)
            return;

        pickedChoiceIndex = 0;
        doneDialog = false;
        dialogWindow.gameObject.SetActive(true);

        curChoice = curDialog.choices[0];
        StartCoroutine(DisplayDescription());
    }

    private IEnumerator DisplayDescription()
    {
        speakerText.text = curChoice.speaker + ':';
        doneDescription = false;
        dialogText.text = "";

        foreach (char letter in curChoice.sentences.ToCharArray())
        {
            if (doneDescription) //stopped from outside coroutine
            {
                SkipDescriptionScroll();
                yield break;
            }

            dialogText.text += letter;
            yield return new WaitForSeconds(0.1f); 
        }

        if (curChoice.children.Length == 0)
        {
            EndDialog();
        }
        else if (curChoice.children.Length > 1)
        {
            DisplayOptions(curChoice.children);
        }

        doneDescription = true;
    }

    private void DisplayOptions(Choice[] choices)
    {
        foreach (var choice in choices)
        {
            Image choiceImage = Instantiate(choicePrefabHighlight, choiceParentPrefab.transform);
            choiceImage.GetComponentInChildren<Text>().text = choice.sentences;
            choiceObjects.Add(choiceImage.gameObject);
        }

        ChangeHighlight();
    }

    private void EndDialog()
    {
        dialogWindow.gameObject.SetActive(false);
        curDialog = null;
        doneDialog = true;
    }

    private void ChangeHighlight()
    {
        for (int i = 0; i < choiceObjects.Count; i++)
        {
            var choiceObj = choiceObjects[i];
            var alpha = i == pickedChoiceIndex ? 1 : 0;
            Color newColor = new Color(choiceObj.GetComponent<Image>().color.r, choiceObj.GetComponent<Image>().color.g, choiceObj.GetComponent<Image>().color.b, alpha);
            choiceObj.GetComponent<Image>().color = newColor;
        }
    }

    private void InventoryInterrupt(bool inventoryIsOpen)
    {
        //TODO:
    }
}
