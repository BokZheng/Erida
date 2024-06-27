using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Cutscenecontrol : MonoBehaviour
{
    public Animator animator;
    public UnityEvent onAnimationComplete;
    void Start()
    {
        
    }

    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.normalizedTime > 0.999f)
        {
            SceneManager.LoadScene(2);
        }
    }
}
