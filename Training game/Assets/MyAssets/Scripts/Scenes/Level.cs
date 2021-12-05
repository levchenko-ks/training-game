using UnityEngine;

public class Level : MonoBehaviour
{
    private IResourcesManager _resourcesManager;
    private ITaskManager _taskManager;
    
    private ICameraControl _camera;

    private void Awake()
    {
        _resourcesManager = ServiceLocator.GetResourcesManager();
        _taskManager = ServiceLocator.GetTaskManager();
        _camera = ServiceLocator.GetCamera();
    }

    private void Start()
    {
        var player = ServiceLocator.GetPlayer();
        _camera.SetTarget(player);

        _resourcesManager.GetInstance<CoreComponents, Light>(CoreComponents.Standart_Directional_Light);
        _resourcesManager.GetInstance<EnvironmentComponents, Environment>(EnvironmentComponents.Environment);
        _resourcesManager.GetInstance<EnvironmentComponents, Spawner>(EnvironmentComponents.Spawner);
        _resourcesManager.GetInstance<UIModels, GameHUD>(UIModels.GameHUD);

        player.AddWeapon(Weapons.AK_74);

        var FirstTask = new KillingTask("Hunt", Characters.Zombie, 2);
        _taskManager.AddTask(FirstTask);
        FirstTask.Done += FirstTask_Done;
    }

    private void FirstTask_Done()
    {
        var SecondTask = new KillingTask("Second Hunt", Characters.Zombie, 1);
        _taskManager.AddTask(SecondTask);
    }
}