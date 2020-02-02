using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteract : MonoBehaviour, Interactable
{
    Item item;

    public void Start()
    {
        item = gameObject.GetComponent<Item>();
    }

    public void HoverInteract()
    {
        Debug.Log("HOVERING OVER ITEM");
    }

    public void ClickInteract()
    {
        Debug.Log("CLICKING AN ITEM");
    }

    public void KeyInteract()
    {

    }

    public void OnMouseEnter()
    {
        item.descriptionBox.SetActive(true);
    }

    public void OnMouseExit()
    {
        item.descriptionBox.SetActive(false);
    }
}
