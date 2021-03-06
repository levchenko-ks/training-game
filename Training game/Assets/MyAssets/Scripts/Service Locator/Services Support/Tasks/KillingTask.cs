using System;

public class KillingTask : Task
{
    private IUnitRepository _unitRepository;

    private string _target;
    private int _requiredAmount;
    private int _currentAmount = 0;


    public KillingTask(string name, Characters Target, int Amount)
    {
        _unitRepository = ServiceLocator.GetUnitRepository();

        _name = name;
        _target = Target.ToString();
        _requiredAmount = Amount;
        DescriptionChanging();
        
        _unitRepository.EnemyDied += Progress;
    }

    private void DescriptionChanging()
    {
        _description = $"Kill {_currentAmount}/{_requiredAmount} {_target}.";
    }

    private void Progress(IEnemy enemy)
    {
        if (_isDone)
        { return; }

        var name = enemy.GetType().Name;
        if (name != _target)
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
