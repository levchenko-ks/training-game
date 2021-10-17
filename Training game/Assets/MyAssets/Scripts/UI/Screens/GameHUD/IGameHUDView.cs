using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameHUDView 
{
    void Show();
    void Hide();
    void SetMaxHP(float amount);
    void SetHP(float amount);
    void SetReloadTime(float amount);
    void SetReloadStatus(float amount);
    void SetMaxAmmo(float amount);
    void SetAmmo(int count);
    void SetWeaponIcon(int count);
}
