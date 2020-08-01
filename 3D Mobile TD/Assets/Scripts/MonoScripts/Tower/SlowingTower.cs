using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowingTower : Tower
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        if (targetEnemyMoving != null)
        {
            targetEnemyMoving.StartSlowing(towerData.slowingPower, 2);
        }
    }
}
