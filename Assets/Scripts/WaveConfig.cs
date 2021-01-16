using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")] 
public class WaveConfig : ScriptableObject
{

    [SerializeField] Enemy _enemyPrefab;
    [SerializeField] float _waitBeforeStarting = 0f;
    [SerializeField] float _timeBetweenSpawns = 0.5f;
    [SerializeField] float _spawnRandomFactor = 0.3f;
    [SerializeField] int _numberOfEnemies = 5;
    [SerializeField] float _moveSpeed = 2f;

    public Enemy GetEnemyPrefab() { return _enemyPrefab;  }
    public float GetWaitTimeBeforeStarting() { return _waitBeforeStarting; }
    public float GetTimeBetweenSpawns() { return _timeBetweenSpawns;  }
    public float GetSpawnRandomFactor() { return _spawnRandomFactor; }
    public int GetNumberOfEnemies() { return _numberOfEnemies; }
    public float GetMoveSpeed() { return _moveSpeed; }







}
