using UnityEngine;

public interface IEnemy
{
    Transform Target { set; }
    Transform Cam { set; }
    void TakeDamage(float damage);
}