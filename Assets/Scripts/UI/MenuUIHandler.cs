using Checkpoint;
using Constants.Stages;
using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject menuUIHandler;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(menuUIHandler);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenuUI();
        }
    }

    public void ToggleMenuUI()
    {
        menuUIHandler.SetActive(!menuUIHandler.activeSelf);
        if (menuUIHandler.activeSelf)
        {
            Time.timeScale = 0;
            PlayerController.Instance.ShowMouse();
        }
        else
        {
            Time.timeScale = 1;
            PlayerController.Instance.HideMouse();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ClearProgress()
    {
        PlayerController.Instance.HideMouse();
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(StagesConstants._3D_STAGE_1);
        menuUIHandler.SetActive(false);
        Destroy(gameObject);
        Destroy(menuUIHandler);
    }
}
