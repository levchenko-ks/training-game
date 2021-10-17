using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISplashScreenView
{
    event Action Clicked;

    void Show();
    void Hide();
}
