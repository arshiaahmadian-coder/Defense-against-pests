using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Plant Data", menuName = "Scriptable Objects/PlantsData")]
public class PlantData : ScriptableObject
{
    public string plantName;
    public int maxHealth;
    public int sun;
    public Vector3 PlantMaterial;
    public int harvestExpGain;
}
