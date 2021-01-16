using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] int _startingWave = 0;
    List<Path> _path;

    private void Start()
    {
        _path = FindObjectsOfType<Path>().ToList();
    }

    public void SpawnAllWaves(List<WaveConfig> waves)
    {
        for(int waveIndex = _startingWave; _startingWave < waves.Count; waveIndex++)
        {
            var currentWave = waves[waveIndex];
            StartCoroutine(SpawnWave(currentWave));
        }
        
    }

    private IEnumerator SpawnWave(WaveConfig waveConfig)
    {
        yield return new WaitForSeconds(waveConfig.GetWaitTimeBeforeStarting());
        StartCoroutine(SpawnEnemies(waveConfig));
    }

    private IEnumerator SpawnEnemies(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(
                waveConfig.GetEnemyPrefab(),
                _path[enemyCount % _path.Count].GetWaypoints()[0].transform.position,
                Quaternion.identity) as Enemy;

            newEnemy.GetComponent<EnemyPathing>().SetWaveConfigAndPath(waveConfig, _path[enemyCount % _path.Count]);
            
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
