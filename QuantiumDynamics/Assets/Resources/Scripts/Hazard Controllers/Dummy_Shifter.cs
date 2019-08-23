using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy_Shifter : MonoBehaviour
{
    public bool State;
    public Vector3 Direction;    
    public int DirectionSmoothing;

    private bool _setter;
    private Vector3 _pointA, _pointB;


    void Start()
    {
        _setter = false;
        _pointA = transform.position;
        _pointB = transform.position + Direction;
    }

    public void Update()
    {
        if (State == true)
        {
            transform.position =
            Vector3.Lerp(transform.position, _pointB, DirectionSmoothing * Time.deltaTime);
        }
        else if (State != true)
        {
            transform.position =
            Vector3.Lerp(transform.position, _pointA, DirectionSmoothing * Time.deltaTime);
        }
    }

    public void Switch()
    {
        if (State == true)
        {
            State = !State;
        }
        else if (State != true)
        {
            State = !State;
        }
    }     
}
