using UnityEngine;

public class Level : MonoBehaviour
{
    private IResourcesManager _resourcesManager;
    private ITaskManager _progressManager;

    private IScreen _gameHUD;
    private CameraControl _camera;    

    private void Awake()
    {
        _resourcesManager = ServiceLocator.GetResourcesManager();
        _progressManager = ServiceLocator.GetProgressManager();
        _camera = ServiceLocator.GetCamera();        
    }

    private void Start()
    {
        var player = ServiceLocator.GetPlayer();
        _camera.SetTarget(player.transform);

        _resourcesManager.GetInstance<CoreComponents, Light>(CoreComponents.Standart_Directional_Light);
        _resourcesManager.GetInstance<EnvironmentComponents, Environment>(EnvironmentComponents.Environment);
        _resourcesManager.GetInstance<EnvironmentComponents, Spawner>(EnvironmentComponents.Spawner);        
        
        var HUDgo = new GameObject(UIViews.GameHUD.ToString(), typeof(GameHUD));
        _gameHUD = HUDgo.GetComponent<GameHUD>();
        _gameHUD.Show();

        player.AddWeapon(Weapons.AK_74);        
    }
}