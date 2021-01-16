using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{


    WaveConfig _waveConfig;
    List<Transform> _waypoints;
    int _waypointIndex = 0;

    Transform _currentFlag;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Enemy";
        _waypoints = _waveConfig.GetWaypoints();
        _currentFlag = _waypoints[_waypointIndex];

        
        

        var targetPos = _waypoints[_waypointIndex].transform.position;
        LookTowardTarget(targetPos);
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardWaypoint();

    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        _waveConfig = waveConfig;
    }

    private void MoveTowardWaypoint()
    {
        if (_waypointIndex <= _waypoints.Count - 1)
        {
            var targetPos = _waypoints[_waypointIndex].transform.position;
            var movementThisFrame = _waveConfig.GetMoveSpeed() * Time.deltaTime;
            
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
