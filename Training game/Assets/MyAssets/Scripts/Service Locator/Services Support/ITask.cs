using System;

public interface ITask
{
    event Action Done;
    event Action<string> DescriptionChanged;

    string Name { get; }
    string Description { get; }
    bool isDone { get; }
    bool isSide { get; }   
    
}
