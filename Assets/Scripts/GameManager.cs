using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject FollowPlayer;
    public Camera Camera;
    public Animator camanim;
    public GameObject SpawnManager;
    public TextMeshProUGUI Start;
    public TextMeshProUGUI Exit;

    public void Awake()
    {
        
    }
    public void StartGame()
    {
        
        StartCoroutine(Anim());
        
    }

    IEnumerator Anim()
    {
        camanim.SetBool("True",true);
        Start.enabled = false;
        Exit.enabled = false;
        yield return new WaitForSeconds(2);
        Camera.enabled = false;
        SpawnManager.SetActive(true);
        FollowPlayer.SetActive(true);

    }
    
}
