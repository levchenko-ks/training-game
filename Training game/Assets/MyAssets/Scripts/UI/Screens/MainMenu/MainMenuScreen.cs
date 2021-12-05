using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour, IScreen
{
    public event Action Hided;

    private IResourcesManager _resourcesManager;
    private ISaveService _saveService;
    private Canvas _canvasFHD;
    private IMainMenuView View;

    private void Awake()
    {
        _resourcesManager = ServiceLocator.GetResourcesManager();
        _saveService = ServiceLocator.GetSaveService();
        _canvasFHD = ServiceLocator.GetCanvas();

        View = _resourcesManager.GetInstance<UIViews, MainMenuView>(UIViews.MainMenuScreenView);
        View.SetCanvas(_canvasFHD);
        View.ContinueClicked += OnContinueClicked;
        View.NewGameClicked += OnNewGameClicked;
        View.SettingsClicked += OnSettingsClicked;
        View.ExitClicked += OnExitClicked;

        Hide();
    }

    private void Start()
    {
        Hide();
    }
    private void OnDestroy()
    {
        View.ContinueClicked -= OnContinueClicked;
        View.NewGameClicked -= OnNewGameClicked;
        View.SettingsClicked -= OnSettingsClicked;
        View.ExitClicked -= OnExitClicked;
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
        _saveService.ClearProgress();
        SceneManager.LoadScene("Level");
    }

    private void OnContinueClicked()
    {
        SceneManager.LoadScene("Level");
    }

    public void Hide() => View.Hide();

    public void Show() => View.Show();
}
