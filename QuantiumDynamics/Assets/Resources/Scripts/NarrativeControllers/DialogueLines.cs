using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLines : MonoBehaviour
{
    public enum Dialogues
    {
        Entry,Distance,Gravity,Puzzle
    }
    public DialogueClass dialogueLines;
    public Queue<string> names;
    public Queue<float> timing;
    public Queue<string> diaLines;
    //[System.Serializable]
    
    public Dialogues dialogue;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void StartDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogueLines);

    }
    // Update is called once per frame
    void Update()
    {
        switch (dialogue)
        {
            case Dialogues.Entry:
                names = new Queue<string>();
                timing = new Queue<float>();
                diaLines = new Queue<string>();
                names.Enqueue("Ryan");
                timing.Enqueue(2.5f);
                diaLines.Enqueue("Good Morning, Andy.");
                names.Enqueue("Ryan");
                timing.Enqueue(6f);
                diaLines.Enqueue("If it's all right, we'd like to run another series of tests.");
                names.Enqueue("Andy");
                timing.Enqueue(5f);
                diaLines.Enqueue("Yes, father. I like to help you test.");
                names.Enqueue("Ryan");
                timing.Enqueue(10f);
                diaLines.Enqueue("I know you do, Andy. Let's start things off easy; just make your way up to that ledge up there.");
                break;
            case Dialogues.Distance:
                names = new Queue<string>();
                timing = new Queue<float>();
                diaLines = new Queue<string>();
                names.Enqueue("Ryan");
                timing.Enqueue(8f);
                diaLines.Enqueue("Very good, Andy. Let's find a path over these platforms next.");
                break;
            case Dialogues.Gravity:
                names = new Queue<string>();
                timing = new Queue<float>();
                diaLines = new Queue<string>();
                break;
            case Dialogues.Puzzle:
                break;
        }
    }
}
