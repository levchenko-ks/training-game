using System;

public interface ITask
{
    event Action Done;
    event Action<ITask> StatusChanged;

    string Name { get; }
    string Description { get; }
    bool IsDone { get; }        
}
