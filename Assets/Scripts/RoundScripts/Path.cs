using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{

    List<Transform> _waypoints;
    Grid _grid;
    // Start is called before the first frame update
    void Start()
    {
        _grid = FindObjectOfType<Grid>();

        CreateWaypointsList();
        CenterWaypoints();
    }

    private void CenterWaypoints()
    {
        foreach(Transform waypoint in _waypoints)
        {
            Vector3Int cell = _grid.WorldToCell(waypoint.transform.position);
            Vector3 cellPos = _grid.CellToWorld(cell);
            waypoint.transform.position = new Vector3(cellPos.x + .5f, cellPos.y + .5f, 0);
        }
        
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
