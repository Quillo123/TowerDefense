using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyDisplay : MonoBehaviour
{

    [SerializeField] int _money = 100;

    TextMeshProUGUI _moneyText;

    private void Start()
    {
        _moneyText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        _moneyText.text = "$" + _money.ToString();
    }

    public void AddMoney(int moneyToBeAdded)
    {
        _money += moneyToBeAdded;
        UpdateDisplay();
    }

    public bool SpendMoney(int cost)
    {
        if (cost > _money)
            return false;

        _money -= cost;

        UpdateDisplay();
        return true;
    }
}
