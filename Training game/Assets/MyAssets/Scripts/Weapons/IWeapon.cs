using System;
using UnityEngine;

public interface IWeapon
{
    event Action<float> ReloadTimeChanged;
    event Action<float> ReloadStatusChanged;
    event Action<int> MaxAmmoChanged;
    event Action<int> CurrentAmmoChanged;
    event Action<int> WeaponIconUpdate;

    int WeaponIndex { get; }

    void SetHolder(Transform holder);
    void SetWeaponCharacterisctics(ICharacteristicControl characteristics);
    void SetActive(bool state);
}