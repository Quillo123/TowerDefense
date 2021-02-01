using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour
{

    List<RoundConfig> _roundConfigs;
    [SerializeField] int _currRound;

    RoundGenerator _roundGenerator;
    GameState _gameState;
    EnemySpawner _enemySpawner;
    MessageController _messageController;

    private void Start()
    {
        _roundGenerator = GetComponent<RoundGenerator>();
        _gameState = FindObjectOfType<GameState>();
        _enemySpawner = GetComponentInChildren<EnemySpawner>();
        _messageController = FindObjectOfType<MessageController>();

    }

    public void StartNextRound()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && GameObject.FindGameObjectWithTag("WaveChecker") == null)
        {
            if (_gameState.GetGeneratorState() == GameState.RoundGeneratorState.Set)
                _enemySpawner.SpawnAllWaves(_roundConfigs[_currRound].GetRoundWaves());
            else
                _enemySpawner.SpawnAllWaves(_roundGenerator.GenerateNextRound().GetRoundWaves());
            _currRound++;
        }
        else
        {
            _messageController.PlayMessage("Round not over");
        }
    }

    public int GetCurrentRound() { return _currRound; }
}
