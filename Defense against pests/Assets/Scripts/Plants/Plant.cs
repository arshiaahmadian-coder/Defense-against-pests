using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Plant : BasePlant, IDamageable
{
    [SerializeField] private GameObject[] stageObjects;
    [SerializeField] private float[] growingTimes;
    private float currentHealth = 0;
    private float timer = 0;
    private bool grow = false;

    private void Start()
    {
        maxStage = growingTimes.Length - 1;
        currentHealth = data.maxHealth;
        EnemyTargetsList.instance.AddTargetToList(this);
    }

    public override void StartGrowing()
    {
        grow = true;
    }

    private void FixedUpdate()
    {
        if (currentStage >= maxStage) return;

        if (grow)
        {
            timer += (DayNightCycle.instance.isDay) ? Time.deltaTime : Time.deltaTime / 2;

            if (timer >= growingTimes[currentStage])
            {
                stageObjects[currentStage++].SetActive(false);
                stageObjects[currentStage].SetActive(true);
        
                tile.GetDry();
                grow = false;
                timer = 0;
            }
        }
    }

    public override void Harvest(bool giveMaterial)
    {
        if (currentStage >= growingTimes.Length - 1 && giveMaterial) // its in last growing stage
        {
            Player.instance.Inventory.AddMaterials(
                (int) data.PlantMaterial.x, 
                (int) data.PlantMaterial.y, 
                (int) data.PlantMaterial.z
            );
        }
        
        tile.GetDry();
        EnemyTargetsList.instance.RemoveTargetFromList(this);
        base.Harvest();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Harvest(false);
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
