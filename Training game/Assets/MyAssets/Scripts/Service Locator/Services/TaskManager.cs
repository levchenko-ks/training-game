using System;
using UnityEngine;

public class TaskManager : MonoBehaviour, ITaskManager
{
    public event Action<ITask> TaskAdded;
    public event Action<ITask> TaskDone;
    public event Action<ITask> TaskDescriptionChanged;

    private IResourcesManager _resourcesManager;

    private TasksWidget _tasksWidget;

    private void Awake()
    {
        _resourcesManager = ServiceLocator.GetResourcesManager();
        _tasksWidget = _resourcesManager.GetInstance<UIViews, TasksWidget>(UIViews.TasksWidget);

        _tasksWidget.
    }

    public void AddTask(ITask task)
    {
        
    }
}
