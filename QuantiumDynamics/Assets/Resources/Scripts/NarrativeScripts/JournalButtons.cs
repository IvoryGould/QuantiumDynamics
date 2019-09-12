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
        if (journalBoxTxt == null)
        {
            journalBox = GameObject.FindGameObjectWithTag("JournalBox");
            journalBoxTxt = journalBox.GetComponent<TextMeshProUGUI>();
        }
        if (narrativeManager.entry == true)
        {
            journalBoxTxt.text = narrativeManager.entryJourn;
        }
    }
    public void GravFlipButton()
    {
        if (journalBoxTxt == null)
        {
            journalBox = GameObject.FindGameObjectWithTag("JournalBox");
            journalBoxTxt = journalBox.GetComponent<TextMeshProUGUI>();
        }
        if(narrativeManager.gravAct==true)
        {
            journalBoxTxt.text = narrativeManager.gravActJourn;
        }
    }
    public void TestEnd()
    {
        if(journalBoxTxt == null)
        {
            journalBox = GameObject.FindGameObjectWithTag("JournalBox");
            journalBoxTxt = journalBox.GetComponent<TextMeshProUGUI>();
        }
        if(narrativeManager.end==true)
        {
            journalBoxTxt.text = narrativeManager.gravActJourn;
        }
    }
    public void KeyChipJourn()
    {
        if (journalBoxTxt == null)
        {
            journalBox = GameObject.FindGameObjectWithTag("JournalBox");
            journalBoxTxt = journalBox.GetComponent<TextMeshProUGUI>();
        }
        if (narrativeManager.keyChip == true)
        {
            journalBoxTxt.text = narrativeManager.keyChipJourn;
        }
    }
    public void RyanPortableJourn1()
    {
        if (journalBoxTxt == null)
        {
            journalBox = GameObject.FindGameObjectWithTag("JournalBox");
            journalBoxTxt = journalBox.GetComponent<TextMeshProUGUI>();
        }
        if (narrativeManager.ryanPortable1 == true)
        {
            journalBoxTxt.text = narrativeManager.ryanPortableJourn1;
        }
    }
    public void JasonPortableJourn1()
    {
        if (journalBoxTxt == null)
        {
            journalBox = GameObject.FindGameObjectWithTag("JournalBox");
            journalBoxTxt = journalBox.GetComponent<TextMeshProUGUI>();
        }
        if (narrativeManager.jasonPortable1 == true)
        {
            journalBoxTxt.text = narrativeManager.jasonPortableJourn1;
        }
    }
    public void RyanPortableJourn2()
    {
        if (journalBoxTxt == null)
        {
            journalBox = GameObject.FindGameObjectWithTag("JournalBox");
            journalBoxTxt = journalBox.GetComponent<TextMeshProUGUI>();
        }
        if (narrativeManager.ryanPortable2 == true)
        {
            journalBoxTxt.text = narrativeManager.ryanPortableJourn2;
        }
    }
    public void RyanIDCard()
    {
        if (journalBoxTxt == null)
        {
            journalBox = GameObject.FindGameObjectWithTag("JournalBox");
            journalBoxTxt = journalBox.GetComponent<TextMeshProUGUI>(); 
        }
        if (narrativeManager.ryanIDCard == true)
        {
            journalBoxTxt.text = narrativeManager.ryanIDCardJourn;
        }
    }
    public void VHSTapeJourn()
    {
        if (journalBoxTxt == null)
        {
            journalBox = GameObject.FindGameObjectWithTag("JournalBox");
            journalBoxTxt = journalBox.GetComponent<TextMeshProUGUI>();
        }
        if (narrativeManager.vHSTape == true)
        {
            journalBoxTxt.text = narrativeManager.vHSTapeJourn;
        }
    }
}
