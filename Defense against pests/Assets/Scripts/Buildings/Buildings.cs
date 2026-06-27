using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour
{
    public BuildingData data;
    public BaseTile tile;

    public virtual void DestroyBuilding()
    {
        Destroy(gameObject);
    }
}
