  using UnityEditor;
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
        EditorApplication.ExitPlaymode();
    }

    private void OnSettingsClicked()
    {
        throw new System.NotImplementedException();
    }

    private void OnNewGameClicked()
    {
        ClearProgress();
        SceneManager.LoadScene("Level");
    }

    private void OnContinueClicked()
    {
        SceneManager.LoadScene("Level");
    }

    public void Hide() => View.Hide();

    public void Show() => View.Show();

    private void ClearProgress()
    {
        PlayerPrefs.SetInt(SavesKeys.Level.ToString(), 1);

        PlayerPrefs.DeleteKey(SavesKeys.Score.ToString());
        PlayerPrefs.DeleteKey(SavesKeys.Health.ToString());
        PlayerPrefs.DeleteKey(SavesKeys.Stamina.ToString());
        PlayerPrefs.DeleteKey(SavesKeys.ReloadSpeed.ToString());
        PlayerPrefs.DeleteKey(SavesKeys.MoveSpeed.ToString());
        PlayerPrefs.DeleteKey(SavesKeys.Accuracy.ToString());        
    }
    
}
