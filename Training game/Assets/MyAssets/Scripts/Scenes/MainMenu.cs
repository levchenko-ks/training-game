using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private IStateService _stateService;
    private ISoundManager _soundManager;


    private void Awake()
    {
        _stateService = ServiceLocator.GetStateServiceStatic();
        _soundManager = ServiceLocator.GetSoundManagerStatic();
    }

    private void Start()
    {
        if (_stateService.SessionStarted == false)
        {
            var SSgo = new GameObject(UIViews.SplashScreen.ToString(), typeof(SplashScreen));
            SSgo.GetComponent<SplashScreen>().Show();

            _soundManager.PlayMusic(Sounds.MainTheme);

            _stateService.SessionStarted = true;
        }
        else
        {
            var MMgo = new GameObject(UIViews.MainMenuScreen.ToString(), typeof(MainMenuScreen));
            MMgo.GetComponent<MainMenuScreen>().Show();
        }
    }
}
