using System.Collections.Generic;
using UnityEngine;

public class TasksWidget : BaseView, ITasksWidget
{
    public Transform TaskHolder;

    private IResourcesManager _resourcesManager;
    private Canvas _canvas;

    private Dictionary<ITask, ISimpleTaskView> _tasksViews = new Dictionary<ITask, ISimpleTaskView>();

    private void Awake()
    {
        _resourcesManager = ServiceLocator.GetResourcesManager();
        _canvas = ServiceLocator.GetCanvas();
    }

    public void AddTask(ITask task)
    {
        var taskView = _resourcesManager.GetInstance<UIViews, SimpleTaskView>(UIViews.SimpleTaskView);

        _tasksViews.Add(task, taskView);

        taskView.Show();
        taskView.SetCanvas(_canvas);
        taskView.transform.SetParent(TaskHolder, false);

        UpdateTaskView(task);
    }

    private void UpdateTaskView(ITask task)
    {
        var taskView = _tasksViews[task];
        
        taskView.SetName(task.Name);
        taskView.SetDescription(task.Description);
        taskView.SetCheckMark(task.IsDone);
    }

    public void RemoveTask(ITask task)
    {
        var taskView = _tasksViews[task];
        taskView.Hide();
        _tasksViews.Remove(task);
    }

    public void UpdateTask(ITask task)
    {
        UpdateTaskView(task);
    }
}
