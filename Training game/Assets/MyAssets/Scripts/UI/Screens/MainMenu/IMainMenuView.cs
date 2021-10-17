using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMainMenuView
{
    event Action ContinueClicked;
    event Action NewGameClicked;    
    event Action SettingsClicked;
    event Action ExitClicked;

    void Hide();
    void Show();
    void OnNewGameClicked();
    void OnContinueClicked();
    void OnSettingsClicked();
    void OnExitClicked();
}
