using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class TrashPlant : BasePlant
{
    private void Start()
    {
        if (plantName == "Grass")
        {
            float randScale = Random.Range(0.6f, 1.2f);
            transform.localScale = new Vector3(randScale, randScale, randScale);
        }
    }
}
