using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public enum TileType {
    Grass,
    Jungle,
    Well
}

public class BaseTile : MonoBehaviour
{
    public BasePlant plant = null;
    public Buildings building = null;
    public bool isPlowed = false;
    public GameObject[] trashPlants;
    public float interactingTime;
    public TileType tileType;

    protected void Awake()
    {
        Initialization();
    }

    public virtual void Initialization() { }

    public virtual void Interact()
    {
        if (isPlowed) UnPlow();
        else Plow();
    }

    public virtual void Plow()
    {
        isPlowed = true;
    }

    public virtual void UnPlow()
    {
        isPlowed = false;
    }

    public virtual void Build(GameObject buildingPrefab) { }

    public virtual void Plant(GameObject plantPrefab) { }
    
    public virtual void GenerateRandomTrashPlant(float p = 0.5f, float c = 3.33f)
    {
        // has 30% chance to have trash plant on it
        float rnd = Random.Range(1.0f, 10.0f);
        if (rnd <= c)
        {
            // random trash plant and position on tile
            int i = Random.Range(0, trashPlants.Length);
            Vector3 pos = transform.position + new Vector3(Random.Range(-p, p), 0, Random.Range(-p, p));
            
            // put trash plant on it
            GameObject newPlant = Instantiate(trashPlants[i], pos, Quaternion.identity);
            
            plant = newPlant.GetComponent<BasePlant>();
        }
    }
    
    public virtual void GetWet() { }
    public virtual void GetDry() { }
}