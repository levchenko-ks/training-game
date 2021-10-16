using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour, ISplashScreen
{
    private ISplashScreenView _viewPrefab;
    private ISplashScreenView View;

    public ISplashScreenView ViewPrefab { set => _viewPrefab = value; }

    public void Hide()
    {
        View.Hide();
    }

    public void Show()
    {
        View.Show();
    }
}
