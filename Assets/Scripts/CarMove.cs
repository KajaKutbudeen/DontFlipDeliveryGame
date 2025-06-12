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

    [Header("Speed Variation")]

    Vector3 move;
   Rigidbody rb;
    void Start()
    {
        Application.targetFrameRate = 60;
        Cursor.lockState = CursorLockMode.Locked;
        rb= GetComponent<Rigidbody>();
    }
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
   
   
}
