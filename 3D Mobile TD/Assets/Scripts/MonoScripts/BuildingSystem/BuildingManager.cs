using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager instance;
    [Header("Attack Tower")]
    public TowerData attackTower1;
    public TowerData attackTower2;
    public TowerData attackTower3;
    public TowerData attackTower4;

    [Header("Support Tower")]
    public TowerData supportTower1;
    public TowerData supportTower2;
    public TowerData supportTower3;
    public TowerData supportTower4;

    [Header("Player Resource Data")]
    public PlayerResourceData playerResourceData;

    [Header("Upgrade Attack Tower 1")]
    public TowerData upgradeAttackTower1_LEVEL2;
    public TowerData upgradeAttackTower1_LEVEL3;

    [Header("Upgrade Attack Tower 2")]
    public TowerData upgradeAttackTower2_LEVEL2;
    public TowerData upgradeAttackTower2_LEVEL3;

    [Header("Upgrade Attack Tower 3")]
    public TowerData upgradeAttackTower3_LEVEL2;
    public TowerData upgradeAttackTower3_LEVEL3;

    [Header("Upgrade Attack Tower 4")]
    public TowerData upgradeAttackTower4_LEVEL2;
    public TowerData upgradeAttackTower4_LEVEL3;



    [Header("Upgrade Support Tower 1")]
    public TowerData upgradeSupportTower1_LEVEL2;
    public TowerData upgradeSupportTower1_LEVEL3;

    [Header("Upgrade Support Tower 2")]
    public TowerData upgradeSupportTower2_LEVEL2;
    public TowerData upgradeSupportTower2_LEVEL3;

    [Header("Upgrade Support Tower 3")]
    public TowerData upgradeSupportTower3_LEVEL2;
    public TowerData upgradeSupportTower3_LEVEL3;

    [Header("Upgrade Support Tower 4")]
    public TowerData upgradeSupportTower4_LEVEL2;
    public TowerData upgradeSupportTower4_LEVEL3;

    private void Awake()
    {
        instance = this;
    }
}
