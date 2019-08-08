using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public Transform position;
    public Vector3 newPos;
    public Vector3 originalPos;
    [Tooltip("Time to move")]
    public float time;
    [SerializeField]
    [Tooltip("Distance to move on Z")]
    private float posZ;
    // Start is called before the first frame update
    void Start()
    {
        position = GetComponent<Transform>();
        originalPos = position.position;
        newPos.z = originalPos.z+posZ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveDoors()
    {
        if (position.position == originalPos)
        {
            position.position = Vector3.Lerp(originalPos, newPos, time);
        }
        else if (position.position == newPos)
        {
            position.position = Vector3.Lerp(newPos, originalPos, time);
        }
    }
}
