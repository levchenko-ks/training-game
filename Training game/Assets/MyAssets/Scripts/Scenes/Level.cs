using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    private IResourcesManager _resourcesManager;
    private ITaskManager _taskManager;
    private ISaveService _saveService;

    private ICameraControl _camera;
    private IGameHUD _gameHUD;
    private IScreen _pauseScreen;
    private IScreen _gameOverScreen;
    private IPlayer _player;
    private IEnvironment _environment;
    private ISpawner _spawner;

    private int _level;

    private void Awake()
    {
        _resourcesManager = ServiceLocator.GetResourcesManager();
        _taskManager = ServiceLocator.GetTaskManager();
        _saveService = ServiceLocator.GetSaveService();
        _camera = ServiceLocator.GetCamera();
        _player = ServiceLocator.GetPlayer();
    }

    private void Start()
    {
        _resourcesManager.GetInstance<CoreComponents, Light>(CoreComponents.Standart_Directional_Light);

        _gameHUD = _resourcesManager.GetInstance<UIModels, GameHUD>(UIModels.GameHUD);
        _pauseScreen = _resourcesManager.GetInstance<UIModels, PauseScreen>(UIModels.PauseScreen);
        _gameOverScreen = _resourcesManager.GetInstance<UIModels, GameOverScreen>(UIModels.GameOverScreen);
        _environment = _resourcesManager.GetInstance<EnvironmentComponents, Environment>(EnvironmentComponents.Environment);
        _spawner = _resourcesManager.GetInstance<EnvironmentComponents, Spawner>(EnvironmentComponents.Spawner);
        _level = _saveService.GetLevel();

        SetupUI();
        SetupSpawner();
        SetupEnvironment();
        SetupTasks();

        _camera.SetTarget(_player);
        _player.AddWeapon(Weapons.AK_74);
        _player.PlayerDied += InterruptLevel;
    }

    private void SetupUI()
    {
        var go = new GameObject(PlaceHolders.UIModelsHolder.ToString());
        var UIModelsHolder = go.transform;
        _gameHUD.SetHolder(UIModelsHolder);
        _pauseScreen.SetHolder(UIModelsHolder);
        _gameOverScreen.SetHolder(UIModelsHolder);

        _pauseScreen.Hide();
        _gameOverScreen.Hide();
    }

    private void SetupSpawner()
    {        
        var counter = 4 + _level * 6;
        _spawner.SetEnemyCounter(counter);
        _spawner.StartSpawning();
    }

    private void SetupEnvironment()
    {
        _environment.CreatePlane();
        _environment.CreateBonuses();
    }



    private void InterruptLevel(IPlayer player)
    {
        _gameOverScreen.Show();
    }

    private void SetupTasks()
    {        
        var counter = _level * 3;
        var firstTask = new KillingTask("Test", Characters.Zombie, counter);
        _taskManager.AddTask(firstTask);

        firstTask.Done += CreateSecondTask;
    }
    private void CreateSecondTask()
    {
        var secondTask = new FindingTask("Test_2", EnvironmentComponents.HiddenObject, 1);
        _taskManager.AddTask(secondTask);
        _environment.CreateHiddenObject();

        secondTask.Done += FinishLevel;
    }

    private void FinishLevel()
    {
        _saveService.SetLevel(_level + 1);
        SceneManager.LoadScene(Scenes.HUB.ToString());
    }
}