using UnityEngine;

public class SaveService : ISaveService
{
    private static readonly string
        ScoreKey = "Score",
        LevelKey = "Level",
        HealthKey = "Health",
        MoveSpeedKey = "MoveSpeed",
        StaminaKey = "Stamina",
        ReloadSpeedKey = "ReloadSpeed",
        AccuracyKey = "Accuracy",
        WeaponLevelKey_1 = "WeaponLevel_1",
        WeaponLevelKey_2 = "WeaponLevel_2",
        WeaponLevelKey_3 = "WeaponLevel_3",
        WeaponLevelKey_4 = "WeaponLevel_4",
        WeaponLevelKey_5 = "WeaponLevel_5",
        WeaponLevelKey_6 = "WeaponLevel_6";


    public void Save()
    {
        PlayerPrefs.Save();
    }

    public void ClearProgress()
    {
        PlayerPrefs.SetInt(LevelKey, 1);
        PlayerPrefs.SetFloat(ScoreKey, 0f);

        PlayerPrefs.DeleteKey(HealthKey);
        PlayerPrefs.DeleteKey(StaminaKey);
        PlayerPrefs.DeleteKey(ReloadSpeedKey);
        PlayerPrefs.DeleteKey(MoveSpeedKey);
        PlayerPrefs.DeleteKey(AccuracyKey);

        PlayerPrefs.DeleteKey(WeaponLevelKey_1);
        PlayerPrefs.DeleteKey(WeaponLevelKey_2);
        PlayerPrefs.DeleteKey(WeaponLevelKey_3);
        PlayerPrefs.DeleteKey(WeaponLevelKey_4);
        PlayerPrefs.DeleteKey(WeaponLevelKey_5);
        PlayerPrefs.DeleteKey(WeaponLevelKey_6);

        PlayerPrefs.Save();
    }

    public void SetScore(float value) => PlayerPrefs.SetFloat(ScoreKey, value);

    public void SetLevel(int value) => PlayerPrefs.SetInt(LevelKey, value);

    public void SetHealth(float value) => PlayerPrefs.SetFloat(HealthKey, value);

    public void SetMoveSpeed(float value) => PlayerPrefs.SetFloat(MoveSpeedKey, value);

    public void SetStamina(float value) => PlayerPrefs.SetFloat(StaminaKey, value);

    public void SetReloadSpeed(float value) => PlayerPrefs.SetFloat(ReloadSpeedKey, value);

    public void SetAccuracy(float value) => PlayerPrefs.SetFloat(AccuracyKey, value);

    public void SetWeaponLevel(int weapon, int level)
    {
        string key;

        switch (weapon)
        {
            case 1:
                key = WeaponLevelKey_1;
                break;
            case 2:
                key = WeaponLevelKey_2;
                break;
            case 3:
                key = WeaponLevelKey_3;
                break;
            case 4:
                key = WeaponLevelKey_4;
                break;
            case 5:
                key = WeaponLevelKey_5;
                break;
            case 6:
                key = WeaponLevelKey_6;
                break;
            default:
                return;
        }

        PlayerPrefs.SetInt(key, level);
    }

    public float GetScore() => PlayerPrefs.GetFloat(ScoreKey);

    public int GetLevel() => PlayerPrefs.GetInt(LevelKey);

    public float GetHealth() => PlayerPrefs.GetFloat(HealthKey);

    public float GetMoveSpeed() => PlayerPrefs.GetFloat(MoveSpeedKey);

    public float GetStamina() => PlayerPrefs.GetFloat(StaminaKey);

    public float GetReloadSpeed() => PlayerPrefs.GetFloat(ReloadSpeedKey);

    public float GetAccuracy() => PlayerPrefs.GetFloat(AccuracyKey);

    public int GetWeaponLevel(int weapon)
    {
        string key;

        switch (weapon)
        {
            case 1:
                key = WeaponLevelKey_1;
                break;
            case 2:
                key = WeaponLevelKey_2;
                break;
            case 3:
                key = WeaponLevelKey_3;
                break;
            case 4:
                key = WeaponLevelKey_4;
                break;
            case 5:
                key = WeaponLevelKey_5;
                break;
            case 6:
                key = WeaponLevelKey_6;
                break;
            default:
                return 0;
        }

        return PlayerPrefs.GetInt(key, 0);
    }
}
