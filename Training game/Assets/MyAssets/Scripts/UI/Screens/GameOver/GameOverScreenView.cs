using System;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreenView : MonoBehaviour, IGameOverScreenView
{
    public event Action RestartClicked;
    public event Action MainMenuClicked;

    public Button RestartButton;
    public Button MainMenuButton;

    private void Awake()
    {
        RestartButton.onClick.AddListener(OnRestartClicked);
        MainMenuButton.onClick.AddListener(OnMainMenuClicked);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnMainMenuClicked()
    {
        MainMenuClicked();        
    }

    public void OnRestartClicked()
    {
        RestartClicked();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
