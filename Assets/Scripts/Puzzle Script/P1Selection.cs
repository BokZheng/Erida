
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class P1Selection : MonoBehaviour
{
    public GameObject[] leftSelection;
    public GameObject[] rightSelection;
    public GameObject exitCarpet;

    public Animator slcAnimation;
    public Animator stringAnimation1;
    public Animator stringAnimation2;
    public Animator stringAnimation3;

    private int currentLeftSelection = 0;
    private int currentRightSelection = 0;
    private bool isSelectingRight = false;
    private bool isStringAnimationPlaying = false;
    private bool isCombinationTrue = false;

    private List<string> activeConnections = new List<string>(); // List to keep track of active connections

    void Start()
    {
        
        UpdateIndicator();
        
        exitCarpet.SetActive(false);
        isCombinationTrue = false;
    }

    void Update()
    {

        if (!isStringAnimationPlaying)
        {
            HandleInput();
        }
        if (isCombinationTrue == true)
        {
            Debug.Log(message: "comb true");
            CheckCombination();
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
                ExitSelectionMode();
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

        if (!activeConnections.Contains(stringAnimationName))
        {
            activeConnections.Add(stringAnimationName);
            Debug.Log(stringAnimationName);
        }
        if (activeConnections.Contains("s31") && activeConnections.Contains("s12") && activeConnections.Contains("s23"))
        {
            exitCarpet.SetActive(true);
        }



        // Play animations for all three animators
        stringAnimation1.Play(stringAnimationName);
        stringAnimation2.Play(stringAnimationName);
        stringAnimation3.Play(stringAnimationName);

        // Wait for the animations to finish
        yield return new WaitUntil(() =>
            stringAnimation1.GetCurrentAnimatorStateInfo(0).IsName(stringAnimationName) &&
            stringAnimation1.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f &&
            stringAnimation2.GetCurrentAnimatorStateInfo(0).IsName(stringAnimationName) &&
            stringAnimation2.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f &&
            stringAnimation3.GetCurrentAnimatorStateInfo(0).IsName(stringAnimationName) &&
            stringAnimation3.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);
        

        // Freeze animations at the end
        FreezeAnimations(stringAnimation1, stringAnimationName);
        FreezeAnimations(stringAnimation2, stringAnimationName);
        FreezeAnimations(stringAnimation3, stringAnimationName);

        //isStringAnimationPlaying = false;
        //isSelectingRight = false; // Ensure we go back to left selection
        //UpdateIndicator(); // Return to updating indicator

        

        // Stop the right selection animation explicitly
        //StopRightSelectionAnimation();
    }

    void FreezeAnimations(Animator animator, string animationName)
    {
        animator.speed = 0;
        animator.Play(animationName, 0, 1.0f);
    }

    /*void StopRightSelectionAnimation()
    {
        string rightAnimationName = "p1s" + (currentLeftSelection + 1) + (currentRightSelection + 1);
        */

    void ExitSelectionMode()
    {
        isStringAnimationPlaying = false;
        isSelectingRight = false;
        UpdateIndicator();
       
    }

    

    void CheckCombination()
    {
        if (activeConnections.Contains("s11") && activeConnections.Contains("s22") && activeConnections.Contains("s33"))
        {
            exitCarpet.SetActive(true);
        }
    }
}