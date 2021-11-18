using UnityEngine;

public class SaveService : ISaveService
{
    public void ClearProgress()
    {
        PlayerPrefs.SetInt(SavesKeys.Level.ToString(), 1);
        PlayerPrefs.SetFloat(SavesKeys.Score.ToString(), 0f);

        PlayerPrefs.DeleteKey(SavesKeys.Health.ToString());
        PlayerPrefs.DeleteKey(SavesKeys.Stamina.ToString());
        PlayerPrefs.DeleteKey(SavesKeys.ReloadSpeed.ToString());
        PlayerPrefs.DeleteKey(SavesKeys.MoveSpeed.ToString());
        PlayerPrefs.DeleteKey(SavesKeys.Accuracy.ToString());

        PlayerPrefs.DeleteKey(SavesKeys.WeaponLevel_1.ToString());
        PlayerPrefs.DeleteKey(SavesKeys.WeaponLevel_2.ToString());
        PlayerPrefs.DeleteKey(SavesKeys.WeaponLevel_3.ToString());
        PlayerPrefs.DeleteKey(SavesKeys.WeaponLevel_4.ToString());
        PlayerPrefs.DeleteKey(SavesKeys.WeaponLevel_5.ToString());
        PlayerPrefs.DeleteKey(SavesKeys.WeaponLevel_6.ToString());

        PlayerPrefs.Save();
    }

    public float GetFloat(SavesKeys key)
    {
        return PlayerPrefs.GetFloat(key.ToString());
    }

    public int GetInt(SavesKeys key)
    {
        return PlayerPrefs.GetInt(key.ToString());
    }

    public void SaveFile()
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
