using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{


    [SerializeField] Projectile _projectile;

    [SerializeField] public float _projectileSpeed = 8;
    [SerializeField] public int _projectileDamage = 1;
    [SerializeField] public int _projectileHealth = 1;

    [SerializeField] float _range = 10f;

    GameObject _currentEnemy;

    [SerializeField] float _fireWaitTime = 1;
    float _timer;
    


    //Cached objects
    Transform _firePos;


    // Start is called before the first frame update
    void Start()
    {
        _firePos = transform.Find("FirePosition");
        _timer = _fireWaitTime;

        _projectile._projectileDamage = _projectileDamage;
        _projectile._projectileHealth = _projectileHealth;
    }

    // Update is called once per frame
    void Update()
    {
        _currentEnemy = FindClosestEnemy();
        if (_currentEnemy != null)
        {
            LookTowardTarget();
            _timer += Time.deltaTime;
            if (_timer > _fireWaitTime)
            {
                FireProjectile();
                _timer = 0;
            }
        }
        
    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        if (closest == null || Vector2.Distance(closest.transform.position, transform.position) > _range)
            return null;
        return closest;
    }

    private void LookTowardTarget()
    {
        Vector3 currentAngle = transform.up;
        Vector3 targetAngle = _currentEnemy.transform.position - transform.position;
        targetAngle.z = 0;

        float angle = Vector3.SignedAngle(currentAngle, targetAngle, transform.forward);
        transform.Rotate(0.0f, 0.0f, angle);    
    }

    private void FireProjectile()
    {
        Vector3 firePosition = new Vector3(_firePos.position.x, _firePos.position.y, _firePos.position.z);
        var projectileInst = Instantiate(_projectile, firePosition, transform.rotation) as Projectile;
        projectileInst.GetComponent<Rigidbody2D>().velocity = _firePos.up * _projectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
