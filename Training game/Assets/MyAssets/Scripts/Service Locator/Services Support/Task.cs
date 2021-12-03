using System;

public abstract class Task : ITask
{
    public event Action Done;
    public event Action<ITask> StatusChanged;

    protected string _name;
    protected string _description; 
    protected bool _isDone = false;
    protected bool _isSide = false;       

    public string Name { get => _name; }
    public string Description { get => _description; }
    public bool IsDone { get => _isDone; }
    public bool IsSide { get => _isSide; }

    protected void StatusChanging()
    {
        StatusChanged?.Invoke(this);
    }
}