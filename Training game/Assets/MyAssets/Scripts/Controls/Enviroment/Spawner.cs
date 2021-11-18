using UnityEngine;

public class Spawner : MonoBehaviour
{
    private IResourcesManager _resourcesManager;
    private ISaveService _saveService;
    private ILevelScore _levelScore;

    private Player _player;
    private Enemy _zombiePref;
    private Transform _cam;

    private float _spawnInterval = 5f;
    private float _timeToSpawn = 2f;
    private Transform _placeholder;     
    
    private int _levelCount;
    private int _enemysToSpawn;
    private int _enemysLeft;         
    

    private void Awake()
    {
        _resourcesManager = ServiceLocator.GetResourcesManagerStatic();
        _saveService = ServiceLocator.GetSaveServiceStatic();

        _levelScore = ServiceLocator.GetLevelScoreStatic();
        _player = ServiceLocator.GetPlayerStatic();        
        _cam = ServiceLocator.GetCameraStatic().GetComponent<Transform>();
        _zombiePref = _resourcesManager.GetPrefab<Characters, Enemy>(Characters.Zombie);
                
        _levelCount = _saveService.GetInt(SavesKeys.Level);        
        SetEnemyCounter();

        // TODO: Implement dependency between levelCount and EnemyCharacteristics
        // SetEnemyCharacteristics();
    }

    private void Start()
    {
        var name = gameObject.name.ToString() + "Placeholder";
        _placeholder = new GameObject(name).transform;
        
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

        var enemy = Instantiate(_zombiePref, _spawnPos, Quaternion.identity, _placeholder);
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