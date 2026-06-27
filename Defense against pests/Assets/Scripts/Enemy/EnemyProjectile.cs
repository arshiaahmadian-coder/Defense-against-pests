using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    [SerializeField] private Vector3 speed;
    public float damage;
    private float timer = 0;
    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(speed.x * Time.deltaTime, 0, speed.z * Time.deltaTime);
        if (timer >= lifeTime) Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IDamageable>() != null) // enemy layer number
        {
            other.GetComponent<IDamageable>().TakeDamage(damage);

        }
        Destroy(gameObject);
    }
}