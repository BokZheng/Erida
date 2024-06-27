using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLamp : MonoBehaviour
{
    public float zAngleIncrement = 90f; 

    void Update()
    {
        Vector3 currentRotation = transform.eulerAngles;

        if (Input.GetKeyDown(KeyCode.W))
        {
            currentRotation.z = 0f;
         }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            currentRotation.z = 180f;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            currentRotation.z = 90f;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            currentRotation.z = -90f;
        }

        transform.eulerAngles = currentRotation;
    }
}
