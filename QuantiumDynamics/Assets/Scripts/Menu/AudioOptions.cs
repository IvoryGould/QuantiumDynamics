using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioOptions : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        audioMixer.SetFloat("Music", -5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
