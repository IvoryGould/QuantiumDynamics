using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class AndyController : MonoBehaviour
{

    Rigidbody _rigidbody;
    public float speed = 10f;
    public float jumpForce = 7.5f;

    public float gravityModifier = 1;

    public QuantumPhysics quantumPhysics;

    float distToGround;

    bool gravityToggle = false;
    bool timeToggle = false;
    bool stopTimeToggle = false;

    int enumIter;

    enum ABILITIES
    {

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

        //Movement();

        if (Input.GetButtonDown("GravityFlip") && !stopTimeToggle) {

            gravityToggle = !gravityToggle;

            if (gravityToggle == true) {

                //Physics.gravity = new Vector3(0, 19.62f, 0);
                this.gravityModifier = -1 / Time.timeScale;
                transform.Rotate(0, 0, 180, Space.Self);

            } else {

                //Physics.gravity = new Vector3(0, -19.62f, 0);
                this.gravityModifier = 1 / Time.timeScale;
                transform.Rotate(0, 0, 180, Space.Self);

            }

        }

        if (Input.GetButtonDown("TimeScaleSlow") && !stopTimeToggle) {

            timeToggle = !timeToggle;

            if (timeToggle == true)
                quantumPhysics.timeModifier = 0.2f;
            //Time.timeScale = 0.2f;
            else
                quantumPhysics.timeModifier = 1;
                //Time.timeScale = 1;

            Time.fixedDeltaTime = 0.02f * Time.timeScale;

        }

        if (Input.GetButtonDown("TimeScaleStop")) {

            stopTimeToggle = !stopTimeToggle;
            timeToggle = false;

            if (stopTimeToggle == true)
                quantumPhysics.timeModifier = 0;
            //Time.timeScale = 0;
            else
                quantumPhysics.timeModifier = 1;
                //Time.timeScale = 1;

        }

        if (Input.GetButtonDown("AbilityBack")) {



        }

    }

    private void FixedUpdate()
    {

        //_rigidbody.AddForce(0, gravityModifier * Physics.gravity.y, 0, ForceMode.Force);
        _rigidbody.velocity += new Vector3(0, gravityModifier * -0.25f, 0);

        Movement();

    }

    bool IsGrounded()
    {

        if (gravityToggle == false)
            return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f);
        else
            return Physics.Raycast(transform.position, Vector3.up, distToGround + 0.1f);

    }

    void Movement()
    {

        float translation = Input.GetAxis("Horizontal") * speed;
        
        //translation *= Time.deltaTime;

        //transform.Translate(translation, 0, 0, Space.World);
        _rigidbody.velocity = new Vector3(translation, _rigidbody.velocity.y);


        if (translation > 0) {

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, -90, transform.eulerAngles.z);

        } else if (translation < 0) {

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90, transform.eulerAngles.z);

        }

        if (Input.GetButtonDown("Jump") && IsGrounded()) {

            if (gravityToggle == false)
                _rigidbody.velocity = Vector3.up * jumpForce;
            else
                _rigidbody.velocity = Vector3.down * jumpForce;

        }

    }

    void Teleport()
    {



    }

}
