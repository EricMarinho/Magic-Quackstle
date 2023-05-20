using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalHandler : MonoBehaviour, IInteractable
{
    [SerializeField] private string stageToTeleport;

    public void Interact()
    {
        TeleportToDimension();
    }
    
    public void TeleportToDimension()
    {
        SceneManager.LoadScene(stageToTeleport);
    }
}
