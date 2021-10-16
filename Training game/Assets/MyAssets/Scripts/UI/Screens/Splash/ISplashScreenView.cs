using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISplashScreenView
{
    event Action Cliked;

    void Show();
    void Hide();
}
