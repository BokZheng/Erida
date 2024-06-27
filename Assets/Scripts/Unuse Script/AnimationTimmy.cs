using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTimmy : MonoBehaviour
{
    private Animator anim;
    public bool isWalkingDown = false;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            isWalkingDown = true;
            anim.Play("WalkDown");
        }
        else
        {
            isWalkingDown = false;
            anim.Play("Idle");
        }
    }
}

    
