using System;
using UnityEngine;
using UnityEngine.UI;

public class SplashScreenView : MonoBehaviour, ISplashScreenView
{
    public event Action Cliked;

    public Button StartButton;

    private void Awake()
    {
        StartButton.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        Cliked();
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
