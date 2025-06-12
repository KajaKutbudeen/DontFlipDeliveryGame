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

    [Header("Player Failed")]
    public GameObject FailedUI;
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
