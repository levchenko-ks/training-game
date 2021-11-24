using UnityEngine;

public class ServiceLocator : MonoBehaviour
{
    // Services
    private static IResourcesManager _resourcesManager;
    private static IStateService _stateService;
    private static ISaveService _saveService;
    private static IInputManager _inputManager;
    private static ISoundManager _soundManager;
    private static ITaskManager _progressManager;
    private static IUnitRepository _unitRepository;


    // Instances references
    private static Player Player;
    private static CameraControl Camera;
    private static Canvas Canvas;
    private static LevelScore LevelScore;


    private void Awake()
    {
        _inputManager = null;
        _progressManager = null;
        _resourcesManager = null;
        _soundManager = null;

        Player = null;
        Camera = null;
        Canvas = null;
        LevelScore = null;
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

    public static ITaskManager GetProgressManager()
    {
        if(_progressManager == null)
        {
            var go = new GameObject(Services.ProgressManager.ToString());
            _progressManager = go.AddComponent<TaskManager>();
        }

        return _progressManager;
    }

    public static Player GetPlayer()
    {
        if (Player == null)
        {
            var service = GetResourcesManager();
            Player = service.GetInstance<Characters, Player>(Characters.Player);
        }

        return Player;
    }

    public static CameraControl GetCamera()
    {
        if (Camera == null)
        {
            var service = GetResourcesManager();
            Camera = service.GetInstance<CoreComponents, CameraControl>(CoreComponents.Main_Camera);
        }

        return Camera;
    }

    public static Canvas GetCanvas()
    {
        if (Canvas == null)
        {
            var service = GetResourcesManager();
            Canvas = service.GetInstance<UIViews, Canvas>(UIViews.CanvasFHD);
        }

        return Canvas;
    }

    public static LevelScore GetLevelScore()
    {
        if (LevelScore == null)
        {
            var service = GetResourcesManager();
            LevelScore = service.GetInstance<EnvironmentComponents, LevelScore>(EnvironmentComponents.LevelScore);
        }

        return LevelScore;
    }

}
