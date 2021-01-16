using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour
{

    [SerializeField] List<RoundConfig> _roundConfigs;
    [SerializeField] int _StartRound;

    EnemySpawner _enemySpawner;

    private void Start()
    {
        _enemySpawner = GetComponentInChildren<EnemySpawner>();
    }

    public void StartNextRound()
    {
        _enemySpawner.SpawnAllWaves(_roundConfigs[_StartRound].GetRoundWaves());
        _StartRound++;
    }
}
