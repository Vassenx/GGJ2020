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
    [SerializeField] private GameObject choicePrefab = null;

    private bool doneSentence = true;
    private bool doneDialog = true;
    private int curSentenceIndex = 0;
    private int curChoiceIndex = 0;
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
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartDialog(curDialog);
        }

        if (curDialog == null)
            return;

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            pickedChoiceIndex %= curDialog.choices[curChoiceIndex].children.Length;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach(var choiceObject in choiceObjects)
            {
                Destroy(choiceObject);
            }

            DisplayChoice(curDialog.choices[curChoiceIndex].children[pickedChoiceIndex]);
        }
    }

    public void StartDialog(Dialog dialog)
    {
        if (!doneDialog)
            return;

        pickedChoiceIndex = 0;
        doneDialog = false;
        dialogWindow.gameObject.SetActive(true);
        speakerText.text = curDialog.speaker + ':';

        DisplayChoice(curDialog.choices[0]);

        curChoiceIndex++;
    }

    private void DisplayOptions(Choice[] choices)
    {
        //TODO
        foreach(var choice in choices)
        {
            choiceObjects.Add(Instantiate(choicePrefab, dialogWindow.transform));
        }
    }

    private void DisplayChoice(Choice choice, int curSentenceIndex = 0)
    {
        //done with current choice
        if (curSentenceIndex >= choice.sentences.Length)
        {
            return;
        }

        doneSentence = false;
        StartCoroutine(TypeSentence(choice.sentences[curSentenceIndex]));

        if (doneSentence == true)
        {
            DisplayChoice(choice, ++curSentenceIndex);
        }
        else
        {
            //skip slow text, write full sentence right away
            dialogText.text.Remove(this.curSentenceIndex);

            dialogText.text += choice.sentences[curSentenceIndex];
            curSentenceIndex++;
            doneSentence = true;
        }

        //done with dialog
        if (choice.children.Length == 0)
        {
            EndDialog();
        }
        else
        {
            DisplayOptions(choice.children);
        }
    }

    private void EndDialog()
    {
        dialogWindow.gameObject.SetActive(false);
        curDialog = null;
        doneSentence = true;
        doneDialog = true;
        curChoiceIndex = 0;
        curSentenceIndex = 0;
        return;
    }

    private IEnumerator TypeSentence(string sentence)
    {
        curSentenceIndex = dialogText.text.ToCharArray().Length;
        dialogText.text += ' ';

        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(0.1f); //deltaTime?
        }
        curSentenceIndex++;
        doneSentence = true;
    }

    private void InventoryInterrupt(bool inventoryIsOpen)
    {
        //TODO:
    }
}
