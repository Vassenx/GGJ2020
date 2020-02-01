using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public static System.Action onOpenInventory;

    public enum Items { HasCarrot, HasPizza };

    //UI
    [SerializeField] private Dialog curDialog = null;
    [SerializeField] private Image dialogWindow = null;
    [SerializeField] private Text dialogText = null;

    private int sentenceIndex = 0;
    private bool doneSentence = true;
    private int curSentenceIndex = 0;

    void Start()
    {
        onOpenInventory += InventoryInterrupt;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && curDialog != null)
        {
            if (sentenceIndex >= curDialog.sentences.Length)
            {
                dialogWindow.gameObject.SetActive(false);
                curDialog = null;
                return;
            }

            if (doneSentence == true)
            {
                NextSentence();
            }
            else
            {
                //skip slow text, write full sentence right away
                dialogText.text.Remove(curSentenceIndex);

                dialogText.text += curDialog.sentences[sentenceIndex];
                sentenceIndex++;
                doneSentence = true;
            }
        }
    }

    public void StartDialog(Dialog dialog)
    {
        dialogWindow.gameObject.SetActive(true);
        dialogText.text = dialog.speaker + ':';
        curDialog = dialog;
        sentenceIndex = 0;
    }

    private void NextSentence()
    {
        doneSentence = false;
        StartCoroutine(TypeSentence(curDialog.sentences[sentenceIndex]));
    }

    private IEnumerator TypeSentence(string sentence)
    {
        curSentenceIndex = dialogText.text.Length;
        dialogText.text += ' ';

        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(0.1f); //deltaTime?
        }
        sentenceIndex++;
        doneSentence = true;
    }

    private void InventoryInterrupt()
    {
        //TODO:
    }
}
