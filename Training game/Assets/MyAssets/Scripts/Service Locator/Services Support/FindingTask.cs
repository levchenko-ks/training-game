public class FindingTask : Task
{
    private EnvironmentComponents _target;
    private int _requiredAmount;
    private int _currentAmount = 0;

    public EnvironmentComponents Target { get => _target; }
    public int Amount { get => _requiredAmount; }


    public FindingTask(EnvironmentComponents Target, int Amount)
    {
        _target = Target;
        _requiredAmount = Amount;
        _descrption = $"Find {Amount} {Target}";
        _type = TaskTypes.FindingTask;
    }

    public override void Progress()
    {
        _currentAmount++;
        if (_currentAmount >= _requiredAmount) { _isDone = true; }
    }
}
