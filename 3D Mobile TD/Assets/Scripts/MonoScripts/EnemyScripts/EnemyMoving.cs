using System;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    [SerializeField] private EnemyData _enemyData;
    [SerializeField] private PlayerResourceData _playerResourceData;

    [SerializeField] public float _enemySpeed;
    
    //TODO: возможно это плохой вариант, т.к. будут создаваться евенты на каждом Enemy
    public delegate void LivesEventHandler();
    public static event LivesEventHandler LivesEvent;

    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        _enemySpeed = _enemyData.enemySpeed;
        target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * _enemySpeed * Time.deltaTime, Space.World);

        //Проверяем дистанцию между врагом и вейпоинтом
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        _enemySpeed = _enemyData.enemySpeed;
    }

    private void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    private void EndPath()
    {
        if (_playerResourceData.lives > 0)
        {
            _playerResourceData.lives--;
        }
        WaveSpawner.EnemiesAlive--;
        LivesEvent?.Invoke();
        Destroy(gameObject);
    }

    public void StartSlowing(float slowPower, float duration)
    {
        _enemySpeed = _enemySpeed * (1f - slowPower);
        if (!IsInvoking("StopSlowing"))
        {
            Invoke("StopSlowing", duration);
        }
    }

    public void StopSlowing()
    {
        _enemySpeed = _enemyData.enemySpeed;
    }
}