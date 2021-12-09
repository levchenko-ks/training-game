public class FindingTask : Task
{
    private EnvironmentComponents _target;
    private int _requiredAmount;
    private int _currentAmount = 0;

    public EnvironmentComponents Target { get => _target; }
    public int Amount { get => _requiredAmount; }    

    public FindingTask(string name, EnvironmentComponents Target, int Amount)
    {
        var player = ServiceLocator.GetPlayer();

        _name = name;
        _target = Target;
        _requiredAmount = Amount;
        DescriptionChanging();

        player.ObjectFinded += Progress;
    }
    private void DescriptionChanging()
    {
        _description = $"Find {_currentAmount}/{_requiredAmount} {_target}.";
    }

    private void Progress(EnvironmentComponents obj)
    {
        if (_isDone)
        { return; }
        
        if (obj != _target)
        { return; }

        _currentAmount++;
        DescriptionChanging();
        if (_currentAmount >= _requiredAmount)
        {
            _isDone = true;
            InvokeDone();
        }

        InvokeStatus();
    }

}
