using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Confirmation Dialogue", menuName = "Dialogue/Confirmation Dialogue")]
public class ConfirmationDialogue : ScriptableObject
{
    public string speakerName;
    public string dialogueText;
    public AudioClip typingSound;
}
