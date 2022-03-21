using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnpoint;
    public float timeBetweenWaves = 10f;
    private float countDown = 2f;
    private int waveNumber = 0;
    

    void Update()
    {
        if (countDown <= 0f)
        {
            StartCoroutine(spawnWave());
            countDown = timeBetweenWaves;
        }

        countDown -= Time.deltaTime;
    }

    IEnumerator spawnWave()
    {
        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
        {
            spawnEnemy();
            yield return new WaitForSeconds(.5f);
        }
       

    }

    void spawnEnemy()
    {
        Instantiate(enemyPrefab, spawnpoint.position, spawnpoint.rotation);
    }
    
    
}
