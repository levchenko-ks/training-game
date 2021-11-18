using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour, IScreen
{
    private IResourcesManager _resourcesManager;
    private IInputManager _inputManager;
    private IStateService _stateService;
    private Canvas _canvasFHD;
    private IPauseScreenView View;

    private void Awake()
    {
        _resourcesManager = ServiceLocator.GetResourcesManagerStatic();
        _inputManager = ServiceLocator.GetInputManagerStatic();
        _stateService = ServiceLocator.GetStateServiceStatic();
        _canvasFHD = ServiceLocator.GetCanvasStatic();

        View = _resourcesManager.GetInstance<UIViews, PauseScreenView>(UIViews.PauseScreen);
        View.SetCanvas(_canvasFHD);
        View.MainMenuClicked += OnMainMenuClicked;
        View.ResumeClicked += OnResumeCliked;

        _inputManager.Pause += Pause;
    }

    private void Start()
    {
        _stateService.GamePaused = false;
        Hide();
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
        _stateService.GamePaused = !_stateService.GamePaused;
        if (_stateService.GamePaused)
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
        Pause();
        SceneManager.LoadScene("MainMenu");
    }


}
