using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeDisplay : MonoBehaviour
{
    [SerializeField] int _life = 100;

    TextMeshProUGUI _lifeText;

    private void Start()
    {
        _lifeText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        _lifeText.text = _life.ToString();
    }

    public void AddLife(int lifeToBeAdded)
    {
        _life += lifeToBeAdded;
        UpdateDisplay();
    }

    public bool RemoveLife(int lifeToBeRemoved)
    {
        if (lifeToBeRemoved > _life)
            return false;
            

        _life -= lifeToBeRemoved;

        if (_life <= 0)
            GameStates.SetGameState(GameStates.GameState.Lost);

        UpdateDisplay();
        return true;
    }
}
