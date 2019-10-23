using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWallController : MonoBehaviour
{

    Transform waypointOne;
    Transform waypointTwo;

    public float moveSpeed;

    private Rigidbody _rigidbody;
    private Vector3 startPosition;

    PhysicsObject physicsObject;
    TriggerArea triggerArea;

    bool hasHitOne;
    bool hasHitTwo;

    public enum LAZERTYPE {

        Stationary,
        NonTrigger,
        Trigger

    }

    public LAZERTYPE lazerType;

    private void Awake() {

        _rigidbody = GetComponent<Rigidbody>();
        waypointOne = this.transform.parent.GetChild(0);
        waypointTwo = this.transform.parent.GetChild(1);
        physicsObject = GetComponent<PhysicsObject>();
        triggerArea = transform.parent.GetChild(3).GetComponent<TriggerArea>();

    }

    private void Start() {

    }

    private void Update() {
        


    }

    private void FixedUpdate() {

        if (lazerType == LAZERTYPE.NonTrigger) {

            if (hasHitOne == false) {

                transform.position = Vector3.MoveTowards(transform.position, waypointOne.position, moveSpeed * physicsObject.quantumPhysics.timeModifier * Time.fixedDeltaTime);

                if (transform.position == waypointOne.position) {

                    hasHitOne = true;
                    hasHitTwo = false;

                }

            } else if (hasHitTwo == false){

                transform.position = Vector3.MoveTowards(transform.position, waypointTwo.position, moveSpeed * physicsObject.quantumPhysics.timeModifier * Time.fixedDeltaTime);

                if (transform.position == waypointTwo.position) {

                    hasHitTwo = true;
                    hasHitOne = false;

                }

            }

        }

        if (lazerType == LAZERTYPE.Trigger) {

            if (triggerArea.Triggered == true) {

                if (hasHitOne == false) {

                    transform.position = Vector3.MoveTowards(transform.position, waypointOne.position, moveSpeed * physicsObject.quantumPhysics.timeModifier * Time.fixedDeltaTime);

                    if (transform.position == waypointOne.position) {

                        hasHitOne = true;
                        hasHitTwo = false;

                    }

                } else if (hasHitTwo == false) {

                    transform.position = Vector3.MoveTowards(transform.position, waypointTwo.position, moveSpeed * physicsObject.quantumPhysics.timeModifier * Time.fixedDeltaTime);

                    if (transform.position == waypointTwo.position) {

                        hasHitTwo = true;
                        hasHitOne = false;

                    }

                }

            }

        }

    }

}
