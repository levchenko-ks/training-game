using System;
using UnityEngine;

public interface IEnemy
{
    event Action<IEnemy> Died;

    Transform Target { set; }
    Transform Cam { set; }
    void TakeDamage(float damage);
    
}