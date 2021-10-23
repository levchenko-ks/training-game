using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Enemy Zombie;

    public float SpawnInterval = 5f;

    private Player _player;
    private Transform _placeholder;
    private Vector3 _spawnPos;
    private float _timeToSpawn = 0f;
    private Transform _cam;
    private ILevelScore _levelScore;

    public Player Player { get => _player; set => _player = value; }
    public Transform Placeholder { get => _placeholder; set => _placeholder = value; }
    public Transform Cam { get => _cam; set => _cam = value; }
    public ILevelScore LevelScore { set => _levelScore = value; }

    void Update()
    {
        if (Time.time >= _timeToSpawn)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        Vector2 radiusPos = Random.insideUnitCircle * 20;
        _spawnPos = _player.transform.position + new Vector3(radiusPos.x, 0f, radiusPos.y);
        _timeToSpawn = Time.time + SpawnInterval;

        var enemy = Instantiate(Zombie, _spawnPos, Quaternion.identity, _placeholder);
        enemy.Target = _player.transform;
        enemy.Cam = _cam;

        var container = enemy.gameObject.GetComponent<ScoreContainer>();        
        _levelScore.AddScoreContainer(container);
    }
}
