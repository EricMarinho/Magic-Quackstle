using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3D : PlayerController
{
    void Start()
    {
        HideAndLockMouse();
    }

    private void HideAndLockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        interactionHandler.enabled = true;
        currentInteractionObject = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        interactionHandler.enabled = false;
        currentInteractionObject = null;
    }
}
