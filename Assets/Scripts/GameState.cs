using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    RoundController _roundController;
    RoundDisplay _roundDisplay;

    public enum States { NOT_PLAYING, PLAYING, WON, LOST, START }

    States _state = States.START;

    float _roundTimer;

    

    // Start is called before the first frame update
    void Start()
    {
        _roundController = FindObjectOfType<RoundController>();
        _roundDisplay = FindObjectOfType<RoundDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_state == States.PLAYING)
            EndRound();
    }

    public States GetCurrentState() { return _state; }

    public void StartRound()
    {
        _state = States.PLAYING;
        _roundController.StartNextRound();
    }

    private void EndRound()
    {
        _roundTimer += Time.deltaTime;
        if (_roundTimer >= 5 && FindObjectOfType<WaveOverChecker>() == null)
        {
            _state = States.NOT_PLAYING;
            _roundDisplay.UpdateDisplay();
            _roundTimer = 0;
        }
    }
}
