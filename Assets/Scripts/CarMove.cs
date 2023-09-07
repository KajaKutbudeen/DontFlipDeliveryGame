using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    float Horispeed;
    float vertispeed;
    [SerializeField]
    float Forwardspeed = 5;
    [SerializeField]
    float rotateangle = 5;
    private void Update()
    {
        Horispeed = Input.GetAxis("Horizontal");
        vertispeed = Input.GetAxis("Vertical");

       
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * vertispeed * Forwardspeed * Time.deltaTime );
        transform.Rotate(Vector3.up * Horispeed * rotateangle * Time.deltaTime);
    }
    private void LateUpdate()
    {
        
    }
}
