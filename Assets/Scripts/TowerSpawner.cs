using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{

    Tower _tower;

    MoneyDisplay _moneyDisplay;

    private void Start()
    {
        _moneyDisplay = FindObjectOfType<MoneyDisplay>();
    }

    private void OnMouseDown()
    {
        if (_tower != null)
        {
            if (_moneyDisplay.SpendMoney(_tower.GetTowerCost()))
                SpawnTower(GetPosClicked());
            else
                Debug.Log("Not enough money");
        } 
        else
            Debug.Log("Tower not selected");
    }

    public void SetSelectedTower(Tower towerToSelect)
    {
        _tower = towerToSelect;
    }

    private Vector2 GetPosClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return worldPos;
    }

    private void SpawnTower(Vector2 spawnPos)
    {
        Tower newTower = Instantiate(_tower, spawnPos, Quaternion.identity) as Tower;
    }
}
