using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndyRotate : MonoBehaviour
{
    private GameObject andy;
    public float movement;
    // Start is called before the first frame update
    void Start()
    {
        andy = this.gameObject; 
    }

    // Update is called once per frame
    void Update()
    {
        andy.transform.Rotate(0, movement, 0); 
    }
}
