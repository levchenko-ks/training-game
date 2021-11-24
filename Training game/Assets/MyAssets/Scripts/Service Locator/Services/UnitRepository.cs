using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRepository : MonoBehaviour, IUnitRepository
{
    public event Action<IEnemy> EnemyDied;

    private Dictionary<string, List<IEnemy>> _enemyLists = new Dictionary<string, List<IEnemy>>();

    public void AddEnemy(IEnemy enemy)
    {

    }

}
