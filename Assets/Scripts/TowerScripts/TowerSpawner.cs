using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{

    Tower _tower;
    TowerButton _towerButton;

    MoneyDisplay _moneyDisplay;
    MessageController _messageController;

    private void Start()
    {
        _moneyDisplay = FindObjectOfType<MoneyDisplay>();
        _messageController = FindObjectOfType<MessageController>();
    }

    private void OnMouseDown()
    {
        if (_tower != null)
        {
            if (_moneyDisplay.SpendMoney(_tower.GetTowerCost()))
            {
                SpawnTower(GetPosClicked());
            }
            else
            {
                _messageController.PlayMessage("Not Enough Money");
            }
                
        } 
        else
            Debug.Log("Tower not selected");
    }

    public void SetSelectedTower(Tower towerToSelect, TowerButton towerButton)
    {
        _tower = towerToSelect;
        _towerButton = towerButton;
    }

    private Vector2 GetPosClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return worldPos;
    }

    private void SpawnTower(Vector2 spawnPos)
    {
        if(_tower != null)
        {
            Tower newTower = Instantiate(_tower, spawnPos, Quaternion.identity) as Tower;
            _tower = null;
            _towerButton.GetComponent<SpriteRenderer>().color = TowerButton.notSelectedColor;
        }
        else
        {
            Debug.Log("Tower not selected.");
        }
    }
}
