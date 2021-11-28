using System;
using UnityEngine;
using UnityEngine.UI;

public class SplashScreenView : BaseView, ISplashScreenView
{
    public event Action Clicked;

    public Button StartButton;

    private void Awake()
    {
        StartButton.onClick.AddListener(OnStartClicked);
    }

    private void OnStartClicked()
    {
        Clicked();
    }
}
