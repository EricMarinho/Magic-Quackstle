using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndgameHandler : MonoBehaviour
{

    [SerializeField] private GameObject endgamePanel;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            EndGame();        
        }
    }

    private void EndGame()
    {
        Time.timeScale = 0f;
        endgamePanel.SetActive(true);
        PlayerController.Instance.ShowMouse();
    }
}
