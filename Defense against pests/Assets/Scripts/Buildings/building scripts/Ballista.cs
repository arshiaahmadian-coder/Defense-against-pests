using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Ballista : Buildings, IDamageable
{
    [SerializeField] private GameObject arrowObject;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject ballistaHead;
    [SerializeField] private Transform arrowSpawnPoint;
    [SerializeField] private bool flip;

    private float currentHealth;
    private Enemy target = null;
    private bool readyToAttack = true;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip attackClip;
    [SerializeField] private AudioClip loadClip;
    
    private void Start()
    {
        currentHealth = data.maxHealth;
        EnemyTargetsList.instance.AddTargetToList(this);
    }

    private void FixedUpdate()
    {
        target = EnemiesList.instance.SearchForClosestTarget(transform, data.minAttackRange);
        
        if (target != null)
        {
            if (Vector3.Distance(target.transform.position, transform.position) <= data.maxAttackRange)
            {
                // look at target
                Vector3 lookDir = ballistaHead.transform.position - target.transform.position;
                float angle = Mathf.Atan2(lookDir.x, lookDir.z) * Mathf.Rad2Deg - 90f;
                if (flip) angle -= 180;
                ballistaHead.transform.rotation = Quaternion.Euler(0f, angle - 90, 0f);
                // attack target
                if (readyToAttack)
                {
                    // Fire
                    animator.SetTrigger("Attack");
                    readyToAttack = false;
                }
            }
        }
    }

    public void Reload()
    {
        readyToAttack = true;
        audioSource.PlayOneShot(loadClip);
    }

    public void Attack()
    {
        GameObject projectile = Instantiate(arrowObject, arrowSpawnPoint.position, ballistaHead.transform.rotation);
        if (projectile.GetComponent<ArtilleryProjectile>() != null)
        {
            projectile.GetComponent<ArtilleryProjectile>().landPos = target.transform.position;
        }
        
        audioSource.PlayOneShot(attackClip);
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
