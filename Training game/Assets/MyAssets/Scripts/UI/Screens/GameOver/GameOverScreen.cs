using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour, IScreen
{
    public event Action Hided;

    private IResourcesManager _resourcesManager;    

    private Canvas _canvasFHD;
    private IGameOverScreenView View;

    private static string _level = Scenes.Level.ToString();
    private static string _mainMenu = Scenes.MainMenu.ToString();

    private void Awake()
    {
        _resourcesManager = ServiceLocator.GetResourcesManager();        
        _canvasFHD = ServiceLocator.GetCanvas();

        View = _resourcesManager.GetInstance<UIViews, GameOverScreenView>(UIViews.GameOverScreenView);
        View.SetCanvas(_canvasFHD);       

        View.MainMenuClicked += OnMainMenuClicked;
        View.RestartClicked += OnRestartCliked;
    }

    private void OnDestroy()
    {
        View.MainMenuClicked -= OnMainMenuClicked;
        View.RestartClicked -= OnRestartCliked;
    }

    public void SetHolder(Transform holder)
    {
        transform.SetParent(holder, false);
    }

    public void Hide()
    {
        View.Hide();
    }

    public void Show()
    {
        Time.timeScale = 0f;
        View.Show();
    }

    private void OnRestartCliked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_level);
    }

    private void OnMainMenuClicked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_mainMenu);
    }
}
