using System;
using UnityEngine;

public class ArtilleryProjectile : MonoBehaviour
{
    [HideInInspector] public Vector3 landPos;
    [SerializeField] private GameObject explosionPrefab;
    private Vector3 velocity;

    private void Start()
    {
        float time = 1.4f;
        velocity.x = (landPos.x - transform.position.x) / time;
        velocity.z = (landPos.z - transform.position.z) / time;
        velocity.y = (landPos.y - transform.position.y + 0.5f * 9.81f * time * time) / time;
    }

    private void Update()
    {
        velocity.y -= 9.81f * Time.deltaTime;

        transform.position += velocity * Time.deltaTime;

        if (transform.position.y <= 0) // landed
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
