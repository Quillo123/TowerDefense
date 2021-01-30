using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    RoundController _roundController;
    RoundDisplay _roundDisplay;

    bool _isRandom = false;
    int _seed = 0;

    public enum State { NotPlaying, Playing, Lost, Start }
    public enum RoundGeneratorState { RandomNoSeed, RandomSeed, Set}

    State _state = State.Start;

    float _roundTimer;


    public State GetCurrentState() { return _state; }
    public void SetState(State state) { _state = state; }

    public int GetSeed() { return _seed; }

    public bool IsRandomSeed() { return _isRandom; }

    void Start()
    {
        _roundController = FindObjectOfType<RoundController>();
        _roundDisplay = FindObjectOfType<RoundDisplay>();

        MapLoader.LoadMap();
    }

    void Update()
    {
        switch (_state)
        {
            case State.NotPlaying:
                break;
            case State.Playing:
                EndRound();
                break;
            case State.Lost:
                break;
            case State.Start:
                break;
        }
    }

    public void StartRound()
    {
        _state = State.Playing;
        _roundController.StartNextRound();
    }

    private void EndRound()
    {
        _roundTimer += Time.deltaTime;
        if (_roundTimer >= 5 && FindObjectOfType<WaveOverChecker>() == null)
        {
            _state = State.NotPlaying;
            _roundDisplay.UpdateDisplay();
            _roundTimer = 0;
        }
    }
}
