using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(LineRenderer))]
public class AndyController : MonoBehaviour {

    Rigidbody _rigidbody;
    LineRenderer _lineRenderer;

    public GameObject AndyGhost;

    public float speed = 10f;
    public float jumpForce = 7.5f;

    [Header("Jump Calcs")]
    [Tooltip("Maximum Height the player can jump above its self")]
    public float maxJumpHeight; 
    [Tooltip("Gravity multiplier to be applyed to gravity after jump height is reached")]
    public float xGravity;
    private float intialPlayerPos;

    public float gravityModifier = 1;
    public float gravity;
    float intGravity;

    public QuantumPhysics quantumPhysics;

    private bool calledOnce;

    private bool isJumping;

    float distToGround;

    public bool gravityToggle = false;
    public bool timeToggle = false;
    public bool stopTimeToggle = false;
    public bool teleportToggle = false;

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
        _lineRenderer = GetComponent<LineRenderer>();

    }

    // Start is called before the first frame update
    void Start()
    {

        distToGround = GetComponent<CapsuleCollider>().bounds.extents.y;
        Time.timeScale = 1;
        _lineRenderer.enabled = false;
        intGravity = gravity;

    }

    // Update is called once per frame
    void Update()
    {

        //Movement();
        _lineRenderer.SetPosition(0, this.transform.position);

        if (IsGrounded()) {

            gravity = intGravity;
            calledOnce = false;

        }

        if (this.transform.position.y >= intialPlayerPos + maxJumpHeight && !IsGrounded() && !calledOnce) {

            gravity *= xGravity;
            isJumping = false;
            calledOnce = true;

        }

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

        if (Input.GetButtonDown("Teleport")) {

            teleportToggle = !teleportToggle;
            if (teleportToggle == true) {

                _lineRenderer.enabled = true;
                AndyGhost.GetComponent<MeshRenderer>().enabled = true;

            } else {

                _lineRenderer.enabled = false;
                AndyGhost.GetComponent<MeshRenderer>().enabled = false;

            }

        }

        Teleport();

    }

    private void FixedUpdate()
    {

        //_rigidbody.AddForce(0, gravityModifier * Physics.gravity.y, 0, ForceMode.Force);
        _rigidbody.velocity += new Vector3(0, gravityModifier * gravity, 0);

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

            if (gravityToggle == false) {

                _rigidbody.velocity = Vector3.up * jumpForce;
                isJumping = true;
                intialPlayerPos = this.transform.position.y;

            } else {

                _rigidbody.velocity = Vector3.down * jumpForce;

            }

        }

        if (transform.position.y < intialPlayerPos + maxJumpHeight && isJumping == true) {

            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, jumpForce);

        }

    }

    public LayerMask layerMask;
    public bool flipMask;

    void Teleport()
    {

        RaycastHit mouseHit;

        GhostCollision ghostCollision = AndyGhost.GetComponent<GhostCollision>();

        int distance = 5;

        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        Vector3 unitVector = new Vector3();

        if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out mouseHit, Mathf.Infinity, layerMask)) {

            float dX = (mouseHit.point.x - transform.position.x) * (mouseHit.point.x - transform.position.x);
            float dY = (mouseHit.point.y - transform.position.y) * (mouseHit.point.y - transform.position.y);

            float pointDistance = Mathf.Sqrt(dX + dY);

            unitVector.x = (mouseHit.point.x - this.transform.position.x) / pointDistance;
            unitVector.y = (mouseHit.point.y - this.transform.position.y) / pointDistance;

            if (pointDistance > distance) {

                _lineRenderer.SetPosition(1, this.transform.position + (distance * unitVector));

            } else {

                _lineRenderer.SetPosition(1, new Vector3(mouseHit.point.x, mouseHit.point.y));

            }

            if(teleportToggle)
                AndyGhost.transform.position = _lineRenderer.GetPosition(1);

            if (ghostCollision.isColliding == true)
                AndyGhost.GetComponent<Renderer>().material.color = new Color(255, 0, 0, 45);
            else
                AndyGhost.GetComponent<Renderer>().material.color = new Color(0, 0, 255, 45);

            if (Input.GetButtonDown("Fire1") && teleportToggle == true && ghostCollision.isColliding == false) {

                this.transform.position = _lineRenderer.GetPosition(1);
                teleportToggle = false;
                _lineRenderer.enabled = false;
                AndyGhost.GetComponent<MeshRenderer>().enabled = false;

            }
             
        }

    }

}
