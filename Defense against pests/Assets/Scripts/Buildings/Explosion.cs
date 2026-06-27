using System;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float lifeTime;
    public float damage;
    private float timer = 0;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifeTime) Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10 && timer <= 0.35f) // enemy layer number
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
