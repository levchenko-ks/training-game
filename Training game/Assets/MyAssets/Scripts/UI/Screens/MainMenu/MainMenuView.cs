using System;
using System.Collections;
using System.Collections.Generic;
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

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnContinueClicked()
    {
        throw new NotImplementedException();
    }

    public void OnExitClicked()
    {
        throw new NotImplementedException();
    }

    public void OnNewGameClicked()
    {
        throw new NotImplementedException();
    }

    public void OnSettingsClicked()
    {
        throw new NotImplementedException();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
