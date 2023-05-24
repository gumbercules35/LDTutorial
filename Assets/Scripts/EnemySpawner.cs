using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{   
    [SerializeField] private List<WaveConfigSO> waveList;
    [SerializeField] private float timeBetweenWaves = 2.5f;
    private int currentWaveIndex = 0;
    private WaveConfigSO currentWave;
    
    void Start()
    {
        currentWave = waveList[currentWaveIndex];
        //Must be called like this as method is IEnumerator
       StartCoroutine(SpawnEnemies());
    }

    public WaveConfigSO GetCurrentWave(){
        return currentWave;
    }
    private IEnumerator SpawnEnemies()
    { 
        foreach (WaveConfigSO wave in waveList){
            //Set the currentWave to the wave being processed by the foreach loop
            currentWave = wave;
            //Loop through the list of enemies in the current wave
            for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    //Instantiate the enemy, then wait for given spawnTime before spawning the next
                    Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetPathStart().position, Quaternion.identity, transform);
                    yield return new WaitForSecondsRealtime(currentWave.GetSpawnTime());
                }
            //After looping through the enemies, wait for the time between waves before moving on
            yield return new WaitForSecondsRealtime(timeBetweenWaves);
        }   
    }
}