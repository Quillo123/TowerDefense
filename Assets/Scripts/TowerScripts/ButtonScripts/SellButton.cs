using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellButton : MonoBehaviour
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
        GetComponentInParent<Tower>().SellTower();
    }


}
