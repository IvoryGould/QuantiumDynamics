using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUG_RemoveDynamic : MonoBehaviour
{

    private GameObject _dynamic;
    void Start()
    {
        _dynamic = GameObject.Find("_DYNAMIC");
        Destroy(_dynamic);
            
    }
}
