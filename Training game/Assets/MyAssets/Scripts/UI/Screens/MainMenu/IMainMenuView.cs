using System;
using UnityEngine;

public interface IMainMenuView: IView
{
    event Action ContinueClicked;
    event Action NewGameClicked;    
    event Action SettingsClicked;
    event Action ExitClicked;

    void OnNewGameClicked();
    void OnContinueClicked();
    void OnSettingsClicked();
    void OnExitClicked();

}
