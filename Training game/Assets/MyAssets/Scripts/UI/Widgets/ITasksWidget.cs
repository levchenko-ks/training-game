public interface ITasksWidget: IScreen
{
    void AddTask(ITask task);    
    void UpdateTask(ITask task);
    void RemoveTask(ITask task);
}
