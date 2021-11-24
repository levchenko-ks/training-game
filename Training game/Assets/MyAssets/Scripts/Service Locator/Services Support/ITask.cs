using System;

public interface ITask
{
    event Action Done;

    string Name { get; }
    string Description { get; }
    bool isDone { get; }
    bool isSide { get; }   
    
}
