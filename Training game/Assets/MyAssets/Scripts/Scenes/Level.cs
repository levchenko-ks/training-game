using UnityEngine;

public class Level : MonoBehaviour
{
    private IResourcesManager _resourcesManager;

    private IScreen _gameHUD;

    private void Awake()
    {
        _resourcesManager = ServiceLocator.GetResourcesManagerStatic();
    }

    private void Start()
    {
        Debug.Log(1);

        //var player = ServiceLocator.GetPlayerStatic();
        Debug.Log(2);

        _resourcesManager.GetInstance<EnvironmentComponents, Environment>(EnvironmentComponents.Environment);
        _resourcesManager.GetInstance<EnvironmentComponents, Spawner>(EnvironmentComponents.Spawner);
        Debug.Log(3);

        var HUDgo = new GameObject(UIViews.GameHUD.ToString(), typeof(GameHUD));
        _gameHUD = HUDgo.GetComponent<GameHUD>();
        _gameHUD.Show();
    }
}