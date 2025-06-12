using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarMovementController : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] private float carrpm;
    [SerializeField] private float carradius;
    [SerializeField] private float val = 0;




    [Header("Car Speed")]
    public float carspeed = 0f;
    public int Maxspeed = 10;
    public float Accleration = 50f;
    public float deceleration = 2f;
    public float throttleaxis = 0;

    [Header("Wheels")]
    public WheelCollider FrontleftCollider;
    public WheelCollider FrontrightCollider;
    public WheelCollider rearleftCollider;
    public WheelCollider rearrightCollider;

    [Header("Reference")]
    private Rigidbody rb;
    public Vector3 CenterofMass = Vector3.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = CenterofMass;
    }

    private void Update()
    {
      //   carspeed = (2 * Mathf.PI * FrontleftCollider.radius * FrontleftCollider.rpm  * 60) / 1000;
       //   carspeed += Accleration;
         
        carrpm = FrontleftCollider.rpm;

        if (Input.GetKey(KeyCode.W))
        {
            CarForward();
        }
        else if (!Input.GetKey(KeyCode.W))
        {
            ThorttleOff();
        }

    }
    private void FixedUpdate()
    {
       

    }
    public void CarForward()
    {
        Debug.Log("Forward");
        if (Mathf.RoundToInt(carspeed) < Maxspeed)
        {
            FrontleftCollider.brakeTorque = 0;
            FrontleftCollider.motorTorque = carspeed;
            FrontrightCollider.brakeTorque = 0;
            FrontrightCollider.motorTorque = carspeed;
            rearleftCollider.brakeTorque = 0;
            rearleftCollider.motorTorque = carspeed;
            rearrightCollider.brakeTorque = 0;
            rearrightCollider.motorTorque = carspeed;


        }
        else
        {
            FrontleftCollider.motorTorque = 0;
            FrontrightCollider.motorTorque = 0;
            rearleftCollider.motorTorque = 0;
            rearrightCollider.motorTorque = 0;
        }
    }

    public void ThorttleOff()
    {
        Debug.Log("Throttle off");
        FrontleftCollider.motorTorque = 0;
        FrontrightCollider.motorTorque = 0;
        rearleftCollider.motorTorque = 0;
        rearrightCollider.motorTorque = 0;
        FrontleftCollider.rotationSpeed = 0;

       // rb.velocity = rb.velocity * (1f / (1f + (0.025f * deceleration)));
       rb.velocity = Vector3.zero;
    }
}
