using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueEntry
{
    public string speakerName;
    [TextArea(3, 10)]
    public string dialogueText;
}