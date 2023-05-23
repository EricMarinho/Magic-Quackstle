using Checkpoint;
using Constants.PlayerPrefs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalHandler : MonoBehaviour, IInteractable
{
    [SerializeField] private string stageToTeleport;
    [SerializeField] private int checkpointToTeleport;

    public void Interact()
    {
        TeleportToDimension();
    }
    
    public void TeleportToDimension()
    {
        PlayerPrefs.SetString(PlayerPrefsConstants.CONTINUE_GAME_CHECKPOINT, stageToTeleport + "+" + checkpointToTeleport.ToString());
        CheckpointLoader.Instance.SetCheckpoint(checkpointToTeleport);
        StartCoroutine(CheckpointLoader.Instance.FadeOutAndLoadScene(stageToTeleport));
    }
}