using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MaterialSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] materialObjects;
    [SerializeField] private int maxSpawn;
    [SerializeField] private float spawnDistanceFromPlayer;
    [SerializeField] private float spawnInterval;
    [SerializeField] private Vector2 minPos;
    [SerializeField] private Vector2 maxPos;

    private float timer = 0;
    private float spawnedMaterials = 0;

    public static MaterialSpawner instance;

    private void Awake()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (spawnedMaterials < maxSpawn && timer >= spawnInterval) // spawn another one
        {
            // choose where to spawn
            Vector3 spawnPos;
            Vector3 playerPos = Player.instance.transform.position;
            do
            {
                spawnPos = new Vector3(
                    Random.Range(minPos.x, maxPos.x),
                    0,
                    Random.Range(minPos.y, maxPos.y)
                );
            } while (Vector3.Distance(spawnPos, playerPos) < spawnDistanceFromPlayer);
            // choose what to spawn 
            int chance = Random.Range(0, 101);
            GameObject materialObject = (chance < 70) ? materialObjects[0] : materialObjects[1];
            
            // spawn 
            Instantiate(materialObject, spawnPos, Quaternion.identity);
            spawnedMaterials += 1;
            timer = 0;
        }
    }

    public void DecreaseMaterialsSpawned()
    {
        spawnedMaterials -= 1;
    }
}
