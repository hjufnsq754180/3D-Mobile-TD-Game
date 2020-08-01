using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData _enemyData;
    [SerializeField] private PlayerResourceData _playerResourceData;
    [SerializeField] private float _enemyHealth;

    public GameObject deathEffect;

    [Header("Unity Staff")]
    [SerializeField] private Image _healthBar;

    public delegate void GoldEventHandler();
    public static event GoldEventHandler GoldEvent;

    private bool isDead = false;

    private void Start()
    {
        _enemyHealth = _enemyData.enemyHealth;
    }

    public void TakeDamage(float amount)
    {
        _enemyHealth -= amount;

        _healthBar.fillAmount = _enemyHealth / _enemyData.enemyHealth;

        if (_enemyHealth <= 0 && !isDead)
        {
            Die();
        }
    }

    //TODO: доделать эффект
    //TODO: можно прикрутить эффекты и надо давать денег за убийство
    private void Die()
    {
        isDead = true;
        _playerResourceData.gold += _enemyData.worth;
        GoldEvent?.Invoke();
        WaveSpawner.EnemiesAlive--;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
        Destroy(gameObject);
    }
}
