using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private IStateService _stateService;
    private IResourcesManager _resourcesManager;
    private ISoundManager _soundManager;

    private IScreen _splashScreen;

    private void Awake()
    {
        _stateService = ServiceLocator.GetStateService();
        _soundManager = ServiceLocator.GetSoundManager();
    }

    private void Start()
    {
        if (_stateService.SessionStarted == false)
        {
            _splashScreen = _resourcesManager.GetInstance<UIModels, SplashScreen>(UIModels.SplashScreen);
            _splashScreen.Hided += ShowMainMenu;

            _soundManager.PlayMusic(Sounds.MainTheme);
            _stateService.SessionStarted = true;
        }
        else
        {
            _resourcesManager.GetInstance<UIModels, MainMenuScreen>(UIModels.MainMenuScreen);
        }
    }

    private void ShowMainMenu()
    {
        _resourcesManager.GetInstance<UIModels, MainMenuScreen>(UIModels.MainMenuScreen);
        _splashScreen.Hided -= ShowMainMenu;
    }
}
