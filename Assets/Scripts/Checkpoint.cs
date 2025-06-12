using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject nextcheckpoint;
    public GameObject SuccessUI;
    public SimpleCarMovement _sm;

   
    private void OnTriggerEnter(Collider other)
    {
        if(nextcheckpoint ==null)
        {
            gameObject.SetActive(false);
            _sm.IsInput = false;
            Cursor.lockState = CursorLockMode.None;
            SuccessUI.SetActive(true);
        }
        
        else if(other.gameObject.name == "Player")
        {
            nextcheckpoint.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
