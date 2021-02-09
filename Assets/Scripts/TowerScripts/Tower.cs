using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tower : MonoBehaviour
{
    GameObject towerMenu;
    TowerInstance _towerPrefab;
    TowerInstance _towerInstance;

    int _tier = 1;

    private void Start()
    {
        transform.tag = "Tower";
        transform.Find("Range").GetComponent<SpriteRenderer>().sprite = null;
        towerMenu = transform.GetChild(0).gameObject;
        _towerInstance = Instantiate(_towerPrefab, transform.position, Quaternion.identity, transform);
        towerMenu.SetActive(false);

    }

    private void Update()
    {        
        if (Input.GetMouseButtonDown(0))
        {
            if (IsMouseOverObject())
            {
                towerMenu.SetActive(true);
            }
            else 
            { 
                towerMenu.SetActive(false);
            }
        }

    }

    public void SetTowerInstance(TowerInstance tower){ _towerPrefab = tower; }


    private bool IsMouseOverObject()
    {
        Vector2 touchPosition = GameStates.GetMainCamera().ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit2D = Physics2D.Raycast(touchPosition, Vector2.zero);
        bool retVal = hit2D.collider == _towerInstance.GetComponent<Collider2D>() || hit2D.collider == towerMenu.GetComponent<Collider2D>();
        return retVal;
    }

    public void SellTower()
    {
        GameStates.GetMoneyDisplay().AddMoney(_towerInstance.GetTowerCost() / 2);
        Destroy(gameObject);
    }

    public void UpgradeTower()
    {
        _tier++;
        string prefabLocation =_towerInstance.GetFolderLocation() + _tier;
        TowerInstance tower = Resources.Load<TowerInstance>(prefabLocation);
        _towerPrefab = tower;
        UpdateTower();
    }

    public void UpdateTower()
    {
        TowerInstance temp = _towerInstance;
        Destroy(temp);
        _towerInstance = Instantiate(_towerPrefab, transform.position, Quaternion.identity, transform);
    }


}
