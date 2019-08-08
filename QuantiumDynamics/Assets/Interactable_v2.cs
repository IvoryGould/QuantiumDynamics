using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Interactable_v2 : MonoBehaviour
{
    public enum InteractionType { ButtonPress, EnterArea, Dialogue };

    public InteractionType Interaction;
    [Tooltip("Button that Player will use to activate")]
    private MeshCollider _sender;
    [Tooltip("GameObject that will move when activated")]
    public GameObject Reciever;     
    [Tooltip("Direction in which [object] moves when activated")]   
    public Vector3 Direction;       
    [Tooltip("How smoothly the object will transition to the next point")]
    public float DirectionSmoothing;
    [Tooltip("How the player will interact with this")]
    

    private GameObject _player;
    private bool _canActivate, _activated;
    private Vector3 _pointB;


    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _sender = GetComponent<MeshCollider>();
        _canActivate = false;
        _pointB = Reciever.transform.position + Direction;

        switch (Interaction)
        {
            case InteractionType.Dialogue:
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
            case InteractionType.ButtonPress:
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
            case InteractionType.Dialogue:
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

    private void DialogueBox()
    {
        Reciever.SetActive(true);
    }
}
