using UnityEngine;

public class TaskManager : MonoBehaviour, ITaskManager
{
    private IResourcesManager _resourcesManager;
    private Canvas _canvas;

    private ITasksWidget _tasksWidget;

    private void Awake()
    {
        _resourcesManager = ServiceLocator.GetResourcesManager();
        _canvas = ServiceLocator.GetCanvas();

        _tasksWidget = _resourcesManager.GetInstance<UIViews, TasksWidget>(UIViews.TasksWidget);
        _tasksWidget.SetCanvas(_canvas);
    }

    public void AddTask(ITask task)
    {
        _tasksWidget.AddTask(task);

        task.StatusChanged += UpdateTask;
    }

    public void RemoveTask(ITask task)
    {
        _tasksWidget.RemoveTask(task);
    }

    private void UpdateTask(ITask task)
    {
        _tasksWidget.UpdateTask(task);
    }

}
