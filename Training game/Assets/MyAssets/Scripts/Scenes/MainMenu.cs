using UnityEngine;

public class MainMenu : MonoBehaviour
{    
    private IResourcesManager _resourcesManager;
    private ISoundManager _soundManager;

    private IScreen _splashScreen;
    private IScreen _mainMenuScreen;

    private static bool SessionStarted;

    private void Awake()
    {        
        _resourcesManager = ServiceLocator.GetResourcesManager();
        _soundManager = ServiceLocator.GetSoundManager();
    }

    private void Start()
    {
        if (SessionStarted == false)
        {
            _splashScreen = _resourcesManager.GetInstance<UIModels, SplashScreen>(UIModels.SplashScreen);            
            _splashScreen.Hided += ShowMainMenu;

            _soundManager.PlayMusic(Sounds.MainTheme);
            SessionStarted = true;
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
