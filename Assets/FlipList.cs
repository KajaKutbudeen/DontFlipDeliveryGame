using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipList : MonoBehaviour
{
    public List<GameObject> Checkpoints;

    public void Addpoint(GameObject cp)
    {
       Checkpoints.Add(cp);
    }
}
