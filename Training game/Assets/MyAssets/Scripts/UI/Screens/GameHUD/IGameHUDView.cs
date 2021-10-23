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
    void ShowWeaponIcon(int index);
    void HideWeaponIcon(int index);
    void SetCharacteristic(CharacteristicsNames name, float count);
    void SetScore(float score);
}
