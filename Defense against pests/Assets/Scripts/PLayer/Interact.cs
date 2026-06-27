using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private Player player;
    [SerializeField] private GameObject buildingMenu;
    [SerializeField] private Well waterWell;
    [SerializeField] private GameObject plantingMenu;
    [SerializeField] private float holdingTime;
    private float timer;
    private bool isHoldingKey = false;

    private void Start()
    {
        player = Player.instance;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R)) // remove ability
        {
            RemoveCheck();
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            isHoldingKey = false;
            timer = 0;
            waterWell.rotate = false;
            CheckStage();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            isHoldingKey = true;
            if (waterWell.rotate == false && player.selectedTile.tileType == TileType.Well) waterWell.rotate = true;
        }

        if (isHoldingKey)
        {
            timer += Time.deltaTime;
            if (player.selectedTile.tileType == TileType.Well) waterWell.rotate = true;
            else waterWell.rotate = false;
            
            if (timer >= holdingTime)
            {
                timer = 0;
                
                if (player.selectedTile.tileType == TileType.Well) // is near water well
                {
                    // get water
                    GetWater();
                } 
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            buildingMenu.SetActive(false);
            plantingMenu.SetActive(false);
        }
    }

    private void CheckStage()
    {
        if (player.selectedTile.tileType == TileType.Grass)
        {
            if (player.selectedTile.isPlowed) // plant / harvest / water
            {
                if (player.selectedTile.plant == null)
                {
                    // plant
                    OpenPlantingMenu();
                } else if (player.selectedTile.plant.currentStage >= player.selectedTile.plant.maxStage)
                {
                    // harvest
                    player.selectedTile.plant.Harvest();
                } else if (player.selectedTile.plant.currentStage < player.selectedTile.plant.maxStage)
                {
                    // water
                    player.selectedTile.GetWet();
                }
            }
            else
            {
                // plow - build
                if (Player.instance.selectedTile.building == null)
                {
                    OpenBuildingMenu();
                }
            }
        }
    }

    private void RemoveCheck()
    {
        if (player.selectedTile.tileType == TileType.Grass)
        {
            if (player.selectedTile.isPlowed) // remove the plant and unPlow it
            {
                if (player.selectedTile.plant != null)
                {
                    player.selectedTile.plant.Harvest(false);
                }
                player.selectedTile.UnPlow();
            }
            else // remove the building
            {
                if (player.selectedTile.building != null)
                {
                    // give 50% off the material
                    Vector3 mat = player.selectedTile.building.data.materialsNeedToBuild;
                    player.Inventory.AddMaterials(0, (int) (mat.y / 2), (int) (mat.z / 2));
                    // destroy building
                    player.selectedTile.building.DestroyBuilding();
                }
            }
        }
    }
    
    private void OpenBuildingMenu()
    {
        if (buildingMenu.activeSelf)
        {
            buildingMenu.SetActive(false);
            plantingMenu.SetActive(false);
        }
        else
        {
            buildingMenu.SetActive(true);
            plantingMenu.SetActive(false);
        }
        
    }
    
    private void OpenPlantingMenu()
    {
        if (buildingMenu.activeSelf)
        {
            buildingMenu.SetActive(false);
            plantingMenu.SetActive(false);
        }
        else
        {
            plantingMenu.SetActive(true);
            buildingMenu.SetActive(false);
        }
    }

    private void GetWater()
    {
        // if (player.Inventory.Water >= player.Inventory.)
        player.selectedTile.Interact();
    }
}
