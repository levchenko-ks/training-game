using System;
using UnityEngine;

public class SplashScreen : MonoBehaviour, ISplashScreen, IScreen
{
    public event Action ViewHided;

    public SplashScreenView _viewPrefab;

    private Canvas _canvasFHD;
    private ISplashScreenView View;

    public Canvas CanvasFHD
    {
        set
        {
            _canvasFHD = value;
            View = Instantiate(_viewPrefab, _canvasFHD.transform);
            Hide();
            View.Clicked += OnStartClicked;
        }
    }

    private void OnStartClicked()
    {
        Hide();
    }

    public void Hide()
    {
        View.Hide();
        ViewHided?.Invoke();
    }

    public void Show() => View.Show();
}
