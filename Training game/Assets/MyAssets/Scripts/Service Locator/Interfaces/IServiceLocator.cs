using UnityEngine;

public interface IServiceLocator
{
    IResourcesManager GetResourcesManager();
    IStateService GetStateService();
    ISaveService GetSaveService();
    IInputManager GetInputManager();
    Player GetPlayer();
    Camera GetCamera();
    Canvas GetCanvas();
    LevelScore GetLevelScore();
}
