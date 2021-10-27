using UnityEngine;

public class ServiceLocator : MonoBehaviour, IServiceLocator
{
    private IResourcesService _resourcesService;
    private static IStateService _stateService;
    private ISaveService _saveService;

    public IResourcesService ResourcesService
    {
        get
        {
            if (_resourcesService == null)
            {
                // Constructor
            }

            return _resourcesService;
        }
    }

    public IStateService StateService
    {
        get
        {
            if (_stateService == null)
            {
                // Constructor
            }

            return _stateService;
        }
    }

    public ISaveService SaveService
    {
        get
        {
            if (_saveService == null)
            {
                // Constructor
            }

            return _saveService;
        }
    }

    private void Awake()
    {
        _resourcesService = null;
    }
}
