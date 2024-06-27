using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1stringanistay : MonoBehaviour
{
    //exploring second solution while fixing first
        public Animator animator;

        
        public void OnAnimationEnd()
        {

        animator.SetTrigger("");
        }
    void Update()
    {
        
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.normalizedTime >= 1.0f)
        {
            
           
        }
    }

}
