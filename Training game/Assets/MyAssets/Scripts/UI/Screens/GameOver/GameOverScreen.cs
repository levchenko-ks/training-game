using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            Hide();
            View.MainMenuClicked += OnMainMenuClicked;
            View.RestartClicked += OnRestartCliked;
        }
    }

    private void OnRestartCliked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level");
    }

    private void OnMainMenuClicked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Hide()
    {
        View.Hide();
    }

    public void Show()
    {
        Time.timeScale = 0f;
        View.Show();
    }
}
