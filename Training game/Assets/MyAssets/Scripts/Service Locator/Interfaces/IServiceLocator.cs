using UnityEngine;

public interface IServiceLocator
{
    IResourcesManager GetResourcesManager();
    IStateService GetStateService();
    ISaveService GetSaveService();
    IInputManager GetInputManager();
    ISoundManager GetSoundManager();
    IObjectPooler GetObjectPooler();
    Player GetPlayer();
    CameraControl GetCamera();
    Canvas GetCanvas();
    LevelScore GetLevelScore();
}
