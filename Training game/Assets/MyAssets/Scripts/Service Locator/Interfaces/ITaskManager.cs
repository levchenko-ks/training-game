using System;

public interface ITaskManager
{
    event Action<ITask> TaskAdded;
    event Action<ITask> TaskRemoved;
    event Action<ITask> TaskUpdated;

    void AddTask(ITask task);
    void RemoveTask(ITask task);
}
