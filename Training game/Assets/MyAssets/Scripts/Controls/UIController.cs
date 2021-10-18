using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public SplashScreen SplashScreenPref;
    public MainMenu MainMenuPref;
    public GameHUD GameHUDPref;
    public PauseScreen PauseScreenPref;
    public GameOverScreen GameOverScreenPref;

    private Canvas _canvasFHD;
    private List<GameObject> _screenList;

    private SplashScreen _splashScreen;
    private MainMenu _mainMenu;
    private GameHUD _gameHUD;
    private PauseScreen _pauseScreen;
    private GameOverScreen _gameOverScreen;

    public Canvas CanvasFHD { set => _canvasFHD = value; }
    public SplashScreen SplashScreen { get => _splashScreen; }
    public MainMenu MainMenu { get => _mainMenu; }
    public GameHUD GameHUD { get => _gameHUD; }
    public PauseScreen PauseScreen { get => _pauseScreen; }
    public GameOverScreen GameOver { get => _gameOverScreen; }

    private void Awake()
    {
        _screenList = new List<GameObject>();
    }

    public void CreateSplashScreen()
    {
        _splashScreen = Instantiate(SplashScreenPref);
        _screenList.Add(_splashScreen.gameObject);

        SetCanvas(_splashScreen);
        _splashScreen.GetComponent<ISplashScreen>().ViewHided += OnSplashScreenHide;
        // _splashScreen.ViewHided += OnSplashScreenHide;
    }

    public void CreateMainMenu()
    {
        _mainMenu = Instantiate(MainMenuPref);
        _screenList.Add(_mainMenu.gameObject);

        SetCanvas(_mainMenu);
    }

    public void CreateGameHUD()
    {
        _gameHUD = Instantiate(GameHUDPref);
        _screenList.Add(_gameHUD.gameObject);

        SetCanvas(_gameHUD);
    }

    public void CreatePauseScreen()
    {
        _pauseScreen = Instantiate(PauseScreenPref);
        _screenList.Add(_pauseScreen.gameObject);

        SetCanvas(_pauseScreen);
    }

    public void CreateGameOverScreen()
    {
        _gameOverScreen = Instantiate(GameOverScreenPref);
        _screenList.Add(_gameOverScreen.gameObject);

        SetCanvas(_gameOverScreen);
    }

    public void Show(IScreen screen)
    {
        screen.Show();
    }

    public void Hide(IScreen screen)
    {
        screen.Hide();
    }

    public void HideAll()
    {
        foreach (GameObject element in _screenList)
        {
            element.GetComponent<IScreen>().Hide();
        }
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
