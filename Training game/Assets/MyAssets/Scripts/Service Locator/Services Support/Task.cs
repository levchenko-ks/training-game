using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Task
{
    protected bool _isDone = false;
    protected string _descrption = "";
    protected TaskTypes _type;

    public bool IsDone { get => _isDone; }
    public string Description { get => _descrption; }
    public TaskTypes Type { get => _type; }

    public abstract void Progress();

}
