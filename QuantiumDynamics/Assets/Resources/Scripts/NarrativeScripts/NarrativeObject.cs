﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeObject : MonoBehaviour
{
    public enum Type
    {
        Terminal, Item, Log
    }
    public enum Terminal
    {
        Null, Entry, GravFlip, EndLvl1
    }
    public enum Item
    {
        Null, KeyChip
    }
    public enum Log
    {
        Null
    }
    public Type type;
    public Terminal terminal;
    public Item item;
    public Log log;
    private string narrativeName;
    private NarrativeManager narrativeManager;
    private GameObject player;
    private Collider playerCol;
    // Start is called before the first frame update
    void Start()
    {
        if(narrativeManager==null)
        {
            narrativeManager = FindObjectOfType<NarrativeManager>();
        }
        if (playerCol ==null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerCol = player.GetComponent<Collider>();
        }
    }
    public void PickedUp()
    {
        switch (terminal)
        {
            case Terminal.Null:
                break;
            case Terminal.Entry:
                narrativeManager.entry = true;
                break;
            case Terminal.GravFlip:
                narrativeManager.gravAct = true;
                break;
            case Terminal.EndLvl1:
                narrativeManager.end = true;
                break;
        }
        switch (item)
        {
            case Item.KeyChip:
                narrativeManager.keyChip = true;
                break;
        }
    }
    public void OnTriggerStay(Collider playerCol)
    {
        switch (type)
        {
            case Type.Item:
                PickedUp();
                Destroy(this.gameObject);
                break;
            case Type.Terminal:
                if (Input.GetButtonDown("Interact"))
                {
                    PickedUp();
                }
                break;
        }
    }
}
