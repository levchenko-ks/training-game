using UnityEngine;

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

    private readonly string _holder = PlaceHolders.UIModelsHolder.ToString();

    private void Awake()
    {
        _resourcesManager = ServiceLocator.GetResourcesManager();
        _taskManager = ServiceLocator.GetTaskManager();
        _stateService = ServiceLocator.GetStateService();
        _saveService = ServiceLocator.GetSaveService();
        _camera = ServiceLocator.GetCamera();
    }

    private void Start()
    {
        var player = ServiceLocator.GetPlayer();
        _stateService.PlayerIsDead = false;

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

        _camera.SetTarget(player);
        player.AddWeapon(Weapons.AK_74);
        player.PlayerDied += InterruptLevel;
    }

    private void InterruptLevel(IPlayer player)
    {
        _stateService.PlayerIsDead = true;
        _gameOverScreen.Show();
    }

    private void SetupTasks()
    {
        //var level = _saveService.
    }
}