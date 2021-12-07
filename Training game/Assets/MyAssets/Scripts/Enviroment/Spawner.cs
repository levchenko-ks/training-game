using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    private IResourcesManager _resourcesManager;
    private ISaveService _saveService;
    private IUnitRepository _unitRepository;

    private IPlayer _player;
    private IMovable _cam;

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
        _unitRepository = ServiceLocator.GetUnitRepository();

        _player = ServiceLocator.GetPlayer();
        _cam = ServiceLocator.GetCamera();

        _levelCount = _saveService.GetLevel();
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
            Spawn(Characters.Zombie);
        }
    }

    private void Spawn(Characters name)
    {
        Vector2 radiusPos = Random.insideUnitCircle * 20;

        var playerPosition = _player.Position;
        var _spawnPos = playerPosition + new Vector3(radiusPos.x, 0f, radiusPos.y);

        var go = _resourcesManager.GetPooledObject<Characters, BaseEnemy>(name);
        var enemy = go.GetComponent<IEnemy>();

        go.transform.position = _spawnPos;
        go.transform.SetParent(_placeholder);
        go.SetActive(true);

        enemy.Target = _player;
        enemy.BillboardCam = _cam;

        _unitRepository.AddEnemy(enemy);

        _timeToSpawn = Time.time + _spawnInterval;
        _enemysLeft--;
    }

    private void SetEnemyCounter()
    {
        _enemysToSpawn = 6 + _levelCount * 2;
        _enemysLeft = _enemysToSpawn;
    }

    private void SetEnemyCharacteristics()
    {

    }
}
