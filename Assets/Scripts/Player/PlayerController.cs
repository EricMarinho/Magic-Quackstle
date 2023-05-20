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

}
