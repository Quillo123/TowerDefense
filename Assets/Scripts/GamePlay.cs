using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{

    [SerializeField] GameState _gameState;
    [SerializeField] GameObject _tank;

    [SerializeField] Transform _spawn;
    [SerializeField] public float _spawnInterval = 7;
    float _timer;


    private void Start()
    {

    }

    private void Update()
    {

    }

}
