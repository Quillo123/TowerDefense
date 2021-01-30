using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MapLoader : MonoBehaviour
{
    static int _mapNum = 1;

    public static void SetMapNum(int mapNum)
    {
        _mapNum = mapNum;
    }

    public static int GetMapNum()
    {
        return _mapNum;
    }

    public static void LoadMap()
    {
        if(_mapNum == -1)
        {
            Debug.LogError("Map never Set!!! Returning to main menu!!");
            FindObjectOfType<SceneLoader>().LoadMainMenu();
        }
        else
        {
            Object map = Resources.Load("Maps/LevelMap_" + _mapNum.ToString());

            if(map == null)
            {
                Debug.LogError("Invalid Map");
            }
            else
            {
                Instantiate(map);
            }
        }
    }
}
