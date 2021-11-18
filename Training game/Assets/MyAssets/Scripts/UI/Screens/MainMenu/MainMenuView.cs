using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour, IMainMenuView
{
    public event Action ContinueClicked;
    public event Action NewGameClicked;    
    public event Action SettingsClicked;
    public event Action ExitClicked;

    public Button ContinueButton;
    public Button NewGameButton;
    public Button SettingsButton;
    public Button ExitButton;


    private void Awake()
    {
        ContinueButton.onClick.AddListener(OnContinueClicked);
        NewGameButton.onClick.AddListener(OnNewGameClicked);
        SettingsButton.onClick.AddListener(OnSettingsClicked);
        ExitButton.onClick.AddListener(OnExitClicked);
    }

    public void SetCanvas(Canvas canvas)
    {
        transform.SetParent(canvas.transform, false);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnContinueClicked()
    {
        ContinueClicked();
    }

    public void OnExitClicked()
    {
        ExitClicked();
    }

    public void OnNewGameClicked()
    {
        NewGameClicked();
    }

    public void OnSettingsClicked()
    {
        SettingsClicked();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
