using UnityEngine;

public class ServiceLocator : MonoBehaviour, IServiceLocator
{
    // Services
    private static IResourcesManager _resourcesManager;
    private static IStateService _stateService;
    private static ISaveService _saveService;
    private static IInputManager _inputControls;
    // private static IUnitRepository _unitRepository;


    // Instances references
    public static Player Player;
    public static Camera Camera;
    public static Canvas Canvas;
    public static LevelScore LevelScore;


    private void Awake()
    {
        _inputControls = null;

        Player = null;
        Camera = null;
        Canvas = null;
        LevelScore = null;
    }

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
        if (_inputControls == null)
        {
            var go = new GameObject("InputControls");
            _inputControls = go.AddComponent<InputManager>();
        }

        return _inputControls;
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

    public static Camera GetCameraStatic()
    {
        if (Camera == null)
        {
            var service = GetResourcesManagerStatic();
            Camera = service.GetInstance<CoreComponents, Camera>(CoreComponents.Main_Camera);
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
        if(LevelScore == null)
        {
            var service = GetResourcesManagerStatic();
            LevelScore = service.GetInstance<EnvironmentComponents, LevelScore>(EnvironmentComponents.LevelScore);
        }

        return LevelScore;
    }
    public IResourcesManager GetResourcesManager()
    {
        return GetResourcesManagerStatic();
    }

    public IStateService GetStateService()
    {
        return GetStateServiceStatic();
    }

    public ISaveService GetSaveService()
    {
        return GetSaveServiceStatic();
    }

    public IInputManager GetInputManager()
    {
        return GetInputManagerStatic();
    }

    public Player GetPlayer()
    {
        return GetPlayerStatic();
    }

    public Camera GetCamera()
    {
        return GetCameraStatic();
    }

    public Canvas GetCanvas()
    {
        return GetCanvasStatic();
    }

    public LevelScore GetLevelScore()
    {
        return GetLevelScoreStatic();
    }
}
