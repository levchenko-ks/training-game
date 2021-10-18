using System;

public interface ISplashScreenView
{
    event Action Clicked;

    void Show();
    void Hide();
}
