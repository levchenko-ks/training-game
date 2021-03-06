public interface IGameHUD : IScreen
{
    void SetMaxHP(float amount);
    void SetHP(float amount);
    void SetReloadTime(float amount);
    void SetReloadStatus(float amount);
    void SetMaxAmmo(int amount);
    void SetAmmo(int count);
    void ShowWeaponIcon(int index);
    void HideWeaponIcon(int index);
    void SetCharacteristic(CharacteristicsNames name, float count);
    void SetScore(float count);

    void UpdateTaskWidget(ITask task);
    void RemoveTaskWidget(ITask task);
    void CreateTaskWidget(ITask task);
}
