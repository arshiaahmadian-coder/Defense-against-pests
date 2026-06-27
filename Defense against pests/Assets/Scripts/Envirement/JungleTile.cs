using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class JungleTile : BaseTile
{
    [SerializeField] private float hasTrashPlantChance;
    public override void Initialization()
    {
        base.Initialization();
        GenerateRandomTrashPlant(0.4f, hasTrashPlantChance);
    }
}