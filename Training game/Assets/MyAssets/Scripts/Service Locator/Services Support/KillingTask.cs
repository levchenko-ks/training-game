public class KillingTask : Task
{
    private Characters _target;
    private int _requiredAmount;
    private int _currentAmount = 0;

    
    public KillingTask(string name, Characters Target, int Amount)
    {
        _name = name;
        
        _target = Target;
        _requiredAmount = Amount;
        _description = $"Kill {Amount} {Target}.";        
    }

    public void Progress()
    {
        _currentAmount++;
        if (_currentAmount >= _requiredAmount) { _isDone = true; }        
    }
}
