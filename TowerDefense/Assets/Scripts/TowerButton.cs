using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour
{

    [SerializeField] Tower _towerPrefab;

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<TowerButton>();

        foreach(TowerButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(32, 32, 32, 255);
        }
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;

        FindObjectOfType<TowerSpawner>().SetSelectedTower(_towerPrefab);
    }
}
