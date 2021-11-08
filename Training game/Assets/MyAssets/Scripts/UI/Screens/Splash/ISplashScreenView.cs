using System;
using UnityEngine;

public interface ISplashScreenView
{
    event Action Clicked;

    void Show();
    void Hide();
    void SetCanvas(Canvas canvas);
}
