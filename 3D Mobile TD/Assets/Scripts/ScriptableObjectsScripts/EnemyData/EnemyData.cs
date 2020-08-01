using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Data")]
public class EnemyData : ScriptableObject
{
    public float enemyHealth;
    public float enemySpeed;
    public int enemyDamage;
    public float enemyAttackDelay;
    public int worth;

}
