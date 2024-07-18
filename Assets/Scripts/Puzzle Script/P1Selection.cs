using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.WSA;

public class P1Selection : MonoBehaviour
{
    public GameObject[] leftSelection;
    public GameObject[] rightSelection;

    public Animator slcAnimation;
    public Animator stringAnimation1;
    public Animator stringAnimation2;
    public Animator stringAnimation3;

    private int currentLeftSelection = 0;
    private int currentRightSelection = 0;
    private bool isSelectingRight = false;
    private bool isStringAnimationPlaying = false;

    private List<string> activeConnections = new List<string>(); 

    void Start()
    {
        UpdateIndicator();
    }

    void Update()
    {
        if (!isStringAnimationPlaying)
        {
            HandleInput();
        }
    }

    void HandleInput()
    {
        if (!isSelectingRight)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                ChangeSelection(ref currentLeftSelection, leftSelection.Length, -1);
                UpdateIndicator();
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                ChangeSelection(ref currentLeftSelection, leftSelection.Length, 1);
                UpdateIndicator();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                isSelectingRight = true;
                UpdateRightIndicator();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                ChangeSelection(ref currentRightSelection, rightSelection.Length, -1);
                UpdateRightIndicator();
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                ChangeSelection(ref currentRightSelection, rightSelection.Length, 1);
                UpdateRightIndicator();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(PlayStringAnimation());
            }
        }
    }

    void ChangeSelection(ref int selectionIndex, int selectionLength, int change)
    {
        selectionIndex += change;
        if (selectionIndex < 0)
        {
            selectionIndex = selectionLength - 1;
        }
        else if (selectionIndex >= selectionLength)
        {
            selectionIndex = 0;
        }
    }

    void UpdateIndicator()
    {
        string animationName = "p1s" + (currentLeftSelection + 1);
        slcAnimation.Play(animationName);
    }

    void UpdateRightIndicator()
    {
        string animationName = "p1s" + (currentLeftSelection + 1) + (currentRightSelection + 1);
        slcAnimation.Play(animationName);
    }

    IEnumerator PlayStringAnimation()
    {
        isStringAnimationPlaying = true;
        string stringAnimationName = "s" + (currentLeftSelection + 1) + (currentRightSelection + 1);

        stringAnimation1.Play(stringAnimationName);
        stringAnimation2.Play(stringAnimationName);
        stringAnimation3.Play(stringAnimationName);

        yield return new WaitUntil(() =>
            stringAnimation1.GetCurrentAnimatorStateInfo(0).IsName(stringAnimationName) &&
            stringAnimation1.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f &&
            stringAnimation2.GetCurrentAnimatorStateInfo(0).IsName(stringAnimationName) &&
            stringAnimation2.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f &&
            stringAnimation3.GetCurrentAnimatorStateInfo(0).IsName(stringAnimationName) &&
            stringAnimation3.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);

        if (!activeConnections.Contains(stringAnimationName))
        {
            activeConnections.Add(stringAnimationName);
        }

        FreezeAnimations(stringAnimation1, stringAnimationName);
        FreezeAnimations(stringAnimation2, stringAnimationName);
        FreezeAnimations(stringAnimation3, stringAnimationName);

        isStringAnimationPlaying = false;
        isSelectingRight = false; 
        HandleInput(); 

    }

    void FreezeAnimations(Animator animator, string animationName)
    {
        animator.speed = 0;
        animator.Play(animationName, 0, 1.0f);
    }

   
}