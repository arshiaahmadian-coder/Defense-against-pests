using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBuilding : Buildings, IDamageable
{
    private float currentHealth;
    
    private void Start()
    {
        currentHealth = data.maxHealth;
        EnemyTargetsList.instance.AddTargetToList(this);
    }
    
    public override void DestroyBuilding()
    {
        EnemyTargetsList.instance.RemoveTargetFromList(this);
        tile.building = null;
        base.DestroyBuilding();
    }
    
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            DestroyBuilding();
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
