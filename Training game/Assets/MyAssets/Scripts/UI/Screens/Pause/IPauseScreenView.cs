using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IPauseScreenView
{
    event Action ResumeClicked;
    event Action MainMenuClicked;

    void Hide();
    void Show();
    void OnResumeClicked();
    void OnMainMenuClicked();
}
