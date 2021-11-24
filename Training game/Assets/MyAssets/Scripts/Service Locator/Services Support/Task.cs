using System;

public abstract class Task : ITask
{
    public event Action Done;

    protected string _name;
    protected string _description; 
    protected bool _isDone = false;
    protected bool _isSide = false;       

    public string Name { get => _name; }
    public string Description { get => _description; }
    public bool isDone { get => _isDone; }
    public bool isSide { get => _isSide; }
}