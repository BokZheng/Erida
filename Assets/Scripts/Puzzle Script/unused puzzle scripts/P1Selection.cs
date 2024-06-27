using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class P1Selection : MonoBehaviour
{
    public GameObject[] leftSelection;  
    public GameObject[] rightSelection;

    public Animator slcAnimation;
    public Animator stringAnimation;

    private int currentLeftSelection = 0;
    private int currentRightSelection = 0;
    private bool isSelectingRight = false;
    private bool isStringAnimationPlaying = false;

    private HashSet<string> activeConnections = new HashSet<string>(); // Set to keep track of active connections

    void Start()
    {
        UpdateIndicator();
        
    }

    void Update()
    {
        if (!isStringAnimationPlaying)
        HandleInput();
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
                //StartCoroutine(PlayStringAnimation());
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
                
                isSelectingRight = false;
                StartCoroutine(PlayStringAnimation());
            }
        }
    }

    void ChangeSelection(ref int selectionIndex, int selectionLength, int change)
    {
        selectionIndex += change;
        if (selectionIndex < 0)
            selectionIndex = selectionLength - 1;
        else if (selectionIndex >= selectionLength)
            selectionIndex = 0;
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
        string StringOfStringani = "s" + (currentLeftSelection + 1) + (currentRightSelection + 1);
        stringAnimation.Play(StringOfStringani);
        //Debug.Log(message: StringStringani);

        while (stringAnimation.GetCurrentAnimatorStateInfo(0).IsName(StringOfStringani) && stringAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }

        stringAnimation.speed = 0;

        activeConnections.Add(StringOfStringani);

        stringAnimation.Play(StringOfStringani, 0, 1.0f);

        foreach (string connection in activeConnections)
        {
            stringAnimation.Play(connection, 0, 1.0f);
        }

        stringAnimation.speed = 1; 

        isStringAnimationPlaying = false; 
        UpdateIndicator(); 

        //stringAnimation.Play(StringStringani, 0, 1f);
        //stringAnimation.speed = 0;
        //yield return new WaitForSeconds(0.1f);
        //isStringAnimationPlaying = false; 
        //UpdateIndicator();

        /*activeConnections.Add(StringOfStringani);

        isStringAnimationPlaying = false; // Enable input after animation
        UpdateIndicator(); // Update the left selection indicator for the next round

        // Restart the animator to apply the active connections
        foreach (string connection in activeConnections)
        {
            stringAnimation.Play(connection, 0, 1.0f);
        }*/
    }


    
}









/*void Start()
{
    UpdateIndicator();
}

void Update()
{
    HandleInput();
}

void HandleInput()
{
    if (Input.GetKeyDown(KeyCode.W))
    {
        currentselection--;
        if (currentselection < 0)
            currentselection = selection.Length - 1;
        UpdateIndicator();
    }
    else if (Input.GetKeyDown(KeyCode.S))
    {
        currentselection++;
        if (currentselection >= selection.Length)
            currentselection = 0;
        UpdateIndicator();
    }
    else if (Input.GetKeyDown(KeyCode.E))
    {

        if (currentselection == 0)
        {
            slcAnimation.Play("p1s21");
        }
        else if (currentselection == 1)
        {
            slcAnimation.Play("p1s21");
        }
        else if (currentselection == 2)
        {
            slcAnimation.Play("p1s31");
        }
    }
}


void UpAndDownSelection()
{
    if (Input.GetKeyDown(KeyCode.W))
    {
        nextselection--;
        if (nextselection < 0)
            nextselection = selection2.Length - 1;
        SecondIndicator();
    }
    else if (Input.GetKeyDown(KeyCode.S))
    {
        nextselection++;
        if (nextselection >= selection2.Length)
            nextselection = 0;
        SecondIndicator();
    }
}

void SecondIndicator()
{
    if (nextselection == 0)
    {
        switch (nextselection)
        {

        }
    }
    else if (currentselection == 1)
    {
        slcAnimation.Play("p1s2");
    }
    else if (currentselection == 2)
    {
        slcAnimation.Play("p1s3");
    }
}

void UpdateIndicator()
{
    if (currentselection == 0)
    {
        slcAnimation.Play("p1s1");
    }
    else if (currentselection == 1)
    {
        slcAnimation.Play("p1s2");
    }
    else if (currentselection == 2)
    {
        slcAnimation.Play("p1s3");
    }
}*/