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
    [SerializeField] private Text choicePrefabText = null;
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

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            pickedChoiceIndex++;
            pickedChoiceIndex %= curChoice.children.Length;
        }

        if (Input.GetKeyDown(KeyCode.Space) && doneDescription)
        {
            foreach(var choiceObject in choiceObjects)
            {
                Destroy(choiceObject);
            }

            //now iterate through child
            curChoice = curChoice.children[pickedChoiceIndex];
            StartCoroutine(DisplayDescription());
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
        dialogText.text = " ";

        foreach (char letter in curChoice.sentences.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(0.1f); 
        }

        /*skip slow text, write full sentence right away
        dialogText.text.Remove(this.curSentenceIndex);

        dialogText.text += choice.sentences[curSentenceIndex];
        curSentenceIndex++;
        doneSentence = true;*/

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
            Text choiceText = Instantiate(choicePrefabText, choiceParentPrefab.transform);
            choiceText.text = choice.sentences;
            choiceObjects.Add(choiceText.gameObject);
        }
    }

    private void EndDialog()
    {
        dialogWindow.gameObject.SetActive(false);
        curDialog = null;
        doneDialog = true;
    }

    private void InventoryInterrupt(bool inventoryIsOpen)
    {
        //TODO:
    }
}
