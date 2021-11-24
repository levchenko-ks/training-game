using UnityEngine;

public class SaveService : ISaveService
{
    private const string
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

    // TODO: Rewrite all methods to avoid .ToString() expression

    public float GetFloat(SavesKeys key)
    {
        return PlayerPrefs.GetFloat(key.ToString());
    }

    public int GetInt(SavesKeys key)
    {
        return PlayerPrefs.GetInt(key.ToString());
    }

    public void Save()
    {
        PlayerPrefs.Save();
    }

    public void SetFloat(SavesKeys key, float value)
    {
        PlayerPrefs.SetFloat(key.ToString(), value);
    }

    public void SetInt(SavesKeys key, int value)
    {
        PlayerPrefs.SetInt(key.ToString(), value);
    }

}
