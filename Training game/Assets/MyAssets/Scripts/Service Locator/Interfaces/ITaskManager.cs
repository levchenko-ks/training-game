using System;

public interface ITaskManager
{
    void AddTask(ITask task);
    void RemoveTask(ITask task);
}
