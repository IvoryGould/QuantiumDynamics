using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotater : MonoBehaviour
{

    public float rotateVelocity;
    Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {

        _rigidbody = this.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        _rigidbody.angularVelocity = new Vector3(0, 0, rotateVelocity);

    }
}
