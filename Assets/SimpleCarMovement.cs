using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SimpleCarMovement : MonoBehaviour
{
    [Header("Debug")]   
    public GameObject point;
    public float timeremaning = 10f;
    public GameObject FailedUI;
  
    public LayerMask grd;
    public int _rpm;
    public bool IsInput = true;
    private Rigidbody _rb;
    public float maxdist = 0;

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

    [Header("UI")]
    public TextMeshProUGUI _kpmno;

    private void Start()
    {
        Application.targetFrameRate = 60;
        Cursor.lockState = CursorLockMode.Locked;
        _rb = GetComponent<Rigidbody>();
        
    }
    RaycastHit hit;
    private void FixedUpdate()
    {       
        if (IsInput)
        {
            UpdateSpeedText();
            GetInput();
            Thorttle();
            steering();
            animateWheels();
            raycastgrd();
        }
        else
        {
           _rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
           
        }
    }

    void raycastgrd()
    {
       if(Physics.Raycast(point.transform.position,Vector3.down,out hit,maxdist))
        {
            if (hit.collider.gameObject != null)
            {
                timeremaning = 10f;
              //  Debug.Log(hit.collider.gameObject);
            }                       
        }
        else
        {
           if(timeremaning >0)
            {
                timeremaning -= Time.deltaTime;
            }
           else if(timeremaning < 0)
            {
                timeremaning = 0;
                Debug.Log("Timeup");
                FailedUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }
        Debug.DrawRay(point.transform.position, Vector3.down * maxdist);
    }

    void UpdateSpeedText()
    {
        _rpm = (int)(FrontleftCollider.rpm / 100f);
        _kpmno.text = _rpm.ToString();
    }
    void GetInput()
    {
        horizontal_Input = Input.GetAxis("Horizontal");
        vertical_Input = Input.GetAxis("Vertical");
        isBreaking = Input.GetKey(KeyCode.Space);
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
    private void OnDrawGizmos()
    {
    //    Gizmos.color = Color.yellow;
        Vector3 startpoint = transform.position;
        Vector3 endpoint = transform.position + Vector3.down * maxdist;
      //  Gizmos.DrawLine(startpoint,endpoint);
    }
   
}
