using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class DialogueLines
{
    [TextArea(1, 5)]
    public string[] dialogueLines;
    public float[] timing;
    [SerializeField]
    private TextMeshProUGUI textBox;
}
