using UnityEngine;

public class ServiceLocator : MonoBehaviour
{
    // Services
    private static IResourcesManager _resourcesManager;
    private static IStateService _stateService;
    private static ISaveService _saveService;
    private static IInputManager _inputManager;
    private static ISoundManager _soundManager;
    private static ITaskManager _taskManager;
    private static IUnitRepository _unitRepository;


    // Instances references
    private static IPlayer _player;
    private static CameraControl _camera;
    private static Canvas _canvas;
    private static LevelScore _levelScore;
    private static IGameHUD _gameHUD;


    private void Awake()
    {        
        _inputManager = null;
        _taskManager = null;
        _resourcesManager = null;
        _soundManager = null;

        _player = null;
        _camera = null;
        _canvas = null;
        _levelScore = null;
        _gameHUD = null;
    }    

    public static IResourcesManager GetResourcesManager()
    {
        if (_resourcesManager == null)
        {
            _resourcesManager = new ResourcesManager();
        }

        return _resourcesManager;
    }

    public static IStateService GetStateService()
    {
        if (_stateService == null)
        {
            _stateService = new StateService();
        }

        return _stateService;
    }

    public static ISaveService GetSaveService()
    {
        if (_saveService == null)
        {
            _saveService = new SaveService();
        }

        return _saveService;
    }

    public static IUnitRepository GetUnitRepository()
    {
        if(_unitRepository == null)
        {
            var go = new GameObject(Services.UnitRepository.ToString());
            _unitRepository = go.AddComponent<UnitRepository>();
        }

        return _unitRepository;
    }

    public static IInputManager GetInputManager()
    {
        if (_inputManager == null)
        {
            var go = new GameObject(Services.InputManager.ToString());
            _inputManager = go.AddComponent<InputManager>();
        }

        return _inputManager;
    }

    public static ISoundManager GetSoundManager()
    {
        if (_soundManager == null)
        {
            var go = new GameObject(Services.SoundManager.ToString());
            _soundManager = go.AddComponent<SoundManager>();
        }

        return _soundManager;
    }

    public static ITaskManager GetTaskManager()
    {
        if(_taskManager == null)
        {
            var go = new GameObject(Services.ProgressManager.ToString());
            _taskManager = go.AddComponent<TaskManager>();
        }

        return _taskManager;
    }

    public static IPlayer GetPlayer()
    {
        if (_player == null)
        {
            var service = GetResourcesManager();
            _player = service.GetInstance<Characters, Player>(Characters.Player);
        }

        return _player;
    }

    public static CameraControl GetCamera()
    {
        if (_camera == null)
        {
            var service = GetResourcesManager();
            _camera = service.GetInstance<CoreComponents, CameraControl>(CoreComponents.Main_Camera);
        }

        return _camera;
    }

    public static Canvas GetCanvas()
    {
        if (_canvas == null)
        {
            var service = GetResourcesManager();
            _canvas = service.GetInstance<UIViews, Canvas>(UIViews.CanvasFHD);
        }

        return _canvas;
    }

    public static LevelScore GetLevelScore()
    {
        if (_levelScore == null)
        {
            var service = GetResourcesManager();
            _levelScore = service.GetInstance<EnvironmentComponents, LevelScore>(EnvironmentComponents.LevelScore);
        }

        return _levelScore;
    }
}
