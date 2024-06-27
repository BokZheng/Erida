using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundaries : MonoBehaviour
{
    public Transform target; 
    public BoxCollider2D boundary; 
    public float smoothSpeed = 0.125f; 
    public Vector3 offset; 

    private float minX, maxX, minY, maxY;

    void Start()
    {
        if (boundary != null)
        {
            minX = boundary.bounds.min.x;
            maxX = boundary.bounds.max.x;
            minY = boundary.bounds.min.y;
            maxY = boundary.bounds.max.y;
        }
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Clamp the camera position within the boundaries
            float camHalfHeight = Camera.main.orthographicSize;
            float camHalfWidth = Camera.main.aspect * camHalfHeight;

            smoothedPosition.x = Mathf.Clamp(smoothedPosition.x, minX + camHalfWidth, maxX - camHalfWidth);
            smoothedPosition.y = Mathf.Clamp(smoothedPosition.y, minY + camHalfHeight, maxY - camHalfHeight);

            transform.position = smoothedPosition;
        }
    }
}
