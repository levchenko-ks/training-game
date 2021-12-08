using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    private IResourcesManager _resourcesManager;
    private ITaskManager _taskManager;
    private IStateService _stateService;
    private ISaveService _saveService;

    private ICameraControl _camera;
    private IGameHUD _gameHUD;
    private IScreen _pauseScreen;
    private IScreen _gameOverScreen;
    private IPlayer _player;

    private readonly string
        _holder = PlaceHolders.UIModelsHolder.ToString(),
        _HUB = Scenes.HUB.ToString();

    private void Awake()
    {
        _resourcesManager = ServiceLocator.GetResourcesManager();
        _taskManager = ServiceLocator.GetTaskManager();
        _stateService = ServiceLocator.GetStateService();
        _saveService = ServiceLocator.GetSaveService();
        _camera = ServiceLocator.GetCamera();
        _player = ServiceLocator.GetPlayer();
    }

    private void Start()
    {
        _resourcesManager.GetInstance<CoreComponents, Light>(CoreComponents.Standart_Directional_Light);
        _resourcesManager.GetInstance<EnvironmentComponents, Environment>(EnvironmentComponents.Environment);
        _resourcesManager.GetInstance<EnvironmentComponents, Spawner>(EnvironmentComponents.Spawner);

        _gameHUD = _resourcesManager.GetInstance<UIModels, GameHUD>(UIModels.GameHUD);
        _pauseScreen = _resourcesManager.GetInstance<UIModels, PauseScreen>(UIModels.PauseScreen);
        _gameOverScreen = _resourcesManager.GetInstance<UIModels, GameOverScreen>(UIModels.GameOverScreen);

        _pauseScreen.Hide();
        _gameOverScreen.Hide();

        var UIHolder = new GameObject(_holder).transform;
        _gameHUD.SetHolder(UIHolder);
        _pauseScreen.SetHolder(UIHolder);
        _gameOverScreen.SetHolder(UIHolder);

        _camera.SetTarget(_player);
        _player.AddWeapon(Weapons.AK_74);
        _player.PlayerDied += InterruptLevel;

        var task = new KillingTask("Test", Characters.Zombie, 2);
        _taskManager.AddTask(task);
        task.Done += Task_Done;
    }

    private void Task_Done()
    {
        SceneManager.LoadScene(_HUB);
    }

    private void InterruptLevel(IPlayer player)
    {        
        _gameOverScreen.Show();
    }

    private void SetupTasks()
    {
        var level = _saveService.GetLevel();
    }
}