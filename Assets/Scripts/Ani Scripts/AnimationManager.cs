using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationManager : MonoBehaviour
{
    public Animator animator;
    public UnityEvent onAnimationComplete;

    void Start()
    {
        
    }

    
    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.normalizedTime > 0.9f)
        {
            animator.speed = 0;
            onAnimationComplete.Invoke();
            this.enabled = false;
        }
    }
}
