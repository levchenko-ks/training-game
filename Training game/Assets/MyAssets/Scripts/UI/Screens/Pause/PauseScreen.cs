using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour, IPauseScreen
{
    public static bool IsPaused;
    public PauseScreenView _viewPrefab;

    private Canvas _canvasFHD;
    private InputControls _inputControls;
    private IPauseScreenView View;

    public Canvas CanvasFHD
    {
        set
        {
            _canvasFHD = value;
            View = Instantiate(_viewPrefab, _canvasFHD.transform);
            View.Hide();
            View.MainMenuClicked += OnMainMenuClicked;
            View.ResumeClicked += OnResumeCliked;
        }
    }

    public InputControls InputControls
    {
        set
        {
            _inputControls = value;
            _inputControls.Pause += Pause;
        }
    }

    private void Awake()
    {
        IsPaused = false;
    }

    public void Hide()
    {
        View.Hide();
    }

    public void Show()
    {
        View.Show();
    }

    private void Pause()
    {
        IsPaused = !IsPaused;
        if (IsPaused)
        {
            Time.timeScale = 0f;
            View.Show();
        }
        else
        {
            Time.timeScale = 1f;
            View.Hide();
        }
    }

    private void OnResumeCliked()
    {
        Pause();
    }

    private void OnMainMenuClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
