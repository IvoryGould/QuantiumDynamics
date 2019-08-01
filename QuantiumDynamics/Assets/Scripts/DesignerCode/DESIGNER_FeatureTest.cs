using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DESIGNER_FeatureTest : MonoBehaviour
{
    private GameObject _cameraFollow;
    public Vector3 CameraOffset;
    public float CameraSmoothing;

    private void Start()
    {
        _cameraFollow = GameObject.Find("Main Camera");
        //CameraOffset = 0.3f;
        if (CameraSmoothing == 0f)
        {
            CameraSmoothing = 5f;
        }
    }
    void Update()
    {
        CameraController();
    }

    public void CameraController()
    {
        _cameraFollow.transform.position =
            Vector3.Lerp(_cameraFollow.transform.position, transform.position + CameraOffset, CameraSmoothing * Time.deltaTime);
    }
}
