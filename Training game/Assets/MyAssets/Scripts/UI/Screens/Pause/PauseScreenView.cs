using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreenView : BaseView, IPauseScreenView
{
    public event Action ResumeClicked;
    public event Action MainMenuClicked;

    public Button ResumeButton;
    public Button MainMenuButton;

    private void Awake()
    {
        ResumeButton.onClick.AddListener(OnResumeClicked);
        MainMenuButton.onClick.AddListener(OnMainMenuClicked);
    }

    public void OnMainMenuClicked()
    {
        MainMenuClicked();
    }

    public void OnResumeClicked()
    {
        ResumeClicked();
    }

}
