using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : PlayerController
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactionHandler.enabled = true;
        currentInteractionObject = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactionHandler.enabled = false;
        currentInteractionObject = null;
    }

}
