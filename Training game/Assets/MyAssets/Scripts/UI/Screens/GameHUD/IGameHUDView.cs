public interface IGameHUDView: IView
{
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

    void CreateTaskWidget(ITask task);
    void RemoveTaskWidget(ITask task);
    void UpdateTaskWidget(ITask task);
}
