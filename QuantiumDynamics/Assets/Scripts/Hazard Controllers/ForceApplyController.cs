using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceApplyController : MonoBehaviour
{

    public float force;

    private bool trigger;
    private Collider colliderToPush;

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

            colliderToPush.attachedRigidbody.AddForce(new Vector3(0, force, 0), ForceMode.Acceleration);
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
