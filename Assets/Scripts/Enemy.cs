using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int _health = 1;
    [SerializeField] int _damage = 1;
    [SerializeField] int _moneyAddedOnDeath = 1;

    MoneyDisplay _moneyDisplay;

    private void Start()
    {
        _moneyDisplay = FindObjectOfType<MoneyDisplay>();
    }

    private void Update()
    {
        if (_health <= 0)
            DestroyEnemy();
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
        {
            var projectile = collision.GetComponent<Projectile>();
            int healthRemaining = _health;
            _health -= projectile.projectileHealth;
            projectile.projectileHealth -= healthRemaining;
        }   
    }

    private void DestroyEnemy()
    {
        _moneyDisplay.AddMoney(_moneyAddedOnDeath);
        Destroy(gameObject);
    }

}
