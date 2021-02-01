using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    //Enums
    public enum Difficulty { Easy, Medium, Hard };
    public enum State { NotPlaying, Playing, Lost, Start }
    public enum RoundGeneratorState { RandomNoSeed, RandomWithSeed, Set}



    Difficulty _gameDifficulty = Difficulty.Easy;
    State _state = State.Start;

    RoundGeneratorState _generatorState = RoundGeneratorState.RandomWithSeed;
    int _seed = 0;

    float _roundTimer;

    GameObject _gameOverPanel;
    string _gameOverPanelName = "GameOverPanel";
    RoundController _roundController;
    RoundDisplay _roundDisplay;

    public State GetCurrentState() { return _state; }

    public Difficulty GetGameDifficulty() { return _gameDifficulty; }

    public RoundGeneratorState GetGeneratorState() { return _generatorState; }

    public int GetSeed() { return _seed; }

    public void SetState(State state) { _state = state; }



    void Start()
    {
        _roundController = FindObjectOfType<RoundController>();
        _roundDisplay = FindObjectOfType<RoundDisplay>();
        _gameOverPanel = GameObject.Find(_gameOverPanelName);

        _gameOverPanel.gameObject.SetActive(false);

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
                _gameOverPanel.gameObject.SetActive(true);
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
