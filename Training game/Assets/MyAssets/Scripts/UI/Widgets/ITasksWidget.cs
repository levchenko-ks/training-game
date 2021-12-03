public interface ITasksWidget: IView
{
    void AddTask(ITask task);    
    void UpdateTask(ITask task);
    void RemoveTask(ITask task);
}
