using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlant : MonoBehaviour
{
    public string plantName;
    public BaseTile tile;
    public PlantData data;
    public int currentStage = 0;
    public int maxStage = 2;

    public virtual void Harvest(bool giveMaterial = true)
    {
        Destroy(gameObject);
    }
    
    public virtual void StartGrowing() {}
}
