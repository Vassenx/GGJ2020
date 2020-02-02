﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteract : MonoBehaviour, Interactable
{
    [SerializeField] private DialogSystem dialogSystem = null;
    [SerializeField] private Dialog dialog = null;

    public void HoverInteract()
    {

    }

    public void ClickInteract()
    {

    }

    public void KeyInteract()
    {
        dialogSystem.StartDialog(dialog);
    }
}
