using System;
using UnityEngine;

public interface IEnemy
{
    event Action<IEnemy> Died;

    IMovable Target { set; }
    Transform BillboardCam { set; }
    void TakeDamage(float damage);
    
}