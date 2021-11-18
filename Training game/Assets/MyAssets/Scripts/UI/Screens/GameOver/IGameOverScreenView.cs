using System;
using UnityEngine;

public interface IGameOverScreenView
{
    event Action RestartClicked;
    event Action MainMenuClicked;

    void Hide();
    void Show();
    void OnRestartClicked();
    void OnMainMenuClicked();
    void SetCanvas(Canvas canvas);
}
