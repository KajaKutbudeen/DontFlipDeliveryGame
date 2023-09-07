using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
 
    public List<GameObject> spawnlistR = new List<GameObject>();
    public List<GameObject> spawnlistL = new List<GameObject>();


    public Transform SpawnpointL;
    public Transform SpawnpointR;
   
    [SerializeField]
    int index = 0;

   

  

    private void Awake()
    {
      
    }
    void Start()
    {
        StartCoroutine(SpawnCarsRightside());
        StartCoroutine(SpawnCarsLeftside());
    }


    void Update()
    {
       
    }

    IEnumerator SpawnCarsRightside()
    {
        while ((index < 15))
        {      
            int carno = Random.Range(0, spawnlistR.Count);
            GameObject car = Instantiate(spawnlistR[carno],SpawnpointR.position, Quaternion.identity);
            index++;
            SpawnpointR.position += new Vector3(0f, 0f, 300f);
            yield return new WaitForSeconds(5);
        }
    }

    IEnumerator SpawnCarsLeftside()
    {
        while ((index < 15))
        {
            int carno = Random.Range(0, spawnlistL.Count);
            GameObject car = Instantiate(spawnlistL[carno], SpawnpointL.position,Quaternion.Euler(new Vector3(0f,180f,0f)));
            index++;
            SpawnpointL.position += new Vector3(0f, 0f, 100f);
            yield return new WaitForSeconds(5);
        }
    }
}
