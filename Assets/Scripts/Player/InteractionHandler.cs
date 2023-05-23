using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class InteractionHandler : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (playerController.currentInteractionObject != null)
            {
                playerController.currentInteractionObject.GetComponent<IInteractable>().Interact();
            }
        }
    }
}
