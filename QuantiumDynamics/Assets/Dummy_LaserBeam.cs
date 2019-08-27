using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy_LaserBeam : MonoBehaviour
{
    [Header("Key Points")]
    public Transform StartPoint;
    public Transform EndPoint;

    private LineRenderer _laserLine;

    // Start is called before the first frame update
    void Start()
    {
        _laserLine = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _laserLine.SetPosition(0, StartPoint.position);
        _laserLine.SetPosition(1, EndPoint.position);
    }
}
