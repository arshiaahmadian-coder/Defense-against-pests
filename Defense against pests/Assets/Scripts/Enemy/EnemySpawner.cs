using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private int[] enemySpawnValues;
    [SerializeField] private float startSpawningDelay;
    public float spawnInterval;

    private float timer = 0;
    private bool started = false;
    [SerializeField] private int enemiesSpawned = 0;
    public float spawnValue = 1;
    private float currentSpawnValue = 1;

    public static EnemySpawner instance;

    private void Awake()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        timer += (DayNightCycle.instance.isDay) ? Time.deltaTime : Time.deltaTime; // Time.deltaTime * 1.5f

        if (!started && timer >= startSpawningDelay) started = true;

        if (started)
        {
            if (timer >= spawnInterval)
            {
                // spawn
                Spawn();
            }
        }
    }

    public void DecreaseEnemiesSpawned()
    {
        enemiesSpawned -= 1;
    }

    private GameObject WhatToSpawn()
    {
        int i = 0;
        for(int j = 0; j < enemySpawnValues.Length; j++)
        {
            if (enemySpawnValues[j] <= spawnValue)
            {
                i = j;
            }
        }

        int index = Random.Range(0, i + 1);
        currentSpawnValue -= enemySpawnValues[i];

        return enemyPrefabs[index];
    }

    private void Spawn()
    {
        int i = Random.Range(0, spawnPoints.Length);
        GameObject newEnemy = Instantiate(WhatToSpawn(), spawnPoints[i].position, Quaternion.identity);
        EnemiesList.instance.AddTargetToList(newEnemy.GetComponent<Enemy>());
        enemiesSpawned += 1;
        timer = 0;

        if (currentSpawnValue >= 1) Spawn();
        else
        {
            currentSpawnValue = spawnValue;
            spawnValue += 0.8f;
        }
    }
}
