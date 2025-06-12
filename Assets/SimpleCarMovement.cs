using System;
using UnityEngine;

public class SimpleCarMovement : MonoBehaviour
{
    [Header("Input")]
    public float horizontal_Input;
    public float vertical_Input;

    [Header("Car Properties")]
    public float Carspeed;
    public float steerangle;
    private float currensteeringangle;

    [Header("Breaks")]
    private float currentbreakForce;
    private bool isBreaking;
    public float breakForce = 350;

    [Header("Wheelcolliders")]
    public WheelCollider FrontleftCollider;
    public WheelCollider FrontrightCollider;
    public WheelCollider rearleftCollider;
    public WheelCollider rearrightCollider;

    [Header("WheelsTransform")]
    public Transform Frontleft;
    public Transform Frontright;
    public Transform rearleft;
    public Transform rearright;

    private void Start()
    {
        Application.targetFrameRate = 60;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()               
    {
        horizontal_Input = Input.GetAxis("Horizontal");
        vertical_Input = Input.GetAxis("Vertical");
        isBreaking = Input.GetKey(KeyCode.Space);

        Thorttle();
        steering();
        animateWheels();
    }

    void Thorttle()
    {
        FrontleftCollider.motorTorque = Carspeed * vertical_Input;
        FrontrightCollider.motorTorque = Carspeed * vertical_Input;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }
    void steering()
    { 
         currensteeringangle = steerangle * horizontal_Input;
        FrontleftCollider.steerAngle = currensteeringangle;
        FrontrightCollider.steerAngle = currensteeringangle;
    }
    private void ApplyBreaking()
    {
        FrontleftCollider.brakeTorque = currentbreakForce;
        FrontrightCollider.brakeTorque = currentbreakForce;
        rearleftCollider.brakeTorque = currentbreakForce;
        rearrightCollider.brakeTorque = currentbreakForce;
    }

    public void animateWheels()
    {
        UpdateSingleWheel(FrontleftCollider, Frontleft);
        UpdateSingleWheel(FrontrightCollider, Frontright);
        UpdateSingleWheel(rearleftCollider, rearleft);
        UpdateSingleWheel(rearrightCollider, rearright);
    }
    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
   
}
