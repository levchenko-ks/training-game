using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public SplashScreen SplashScreenPref;
    public MainMenu MainMenuPref;
    public GameHUD GameHUDPref;

    private Canvas _canvasFHD;

    private List<GameObject> _screenList;
    private SplashScreen _splashScreen;
    private MainMenu _mainMenu;
    private GameHUD _gameHUD;

    public Canvas CanvasFHD { set => _canvasFHD = value; }
    public SplashScreen SplashScreen { get => _splashScreen; }
    public MainMenu MainMenu { get => _mainMenu; }
    public GameHUD GameHUD { get => _gameHUD; }

    private void Awake()
    {
        _screenList = new List<GameObject>();
    }

    public void CreateSplashScreen()
    {
        _splashScreen = Instantiate(SplashScreenPref);
        _splashScreen.CanvasFHD = _canvasFHD;
        _screenList.Add(_splashScreen.gameObject);
    }

    public void CreateMainMenu()
    {
        _mainMenu = Instantiate(MainMenuPref);
    }

    public void CreateGameHUD()
    {
        _gameHUD = Instantiate(GameHUDPref);
        _gameHUD.CanvasFHD = _canvasFHD;        
        _screenList.Add(_gameHUD.gameObject);
    }

    public void Show(IScreen screen)
    {
        screen.Show();
    }
}
