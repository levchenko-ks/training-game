using System;
using UnityEngine;

public class TaskManager : MonoBehaviour, ITaskManager
{
    public event Action<ITask> TaskAdded;
    public event Action<ITask> TaskDone;
    public event Action<string> TaskDescriptionChanged;


    private void Awake()
    {

    }

    public void AddTask(ITask task)
    {
        throw new NotImplementedException();
    }
}
