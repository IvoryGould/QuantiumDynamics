using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Tooltip("Autofills based off tag")]
    public GameObject[] platforms;
    [Tooltip("Autofills based off tag")]
    public GameObject[] doors;
    [Tooltip("Place on the GameObject with the collider you want")]
    public Collider button;
    [SerializeField]
    [Tooltip("Autofills based off tag")]
    private GameObject player;
    [Tooltip("Autofills based off Doors script")]
    public Doors[] doorControl;
    [Tooltip("Autofills based off Platforms script")]
    public Platforms[] platformControl;
    // Start is called before the first frame update
    void Start()
    {
        platforms = GameObject.FindGameObjectsWithTag("Platform");
        doors = GameObject.FindGameObjectsWithTag("Door");
        button = GetComponent<Collider>();
        player = GameObject.FindGameObjectWithTag("Player");
        doorControl = FindObjectsOfType<Doors>();
        platformControl = FindObjectsOfType<Platforms>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider player)
    {
        if (Input.GetButtonDown("Fire3"))
        {
            for (int i = 0; i < doors.Length; i++)
            {
                doorControl[i].MoveDoors();
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            for (int i = 0; i < doors.Length; i++)
            {
                platformControl[i].MovePlatforms();
            }
        }
    }
}
