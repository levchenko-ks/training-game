using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour, ISpawner
{
    private IResourcesManager _resourcesManager;
    private ISaveService _saveService;
    private IUnitRepository _unitRepository;

    private IPlayer _player;
    private IMovable _cam;

    private float _spawnInterval = 3f;
    private Transform _placeholder;

    private int _levelCount;
    private int _enemysToSpawn;


    private void Awake()
    {
        _resourcesManager = ServiceLocator.GetResourcesManager();
        _saveService = ServiceLocator.GetSaveService();
        _unitRepository = ServiceLocator.GetUnitRepository();

        _player = ServiceLocator.GetPlayer();
        _cam = ServiceLocator.GetCamera();

        // TODO: Implement dependency between levelCount and EnemyCharacteristics
        // _levelCount = _saveService.GetLevel();
        // SetEnemyCharacteristics();
    }

    private void Start()
    {
        var go = new GameObject(PlaceHolders.EnemiesHolder.ToString());
        _placeholder = go.transform;
    }

    public void Spawn(Characters name)
    {
        Vector2 radiusPos = Random.insideUnitCircle * 20;
        var _spawnPos = new Vector3(radiusPos.x, 0f, radiusPos.y);

        var go = _resourcesManager.GetPooledObject(name);
        go.transform.SetParent(_placeholder);
        go.SetActive(true);
        var enemy = go.GetComponent<IEnemy>();
        enemy.SetPosition(_spawnPos);

        enemy.Target = _player;
        enemy.BillboardCam = _cam;

        _unitRepository.AddEnemy(enemy);
    }

    public void SetEnemyCounter(int counter)
    {
        _enemysToSpawn = counter;
    }

    public void StartSpawning()
    {
        StartCoroutine(Spawning(_enemysToSpawn));
    }

    public void StopSpawning()
    {
        StopAllCoroutines();
    }

    private IEnumerator Spawning(int counter)
    {
        for (int i = 0; i < counter; i++)
        {
            yield return new WaitForSeconds(_spawnInterval);
            Spawn(Characters.Zombie);
            _enemysToSpawn--;            
        }
    }
}
