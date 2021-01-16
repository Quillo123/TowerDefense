using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    RoundController _roundController;

    public enum States { NOT_PLAYING, PLAYING, WON, LOST, START }

    public States state = States.START;

    

    // Start is called before the first frame update
    void Start()
    {
        _roundController = FindObjectOfType<RoundController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartRound()
    {
        state = States.PLAYING;
        _roundController.StartNextRound();
    }
}
