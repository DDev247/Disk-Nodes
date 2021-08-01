using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider[] colliders;

    public float moveSpeed = 400f;
    public float brakeForce = 2500f;

    public void Create(WheelCollider[] cols)
    {
        colliders = new WheelCollider[4];

        colliders[0] = cols[0];
        colliders[1] = cols[1];
        colliders[2] = cols[2];
        colliders[3] = cols[3];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            colliders[0].motorTorque = moveSpeed;
            colliders[1].motorTorque = moveSpeed;
            colliders[2].motorTorque = moveSpeed;
            colliders[3].motorTorque = moveSpeed;
        }
        else
        {
            colliders[0].motorTorque = 0f;
            colliders[1].motorTorque = 0f;
            colliders[2].motorTorque = 0f;
            colliders[3].motorTorque = 0f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            colliders[0].brakeTorque = brakeForce;
            colliders[1].brakeTorque = brakeForce;
            colliders[2].brakeTorque = brakeForce;
            colliders[3].brakeTorque = brakeForce;
        }
        else
        {
            colliders[0].brakeTorque = 0f;
            colliders[1].brakeTorque = 0f;
            colliders[2].brakeTorque = 0f;
            colliders[3].brakeTorque = 0f;
        }

        float steering = Input.GetAxis("Horizontal");

        colliders[1].steerAngle = steering * 20f;
        colliders[2].steerAngle = steering * 20f;
    }
}
