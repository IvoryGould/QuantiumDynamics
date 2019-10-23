using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceApplyController : MonoBehaviour
{

    public float force;

    private bool trigger;
    private Collider colliderToPush;

    public enum FANTYPE {

        Push,
        Suck

    }

    public FANTYPE fanType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate() {

        if (trigger == true) {

            if(fanType == FANTYPE.Push)
                colliderToPush.attachedRigidbody.AddForce(new Vector3(0, force, 0), ForceMode.Acceleration);
            else if(fanType == FANTYPE.Suck)
                colliderToPush.attachedRigidbody.AddForce(new Vector3(0, -force, 0), ForceMode.Acceleration);


        }

    }

    private void OnTriggerEnter(Collider other) {

        colliderToPush = other;
        trigger = true;

    }

    private void OnTriggerExit(Collider other) {

        trigger = false;

    }

}
