using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EridaChase : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 3f;
    public float minDistance = 2f; 

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 direction = player.position - transform.position;

        float distance = direction.magnitude;

        if (distance < minDistance)
        {
            Vector3 desiredPosition = player.position - direction.normalized * minDistance;

            rb.MovePosition(Vector2.MoveTowards(transform.position, desiredPosition, chaseSpeed * Time.deltaTime));
        }
        else
        {
            rb.MovePosition(Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime));
        }
    }
}
