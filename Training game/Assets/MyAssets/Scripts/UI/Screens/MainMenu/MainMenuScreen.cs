using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour, IScreen
{
    public MainMenuView _viewPrefab;

    private Canvas _canvasFHD;
    private IMainMenuView View;

    public Canvas CanvasFHD
    {
        set
        {
            _canvasFHD = value;
            View = Instantiate(_viewPrefab, _canvasFHD.transform);
            Hide();
            View.ContinueClicked += OnContinueClicked;
            View.NewGameClicked += OnNewGameClicked;
            View.SettingsClicked += OnSettingsClicked;
            View.ExitClicked += OnExitClicked;
        }
    }

    private void OnExitClicked()
    {
        throw new System.NotImplementedException();
    }

    private void OnSettingsClicked()
    {
        throw new System.NotImplementedException();
    }

    private void OnNewGameClicked()
    {
        SceneManager.LoadScene("Level");
    }

    private void OnContinueClicked()
    {
        throw new System.NotImplementedException();
    }

    public void Hide() => View.Hide();

    public void Show() => View.Show();
    
}
