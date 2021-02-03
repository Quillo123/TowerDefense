using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class GameStates
{
    #region GameStates

    /** The current state the game is in
     *  NotPlaying - In between rounds
     *  Playing - a round is currently in progress
     *  Lost - Player has lost the Game
     *  Start - Game has not yet begun
     *  Paused - open pause menu - all items in game stop moving
     **/
    public enum GameState { NotPlaying, Playing, Lost, Start, Paused }
    static GameState _state = GameState.Start;

    /** The Difficulty enemies should Be
     *  Easy - 1/2 the life and damage
     *  Medium - normal life and damage
     *  Hard - 2x life and damage
     **/
    public enum Difficulty { Easy, Medium, Hard };
    static Difficulty _gameDifficulty = Difficulty.Easy;
    

    /** The RoundGenerator state determines how rounds should Generate.
     *  RandomNoSeed - Generate randomly with random seed
     *  RandomWithSeed - Generate randomly using _seed 
     *  Set - Get the rounds from a set list of prefabs
    **/
    public enum RoundGeneratorState { RandomNoSeed, RandomWithSeed, Set }
    static RoundGeneratorState _generatorState = RoundGeneratorState.RandomWithSeed;
    static int _seed = 0;
    static string _prefabList = string.Empty;

    //Getters
    public static GameState GetGameState() { return _state; }
    public static Difficulty GetGameDifficulty() { return _gameDifficulty; }
    public static RoundGeneratorState GetGeneratorState() { return _generatorState; }
    public static int GetSeed() { return _seed; }

    //Setters
    public static void SetGameState(GameState state) { _state = state; }
    public static void SetGameDifficulty(Difficulty difficulty) { _gameDifficulty = difficulty; }
    
    #endregion

    #region CachedObjects

    //Cached GameObjects
    static GameObject _gameOverPanel;
    static RoundController _roundController;
    static RoundGenerator _roundGenerator;
    static RoundDisplay _roundDisplay;
    static GameController _gameController;
    static EnemySpawner _enemySpawner;
    static MessageController _messageController;
    static LifeDisplay _lifeDisplay;
    static MoneyDisplay _moneyDisplay;


    //Get Cached GameObjects
    public static GameObject GetGameOverPanel() { return _gameOverPanel; }
    public static RoundController GetRoundController() { return _roundController; }
    public static RoundGenerator GetRoundGenerator() { return _roundGenerator; }
    public static RoundDisplay GetRoundDisplay() { return _roundDisplay; }
    public static GameController GetGameController() { return _gameController; }
    public static EnemySpawner GetEnemySpawner() { return _enemySpawner; }
    public static MessageController GetMessageController() { return _messageController; }
    public static LifeDisplay GetLifeDisplay() { return _lifeDisplay; }
    public static MoneyDisplay GetMoneyDisplay() { return _moneyDisplay; }

    public static void PopulateCachedGameObjects(string gameOverPanel)
    {
        _gameOverPanel = GameObject.Find(gameOverPanel);
        _roundController = GameObject.FindObjectOfType<RoundController>();
        _roundGenerator = GameObject.FindObjectOfType<RoundGenerator>();
        _roundDisplay = GameObject.FindObjectOfType<RoundDisplay>();
        _gameController = GameObject.FindObjectOfType<GameController>();
        _enemySpawner = GameObject.FindObjectOfType<EnemySpawner>();
        _messageController = GameObject.FindObjectOfType<MessageController>();
        _lifeDisplay = GameObject.FindObjectOfType<LifeDisplay>();
        _moneyDisplay = GameObject.FindObjectOfType<MoneyDisplay>();
    }

    #endregion
}
