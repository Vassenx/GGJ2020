using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public static System.Action onOpenInventory;

    [SerializeField]
    public class Dialog
    {
        public string speaker;
        public string[] sentences;
    }

    //UI
    [SerializeField] private Dialog curDialog = null;
    [SerializeField] private Image dialogWindow = null;

    private int sentenceIndex = 0;
    private bool doneSentence;

    void Start()
    {
        onOpenInventory += InterruptDialog;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (curDialog == null && doneSentence != true)
            {
                NextSentence();
            }
        }
    }

    public void StartDialog(Dialog dialog)
    {
        dialogWindow.gameObject.SetActive(true);
        Debug.Log(dialog.speaker);
        curDialog = dialog;
        sentenceIndex = 0;
    }

    public void NextSentence()
    {
        doneSentence = false;

        if (curDialog.sentences.Length <= sentenceIndex)
        {
            StartCoroutine(TypeSentence(curDialog.sentences[sentenceIndex]));
        }
        else
        {
            dialogWindow.gameObject.SetActive(false);
        }
    }

    private IEnumerator TypeSentence(string sentence)
    {
        foreach(char letter in sentence.ToCharArray())
        {
            Debug.Log(letter);
            yield return new WaitForSeconds(0.1f); //deltaTime?
        }
        sentenceIndex++;
        doneSentence = true;
    }

    private void InterruptDialog()
    {
        //TODO:
    }
}
