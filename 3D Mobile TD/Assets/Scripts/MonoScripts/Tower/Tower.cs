using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    [Header("Solo Target")]
    [SerializeField] protected Transform target;
    [SerializeField] protected Enemy targetEnemy;
    [SerializeField] protected EnemyMoving targetEnemyMoving;

    [Header("Attributes")]
    [SerializeField] public int towerLevel;
    [SerializeField] private float _range;

    //чем меньше fireRate, тем медленнее выстрел
    [SerializeField] private float _fireRate;
    private float _fireCountdown = 0f;

    private string _enemyTag = "Enemy";
    [Header("Unity Setup Fields")]
    [SerializeField] private Transform _partToRotate;
    [SerializeField] private float _turnSpeed = 10f;

    [SerializeField] protected GameObject _bulletPrefab;
    [SerializeField] protected Transform _firePoint;

    public TowerData towerData;
    

    //подписка на эвент для обновления данных
    private void OnEnable()
    {
        BuildingSlot.UpdateDataEvent += SetTowerData;
    }

    private void Awake()
    {
        SetTowerData();
        InvokeRepeating("UpdateTarget", 0f, 0.2f);
    }

    protected virtual void Start()
    {
        SetTowerData();
        if (_bulletPrefab != null)
        {
            _bulletPrefab.GetComponent<Bullet>().towerData = towerData;
        }
        else
        {
            print("Bullet is not found!");
        }
        
    }

    protected virtual void Update()
    {
        if (target == null)
        {
            return;
        }

        TargetLookOn();

        if (!towerData.laserTower)
        {
            if (_fireCountdown <= 0f)
            {
                Shoot();
                _fireCountdown = .3f / _fireRate;
            }
            _fireCountdown -= Time.deltaTime;
        }
    }

    private void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.towerData = towerData;

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(_enemyTag);
        float shortestDistance = Mathf.Infinity; // кратчайшая дистанция
        GameObject nearestEnemy = null; // ближайший враг

        foreach (var enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= _range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
            targetEnemyMoving = nearestEnemy.GetComponent<EnemyMoving>();
        }
        else
        {
            target = null;
            targetEnemy = null;
            targetEnemyMoving = null;
        }
    }

    private void TargetLookOn()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(_partToRotate.rotation, lookRotation, Time.deltaTime * _turnSpeed).eulerAngles;
        _partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    //Рисует гизмос
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }

    private void SetTowerData()
    {
        _range = towerData.towerRadius;
        _fireRate = towerData.towerAttackDelay;
        towerLevel = towerData.towerLevel;
        //ещё меш менять надо на новый

    }

    private void OnDisable()
    {
        BuildingSlot.UpdateDataEvent += SetTowerData;
    }
}


