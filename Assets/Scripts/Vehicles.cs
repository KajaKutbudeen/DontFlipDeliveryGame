using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicles : MonoBehaviour
{
    [SerializeField]
    float speed = 2f;
   

    private void Awake()
    {
       
    }

    void Update()
    {
        Move();
        Die();
        
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void Die()
    {
        if (transform.position.y < -3f)
        {
            Destroy(gameObject);
        }
    }
}
