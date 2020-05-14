using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemHover : MonoBehaviour
{
    [SerializeField] private HintItem hint = null;
    [SerializeField] private InventorySystem invSys = null;
    [SerializeField] private TextMeshProUGUI txtmsh = null;
    //Ray raycast;
    //RaycastHit contact;
    public Renderer renderer;
     
    void Start()
    {
        renderer = GetComponent<Renderer>();  
    }

    void Update()
    {
       
    }

    private void OnMouseEnter()
    {
        Debug.Log("Hello World");
    }



}
