using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{

    [SerializeField] Tower _tower;
    TowerInstance _towerInstance;
    TowerButton _towerButton;

    private void OnMouseDown()
    {
        if (_towerInstance != null)
        {
            if (GameStates.GetMoneyDisplay().SpendMoney(_towerInstance.GetTowerCost()))
            {
                SpawnTower(GetPosClicked());
            }
            else
            {
                GameStates.GetMessageController().PlayMessage("Not Enough Money");
            }
                
        } 
        else
            Debug.Log("Tower not selected");
    }

    public void SetSelectedTower(TowerInstance towerToSelect, TowerButton towerButton)
    {
        _towerInstance = towerToSelect;
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
        if(_towerInstance != null)
        {
            Tower newTower = Instantiate(_tower, spawnPos, Quaternion.identity) as Tower;
            newTower.SetTowerInstance(_towerInstance);

            _towerInstance = null;
            _towerButton.GetComponent<SpriteRenderer>().color = TowerButton.notSelectedColor;
        }
        else
        {
            Debug.Log("Tower not selected.");
        }
    }
}
