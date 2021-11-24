using System;

public interface ITaskManager
{
    event Action<ITask> TaskAdded;
    event Action<ITask> TaskDone;
    event Action<string> TaskDescriptionChanged;

    void AddTask(ITask task);
}
