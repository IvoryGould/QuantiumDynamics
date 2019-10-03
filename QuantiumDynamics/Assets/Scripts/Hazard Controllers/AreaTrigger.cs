using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    public enum ObjectSelection {LaserWall, Environment}
    public ObjectSelection HazardType;

    [Tooltip("Game Object that contains the Laser Wall assets")]
    public GameObject LaserWall;
    [Tooltip("Array of Environmental Assets that will animate")]
    [SerializeField]
    public GameObject[] EnvironmentObjects;
    [Tooltip("Boolean to display if objects are active - debugging")]
    public bool isActive = true;


    //private Collider Player;
    private LaserWallController LaserWallController;

    [HideInInspector]
    public int _toolbarTab;
    [HideInInspector]
    public string _currentTab;

    void Start()
    {
        switch (HazardType)
        {
            case ObjectSelection.LaserWall:
                LaserWallController = LaserWall.GetComponent<LaserWallController>();
                break;
            case ObjectSelection.Environment:
                break;
        }

        
    }

    void OnTriggerEnter(Collider player)
    {
        switch (HazardType)
        {
            case ObjectSelection.LaserWall:
                LaserWallController.Activated = true;
                break;

            case ObjectSelection.Environment:
                Deactivate();
                break;
        }
        
    }

    public void Activate()
    {
        foreach (GameObject go in EnvironmentObjects)
        {
            go.SetActive(true);
        }
        // enable all game objects here
    }

    public void Deactivate()
    {
        foreach(GameObject go in EnvironmentObjects)
        {
            go.SetActive(false);
        }
        // deactivate all game objects here.
    }
}
