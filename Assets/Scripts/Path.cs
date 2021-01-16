using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{

    List<Transform> _waypoints;

    // Start is called before the first frame update
    void Start()
    {
        CreateWaypointsList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateWaypointsList()
    {
        _waypoints = new List<Transform>();

        foreach (Transform child in transform)
        {
            _waypoints.Add(child);
        }
    }

    public List<Transform> GetWaypoints() { return _waypoints;  }

}
