using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour, ISplashScreen, IScreen
{
    private Canvas _canvasFHD;
    public SplashScreenView _viewPrefab;
    private ISplashScreenView View;

    public Canvas CanvasFHD
    {
        set
        {
            _canvasFHD = value;
            View = Instantiate(_viewPrefab, _canvasFHD.transform);
            View.Clicked += OnSplashClicked;
        }
    }

    private void OnSplashClicked()
    {
        Hide();
    }

    public void Hide()
    {
        View.Hide();
    }

    public void Show()
    {
        View.Show();
    }
}
