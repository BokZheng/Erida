using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float walkSpeed = 3f; 
    public float runSpeed = 6f; 
    public bool isRunning = false;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX, moveY).normalized;

        float speed = isRunning ? runSpeed : walkSpeed;

        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);

        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //{
       //     isRunning = true;
        //}

        /*if (Input.GetKeyDown(KeyCode.S))
        {
            isWalkingDown = true;
            anim.Play("WalkDown");
        }
        else
        {
            isWalkingDown = false;
            anim.Play("Idle");
        }*/
    }
}