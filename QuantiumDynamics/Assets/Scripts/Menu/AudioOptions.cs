using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioOptions : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;
    private AudioOptions[] audioManager;
    public float musicVolume;
    public float sFXVolume;
    public float masterVolume;
    [SerializeField]
    private Slider musicSlider;
    [SerializeField]
    private Slider sFXSlider;
    [SerializeField]
    private Slider masterSlider;
    void Awake()
    {
        //If it exists already, delete the new instance
        audioManager = UnityEngine.Object.FindObjectsOfType<AudioOptions>();
        if (audioManager.Length >= 2)
        {
            Destroy(this);
        }
        UnityEngine.Object.DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        musicSlider = GameObject.Find("MusicVol").GetComponent<Slider>();
        musicVolume = Mathf.Log10(musicSlider.value) * 20;
        sFXSlider = GameObject.Find("SFXVol").GetComponent<Slider>();
        sFXVolume = Mathf.Log10(sFXSlider.value) * 20;
        masterSlider = GameObject.Find("MasterVol").GetComponent<Slider>();
        masterVolume = Mathf.Log10(masterSlider.value) * 20;
        SetMusic(musicSlider.value);
        SetMaster(masterSlider.value);
        SetSFX(sFXSlider.value);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetMusic(float musicSlider)
    {
        musicVolume = Mathf.Log10(musicSlider) * 20f;
        audioMixer.SetFloat("Music", musicVolume);
    }
    public void SetSFX(float sFXSlider)
    {
        sFXVolume = Mathf.Log10(sFXSlider) * 20f;
        audioMixer.SetFloat("SFX", sFXVolume);
    }
    public void SetMaster(float masterSlider)
    {
        masterVolume = Mathf.Log10(masterSlider) * 20f;
        audioMixer.SetFloat("Master", masterVolume);
    }
}
