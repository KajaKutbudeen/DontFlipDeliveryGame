using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailedUI : MonoBehaviour
{
    public GameObject[] gameObjects;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject go in gameObjects)
        {
            go.SetActive(false);
        }
    }

   
}
