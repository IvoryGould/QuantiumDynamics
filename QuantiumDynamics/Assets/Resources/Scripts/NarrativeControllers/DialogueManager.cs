using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> dialogueLines;
    private Queue<float> timing;
    private TextMeshProUGUI textBox;
    private float? time;
    // Start is called before the first frame update
    void Start()
    {
        dialogueLines = new Queue<string>();
        if (textBox == null)
        {
            textBox = FindObjectOfType<TextMeshProUGUI>();
        }
        timing = new Queue<float>();
        dialogueLines.Clear();
        time = null;
    }
    void Update()
    {
        if (time != null)
        {
            time = time - Time.deltaTime;
            if (time <= 0f)
            {
                NextLine();
            }
        }
        Debug.Log(time);
    }
    public void StartDialogue (DialogueLines dialogue)
    {
        dialogueLines.Clear();
        timing.Clear();
        foreach (string line in dialogue.dialogueLines)
        {
            dialogueLines.Enqueue(line);
        }
        foreach (float time in dialogue.timing)
        {
            timing.Enqueue(time);
        }
        NextLine();
    }
    public void NextLine()
    {
        if (dialogueLines.Count == 0)
        {
            EndDialogue();
            time = null;
        }
        else
        {
            string line = dialogueLines.Dequeue();
            time = timing.Dequeue();
            textBox.text = line;
        }

    }
    void EndDialogue()
    {
        Debug.Log("ConvEnd");
        timing.Clear();
        textBox.text = " ";
    }
}
