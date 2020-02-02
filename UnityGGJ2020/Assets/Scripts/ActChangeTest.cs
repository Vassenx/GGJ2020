using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ActChangeTest : MonoBehaviour
{
    private int inc = 0;

    [SerializeField] private DialogSystem temp;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(ClickTrigger);
    }

    public void ClickTrigger()
    {
        Debug.Log(temp.curDialog.actNum);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
