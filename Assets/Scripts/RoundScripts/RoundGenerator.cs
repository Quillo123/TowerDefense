using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class RoundGenerator : MonoBehaviour
{
    string _enemyFolder = "Enemies";
    List<Enemy> _enemyList = new List<Enemy>();

    System.Random _random;

    GameState _gameState;
    RoundController _roundController;

    private void Start()
    {
        _gameState = FindObjectOfType<GameState>();
        _roundController = GetComponent<RoundController>();

        LoadEnemyList();

        if (!_gameState.IsRandomSeed())
            _random = new System.Random(_gameState.GetSeed());
        else
            _random = new System.Random();
    }

    private void LoadEnemyList()
    {
        _enemyList = Resources.LoadAll<Enemy>(_enemyFolder).ToList();
        _enemyList.OrderBy(o => o.GetDifficulty());
    }

    public void GenerateNextRound(int Difficulty)
    {
        Enemy enemy = _enemyList.ElementAt(_random.Next(_enemyList.Count));

    }
}