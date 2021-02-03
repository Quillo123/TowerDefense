using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundDisplay : MonoBehaviour
{
    TextMeshProUGUI _roundText;

    private void Start()
    {
        _roundText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        _roundText.text = "Round: " + (GameStates.GetRoundController().GetCurrentRound() + 1).ToString();
    }
}
