using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> names;
    private Queue<string> dialogueLines;
    private Queue<float> timing;
    private TextMeshProUGUI[] textBoxes;
    private TextMeshProUGUI nameBox;
    private TextMeshProUGUI diaBox;
    private float? time;
    private DialogueLines diaLines;
    // Start is called before the first frame update
    void Start()
    {
        diaLines = FindObjectOfType<DialogueLines>();
        names = new Queue<string>();
        dialogueLines = new Queue<string>();
        if (textBoxes == null)
        {
            textBoxes = FindObjectsOfType<TextMeshProUGUI>();
            if (textBoxes[0].name == "DialogueBox")
            {
                diaBox = textBoxes[0];
                nameBox = textBoxes[1];
            }
            else
            {
                nameBox = textBoxes[0];
                diaBox = textBoxes[1];
            }

        }
        timing = new Queue<float>();
        names.Clear();
        dialogueLines.Clear();
        time = null;
        diaBox.text = " ";
        nameBox.text = " ";
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
    public void StartDialogue (DialogueClass dialogue)
    {
        names.Clear();
        dialogueLines.Clear();
        timing.Clear();
        /*foreach (string line in dialogue.dialogueLines)
        {
            dialogueLines.Enqueue(line);
        }
        foreach (float time in dialogue.timing)
        {
            timing.Enqueue(time);
        }
        foreach (string name in dialogue.names)
        {
            names.Enqueue(name);
        }*/
        dialogueLines = diaLines.diaLines;
        timing = diaLines.timing;
        names = diaLines.names;
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
            string name = names.Dequeue();
            string line = dialogueLines.Dequeue();
            time = timing.Dequeue();
            diaBox.text = line;
            nameBox.text = name;
        }

    }
    void EndDialogue()
    {
        Debug.Log("ConvEnd");
        timing.Clear();
        nameBox.text = " ";
        diaBox.text = " ";
    }
}
