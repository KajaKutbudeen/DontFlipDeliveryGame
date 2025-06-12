using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject nextcheckpoint;

    private void OnTriggerEnter(Collider other)
    {
        if(nextcheckpoint ==null)
        {
            gameObject.SetActive(false);
        }
        
        if(other.gameObject.name == "Player")
        {
            nextcheckpoint.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
