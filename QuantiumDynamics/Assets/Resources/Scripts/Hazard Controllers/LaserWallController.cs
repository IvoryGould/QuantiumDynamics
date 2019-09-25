using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWallController : MonoBehaviour
{
    public enum Movement { Constant, Lerp };

    public Movement MovementType;

    [Header("GameObjects")]
    [Tooltip("GameObject that will be moved")]
    public GameObject LaserWall;
    [Tooltip("Destination point where GameObject will move to")]
    public Transform Destination;
    [Header("Variables")]
    [Tooltip("Speed of which the laser wall will move.")]
    public float Speed;
    [Tooltip("Length of time until wall resets")]
    public float ReturnTime;

    [HideInInspector]
    public bool Activated;
    [HideInInspector]
    public int _toolbarTab;
    [HideInInspector]
    public string _currentTab;
    [HideInInspector]
    public Vector3 _origin;
    private float _timer;

    private bool calledOnce = false;
    
    void Start()
    {
        Activated = false;
        
        _origin = LaserWall.transform.position;
    }

    void Update()
    {
        switch (Activated)
        {
            case true:
                switch (MovementType)
                {
                    case Movement.Constant:
                        LaserWall.transform.position = Vector3.MoveTowards(LaserWall.transform.position, Destination.position, Speed / 1000);
                        break;
                    case Movement.Lerp:

                        if (LaserWall.transform.position != Destination.position && calledOnce == false) {

                            LaserWall.transform.position = Vector3.Lerp(LaserWall.transform.position, Destination.position, Speed / 100);

                        }

                        if (calledOnce == false) {

                            StartCoroutine(LerpMovement(ReturnTime));

                        }

                        break;
                }
                break;
        }
    }

    public void ResetLaser()
    {
        LaserWall.transform.position = _origin;
    }

    IEnumerator LerpMovement(float time) {

        calledOnce = true;

        yield return new WaitForSeconds(time);

        if (LaserWall.transform.position != _origin) {

            LaserWall.transform.position = Vector3.Lerp(LaserWall.transform.position, _origin, Speed / 100);

        }

        calledOnce = false;

    }

}
