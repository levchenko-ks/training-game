using UnityEngine;

public class Spawner : MonoBehaviour
{
    private IResourcesManager _resourcesManager;
    private ISaveService _saveService;
    private ILevelScore _levelScore;

    private Player _player;
    private Transform _cam;

    private float _spawnInterval = 5f;
    private float _timeToSpawn = 2f;
    private Transform _placeholder;

    private int _levelCount;
    private int _enemysToSpawn;
    private int _enemysLeft;


    private void Awake()
    {
        _resourcesManager = ServiceLocator.GetResourcesManager();
        _saveService = ServiceLocator.GetSaveService();

        _levelScore = ServiceLocator.GetLevelScore();
        _player = ServiceLocator.GetPlayer();
        _cam = ServiceLocator.GetCamera().GetComponent<Transform>();

        _levelCount = _saveService.GetInt(SavesKeys.Level);
        SetEnemyCounter();

        // TODO: Implement dependency between levelCount and EnemyCharacteristics
        // SetEnemyCharacteristics();
    }

    private void Start()
    {
        _placeholder = new GameObject(PlaceHolders.EnemiesHolder.ToString()).transform;
    }

    void Update()
    {
        if (_enemysLeft == 0)
        {
            return;
        }

        if (Time.time >= _timeToSpawn)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        Vector2 radiusPos = Random.insideUnitCircle * 20;
        var _spawnPos = _player.transform.position + new Vector3(radiusPos.x, 0f, radiusPos.y);
        _timeToSpawn = Time.time + _spawnInterval;
        _enemysLeft--;

        //Debug.Log("Try spawn " + _enemysLeft);

        var go = _resourcesManager.GetPooledObject<Characters, Enemy>(Characters.Zombie);
        var enemy = go.GetComponent<Enemy>();
        var container = go.GetComponent<ScoreContainer>();

        go.transform.position = _spawnPos;
        go.transform.SetParent(_placeholder);
        go.SetActive(true);

        enemy.Target = _player.transform;
        enemy.Cam = _cam;

        _levelScore.AddScoreContainer(container);

        //Debug.Log("Good spawn " + _enemysLeft);
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
