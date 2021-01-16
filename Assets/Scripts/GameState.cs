using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    public enum States { NOT_PLAYING, PLAYING, WON, LOST, START }

    public States state = States.START;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRound()
    {
        state = States.PLAYING;
    }
}
