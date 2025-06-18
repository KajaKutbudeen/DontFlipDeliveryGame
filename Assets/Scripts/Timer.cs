using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public GameObject FailedUI;
    public TextMeshProUGUI Timertext;
    public float Remainingtime = 2f;

    private void Update()
    {
        if (Remainingtime > 0)
        {
            Remainingtime -= Time.deltaTime;
        }
        else if (Remainingtime < 0)
        {
            Remainingtime = 0;
            FailedUI.SetActive(true);
        }

        int minutes = Mathf.FloorToInt(Remainingtime / 60);
        int seconds = Mathf.FloorToInt(Remainingtime % 60);

        Timertext.text = string.Format("{0:00} : {1:00}",minutes,seconds);
    }
}
