using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardCog : MonoBehaviour
{
    public int RotateSpeed_norm, RotateSpeed_slow;

    private bool _timeSlow;
    private CapsuleCollider _cc;
    private MeshCollider _mc;

    
    void Start()
    {
        if (RotateSpeed_norm == 0)
        {
            RotateSpeed_norm = 250;
        }

        if (RotateSpeed_slow == 0)
        {
            RotateSpeed_slow = 60;
        }

        _timeSlow = false;
        _cc = GetComponent<CapsuleCollider>();
        _mc = GetComponent<MeshCollider>();

        _cc.enabled = true;
        _mc.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_timeSlow)
        {
            transform.Rotate(Vector3.up, RotateSpeed_norm * Time.deltaTime, Space.Self);
        }
        else if (_timeSlow == true)
        {
            transform.Rotate(Vector3.up, RotateSpeed_slow * Time.deltaTime, Space.Self);
        }

        if (Input.GetKeyDown(KeyCode.T) && _timeSlow == false)
        {
            _timeSlow = true;
            _cc.enabled = false;
            _mc.enabled = true;

            Debug.Log("TimeSlow: " + _timeSlow + " | CC Enabled: " + _cc + " | MC Enabled: " + _mc);
        }
        else if (Input.GetKeyDown(KeyCode.T) && _timeSlow == true)
        {
            _timeSlow = false;
            _cc.enabled = true;
            _mc.enabled = false;

            Debug.Log("TimeSlow: " + _timeSlow + " | CC Enabled: " + _cc + " | MC Enabled: " + _mc);
        }
                

    }
}
