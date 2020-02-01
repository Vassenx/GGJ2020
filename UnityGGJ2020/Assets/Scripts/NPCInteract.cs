using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteract : Interactable
{
    [SerializeField] private DialogSystem dialogSystem = null;
    [SerializeField] private Dialog dialog = null;

    protected override void Interact()
    {
        base.Interact();
        dialogSystem.StartDialog(dialog);
    }
}
