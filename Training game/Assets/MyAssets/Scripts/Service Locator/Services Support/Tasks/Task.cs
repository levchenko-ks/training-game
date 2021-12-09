using System;

public abstract class Task : ITask
{
    public event Action Done;
    public event Action<ITask> StatusChanged;

    protected string _name;
    protected string _description;
    protected bool _isDone = false;    

    public string Name { get => _name; }
    public string Description { get => _description; }
    public bool IsDone { get => _isDone; }    

    protected void InvokeStatus()
    {
        StatusChanged?.Invoke(this);
    }

    protected void InvokeDone()
    {
        Done?.Invoke();
    }
}