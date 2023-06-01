using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class OpenDoorHandler : MonoBehaviour, IInteractable
{

    [SerializeField] private Animation openDoorAnimation;
    private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public void Interact()
    {
        OpenDoor();
    }

    private void OpenDoor()
    {
        UIInteractionHandler.Instance.HideInteractionUI();
        openDoorAnimation.Play();
        gameObject.SetActive(false);
    }
}
