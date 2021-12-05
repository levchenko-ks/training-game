using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour, IScreen
{
    public event Action Hided;

    private IResourcesManager _resourcesManager;    

    private Canvas _canvasFHD;
    private IGameOverScreenView View;

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
    private void OnRestartCliked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level");
    }

    private void OnMainMenuClicked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
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
}
