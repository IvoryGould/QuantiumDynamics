using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{

    Rigidbody _rigidbody;
    float speed = 10.0f;

    float distToGround;

    bool gravityToggle = false;
    bool timeToggle = false;
    bool stopTimeToggle = false;

    int enumIter;

    enum ABILITIES {

        GravityFilp,
        TimeSlow,
        TimeStop

    }

    private void Awake()
    {

        _rigidbody = GetComponent<Rigidbody>();

    }

    // Start is called before the first frame update
    void Start()
    {

        distToGround = GetComponent<CapsuleCollider>().bounds.extents.y;
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("GravityFlip")) {

            gravityToggle = !gravityToggle;

            if (gravityToggle == true) {

                Physics.gravity = new Vector3(0, 19.62f, 0);
                transform.Rotate(0, 0, 180, Space.Self);

            } else {

                Physics.gravity = new Vector3(0, -19.62f, 0);
                transform.Rotate(0, 0, 180, Space.Self);

            }

        }

        if (Input.GetButtonDown("TimeScaleSlow") && !stopTimeToggle) {

            timeToggle = !timeToggle;

            if (timeToggle == true)
                Time.timeScale = 0.2f; 
            else
                Time.timeScale = 1;

        }

        if (Input.GetButtonDown("TimeScaleStop")) {

            stopTimeToggle = !stopTimeToggle;
            timeToggle = false;

            if (stopTimeToggle == true) 
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
            
        }

        if (Input.GetButtonDown("AbilityBack")) {

            

        }

    }

    private void FixedUpdate()
    {

        Movement();

    }

    bool IsGrounded() {

        if(gravityToggle == false)
            return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f);
        else
            return Physics.Raycast(transform.position, Vector3.up, distToGround + 0.1f);

    }

    void Movement() {

        float translation = Input.GetAxis("Horizontal") * speed;

        translation *= Time.deltaTime;

        transform.Translate(translation, 0, 0, Space.World);

        if (translation > 0) {

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, -90, transform.eulerAngles.z);

        } else if (translation < 0) {

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90, transform.eulerAngles.z);

        }

        if (Input.GetButtonDown("Jump") && IsGrounded()) {

            if (gravityToggle == false)
                _rigidbody.AddForce(Vector3.up * 10f, ForceMode.Impulse);
            else
                _rigidbody.AddForce(Vector3.down * 10f, ForceMode.Impulse);

        }

    }

}
