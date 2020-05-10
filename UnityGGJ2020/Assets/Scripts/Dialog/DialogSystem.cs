using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class DialogSystem : MonoBehaviour
{
    //UI
    [SerializeField] private Image dialogWindow = null;
    [SerializeField] private TextMeshProUGUI dialogText = null;
    [SerializeField] private TextMeshProUGUI speakerText = null;
    [SerializeField] private Image choicePrefabHighlight = null;
    [SerializeField] private GameObject choiceParentPrefab = null;
    [SerializeField] private float scrollWaitTime = 0.05f;

    private bool doneDialog = true;
    private bool doneDescription = true;

    private DialogTree curDialog = null;
    private DialogNode curChoice; //cur node chosen to be next up if there are multiple options
    private List<GameObject> choiceObjects;
    private int pickedChoiceIndex = 0; //ex: if there are 2 choices for curChoice, and picked 2nd choice, pickedChoiceIndex = 1
    private int actNum = 1;

    public static DialogSystem instance;

    //Lazy singleton. This class manages all dialogs possible
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }

        instance = this;

        //load all the possible dialog trees from json
        JsonConverter.LoadJson("Assets/Json/jtest.json");

        curDialog = null;
    }

    void Start()
    {
        InventorySystem.OnOpenInventory += InventoryInterrupt;
        ActSystem.OnActChange += ((int newActNum) => actNum = newActNum);

        dialogWindow.gameObject.SetActive(false);
        choiceObjects = new List<GameObject>();
    }

    //TODO: make this an event, on start of dialog, start checking for these key bindings?
    void Update()
    {
        if (curDialog == null || curDialog.nodes == null)
            return;

        TryChangeOption();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (doneDescription)
            {
                foreach (var choiceObject in choiceObjects)
                {
                    Destroy(choiceObject);
                }
                choiceObjects.Clear();

                //now iterate through child
                if(curChoice.choices.Length != 0)
                {
                    curChoice = curDialog.nodes[curChoice.choices[pickedChoiceIndex]];
                }
                
                pickedChoiceIndex = 0; //reset
                StartCoroutine(DisplayDescription());
            }
            else
            {
                doneDescription = true;
            }
        }
    }

    //User input if want to change option or not
    private void TryChangeOption()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) 
            && curChoice.choices.Length != 0)
        {
            pickedChoiceIndex++;
            pickedChoiceIndex %= curChoice.choices.Length;

            //for response, when pick a choice, background appears (highlight)
            ChangeHighlight();
        }
        else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) || Input.GetKeyDown(KeyCode.A) 
                  && pickedChoiceIndex > 0 && curChoice.choices.Length != 0)
        {
            pickedChoiceIndex--;
            pickedChoiceIndex %= curChoice.choices.Length;

            ChangeHighlight();
        }
    }

    public void StartDialog(DialogTree dialog)
    {
        if (!doneDialog)
            return;

        pickedChoiceIndex = 0;
        doneDialog = false;
        dialogWindow.gameObject.SetActive(true);

        curDialog = dialog;
        curChoice = curDialog.nodes[0]; //start with the first node

        StartCoroutine(DisplayDescription());
    }

    private IEnumerator DisplayDescription()
    {
        speakerText.text = curChoice.speaker;
        doneDescription = false;
        dialogText.text = "";

        foreach (char letter in curChoice.text.ToCharArray())
        {
            if (doneDescription) //stopped from outside coroutine
            {
                SkipDescriptionScroll();
                yield break;
            }

            dialogText.text += letter;
            yield return new WaitForSeconds(scrollWaitTime); 
        }

        if (curChoice.choices.Length == 0)
        {
            EndDialog();
        }
        else if (curChoice.choices.Length > 1)
        {
            DisplayOptions(curChoice.choices);
        }

        doneDescription = true;
    }

    public void SkipDescriptionScroll()
    {
        //skip slow text, write full sentence right away
        dialogText.text = curChoice.text;
        doneDescription = true;

        if (curChoice.choices.Length == 0)
        {
            EndDialog();
        }
        else if (curChoice.choices.Length > 1)
        {
            DisplayOptions(curChoice.choices);
        }
    }

    ///<param name="options">The identifier of the node (span of text of a speaker) in the dialog. </param>
    private void DisplayOptions(int[] options)
    {
        foreach (var option in options)
        {
            var node = curDialog.nodes[option];

            Image choiceImage = Instantiate(choicePrefabHighlight, choiceParentPrefab.transform);
            choiceImage.GetComponentInChildren<TextMeshProUGUI>().text = node.text;
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
            var choiceObjImage = choiceObjects[i].GetComponent<Image>();
            var alpha = i == pickedChoiceIndex ? 1 : 0;

            Color newColor = new Color(choiceObjImage.color.r, choiceObjImage.color.g, choiceObjImage.color.b, alpha);
            choiceObjImage.color = newColor;
        }
    }

    private void InventoryInterrupt(bool inventoryIsOpen)
    {
        //TODO:
    }
}
