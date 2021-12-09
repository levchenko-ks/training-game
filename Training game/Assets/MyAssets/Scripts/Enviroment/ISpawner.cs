internal interface ISpawner
{
    void SetEnemyCounter(int counter);
    void Spawn(Characters name);
    void StartSpawning();
    void StopSpawning();
}