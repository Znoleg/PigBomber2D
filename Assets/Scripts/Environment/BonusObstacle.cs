using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BonusObstacle : Obstacle, IHitable
{
    [SerializeField]
    private BonusSpawner _bonusSpawner;

    protected override IHitable Hitable => this;

    public void GetHit()
    {
        _bonusSpawner.TrySpawnBonus(transform.position);
        Destroy(gameObject);
    }
}

