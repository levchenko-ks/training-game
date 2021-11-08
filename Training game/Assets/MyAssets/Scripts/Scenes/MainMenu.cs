using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private IStateService _stateService;


    private void Awake()
    {
        _stateService = ServiceLocator.GetStateServiceStatic();
    }

    private void Start()
    {
        if (_stateService.SessionStarted == false)
        {
            var SSgo = new GameObject(UIViews.SplashScreen.ToString(), typeof(SplashScreen));
            SSgo.GetComponent<SplashScreen>().Show();

            _stateService.SessionStarted = false;
        }
        else
        {
            var MMgo = new GameObject(UIViews.MainMenuScreen.ToString(), typeof(MainMenuScreen));
            MMgo.GetComponent<MainMenuScreen>().Show();
        }
    }
}
