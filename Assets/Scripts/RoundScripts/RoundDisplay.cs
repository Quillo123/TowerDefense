using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundDisplay : MonoBehaviour
{
    TextMeshProUGUI _roundText;
    RoundController _roundController;

    private void Start()
    {
        _roundText = GetComponent<TextMeshProUGUI>();
        _roundController = FindObjectOfType<RoundController>();
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        _roundText.text = "Round: " + (_roundController.GetCurrentRound() + 1).ToString();
    }
}
