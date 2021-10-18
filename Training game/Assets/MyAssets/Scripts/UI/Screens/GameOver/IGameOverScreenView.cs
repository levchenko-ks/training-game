using System;

public interface IGameOverScreenView
{
    event Action RestartClicked;
    event Action MainMenuClicked;

    void Hide();
    void Show();
    void OnRestartClicked();
    void OnMainMenuClicked();
}
