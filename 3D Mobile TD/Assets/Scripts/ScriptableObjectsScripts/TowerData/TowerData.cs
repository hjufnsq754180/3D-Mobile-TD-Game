using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Tower Data")]
public class TowerData : ScriptableObject
{
    [Header("Tower Price")]
    public int towerBuyPrice;

    [Header("Tower Upgrade Price")]
    public int towerUpgradePrice;

    [Header("Tower Damage")]
    public int towerDamage;

    [Header("Tower Radius")]
    public float towerRadius;

    [Header("Tower Attack Delay")]
    public float towerAttackDelay;

    [Header("Tower Level")]
    public int towerLevel = 1;

    [Header("Player Resourse Data")]
    public PlayerResourceData resourceData;

    [Header("Tower Upgrade Object")]
    public GameObject towerObject;

    [Header("Tower Destroy Give Gold")]
    public int destroyGiveGold;

    [Header("Tower UI Icon")]
    public Sprite icon;

    [Header("Explosion Radius")]
    public float explosionRadius;

    [Header("Slowing Power")]
    public float slowingPower;

    [Header("Slowing Tower")]
    public bool slowingTower;

    [Header("Laser Tower")]
    public bool laserTower;

    [Header("Laser Damage")]
    public int laserDamageOverTime;

    public void BuildTower()
    {
        resourceData.gold -= towerBuyPrice;
    }

    public void DestroyTower()
    {
        resourceData.gold += destroyGiveGold / 2;
    }

    //проверка на русерсы
    public void UpgradePrice()
    {
        resourceData.gold -= towerUpgradePrice;
    }
}
