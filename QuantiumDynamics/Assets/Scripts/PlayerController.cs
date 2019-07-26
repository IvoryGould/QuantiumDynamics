using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    Rigidbody _rigidbody;
    float speed = 10.0f;

    float distToGround;

    bool gravityToggle = false;
    bool timeToggle = false;
    bool stopTimeToggle = false;

    private bool pressedOnce;
    private float time;
    private float timerLength;

    private void Awake()
    {

        _rigidbody = GetComponent<Rigidbody>();

        pressedOnce = false;
        time = 0;
        timerLength = 1;

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

            if (gravityToggle == false)
                _rigidbody.AddForce(Vector3.up * 10f, ForceMode.Impulse);
            else
                _rigidbody.AddForce(Vector3.down * 10f, ForceMode.Impulse);

        }

        if (Input.GetButtonDown("GravityFlip")) {

            gravityToggle = !gravityToggle;

            if (gravityToggle == true) {

                Physics.gravity = new Vector3(0, 19.62f, 0);
                transform.Rotate(0, 180, 180, Space.Self);

            } else {

                Physics.gravity = new Vector3(0, -19.62f, 0);
                transform.Rotate(0, 180, 180, Space.Self);

            }

        }

        if (Input.GetButtonDown("TimeScale")) {

            if (!pressedOnce) {

                timeToggle = !timeToggle;

                if (timeToggle == true) {

                    Time.timeScale = 0.5f;

                } else {

                    Time.timeScale = 1;

                }

                pressedOnce = true;
                time = Time.time;

            }
            if (Time.time - time < timerLength && Input.GetButtonDown("TimeScale") && pressedOnce) {

                stopTimeToggle = !stopTimeToggle;

                if (stopTimeToggle == true) {

                    Time.timeScale = 0;

                } else {

                    Time.timeScale = 1;

                }

            }

        }

        if (pressedOnce) {

            if (Time.time - time > timerLength) {

                pressedOnce = false;

            }

            time += Time.deltaTime;

        }

    }

    private void FixedUpdate()
    {
        
        

    }

    bool IsGrounded() {

        if(gravityToggle == false)
            return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f);
        else
            return Physics.Raycast(transform.position, Vector3.up, distToGround + 0.1f);

    }

}
