public class KillingTask : Task
{
    private Characters _target;
    private int _requiredAmount;
    private int _currentAmount = 0;

    public Characters Target { get => _target; }
    public int Amount { get => _requiredAmount; }


    public KillingTask(Characters Target, int Amount)
    {
        _target = Target;
        _requiredAmount = Amount;
        _descrption = $"Kill {Amount} {Target}.";
        _type = TaskTypes.KillingTask;
    }

    public override void Progress()
    {
        _currentAmount++;
        if (_currentAmount >= _requiredAmount) { _isDone = true; }        
    }
}
