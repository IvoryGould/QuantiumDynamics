using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCollision : MonoBehaviour
{

    public bool isColliding;

    private void OnTriggerEnter(Collider other) {

        isColliding = true;

    }

    private void OnTriggerExit(Collider other) {

        isColliding = false;

    }

}
