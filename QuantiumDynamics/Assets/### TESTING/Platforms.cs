using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    public Transform position;
    public Vector3 newPos;
    public Vector3 originalPos;
    [Tooltip("Time to move")]
    public float time;
    [SerializeField]
    [Tooltip("Distance to move on X")]
    private float posX;
    [SerializeField]
    [Tooltip("Distance to move on Y")]
    private float posY;
    // Start is called before the first frame update
    void Start()
    {
        position = GetComponent<Transform>();
        originalPos = position.position;
        newPos.x = originalPos.x+posX;
        newPos.y = originalPos.x+posY;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MovePlatforms()
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
