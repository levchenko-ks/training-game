public interface ITaskWidget
{
    void Show();
    void Hide();
    void SetName(string name);
    void SetDescription(string description);
    void SetCheckMark(bool check);   
}