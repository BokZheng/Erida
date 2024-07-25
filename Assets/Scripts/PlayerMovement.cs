using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerMovement : MonoBehaviour
{
 
    public float speed = 1f;
    private KeyCode lastKeyPressed;

    private Rigidbody2D myBody;
    public Animator anim;
    public bool isWalkingDown = false;
    public bool isWalkingLeft = false;
    public bool isWalkingRight = false;
    public bool isWalkingUp = false;


    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
 
    void Start()
    {  }
 
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            isWalkingDown = true;
            anim.Play("walk down");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            isWalkingLeft = true;
            anim.Play("WalkLeft");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            isWalkingRight = true;
            anim.Play("WalkRight");
        }
        else if (Input.GetKey(KeyCode.W))
        {
            isWalkingUp = true;
            anim.Play("WalkUp");
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            anim.Play("UpIdle");
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            anim.Play("LeftIdle");
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            anim.Play("Idle");
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            anim.Play("RightIdle");
        }
        
    }
 
    void FixedUpdate()
    {
        PlayerWalk();
        LockZRotation();
    }
 
    void PlayerWalk()
    {

        float x = 0f;
        float y = 0f;

        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            x = -1f;
        }
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A))
        {
            x = 1f;
        }
        else if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            y = 1f;
        }
        else if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D))
        {
            y = -1f;
        }

        Vector2 movement = new Vector2(x, y).normalized * speed;
        myBody.velocity = movement;
    }
    void LockZRotation()
    {
        Vector3 currentRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, 0f);
    }
}
    
    
   
 
 
    

 

