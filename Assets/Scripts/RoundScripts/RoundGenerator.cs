using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using static GameStates;

public class RoundGenerator : MonoBehaviour
{
    string _enemyFolder = "Enemies";
    List<List<Enemy>> _enemyLists = new List<List<Enemy>>();

    System.Random _random;

    private void Start()
    {
        LoadEnemyList();

        if (GameStates.GetGeneratorState() == GameStates.RoundGeneratorState.RandomWithSeed)
            _random = new System.Random(GameStates.GetSeed());
        else
            _random = new System.Random();
    }

    private void LoadEnemyList()
    {
        IEnumerable<Enemy> enemies = Resources.LoadAll<Enemy>(_enemyFolder).OrderBy(o => o.GetDifficulty());
        foreach(Enemy enemy in enemies)
        {
            if(enemy.GetDifficulty() >= _enemyLists.Count())
            {
                _enemyLists.Add(new List<Enemy>());
            }

            _enemyLists.ElementAt(enemy.GetDifficulty() - 1).Add(enemy);
        }
    }

    public RoundConfig GenerateNextRound()
    {
        RoundConfig nextRound = ScriptableObject.CreateInstance<RoundConfig>();

        int round = GetRoundController().GetCurrentRound();
        GameStates.Difficulty difficulty = GameStates.GetGameDifficulty();

        int allowedDifficulty = (round / 10);
        if (allowedDifficulty >= _enemyLists.Count)
            allowedDifficulty = _enemyLists.Count;

        int numWaves;
        if (round > 1)
        {
            numWaves = _random.Next(round / 2, round);
        }
        else
            numWaves = 1;
            

        WaveConfig lastWave = null;

        for(int i = numWaves; i > 0; i--)
        {
            int newEnemyDifficulty = _random.Next(allowedDifficulty);
            List<Enemy> enemyList = _enemyLists.ElementAt(newEnemyDifficulty);
            Enemy waveEnemy = enemyList.ElementAt(_random.Next(enemyList.Count));

            int numEnemies = (round / waveEnemy.GetDifficulty()) + 5;

            WaveConfig wave = ScriptableObject.CreateInstance<WaveConfig>();

            wave.SetEnemyPrefab(waveEnemy);
            wave.SetNumberOfEnemies(numEnemies);
            wave.SetTimeBetweenSpawns((float)(_random.NextDouble() * 2));

            if(lastWave == null)
                wave.SetWaitTimeBeforeStarting(0);
            else
            {
                float lastWaveLength = lastWave.GetWaveLength();
                wave.SetWaitTimeBeforeStarting((float)_random.NextDouble() * lastWaveLength);
            }
            lastWave = wave;
            nextRound.AddWave(wave);
        }

        return nextRound;

    }
}