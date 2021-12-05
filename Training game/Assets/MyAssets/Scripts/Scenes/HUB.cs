using UnityEngine;

public class HUB : MonoBehaviour
{
    IResourcesManager _resourcesManager;

    private void Awake()
    {
        _resourcesManager = ServiceLocator.GetResourcesManager();
    }

    private void Start()
    {
        _resourcesManager.GetInstance<UIModels, HUBScreen>(UIModels.HUBScreen);
    }
}
