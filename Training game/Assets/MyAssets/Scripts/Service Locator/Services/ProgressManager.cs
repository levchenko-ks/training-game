using System;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour, IProgressManager
{
    public event Action<string> Task1Added;
    public event Action<string> Task2Added;
    public event Action<string> Task3Added;

    public event Action Task1Done;
    public event Action Task2Done;
    public event Action Task3Done;

    private ILevelScore _levelScore;
    private Player _player;

    private readonly List<Task> _tasks = new List<Task> { null, null, null };

    private void Awake()
    {
        _levelScore = ServiceLocator.GetLevelScore();
        _player = ServiceLocator.GetPlayer();

        _levelScore.EnemyKilled += KillingTaskProgress;
        _player.ObjectFinded += FindingTaskProgress;
    }       

    public void AddNewKillingTask(Characters target, int amount)
    {
        var task = new KillingTask(target, amount);

        for (int i = 0; i < _tasks.Count; i++)
        {            
            if (_tasks[i] == null)
            {
                _tasks[i] = task;
                AddDescription(i, task);
                break;
            }
        }
    }

    public void AddNewFindingTask(EnvironmentComponents target, int amount)
    {
        var task = new FindingTask(target, amount);

        for (int i = 0; i < _tasks.Count; i++)
        {
            if (_tasks[i] == null)
            {
                _tasks[i] = task;
                AddDescription(i, task);
                break;
            }
        }
    }

    private void AddDescription(int i, Task task)
    {
        switch(i)
        {
            case 0:
                Task1Added?.Invoke(task.Description);
                break;
            case 1:
                Task2Added?.Invoke(task.Description);
                break;
            case 2:
                Task3Added?.Invoke(task.Description);
                break;
        }
            
    }

    private void TaskDone(int i)
    {
        switch (i)
        {
            case 0:
                Task1Done?.Invoke();
                break;
            case 1:
                Task2Done?.Invoke();
                break;
            case 2:
                Task3Done?.Invoke();
                break;
        }
    }

    private void KillingTaskProgress(Characters obj)
    {
        for (int i = 0; i < _tasks.Count; i++)
        {
            if (_tasks[i].Type == TaskTypes.KillingTask)
            {                
                _tasks[i].Progress();
                if (_tasks[i].IsDone)
                {
                    TaskDone(i);
                }

                break;
            }
        }
    }

    private void FindingTaskProgress(EnvironmentComponents obj)
    {
        for (int i = 0; i < _tasks.Count; i++)
        {
            if (_tasks[i].Type == TaskTypes.FindingTask)
            {
                _tasks[i].Progress();
                if (_tasks[i].IsDone)
                {
                    TaskDone(i);
                }

                break;
            }
        }
    }
}
