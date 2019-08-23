using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Shifter : MonoBehaviour
{
    public GameObject[] Gates;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Interact"))
        {
            foreach (GameObject Gate in Gates)
            {
                Gate.GetComponent<Dummy_Shifter>().Switch();
            }
        }
    }
}
