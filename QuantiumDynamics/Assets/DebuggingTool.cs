using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuggingTool : MonoBehaviour
{
    public bool DebugOn = false;

    public void OnTriggerEnter(Collider other)
    {
        switch (DebugOn)
        {
            case true:
                Debug.Log("Entered Triggerbox");
                break;
            case false:
                break;
            default:
                Debug.Log("This isn't meant to show up... [OnTriggerEnter]");
                    break;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        switch (DebugOn)
        {
            case true:
                Debug.Log("Exited Triggerbox");
                break;
            case false:
                break;
            default:
                Debug.Log("This isn't meant to show up... [OnTriggerExit]");
                break;
        }
    }
}
