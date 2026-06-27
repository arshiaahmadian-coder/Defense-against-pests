using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Well : MonoBehaviour, IDamageable
{
    public bool rotate = false;
    public float rotationSpeed;
    public float maxHealth;
    private float currentHealth;
    [SerializeField] private GameObject hook;

    public static Well instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void FixedUpdate()
    {
        if (rotate) hook.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
    
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
