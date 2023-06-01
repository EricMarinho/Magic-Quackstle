using Checkpoint;
using Constants.PlayerPrefs;
using Constants.Stages;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class UnsealDoorHandler : MonoBehaviour, IInteractable
{
    [SerializeField] private int checkpointToTeleport;
    [SerializeField] private int doorId;

    public void Interact()
    {
        UnsealDoor(doorId);  
    }

    public void UnsealDoor(int doorId)
    {
        UIInteractionHandler.Instance.HideInteractionUI();
        CheckpointLoader.Instance.SetCheckpoint(checkpointToTeleport);
        PlayerPrefs.SetString(PlayerPrefsConstants.CONTINUE_GAME_CHECKPOINT, StagesConstants._3D_STAGE_1 + "+" + checkpointToTeleport.ToString());
        PlayerPrefs.SetString(PlayerPrefsConstants.SEALED_DOORS_LIST + $"+{doorId}", "false");
        StartCoroutine(CheckpointLoader.Instance.FadeOutAndLoadScene(StagesConstants._3D_STAGE_1));
    }

}
