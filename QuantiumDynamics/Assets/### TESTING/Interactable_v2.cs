using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Interactable_v2 : MonoBehaviour
{
    public enum InteractionType { ButtonOpen_Door, ButtonMove_Platform, ButtonReturn_Platform, ButtonDialogue, EnterArea};

    public InteractionType Interaction;
    [Tooltip("Button that Player will use to activate")]
    private MeshCollider _sender;
    [Tooltip("GameObject that will move when activated")]
    public GameObject Reciever;     
    [Tooltip("Direction in which the 'reciever' will Move or Rotate when activated")]   
    public Vector3 Direction;       
    [Tooltip("How smoothly the object will transition to the next point")]
    public float DirectionSmoothing;
    [Tooltip("How the player will interact with this")]


    
    private GameObject _player;
    private bool _canActivate, _activated;
    private Vector3 _pointA, _pointB;


    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _sender = GetComponent<MeshCollider>();
        _canActivate = false;
        _pointA = Reciever.transform.position;
        _pointB = Reciever.transform.position + Direction;

        switch (Interaction)
        {
            case InteractionType.ButtonDialogue:
                Reciever.SetActive(false);
                break;
            default:
                break;
        }
    }

    void Update()
    {
        switch (Interaction)
        {
            case InteractionType.ButtonOpen_Door:
                if (_canActivate == true && Input.GetButtonDown("#Interact") && !_activated)
                {
                    _activated = true;
                    Activate();
                }
                else if (_activated == true)
                {
                    Activate();
                }
                break;
            case InteractionType.ButtonMove_Platform:
                if (_canActivate == true && Input.GetButtonDown("#Interact") && !_activated)
                {
                    _activated = true;
                    Activate();
                }
                else if (_activated == true)
                {
                    Activate();
                }
                break;
            case InteractionType.ButtonReturn_Platform:
                if (Input.GetButtonDown("#Interact") && !_activated)
                {
                    _activated = true;
                    Activate();
                }
                else if (Input.GetButtonDown("#Interact") && _activated == true)
                {
                    _activated = false;
                    Reactivate();
                }
                break;
            case InteractionType.EnterArea:
                if (_canActivate == true && !_activated)
                {
                    _activated = true;
                    Activate();
                }
                else if (_activated == true)
                {
                    Activate();
                }
                break;
            case InteractionType.ButtonDialogue:
                if (_canActivate == true && Input.GetButtonDown("#Interact") && !_activated)
                {
                    _activated = true;
                    DialogueBox();
                }
                break;
            default:
                Debug.Log("Something went wrong: Case switch [INTERACTION]");
            break;
        }
}

    private void OnTriggerEnter(Collider Player)
    {
        _canActivate = true;
    }

    private void OnTriggerExit(Collider Player)
    {
        _canActivate = false;
    }

    private void Activate()
    {
        Reciever.transform.position =
            Vector3.Lerp(Reciever.transform.position, _pointB , DirectionSmoothing * Time.deltaTime);
    }

    private void Reactivate()
    {
        Reciever.transform.position =
            Vector3.Lerp(Reciever.transform.position, _pointA, DirectionSmoothing * Time.deltaTime);
    }
    private void DialogueBox()
    {
        Reciever.SetActive(true);
    }
}
