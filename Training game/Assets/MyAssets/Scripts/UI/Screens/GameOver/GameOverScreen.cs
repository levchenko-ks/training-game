using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour, IScreen
{
    private IResourcesManager _resourcesManager;    

    private Canvas _canvasFHD;
    private IGameOverScreenView View;

    private void Awake()
    {
        _resourcesManager = ServiceLocator.GetResourcesManager();        
        _canvasFHD = ServiceLocator.GetCanvas();

        View = _resourcesManager.GetInstance<UIViews, GameOverScreenView>(UIViews.GameOverScreen);
        View.SetCanvas(_canvasFHD);
        Hide();

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
