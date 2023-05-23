using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants.Tag;
using Constants.PlayerPrefs;
using Checkpoint;
using System;
using Player.Movement;
using UI;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [HideInInspector] public InteractionHandler interactionHandler;
        [HideInInspector] public GameObject currentInteractionObject;
        public MovePlayer movePlayer;
        public PlayerData playerData;

        #region Singleton
        public static PlayerController Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        #endregion

        private void Start()
        {
            interactionHandler = GetComponent<InteractionHandler>();
        }

        public void TriggerEnetered(GameObject interactedObject)
        {
            if (interactedObject.CompareTag(TagConstants.INTERACTABLE))
            {
                interactionHandler.enabled = true;
                currentInteractionObject = interactedObject.gameObject;
                UIInteractionHandler.Instance.ShowInteractionUI();
            }
            else if (interactedObject.CompareTag(TagConstants.CHECKPOINT))
            {
                CheckpointHandler.Instance.SaveCheckpoint(interactedObject);
            }
            else if (interactedObject.CompareTag(TagConstants.DEATH))
            {
                Die();
            }
            else if (interactedObject.CompareTag(TagConstants.LOCKED_DOOR))
            {
                UIInteractionHandler.Instance.ShowLockedDoorUI();
            }
        }

        public void TriggerExited(GameObject interactedObject)
        {
            if (interactedObject.CompareTag(TagConstants.INTERACTABLE))
            {
                interactionHandler.enabled = false;
                UIInteractionHandler.Instance.HideInteractionUI();
            }
            else if (interactedObject.CompareTag(TagConstants.LOCKED_DOOR))
            {
                UIInteractionHandler.Instance.HideLockedDoorUI();
            }
        }

        private void Die()
        {
            StartCoroutine(CheckpointLoader.Instance.FadeOutAndRespawn());
        }

    }
}