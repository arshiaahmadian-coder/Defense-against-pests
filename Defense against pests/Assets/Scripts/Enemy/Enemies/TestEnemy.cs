using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : Enemy
{
    [HideInInspector]
    public float currentHealth;

    [SerializeField] private bool flip;
    [SerializeField] private bool isRanged;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootPos;

    private float timer = 0;
    private bool isAttacking = false;
    
    private void FixedUpdate()
    {
        Target = EnemyTargetsList.instance.SearchForClosestTarget(transform);
        timer += Time.deltaTime;
        
        if (Target != null)
        {
            Vector3 lookDir = transform.position - Target.GetPosition();
            float angle = Mathf.Atan2(lookDir.x, lookDir.z) * Mathf.Rad2Deg - 90f;
            if (flip) angle -= 180;
            transform.rotation = Quaternion.Euler(0f, angle - 90, 0f);
            
            float attackRange = (Target.GetPosition() == Well.instance.transform.position) 
                ? data.attackRange + 0.6f : data.attackRange;
            
            // move to target
            if (Vector3.Distance(Target.GetPosition(), transform.position) <= attackRange)
            {
                // attack target
                if (timer >= data.baseAttackTime && !isAttacking)
                {
                    // deal damage
                    animator.SetBool("IsAttacking", true);
                    isAttacking = true;
                }
            }
            else
            {
                // chase target
                animator.SetBool("IsAttacking", false);
                isAttacking = false;
                int d = flip ? -1 : 1; 
                transform.Translate(0, 0, data.movementSpeed * Time.deltaTime * d);
            }
        }
    }
    public override void Initialisation()
    {
        base.Initialisation();
        currentHealth = data.maxHealth;
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        currentHealth -= damage;
        if (currentHealth <= 0) Die();
    }

    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
        EnemiesList.instance.RemoveTargetFromList(this);
    }

    public void Attack()
    {
        if (isRanged) Instantiate(projectilePrefab, shootPos.position, transform.rotation);
        else Target.TakeDamage(data.attackDamage);
    }
}
