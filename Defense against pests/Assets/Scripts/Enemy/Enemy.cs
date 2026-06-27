using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Enemy : MonoBehaviour
{
    public EnemyData data;
    public IDamageable Target;
    public Rigidbody rb;
    public Animator animator;
    public GameObject soundPlayerPrefab;

    private void Start()
    {
        Initialisation();
    }

    public virtual void Initialisation() { }

    public virtual void TakeDamage(float damage) { }

    public virtual void Die()
    {
        Instantiate(soundPlayerPrefab, transform.position, Quaternion.identity);
        EnemySpawner.instance.DecreaseEnemiesSpawned();
    }
}
