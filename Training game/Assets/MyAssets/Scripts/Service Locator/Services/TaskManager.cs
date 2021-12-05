using System;
using UnityEngine;

public class TaskManager : MonoBehaviour, ITaskManager
{
    public event Action<ITask> TaskAdded;
    public event Action<ITask> TaskRemoved;
    public event Action<ITask> TaskUpdated;

    public void AddTask(ITask task)
    {
        TaskAdded?.Invoke(task);

        task.StatusChanged += UpdateTask;
    }

    public void RemoveTask(ITask task)
    {
        TaskRemoved?.Invoke(task);
    }

    private void UpdateTask(ITask task)
    {
        TaskUpdated?.Invoke(task);
    }

}
