using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteract : MonoBehaviour, Interactable
{
    protected Item item;

    public void Start()
    {
        item = gameObject.GetComponent<Item>();
        if (item != null && item.descriptionBox != null)
        {
            item.descriptionBox.SetActive(false);
        }
    }

    public void HoverInteract()
    {
        //Debug.Log("HOVERING OVER ITEM");
        StartCoroutine(DescriptionPopup());
    }

    private IEnumerator DescriptionPopup()
    {
        if(item != null && item.descriptionBox != null)
        {
            item.descriptionBox.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            item.descriptionBox.SetActive(false);
        }
    }

    public virtual void ClickInteract()
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
