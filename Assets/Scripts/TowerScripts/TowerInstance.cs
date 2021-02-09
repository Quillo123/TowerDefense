using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInstance : MonoBehaviour
{
    [SerializeField] int _cost = 1;
    [SerializeField] string _folderLocation;

    public int GetTowerCost()
    {
        return _cost;
    }

    public string GetFolderLocation() { return _folderLocation; }
}
