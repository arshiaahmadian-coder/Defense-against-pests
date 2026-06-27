using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class GrassTile : BaseTile
{
    [Header("Meshes")] 
    public MeshRenderer grassMesh;
    public GameObject drySoilGameObject;
    public GameObject wetSoilGameObject;

    private bool isWet = false;
    
    [Header("Sounds")]
    [SerializeField] private AudioClip plantClip;
    [SerializeField] private AudioClip buildClip;
    [SerializeField] private AudioClip wateringClip;
    public override void Initialization()
    {
        base.Initialization();
        GenerateRandomTrashPlant();
    }

    public override void UnPlow()
    {
        base.UnPlow();
        
        grassMesh.enabled = true;
        drySoilGameObject.SetActive(false);
        GenerateRandomTrashPlant();
        
        // remove current planted plant
        if (plant != null)
        {
            Destroy(plant.gameObject);
            plant = null;
        }
    }
    
    public override void Plow()
    {
        base.Plow();
        if (plant != null) plant.Harvest();

        grassMesh.enabled = false;
        drySoilGameObject.SetActive(true);
        
        SoundManager.instance.PlaySound(buildClip);
    }

    public override void Plant(GameObject plantPrefab)
    {
        base.Plant(plantPrefab);
        
        plant = Instantiate(plantPrefab, transform.position, Quaternion.identity).GetComponent<Plant>();
        plant.tile = this;
        
        SoundManager.instance.PlaySound(plantClip);
    }

    public override void Build(GameObject buildingPrefab)
    {
        base.Build(buildingPrefab);
        if (plant != null) plant.Harvest();
        building = Instantiate(buildingPrefab, transform.position, Quaternion.identity).GetComponent<Buildings>();
        building.tile = this;
        
        SoundManager.instance.PlaySound(buildClip);
    }

    public override void GetWet()
    {
        if (isWet == true || plant == null || Player.instance.Inventory.Water == 0) return;
        isWet = true;
        Player.instance.Inventory.SpendMaterial(1, 0, 0);
        
        plant.StartGrowing();
        
        drySoilGameObject.SetActive(false);
        wetSoilGameObject.SetActive(true);
        
        SoundManager.instance.PlaySound(wateringClip);
    }

    public override void GetDry()
    {
        drySoilGameObject.SetActive(true);
        wetSoilGameObject.SetActive(false);
        isWet = false;
    }
}