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
        _timer = 3;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_gameState.state == GameState.States.PLAYING && _timer >= 3)
        { 
           var tankInst = Instantiate(_tank, _spawn.transform.position, Quaternion.Euler(new Vector2(0, 0)));
            _timer = 0;
        }
    }

}
