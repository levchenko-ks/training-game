public interface ISaveService
{
    void SaveFile();
    void ClearProgress();
    float GetFloat(SavesKeys key);
    int GetInt(SavesKeys key);
    void SetFloat(SavesKeys key, float value);
    void SetInt(SavesKeys key, int value);
}
