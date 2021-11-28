using System;

public interface ITaskManager
{
    event Action<ITask> TaskAdded;
    event Action<ITask> TaskDone;
    event Action<ITask> TaskDescriptionChanged;

    void AddTask(ITask task);
}
