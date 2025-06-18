using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // public SimpleCarMovement _sm;
    public CinemachineVirtualCamera VirtualCamera;
    public GameObject Menu;

    [Header("Enable")]
    public GameObject[] gameObjects;
    public GameObject[] menuItems;
    public SimpleCarMovement _sm;

    [Header("Player Failed")]
    public GameObject FailedUI;
    public GameObject TutUi;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void StartButton()
    {       
       VirtualCamera.enabled = false;
        Menu.SetActive(false);

        // _sm.IsInput = true;

        foreach (GameObject go in gameObjects)
        {
            go.SetActive(true);
        }
    }

    public void GameStartButton()
    {
       
        foreach (GameObject go in menuItems)
        {
            go.SetActive(true) ;
        }      
        _sm.IsInput = true;
        TutUi.SetActive(false);
    }
    public void GameFailed()
    {
        FailedUI.SetActive(true);
        foreach (GameObject go in gameObjects)
        {
            go.SetActive(false);
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
