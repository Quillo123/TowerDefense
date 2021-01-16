using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] public int projectileHealth = 1;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Projectile";
    }

    // Update is called once per frame
    void Update()
    {
        if (projectileHealth <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BorderWall")
            Destroy(gameObject);
    }
}
