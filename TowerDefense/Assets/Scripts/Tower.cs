using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int _cost = 1;


    private void Start()
    {
        transform.Find("Range").GetComponent<SpriteRenderer>().sprite = null;
    }

    public int GetTowerCost()
    {
        return _cost;
    }

}
