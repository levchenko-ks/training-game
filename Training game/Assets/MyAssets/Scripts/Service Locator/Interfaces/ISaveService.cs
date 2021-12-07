public interface ISaveService
{
    void Save();
    void ClearProgress();

    void SetScore(float value);
    void SetLevel(int value);
    void SetHealth(float value);
    void SetMoveSpeed(float value);
    void SetStamina(float value);
    void SetReloadSpeed(float value);
    void SetAccuracy(float value);
    void SetWeaponLevel(int weapon, int level);

    float GetScore();
    int GetLevel();
    float GetHealth();
    float GetMoveSpeed();
    float GetStamina();
    float GetReloadSpeed();
    float GetAccuracy();
    int GetWeaponLevel(int weapon);
}
