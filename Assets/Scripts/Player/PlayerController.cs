using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public InteractionHandler interactionHandler;
    [HideInInspector] public GameObject currentInteractionObject;

    private void Start()
    {
        interactionHandler = GetComponent<InteractionHandler>();
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
