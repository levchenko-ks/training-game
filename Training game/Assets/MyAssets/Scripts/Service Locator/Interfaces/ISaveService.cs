public interface ISaveService
{
    void Save();
    void ClearProgress();
    float GetFloat(SavesKeys key);
    int GetInt(SavesKeys key);
    void SetFloat(SavesKeys key, float value);
    void SetInt(SavesKeys key, int value);
}
