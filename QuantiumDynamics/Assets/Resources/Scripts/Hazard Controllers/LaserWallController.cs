using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWallController : MonoBehaviour
{
    [Tooltip("DEBUG: When active, laser wall will move towards location.")]
    public bool Activated = false;
    [Tooltip("GameObject that will be moved")]
    public GameObject LaserWall;
    [Tooltip("Destination point where GameObject will move to")]
    public Transform Destination;
    [Tooltip("Speed of which the laser wall will move.")]
    public float Speed;

    [HideInInspector]
    public int _toolbarTab;
    [HideInInspector]
    public string _currentTab;
    [HideInInspector]
    public Vector3 _origin;
    // Start is called before the first frame update
    void Start()
    {
        _origin = LaserWall.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
 

        switch (Activated)
        {
            case true:
                //use to increase speed over time
                //Speed = Speed + (10 * Time.deltaTime);

                LaserWall.transform.position = Vector3.MoveTowards(LaserWall.transform.position, Destination.position, Speed / 1000);
                break;
        }
    }

    public void ResetLaser()
    {
        LaserWall.transform.position = _origin;
    }
}
