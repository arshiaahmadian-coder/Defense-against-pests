using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float maxHealth;
    [HideInInspector] public float currentHealth;
    
    // public void TakeDamage(float damage)
    // {
    //     currentHealth -= damage;
    //     if (currentHealth <= 0)
    //     {
    //         print("Player Died");
    //     }
    // }
    //
    // public Vector3 GetPosition()
    // {
    //     return transform.position;
    // }
}
