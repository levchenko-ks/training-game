using UnityEngine;

public class Spawner : MonoBehaviour
{      
    public Enemy Zombie;
    public float SpawnInterval = 5f;

    private Player _player;
    private Transform _placeholder;
    private Vector3 _spawnPos;
    private float _timeToSpawn = 2f;
    private Transform _cam;
    private ILevelScore _levelScore;
    private int _levelCount;
    private int _enemysToSpawn;
    private int _enemysLeft;

    public Player Player { get => _player; set => _player = value; }
    public Transform Placeholder { get => _placeholder; set => _placeholder = value; }
    public Transform Cam { get => _cam; set => _cam = value; }
    public ILevelScore LevelScore { set => _levelScore = value; }
    public int EnemyToSpawn { get => _enemysToSpawn; }

    private void Awake()
    {
        _levelCount = PlayerPrefs.GetInt(SavesKeys.Level.ToString());
        SetEnemyCounter();
        //SetEnemyCharacteristics();
    }

    void Update()
    {
        if (_enemysLeft == 0)
        {
            return;
        }

        if(Time.time >= _timeToSpawn)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        Vector2 radiusPos = Random.insideUnitCircle * 20;
        _spawnPos = _player.transform.position + new Vector3(radiusPos.x, 0f, radiusPos.y);
        _timeToSpawn = Time.time + SpawnInterval;
        _enemysLeft--;

        var enemy = Instantiate(Zombie, _spawnPos, Quaternion.identity, _placeholder);
        enemy.Target = _player.transform;
        enemy.Cam = _cam;

        var container = enemy.gameObject.GetComponent<ScoreContainer>();        
        _levelScore.AddScoreContainer(container);
    }

    private void SetEnemyCounter()
    {
        _enemysToSpawn = 1 + _levelCount * 2;
        _enemysLeft = _enemysToSpawn;
    }

    private void SetEnemyCharacteristics()
    {
        
    }
}
