using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour
{

    [SerializeField] TowerInstance _towerPrefab;

    public static Color32 notSelectedColor = new Color32(32, 32, 32, 255);

    private void Start()
    {
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {
        Text costText = GetComponentInChildren<Text>();
        if (!costText)
        {
            Debug.LogError(name + " Missing cost text!!!");
        }
        else
        {
            costText.text = "$" + _towerPrefab.GetTowerCost().ToString();
        }
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<TowerButton>();

        foreach(TowerButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = notSelectedColor;
        }
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;

        FindObjectOfType<TowerSpawner>().SetSelectedTower(_towerPrefab, this);
    }
}
