using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour
{

    [SerializeField] List<RoundConfig> _roundConfigs;
    [SerializeField] int _StartRound;

    EnemySpawner _enemySpawner;

    MessageController _messageController;

    private void Start()
    {
        _enemySpawner = GetComponentInChildren<EnemySpawner>();
        _messageController = FindObjectOfType<MessageController>();
    }

    public void StartNextRound()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && GameObject.FindGameObjectWithTag("WaveChecker") == null)
        {
            _enemySpawner.SpawnAllWaves(_roundConfigs[_StartRound].GetRoundWaves());
            _StartRound++;
        }
        else
        {
            _messageController.PlayMessage("Round not over");
        }
    }

    public int GetRoundNumber() { return _StartRound; }
}
