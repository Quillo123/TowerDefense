﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] List<WaveConfig> _waveConfigs;
    [SerializeField] int _startingWave = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAllWaves());
    }

    private IEnumerator SpawnAllWaves()
    {
        for(int waveIndex = _startingWave; _startingWave < _waveConfigs.Count; waveIndex++)
        {
            var currentWave = _waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
        
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(
                waveConfig.GetEnemyPrefab(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity);

            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
