using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollision : MonoBehaviour
{

    public enum HAZARDTYPE {

        LaserWall,
        FanBlades

    }

    public HAZARDTYPE hazardType;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {

        if (hazardType == HAZARDTYPE.LaserWall) {

            //play death animation for this type

            //display death UI

            //move player back to last checkpoint or start

        } else if (hazardType == HAZARDTYPE.FanBlades) {

            //play death animation for this type

            //display death UI

            //move player back to last checkpoint or start

        }

    }
}
