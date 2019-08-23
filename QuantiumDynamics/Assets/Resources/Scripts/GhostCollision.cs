using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCollision : MonoBehaviour
{

    public bool isColliding;

    private void OnTriggerStay(Collider other) {

        isColliding = true;

    }

}
