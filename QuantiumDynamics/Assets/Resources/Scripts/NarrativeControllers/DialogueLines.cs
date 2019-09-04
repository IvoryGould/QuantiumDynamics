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
    public string[] namesArray;
    public float[] timingArray;
    public string[] diaLinesArray;
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
                namesArray = new string[4];
                timingArray = new float[4];
                diaLinesArray = new string[4];
                namesArray[0] = "Ryan";
                timingArray[0] = 2.5f;
                diaLinesArray[0] = "Good Morning, Andy.";
                namesArray[1] = "Ryan";
                timingArray[1] = 6f;
                diaLinesArray[1] = "If it's all right, we'd like to run another series of tests.";
                namesArray[2] = "Andy";
                timingArray[2] = 5f;
                diaLinesArray[2] = "Yes, father. I like to help you test.";
                namesArray[3] = "Ryan";
                timingArray[3] = 10f;
                diaLinesArray[3] = "I know you do, Andy. Let's start things off easy; just make your way up to that ledge up there.";
                names = new Queue<string>();
                foreach (string name in namesArray)
                {
                    names.Enqueue(name);
                }
                timing = new Queue<float>();
                foreach (float time in timingArray)
                {
                    timing.Enqueue(time);
                }
                diaLines = new Queue<string>();
                foreach (string dialogue in diaLinesArray)
                {
                    diaLines.Enqueue(dialogue);
                }
                //names.Enqueue("Ryan");
                //timing.Enqueue(2.5f);
                //diaLines.Enqueue("Good Morning, Andy.");
                //names.Enqueue("Ryan");
                //timing.Enqueue(6f);
                //diaLines.Enqueue("If it's all right, we'd like to run another series of tests.");
                //names.Enqueue("Andy");
                //timing.Enqueue(5f);
                //diaLines.Enqueue("Yes, father. I like to help you test.");
                //names.Enqueue("Ryan");
                //timing.Enqueue(10f);
                //diaLines.Enqueue("I know you do, Andy. Let's start things off easy; just make your way up to that ledge up there.");
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
