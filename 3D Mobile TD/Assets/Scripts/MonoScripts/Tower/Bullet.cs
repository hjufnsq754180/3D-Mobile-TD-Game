using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _target;
    [SerializeField] private float bulletSpeed = 30f;
    //эффект при попадании
    [SerializeField] private GameObject impactEffect;

    //данные о башне, который мы передаем из самой башни, откуда летит пуля
    public TowerData towerData;

    //Метод через который мы передаем target
    public void Seek(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = _target.position - transform.position;
        float distanceThisFrame = bulletSpeed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(_target);
    }

    private void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(towerData.towerDamage);
        }
    }

    private void HitTarget()
    {
        GameObject effectInst = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInst, 2f);

        if (towerData.explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(_target);
        }

        Destroy(gameObject);
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, towerData.explosionRadius);
        foreach (var collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.gameObject.transform);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, towerData.explosionRadius);
    }
}
