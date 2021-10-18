using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour, IScreen
{
    public GameOverScreenView _viewPrefab;

    private Canvas _canvasFHD;
    private IGameOverScreenView View;

    public Canvas CanvasFHD
    {
        set
        {
            _canvasFHD = value;
            View = Instantiate(_viewPrefab, _canvasFHD.transform);
            View.MainMenuClicked += OnMainMenuClicked;
            View.RestartClicked += OnRestartCliked;
        }
    }

    private void OnRestartCliked()
    {
        throw new NotImplementedException();
    }

    private void OnMainMenuClicked()
    {
        throw new NotImplementedException();
    }

    public void Hide()
    {
        View.Hide();
    }

    public void Show()
    {
        View.Show();
    }
}
