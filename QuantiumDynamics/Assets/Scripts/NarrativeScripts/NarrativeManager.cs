using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

[Serializable]

public class NarrativeManager : MonoBehaviour
{

    public BinaryIO binaryIO;
    private NarrativeManager[] narrativeManager;
    //List of all terminals
    [HideInInspector]
    public List<bool> terminals;
    //List of all items that can be picked up
    [HideInInspector]
    public List<bool> items;
    //List of all logs that can be found and stored
    [HideInInspector]
    public List<bool> logs;
    public bool entry;
    public string entryJourn;
    public bool gravAct;
    public string gravActJourn;
    public bool end;
    public string endJourn;
    public bool keyChip;
    public string keyChipJourn;
    public bool ryanPortable1;
    public string ryanPortableJourn1;
    public bool jasonPortable1;
    public string jasonPortableJourn1;
    public bool ryanPortable2;
    public string ryanPortableJourn2;
    public bool ryanIDCard;
    public string ryanIDCardJourn;
    public bool vHSTape;
    public string vHSTapeJourn;
    public bool jasonIDCard;
    public string jasonIDCardJourn;
    private GameObject journalBox; 
    private TextMeshProUGUI journalBoxTxt;
    public Scene currentScene;

    void Awake()
    {
        //If it exists already, delete the new instance
        narrativeManager = UnityEngine.Object.FindObjectsOfType<NarrativeManager>();
        if (narrativeManager.Length>=2)
        {
            Destroy(this);
        }
        UnityEngine.Object.DontDestroyOnLoad(this.gameObject);

    }
    // Start is called before the first frame update
    void Start()
    {
        binaryIO = UnityEngine.Object.FindObjectOfType<BinaryIO>();
        terminals = new List<bool>();
        items = new List<bool>();
        logs = new List<bool>();

        terminals.Add(entry);
        entryJourn = "Test 487. \n\nGravity test 128 \n\nThis test will see how effective you are at navigating by flipping your gavity (X).";
        terminals.Add(gravAct);
        gravActJourn = "The lasers in front of you will kill you...as will any others.";
        terminals.Add(end);
        endJourn = "Test Complete.";
        items.Add(keyChip);
        keyChipJourn = "This is a chip that unlocks the door in Level 1.";
        logs.Add(ryanPortable1);
        ryanPortableJourn1 = "'Prototype Andy seems to have developed unexpected quirks, imprinting on me and referring to me as ‘father’. Requires investigation as to why; not because unwelcome, but out of curiosity.'".Replace("'", "\"");
        logs.Add(jasonPortable1);
        jasonPortableJourn1 = "'Ryan seems oddly attached to the prototype, getting amused by it’s little quirks. His short-sightedness is also starting to cause problems with our research; our funding is starting to dry up, and he’s unwilling to accept military contracts for when the technology is ready. If it keeps up, the only reasonable course may be to go behind his back and accept one to keep the lights on and lab functional.'".Replace("'", "\"");
        logs.Add(ryanPortable2);
        ryanPortableJourn2 = "'Jason continues to bring up military projects as a way to increase funding. He fails to see just how dangerous this technology would be in militaristic hands; when leveraged to it’s full potential, it would make an army, or even a single entity, unstoppable. The technology must be contained, or at the very least kept to a select group of people who understand the situation at stake. No military can be trusted to do so, private or otherwise.'".Replace("'", "\"");
        items.Add(ryanIDCard);
        ryanIDCardJourn = "Ryan’s ID card for the lab. He mentioned it was missing a while ago, and had a new one made, I guess this is his old one. I wonder if it still works to get access to places that are usually locked off...or did he lose it again...maybe I should ask him. He's always losing things.";
        items.Add(vHSTape);
        vHSTapeJourn = "I don’t even know what this is. It seems to encode images onto a magnetic strip, but we haven’t used that kind of storage for anything like that here; we only use that for data storage, and they don’t look like this. Reading it as best I can, it seems to have lots of similar pictures of Ryan, but not as I’ve known him. I wonder what it could be.";
        items.Add(jasonIDCard);
        jasonIDCardJourn = "Jason’s ID card for the lab. It looks like it got caught on something and ripped off the clip. He hasn’t mentioned it was missing, so I guess it just happened. Hopefully he isn’t freaking out about it; he seems to get pretty worried about some things, even when he’s told he doesn’t need to worry. I’ll give it to him when I see him.";

    }
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            currentScene = SceneManager.GetActiveScene();
            if (currentScene.buildIndex==0)
            {
                Application.Quit();
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void CheckBools() {

        if (binaryIO.boolData.terminals.Count == 0) {

            binaryIO.boolData.terminals.Add(entry);
            binaryIO.boolData.terminals.Add(gravAct);
            binaryIO.boolData.terminals.Add(end);

        } else {

            binaryIO.boolData.terminals[0] = entry;
            binaryIO.boolData.terminals[1] = gravAct;
            binaryIO.boolData.terminals[2] = end;

        }

        if (binaryIO.boolData.items.Count == 0) {

            binaryIO.boolData.items.Add(keyChip);
            binaryIO.boolData.items.Add(ryanIDCard);
            binaryIO.boolData.items.Add(vHSTape);
            binaryIO.boolData.items.Add(jasonIDCard);

        } else {

            binaryIO.boolData.items[0] = keyChip;
            binaryIO.boolData.items[1] = ryanIDCard;
            binaryIO.boolData.items[2] = vHSTape;
            binaryIO.boolData.items[3] = jasonIDCard;

        }

        if (binaryIO.boolData.logs.Count == 0) {

            binaryIO.boolData.logs.Add(ryanPortable1);
            binaryIO.boolData.logs.Add(jasonPortable1);
            binaryIO.boolData.logs.Add(ryanPortable2);

        } else {

            binaryIO.boolData.logs[0] = ryanPortable1;
            binaryIO.boolData.logs[1] = jasonPortable1;
            binaryIO.boolData.logs[2] = ryanPortable2;

        }

    }

    public void LoadBools() {

       entry = binaryIO.boolData.terminals[0];
       gravAct = binaryIO.boolData.terminals[1];
       end = binaryIO.boolData.terminals[2];

        keyChip = binaryIO.boolData.items[0];
        ryanIDCard = binaryIO.boolData.items[1];
        vHSTape = binaryIO.boolData.items[2];
        jasonIDCard = binaryIO.boolData.items[3];

        ryanPortable1 = binaryIO.boolData.logs[0];
        jasonPortable1 = binaryIO.boolData.logs[1];
        ryanPortable2 = binaryIO.boolData.logs[2];

    }

}
