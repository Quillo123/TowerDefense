using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameStates;

public class GameController : MonoBehaviour
{

    [SerializeField] string GameOverPanelName = "GameOverPanel";

    float _roundTimer = 0f;

    private void Awake()
    {
        PopulateCachedGameObjects(GameOverPanelName);
    }

    private void Start()
    {  
        GetGameOverPanel().SetActive(false);
        MapLoader.LoadMap();
    }

    void Update()
    {


        switch (GetGameState())
        {
            case GameState.NotPlaying:
                break;
            case GameState.Playing:
                EndRound();
                break;
            case GameState.Lost:
                GetGameOverPanel().gameObject.SetActive(true);
                break;
            case GameState.Start:
                break;
        }
    }

    public void StartRound()
    {
        SetGameState(GameState.Playing);
        GetRoundController().StartNextRound();
    }

    private void EndRound()
    {
        _roundTimer += Time.deltaTime;
        if (_roundTimer >= 5 && FindObjectOfType<WaveOverChecker>() == null)
        {
            SetGameState(GameState.NotPlaying);
            GetRoundDisplay().UpdateDisplay();
            _roundTimer = 0;
        }
    }
}
