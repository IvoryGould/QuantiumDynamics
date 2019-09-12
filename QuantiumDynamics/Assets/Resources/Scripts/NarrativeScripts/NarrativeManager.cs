using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NarrativeManager : MonoBehaviour
{
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
    private GameObject journalBox; 
    private TextMeshProUGUI journalBoxTxt;

    // Start is called before the first frame update
    void Start()
    {
        Object.DontDestroyOnLoad(this.gameObject);
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
    }
}
