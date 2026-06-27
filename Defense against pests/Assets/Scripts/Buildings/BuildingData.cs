using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Default Building", menuName = "Scriptable Objects/Building Data")]
public class BuildingData :  ScriptableObject
{
    [Header("Info")] 
    public string buildingName;

    public Vector3 materialsNeedToBuild;
    public float maxHealth;
    public bool isAttacker;

    [Header("Attack")] 
    public float maxAttackRange;
    public float minAttackRange;
}
