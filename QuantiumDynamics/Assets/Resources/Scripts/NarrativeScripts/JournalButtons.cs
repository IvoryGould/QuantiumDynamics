using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JournalButtons : MonoBehaviour
{
    private NarrativeManager narrativeManager;
    private GameObject journalBox;
    private TextMeshProUGUI journalBoxTxt;
    // Start is called before the first frame update
    void Start()
    {
        narrativeManager = GetComponent<NarrativeManager>();
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
        if (narrativeManager.entry == true)
        {
            journalBoxTxt.text = narrativeManager.entryJourn;
        }
    }
}
