using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants.Tag;
using Constants.PlayerPrefs;
using Checkpoint;
using System;
using Player.Movement;
using Player.Audio;
using UI;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [HideInInspector] public InteractionHandler interactionHandler;
        [HideInInspector] public GameObject currentInteractionObject;
        public MovePlayer movePlayer;
        public PlayerData playerData;
        public PlayerSoundsHandler playerSoundsHandler;

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
            HideMouse();

        }

        public void HideMouse()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void ShowMouse()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
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
            movePlayer.isRunning = false;
            movePlayer.isOnGround = true;
            playerSoundsHandler.PlayDieSound();
            StartCoroutine(CheckpointLoader.Instance.FadeOutAndRespawn());
        }

        public void PlayJump()
        {
            playerSoundsHandler.PlayJumpSound();
        }

        public void PlayRunningAudio()
        {
            playerSoundsHandler.PlayRunningAudio();
        }

        public void StopRunningAudio()
        {
            playerSoundsHandler.StopRunningAudio();
        }

    }
}