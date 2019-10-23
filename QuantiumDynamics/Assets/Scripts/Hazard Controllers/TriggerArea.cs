using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{

    public bool Triggered;

    private void OnTriggerEnter(Collider other) {

        if (other.tag == "Player") {

            Triggered = true;

        }

    }

}
