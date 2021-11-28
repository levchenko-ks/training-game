using System;

public interface IGameOverScreenView: IView
{
    event Action RestartClicked;
    event Action MainMenuClicked;
        
    void OnRestartClicked();
    void OnMainMenuClicked();    
}
