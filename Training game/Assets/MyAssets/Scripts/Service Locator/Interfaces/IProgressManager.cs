using System;

public interface IProgressManager
{
    event Action<string> Task1Added;
    event Action<string> Task2Added;
    event Action<string> Task3Added;

    event Action Task1Done;
    event Action Task2Done;
    event Action Task3Done;

    void AddNewKillingTask(Characters target, int amount);
    void AddNewFindingTask(EnvironmentComponents target, int amount);
}
