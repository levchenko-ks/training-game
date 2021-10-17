using System;
using UnityEngine;
using UnityEngine.UI;

public class SplashScreenView : MonoBehaviour, ISplashScreenView
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

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
