using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData itemData;
    public GameObject descriptionBox;

    public void Start()
    {
        if(descriptionBox != null)
        {
            descriptionBox.SetActive(false);
        }
    }
}
