using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int _health = 1;
    [SerializeField] int _damage = 1;
    [SerializeField] float _moveSpeed = 2f;
    [SerializeField] int _moneyAddedOnDeath = 1;
    [SerializeField] int _difficulty = 1;

    MoneyDisplay _moneyDisplay;


    public int GetDamage() { return _damage; }

    public int GetDifficulty() { return _difficulty}

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
            _health -= projectile._projectileDamage;
            projectile._projectileHealth--;
        }   
    }

    public float GetMoveSpeed() { return _moveSpeed; }

    private void DestroyEnemy()
    {
        _moneyDisplay.AddMoney(_moneyAddedOnDeath);
        Destroy(gameObject);
    }

}
