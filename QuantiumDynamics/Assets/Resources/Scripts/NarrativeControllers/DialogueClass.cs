using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class DialogueClass
{
    private string[] names;
    [TextArea(1, 5)]
    private string[] dialogueLines;
    private float[] timing;
}
