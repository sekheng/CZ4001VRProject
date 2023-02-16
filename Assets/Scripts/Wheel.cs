using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public bool powered = false;
    public float maxAngle = 90f;
    public float offset = 0f;

    private float turnAngle;
    private WheelCollider wcol;
    private Transform wmesh;

    private void Start()
    {
        wcol = GetComponentInChildren<WheelCollider>();
        wmesh = transform.Find("Mesh");
        //Debug.Log(wcol.gameObject);
        //Debug.Log(wmesh.gameObject);
    }

    public void Steer(float steerInput)
    {
        turnAngle = steerInput * maxAngle + offset;
        wcol.steerAngle = turnAngle;
    }

    public void Accelerate(float powerInput)
    {
        if(powered) wcol.motorTorque = powerInput;
        else wcol.brakeTorque = 0;
    }

    public void UpdatePosition(float speed)
    {
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;

        wcol.GetWorldPose(out pos, out rot);
        //wcol.transform.RotateAround(wcol.transform.position, wcol.transform.forward, Mathf.Rad2Deg * speed / wcol.radius);
        wmesh.transform.position = pos;
        //wmesh.transform.rotation = rot;
        wmesh.transform.RotateAround(wmesh.transform.position, wmesh.transform.right, Mathf.Rad2Deg * speed / wcol.radius);
    }
}
