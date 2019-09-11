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
    private GameObject journalBox;
    private TextMeshProUGUI journalBoxTxt;

    // Start is called before the first frame update
    void Start()
    {
        entry = terminals[0] = false;
        entryJourn = "Test 487. \n\nGravity test 128 \n\nAbilities disabled to start, activate in backup chamber";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EntryEntry()
    {
        if (journalBox == null)
        {
            journalBox = GameObject.FindGameObjectWithTag("JournalBox");
            journalBoxTxt = journalBox.GetComponent<TextMeshProUGUI>();
        }
        if (entry == true)
        {
            journalBoxTxt.text = entryJourn;
        }
    }
}
