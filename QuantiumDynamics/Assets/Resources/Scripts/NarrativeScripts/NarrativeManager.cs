using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NarrativeManager : MonoBehaviour
{
    //List of all terminals
    public List<bool> terminals;
    //List of all items that can be picked up
    public List<bool> items;
    //List of all logs that can be found and stored
    public List<bool> logs;
    public bool entry;
    public string entryJourn;
    public bool gravAct;
    public string gravActJourn;
    public bool end;
    public string endJourn;
    public bool keyChip;
    public string keyChipJourn;
    private GameObject journalBox;
    private TextMeshProUGUI journalBoxTxt;

    // Start is called before the first frame update
    void Start()
    {
        terminals = new List<bool>();
        items = new List<bool>();
        terminals.Add(entry);
        entryJourn = "Test 487. \n\nGravity test 128 \n\nAbilities disabled to start, activate in backup chamber";
        terminals.Add(gravAct);
        gravActJourn = "Gravity flip now enabled.";
        terminals.Add(end);
        endJourn = "Test Complete.";
        items.Add(keyChip);
        keyChipJourn = "This chip unlocks the door in Level 1.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
