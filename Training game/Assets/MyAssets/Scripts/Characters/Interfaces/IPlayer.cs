using System;
using UnityEngine;

public interface IPlayer: IMovable
{
    event Action<IPlayer> PlayerDied;
    event Action<float> CurrentHPChanged;
    event Action<float> MaxHPChanged;
    event Action<CharacteristicsNames, float> CharacteristicChanged;
    event Action<IWeapon> WeaponAdded;
    event Action<EnvironmentComponents> ObjectFinded;    

    void AddWeapon(Weapons weapon);
    void CollectBonus(CharacteristicsNames name, Modifier modifier);
    void TakeDamage(float damage);
    void TakeHeal(float heal);
    void FindObject(EnvironmentComponents obj);
}