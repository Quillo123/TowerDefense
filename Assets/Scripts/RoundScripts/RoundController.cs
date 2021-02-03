using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameStates;

public class RoundController : MonoBehaviour
{

    List<RoundConfig> _roundConfigs = null;
    [SerializeField] int _currRound = 0;

    public void StartNextRound()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && GameObject.FindGameObjectWithTag("WaveChecker") == null)
        {
            if (GetGeneratorState() == RoundGeneratorState.Set)
                GetEnemySpawner().SpawnAllWaves(_roundConfigs[_currRound].GetRoundWaves());
            else
                GetEnemySpawner().SpawnAllWaves(GetRoundGenerator().GenerateNextRound().GetRoundWaves());
            _currRound++;
        }
        else
        {
            GetMessageController().PlayMessage("Round not over");
        }
    }

    public int GetCurrentRound() { return _currRound; }
}
