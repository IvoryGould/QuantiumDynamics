using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestEnergyPool : MonoBehaviour
{
    [SerializeField]
    private float gravFlip;
    [SerializeField]
    private float timeSlowStart;
    private bool timeSlowed;
    [SerializeField]
    private float timeSlowCont;
    [SerializeField]
    private float timeStopStart;
    private bool timeStopped;
    [SerializeField]
    private float timeStopCont;
    [SerializeField]
    private float teleport;
    [SerializeField]
    private float gravNode;
    [SerializeField]
    private float energyPool;
    [SerializeField]
    private float energyRegen;
    [SerializeField]
    private TextMeshProUGUI textBox;
    private float normalise;

    // Start is called before the first frame update
    void Start()
    {
        energyPool = 90f;
    }

    // Update is called once per frame
    void Update()
    {
        if (energyPool>= 90)
        {

        }
        else
        {
            energyPool = energyPool + (Time.deltaTime * energyRegen);
        }
        if (timeSlowed == true)
        {
            energyPool = energyPool - (Time.deltaTime * timeSlowCont);
        }
        if (timeStopped == true)
        {
            energyPool = energyPool - (Time.deltaTime * timeStopCont);
        }
        if(energyPool <=0)
        {
            timeStopped = false;
            timeSlowed = false;
        }
        normalise = energyPool / 90f;
        textBox.text = normalise.ToString();
    }
    public void GravFlip()
    {
        if (energyPool >= gravFlip)
        {
            energyPool = energyPool - gravFlip;
        }
    }
    public void timeSlow()
    {
        if(timeSlowed == false)
        {
            if (energyPool >= timeSlowStart)
            {
                energyPool = energyPool - timeSlowStart;
                timeSlowed = true;
            }
        }
        else
        {
            timeSlowed = false;
        }
    }
    public void TimeStop()
    {
        if(timeStopped == false)
        {
            if (energyPool >= timeStopStart)
            {
                energyPool = energyPool - timeStopStart;
                timeStopped = true;
            }
        }
        else
        {
            timeStopped = false;
        }
    }
    public void Teleport()
    {
        if (energyPool >= teleport)
        {
            energyPool = energyPool - teleport;
        }
    }
    public void GravNode()
    {
        if (energyPool >= gravNode)
        {
            energyPool = energyPool - gravNode;
        }
    }
}
