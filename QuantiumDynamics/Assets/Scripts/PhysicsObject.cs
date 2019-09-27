using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsObject : MonoBehaviour
{

    public QuantumPhysics quantumPhysics;

    [Header("Rotation")]
    [Tooltip("The speed at which to rotate")]
    public float rotationSpeed;

    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {

        _rigidbody = this.GetComponent<Rigidbody>();
        //_rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        _rigidbody.useGravity = false;

    }

    // Update is called once per frame
    void Update()
    {

        _rigidbody.velocity = new Vector3(0, quantumPhysics.gravityModifier * quantumPhysics.gravity);

        _rigidbody.velocity *= quantumPhysics.timeModifier;
        _rigidbody.angularVelocity = new Vector3(0, 0, rotationSpeed * quantumPhysics.timeModifier);

    }
}
