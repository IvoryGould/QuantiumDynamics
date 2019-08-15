using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/QTime", order = 1)]
public class QuantumPhysics : ScriptableObject
{

    public float timeModifier = 1;
    public float gravityModifier = 1;
    public float gravity = -9;

}
