using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public SplashScreen SplashScreenPref;
    public MainMenuScreen MainMenuPref;
    public GameHUD GameHUDPref;
    public PauseScreen PauseScreenPref;
    public GameOverScreen GameOverScreenPref;
    public HUBScreen HUBScreenPref;

    private Canvas _canvasFHD;
    private InputControls _inputControls;
    private List<IScreen> _screenList;

    private ISplashScreen _splashScreen;
    private IScreen _mainMenu;
    private IGameHUD _gameHUD;
    private IPauseScreen _pauseScreen;
    private IScreen _gameOverScreen;
    private IHUBScreen _HUBScreen;

    public Canvas CanvasFHD { set => _canvasFHD = value; }
    public InputControls InputControls { set => _inputControls = value; }
    public ISplashScreen SplashScreen { get => _splashScreen; }
    public IScreen MainMenu { get => _mainMenu; }
    public IGameHUD GameHUD { get => _gameHUD; }
    public IScreen PauseScreen { get => _pauseScreen; }
    public IScreen GameOverScreen { get => _gameOverScreen; }
    public IHUBScreen HUBScreen { get => _HUBScreen; }

    private void Awake()
    {
        _screenList = new List<IScreen>();
    }

    public void CreateSplashScreen()
    {
        _splashScreen = Instantiate(SplashScreenPref);
        _screenList.Add(_splashScreen);

        SetCanvas(_splashScreen);
        _splashScreen.ViewHided += OnSplashScreenHide;
    }

    public void CreateMainMenu()
    {
        _mainMenu = Instantiate(MainMenuPref);
        _screenList.Add(_mainMenu);

        SetCanvas(_mainMenu);
    }

    public void CreateGameHUD()
    {
        _gameHUD = Instantiate(GameHUDPref);
        _screenList.Add(_gameHUD);

        SetCanvas(_gameHUD);
    }

    public void CreatePauseScreen()
    {
        _pauseScreen = Instantiate(PauseScreenPref);
        _screenList.Add(_pauseScreen);

        SetCanvas(_pauseScreen);
        _pauseScreen.InputControls = _inputControls;
    }

    public void CreateGameOverScreen()
    {
        _gameOverScreen = Instantiate(GameOverScreenPref);
        _screenList.Add(_gameOverScreen);

        SetCanvas(_gameOverScreen);
    }

    public void CreateHUBScreen()
    {
        _HUBScreen = Instantiate(HUBScreenPref);
        _screenList.Add(_HUBScreen);

        SetCanvas(_HUBScreen);
    }

    public void Show(IScreen screen)
    {
        screen.Show();
    }

    public void Hide(IScreen screen)
    {
        screen.Hide();
    }

    private void SetCanvas(IScreen screen)
    {
        screen.CanvasFHD = _canvasFHD;
    }

    private void OnSplashScreenHide()
    {
        Show(_mainMenu);
    }

}
