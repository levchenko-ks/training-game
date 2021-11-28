using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IPauseScreenView : IView
{
    event Action ResumeClicked;
    event Action MainMenuClicked;

    void OnResumeClicked();
    void OnMainMenuClicked();
}
