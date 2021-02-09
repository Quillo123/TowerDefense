using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] Sprite HighlightedSprite;
    [SerializeField] Sprite DefaultSprite;

    private void OnMouseOver()
    {
        GetComponent<SpriteRenderer>().sprite = HighlightedSprite;
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().sprite = DefaultSprite;
    }

    private void OnMouseDown()
    {
        transform.parent.parent.GetComponent<Tower>().UpgradeTower();
    }
}
