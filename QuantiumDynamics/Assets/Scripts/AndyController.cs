﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
//[RequireComponent(typeof(LineRenderer))]
public class AndyController : MonoBehaviour {

    Rigidbody _rigidbody; //players member rigidbody
    //LineRenderer _lineRenderer; //players member linerenderer
    Animator _animator;
    DeathCollision deathCollision;
    GameObject deathPanel;

    [Header("Generic")]
    [Tooltip("The holographic render of the character for teleport feedback")]
    public GameObject AndyGhost;

    [Header("EnergyBar")]
    [Tooltip("How much energy to remove when gravity flipping")]
    public float gravSubtract;
    [Tooltip("How much energy to Drain per drain tick")]
    public float drainAmount;
    [Tooltip("How much time between drain ticks")]
    public float drainTickTime;
    [Tooltip("How much the energy bar is to refill each tick")]   
    public float refillAmount;
    [Tooltip("How much time between refill ticks")]
    public float fillTickTime;

    [Header("Player Physics")]
    [Tooltip("Maximum Height the player can jump above its self")]
    public float maxJumpHeight; 
    [Tooltip("Gravity multiplier to be applyed to gravity after jump height is reached")]
    public float xGravity;
    [Tooltip("Gravity of the Player")]
    public float gravity = -0.5f;
    [Tooltip("Players Speed to be applyed in movement")]
    public float speed = 10f;
    [Tooltip("Players jump speed to be applyed when jumping")]
    public float jumpForce = 7.5f;
    [Tooltip("Non-physics layer for raycasting")]
    public LayerMask layerMask;

    [Header("UI Items")]
    public GameObject hudBase;
    public GameObject timeIcon;
    public GameObject gravIcon;
    [Tooltip("Energy Bar image for accessing the fill property")]
    public Image energyBar;


    private bool calledOnce;
    private bool isJumping; //check to see if the player is jumping
    private float gravityModifier = 1; //gravity flip modifier
    private bool fillCalledOnce;
    private bool drainCalledOnce;
    private float intialPlayerPos; //storage of the players position for jumping
    private QuantumPhysics quantumPhysics;
    private PlayerCameraController cameraController;
    private bool spinCalledOnce;

    float distToGround;
    float intGravity;

    //toggles for the ablities
    bool gravityToggle = false; //gravity flip
    bool timeToggle = false; //slow time
    bool stopTimeToggle = false; //stop time
    bool teleportToggle = false; //teleportation

    bool flipMask;

    private void Awake()
    {

        _rigidbody = GetComponent<Rigidbody>();
        //_lineRenderer = GetComponent<LineRenderer>();
        _animator = GetComponent<Animator>();
        quantumPhysics = Resources.Load("QuantumPhysics") as QuantumPhysics;
        cameraController = GetComponent<PlayerCameraController>();
        deathCollision = null;
        deathPanel = GameObject.Find("DeathPanel");

    }

    // Start is called before the first frame update
    void Start()
    {

        quantumPhysics.timeModifier = 1;
        distToGround = GetComponent<BoxCollider>().bounds.extents.y;
        Time.timeScale = 1;
        //_lineRenderer.enabled = false;
        intGravity = gravity;
        deathPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        SetAnimParams();

        if (IsGrounded()) {

            gravity = intGravity;
            calledOnce = false;

        }

        if (timeToggle && drainCalledOnce == false) {

            drainCalledOnce = true;
            StopCoroutine(EnergyFill());
            StartCoroutine(EnergyDrain());

        }

        if (this.transform.position.y >= intialPlayerPos + maxJumpHeight && !IsGrounded() && !calledOnce && isJumping) {

            gravity *= xGravity;
            isJumping = false;
            calledOnce = true;

        }
        else if (this.transform.position.y <= intialPlayerPos - maxJumpHeight && !IsGrounded() && !calledOnce && isJumping) {

            gravity *= xGravity;
            isJumping = false;
            calledOnce = true;

        }

        if (Input.GetMouseButtonDown(0) && energyBar.fillAmount >= gravSubtract) {

            gravityToggle = !gravityToggle;
            energyBar.fillAmount -= gravSubtract;

            if (fillCalledOnce == false && drainCalledOnce == false) {

                fillCalledOnce = true;
                StartCoroutine(EnergyFill());

            }

            if (gravityToggle == true) {
                
                //Physics.gravity = new Vector3(0, 19.62f, 0);
                this.gravityModifier *= -1 / Time.timeScale;
                transform.Rotate(0, 180, 180, Space.Self);
                transform.position = new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z);
                cameraController.CameraOffset.y *= -1;
                gravIcon.GetComponent<CanvasRenderer>().GetMaterial().SetFloat("Vector1_77CCC2E3", 0);

            } else {

                //Physics.gravity = new Vector3(0, -19.62f, 0);
                this.gravityModifier *= -1 / Time.timeScale;
                transform.Rotate(0, 180, 180, Space.Self);
                transform.position = new Vector3(transform.position.x, transform.position.y - 2.5f, transform.position.z);
                cameraController.CameraOffset.y *= -1;
                gravIcon.GetComponent<CanvasRenderer>().GetMaterial().SetFloat("Vector1_77CCC2E3", 180);

            }

        }

        if (Input.GetMouseButtonDown(1) || energyBar.fillAmount == 0 && timeToggle == true) {

            timeToggle = !timeToggle;


            if (fillCalledOnce == false) {

                fillCalledOnce = true;
                StartCoroutine(EnergyFill());

            }

            if (timeToggle == true) {

                quantumPhysics.timeModifier = 0.2f;
                //energyBar.fillAmount -= slowSubtract;
                timeIcon.GetComponent<CanvasRenderer>().GetMaterial().SetFloat("Vector1_39BDCCC2", 2);

            } else {

                quantumPhysics.timeModifier = 1;
                timeIcon.GetComponent<CanvasRenderer>().GetMaterial().SetFloat("Vector1_39BDCCC2", 1);

            }

            Time.fixedDeltaTime = 0.02f * Time.timeScale;

        }

        if (Input.GetButtonDown("TimeScaleStop") /*&& energyBar.fillAmount >= stopSubtract*/) {

            //stopTimeToggle = !stopTimeToggle;
            //timeToggle = false;

            //energyBar.fillAmount -= stopSubtract;

            //if (fillCalledOnce == false) {

            //    fillCalledOnce = true;
            //    StartCoroutine(EnergyFill());

            //}

            //if (stopTimeToggle == true)
            //    quantumPhysics.timeModifier = 0;
            //Time.timeScale = 0;
            //else
            //    quantumPhysics.timeModifier = 1;
            //Time.timeScale = 1;

        }

        if (Input.GetButtonDown("Teleport") /*&& energyBar.fillAmount >= teleSubtract*/) {

        //    teleportToggle = !teleportToggle;

        //    if (teleportToggle == true) {

        //        _lineRenderer.enabled = true;
        //        AndyGhost.GetComponent<MeshRenderer>().enabled = true;

        //    } else {

        //        _lineRenderer.enabled = false;
        //        AndyGhost.GetComponent<MeshRenderer>().enabled = false;

        //    }

        }

        //Teleport();

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

        if (spinCalledOnce == true && transform.eulerAngles.y == 180 && !(translation > 0)) {

            spinCalledOnce = false;

        } else if (spinCalledOnce == true && transform.eulerAngles.y == 0 && !(translation < 0)) {

            spinCalledOnce = false;

        }
        
        //translation *= Time.deltaTime;

        //transform.Translate(translation, 0, 0, Space.World);
        _rigidbody.velocity = new Vector3(translation, _rigidbody.velocity.y);


        if (translation > 0 && !gravityToggle) {

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);

            if (spinCalledOnce == false) {

                spinCalledOnce = true;
                _animator.SetTrigger("Spin");

            }

        } else if (translation < 0 && !gravityToggle) {

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);

            if (spinCalledOnce == false) {

                spinCalledOnce = true;
                _animator.SetTrigger("Spin");

            }

        } else if (translation > 0 && gravityToggle) {

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);

            if (spinCalledOnce == false) {

                spinCalledOnce = true;
                _animator.SetTrigger("Spin");

            }

        } else if (translation < 0 && gravityToggle) {

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);

            if (spinCalledOnce == false) {

                spinCalledOnce = true;
                _animator.SetTrigger("Spin");

            }

        }

        if (Input.GetButtonDown("Jump") && IsGrounded()) {

            if (gravityToggle == false) {

                _animator.SetTrigger("Jump");
                _rigidbody.velocity = Vector3.up * jumpForce;
                isJumping = true;
                intialPlayerPos = this.transform.position.y;

            } else {

                _animator.SetTrigger("Jump");
                _rigidbody.velocity = Vector3.down * jumpForce;
                isJumping = true;
                intialPlayerPos = this.transform.position.y;

            }

        }

        if (transform.position.y < intialPlayerPos + maxJumpHeight && isJumping == true && !gravityToggle) {

            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, jumpForce);

        }
        else if (transform.position.y > intialPlayerPos - maxJumpHeight && isJumping == true && gravityToggle) {

            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, -jumpForce);

        }

    }

    void Teleport() {

    //    RaycastHit mouseHit;

    //    GhostCollision ghostCollision = AndyGhost.GetComponent<GhostCollision>();

    //    int distance = 5;

    //    Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

    //    Vector3 unitVector = new Vector3();

    //    if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out mouseHit, Mathf.Infinity, layerMask)) {

    //        float dX = (mouseHit.point.x - transform.position.x) * (mouseHit.point.x - transform.position.x);
    //        float dY = (mouseHit.point.y - transform.position.y) * (mouseHit.point.y - transform.position.y);

    //        float pointDistance = Mathf.Sqrt(dX + dY);

    //        unitVector.x = (mouseHit.point.x - this.transform.position.x) / pointDistance;
    //        unitVector.y = (mouseHit.point.y - this.transform.position.y) / pointDistance;

    //        if (pointDistance > distance) {

    //            _lineRenderer.SetPosition(1, this.transform.position + (distance * unitVector));

    //        } else {

    //            _lineRenderer.SetPosition(1, new Vector3(mouseHit.point.x, mouseHit.point.y, transform.position.z));

    //        }

    //        if(teleportToggle)
    //            AndyGhost.transform.position = _lineRenderer.GetPosition(1);

    //        if (ghostCollision.isColliding == true)
    //            AndyGhost.GetComponent<Renderer>().material.color = new Color(255, 0, 0, 45);
    //        else
    //            AndyGhost.GetComponent<Renderer>().material.color = new Color(0, 0, 255, 45);

    //        if (Input.GetButtonDown("Fire1") && teleportToggle == true && ghostCollision.isColliding == false) {

    //            energyBar.fillAmount -= teleSubtract;

    //            if (fillCalledOnce == false) {

    //                fillCalledOnce = true;
    //                StartCoroutine(EnergyFill());

    //            }

    //            this.transform.position = _lineRenderer.GetPosition(1);
    //            teleportToggle = false;
    //            _lineRenderer.enabled = false;
    //            AndyGhost.GetComponent<MeshRenderer>().enabled = false;

    //        }
             
    //    }

    }

    IEnumerator EnergyFill() {

        while (energyBar.fillAmount != 1 && timeToggle == false) {

            if (timeToggle == true) {

                break;

            }

            yield return new WaitForSeconds(fillTickTime);
            energyBar.fillAmount += refillAmount;

            if (timeToggle == true) {

                break;

            }

        }

        fillCalledOnce = false;

    }

    IEnumerator EnergyDrain() {

        while (timeToggle) {

            yield return new WaitForSeconds(drainTickTime);
            energyBar.fillAmount -= drainAmount;

        }

        drainCalledOnce = false;

    }

    private void OnCollisionEnter(Collision collision) {

        deathCollision = collision.gameObject.GetComponent<DeathCollision>();

        if (deathCollision != null) {

            if (deathCollision.hazardType == DeathCollision.HAZARDTYPE.LaserWall) {

                //play death animation for this type

                //display death UI
                deathPanel.SetActive(true);
                Time.timeScale = 0;

                //move player back to last checkpoint or start

            } else if (deathCollision.hazardType == DeathCollision.HAZARDTYPE.FanBlades) {

                //play death animation for this type

                //display death UI

                //move player back to last checkpoint or start

            }

        }

    }

    void SetAnimParams() {

        _animator.SetFloat("Speed", Input.GetAxis("Horizontal"));
        _animator.SetBool("Grounded", IsGrounded());

        if (_animator.GetFloat("Speed") == 0) {

            _animator.SetBool("Idle", true);

        } else {

            _animator.SetBool("Idle", false);

        }

    }

}
