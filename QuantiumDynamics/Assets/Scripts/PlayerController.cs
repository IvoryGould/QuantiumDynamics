using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    Rigidbody _rigidbody;
    float speed = 10.0f;

    float distToGround;

    private void Awake()
    {

        _rigidbody = GetComponent<Rigidbody>();

    }

    // Start is called before the first frame update
    void Start()
    {

        distToGround = GetComponent<CapsuleCollider>().bounds.extents.y;

    }

    // Update is called once per frame
    void Update()
    {

        float translation = Input.GetAxis("Horizontal") * speed;

        translation *= Time.deltaTime;

        transform.Translate(translation, 0, 0);

        if (Input.GetButtonDown("Jump") && IsGrounded()) {

            _rigidbody.AddForce(Vector3.up * 10f, ForceMode.Impulse);

        }

    }

    private void FixedUpdate()
    {
        
        

    }

    bool IsGrounded() {

        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);

    }

}
