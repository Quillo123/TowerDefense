using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{


    WaveConfig _waveConfig;
    List<Transform> _waypoints;
    int _waypointIndex = 0;

    GameState _gameState;

    void Start()
    {
        gameObject.tag = "Enemy";

        _gameState = FindObjectOfType<GameState>();

        var targetPos = _waypoints[_waypointIndex].transform.position;
        LookTowardTarget(targetPos);
    }

    void Update()
    {
            MoveTowardWaypoint();
    }

    public void SetWaveConfigAndPath(WaveConfig waveConfig, Path path)
    {
        _waveConfig = waveConfig;
        _waypoints = path.GetWaypoints();
    }

    private void MoveTowardWaypoint()
    {
        if (_waypointIndex <= _waypoints.Count - 1)
        {
            var targetPos = _waypoints[_waypointIndex].transform.position;
            var movementThisFrame = GetComponent<Enemy>().GetMoveSpeed() * Time.deltaTime;
            
            transform.position = Vector2.MoveTowards(transform.position, targetPos, movementThisFrame);
            
            if (transform.position == targetPos)
            {
                _waypointIndex++;
                if (_waypointIndex <= _waypoints.Count - 1)
                {
                    targetPos = _waypoints[_waypointIndex].transform.position;
                    LookTowardTarget(targetPos);
                }      
            }
                
        }
        else
            LosePoints();
    }

    void LosePoints()
    {
        if (!FindObjectOfType<LifeDisplay>().RemoveLife(GetComponent<Enemy>().GetDamage()))
        {
            _gameState.SetState(GameState.State.Lost);
        }
        Destroy(gameObject);
    }
    private void LookTowardTarget(Vector3 targetPos)
    {
        Vector3 currentAngle = transform.up;
        Vector3 targetAngle = targetPos - transform.position;
        targetAngle.z = 0;

        float angle = Vector3.SignedAngle(currentAngle, targetAngle, transform.forward);
        transform.Rotate(0.0f, 0.0f, angle);
    }
}
