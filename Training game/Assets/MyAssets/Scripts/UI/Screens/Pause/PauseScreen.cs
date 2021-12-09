using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour, IScreen
{
    public event Action Hided;

    private IResourcesManager _resourcesManager;
    private IInputManager _inputManager;    
    private Canvas _canvasFHD;
    private IPauseScreenView View;

    private void Awake()
    {
        _resourcesManager = ServiceLocator.GetResourcesManager();
        _inputManager = ServiceLocator.GetInputManager();        
        _canvasFHD = ServiceLocator.GetCanvas();

        View = _resourcesManager.GetInstance<UIViews, PauseScreenView>(UIViews.PauseScreenView);
        View.SetCanvas(_canvasFHD);
        View.MainMenuClicked += OnMainMenuClicked;
        View.ResumeClicked += OnResumeCliked;

        _inputManager.Pause += Pause;
    }

    private void OnDestroy()
    {
        View.MainMenuClicked -= OnMainMenuClicked;
        View.ResumeClicked -= OnResumeCliked;
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
        View.Show();
    }

    private void Pause()
    {
        /*
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
        */
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
