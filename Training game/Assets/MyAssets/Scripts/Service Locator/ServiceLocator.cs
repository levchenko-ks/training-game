using UnityEngine;

public class ServiceLocator : MonoBehaviour, IServiceLocator
{
    // Services
    private static IResourcesManager _resourcesManager;
    private static IStateService _stateService;
    private static ISaveService _saveService;
    private static IInputManager _inputManager;
    private static ISoundManager _soundManager;
    private static IObjectPooler _objectPooler;
    // private static IUnitRepository _unitRepository;


    // Instances references
    public static Player Player;
    public static CameraControl Camera;
    public static Canvas Canvas;
    public static LevelScore LevelScore;


    private void Awake()
    {
        _inputManager = null;
        _objectPooler = null;

        Player = null;
        Camera = null;
        Canvas = null;
        LevelScore = null;
    }

    // TODO Universal service calling Method
    // public static T GetService<T>(Services service)    

    public static IResourcesManager GetResourcesManagerStatic()
    {
        if (_resourcesManager == null)
        {
            _resourcesManager = new ResourcesManager();
        }

        return _resourcesManager;
    }

    public static IStateService GetStateServiceStatic()
    {
        if (_stateService == null)
        {
            _stateService = new StateService();
        }

        return _stateService;
    }

    public static ISaveService GetSaveServiceStatic()
    {
        if (_saveService == null)
        {
            _saveService = new SaveService();
        }

        return _saveService;
    }

    public static IInputManager GetInputManagerStatic()
    {
        if (_inputManager == null)
        {
            var go = new GameObject(Services.InputManager.ToString());
            _inputManager = go.AddComponent<InputManager>();
        }

        return _inputManager;
    }

    public static ISoundManager GetSoundManagerStatic()
    {
        if (_soundManager == null)
        {
            var go = new GameObject(Services.SoundManager.ToString());
            _soundManager = go.AddComponent<SoundManager>();
        }

        return _soundManager;
    }

    public static IObjectPooler GetObjectPoolerStatic()
    {
        if (_objectPooler == null)
        {
            var go = new GameObject(Services.ObjectPooler.ToString());
            _objectPooler = go.AddComponent<ObjectPooler>();
        }

        return _objectPooler;
    }

    public static Player GetPlayerStatic()
    {
        if (Player == null)
        {
            var service = GetResourcesManagerStatic();
            Player = service.GetInstance<Characters, Player>(Characters.Player);
        }

        return Player;
    }

    public static CameraControl GetCameraStatic()
    {
        if (Camera == null)
        {
            var service = GetResourcesManagerStatic();
            Camera = service.GetInstance<CoreComponents, CameraControl>(CoreComponents.Main_Camera);
        }

        return Camera;
    }

    public static Canvas GetCanvasStatic()
    {
        if (Canvas == null)
        {
            var service = GetResourcesManagerStatic();
            Canvas = service.GetInstance<UIViews, Canvas>(UIViews.CanvasFHD);
        }

        return Canvas;
    }

    public static LevelScore GetLevelScoreStatic()
    {
        if (LevelScore == null)
        {
            var service = GetResourcesManagerStatic();
            LevelScore = service.GetInstance<EnvironmentComponents, LevelScore>(EnvironmentComponents.LevelScore);
        }

        return LevelScore;
    }

    public IResourcesManager GetResourcesManager() => GetResourcesManagerStatic();

    public IStateService GetStateService() => GetStateServiceStatic();

    public ISaveService GetSaveService() => GetSaveServiceStatic();

    public IInputManager GetInputManager() => GetInputManagerStatic();

    public ISoundManager GetSoundManager() => GetSoundManagerStatic();

    public IObjectPooler GetObjectPooler() => GetObjectPoolerStatic();

    public Player GetPlayer() => GetPlayerStatic();

    public CameraControl GetCamera() => GetCameraStatic();

    public Canvas GetCanvas() => GetCanvasStatic();

    public LevelScore GetLevelScore() => GetLevelScoreStatic();

}
