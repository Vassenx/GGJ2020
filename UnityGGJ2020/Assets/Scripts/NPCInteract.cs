using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class NPCInteract : MonoBehaviour, Interactable
{
    [SerializeField] private DialogSystem dialogSystem = null;
    [SerializeField] private Dialog[] dialogs = null;

    public void HoverInteract()
    {

    }

    public void ClickInteract()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            KeyInteract();
        }
    }

    public void KeyInteract()
    {
        
        dialogSystem.PickActDialog(dialogs);
    }
}
