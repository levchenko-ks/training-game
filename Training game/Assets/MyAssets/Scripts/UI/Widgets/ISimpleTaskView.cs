public interface ISimpleTaskView: IScreen
{
    void SetName(string name);
    void SetDescription(string description);
    void SetCheckMark(bool check);   
}