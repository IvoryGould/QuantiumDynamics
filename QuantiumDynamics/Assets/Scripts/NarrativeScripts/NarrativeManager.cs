using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NarrativeManager : MonoBehaviour
{
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
        narrativeManager = Object.FindObjectsOfType<NarrativeManager>();
        if (narrativeManager.Length>=2)
        {
            Destroy(this);
        }
        Object.DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        terminals = new List<bool>();
        items = new List<bool>();
        logs = new List<bool>();
        terminals.Add(entry);
        entryJourn = "Test 487. \n\nGravity test 128 \n\nAbilities disabled to start, activate in backup chamber";
        terminals.Add(gravAct);
        gravActJourn = "Gravity flip now enabled.";
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
}
