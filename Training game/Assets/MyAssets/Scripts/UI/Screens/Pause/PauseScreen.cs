using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour, IScreen
{
    public PauseScreenView _viewPrefab;

    private Canvas _canvasFHD;
    private IPauseScreenView View;

    public Canvas CanvasFHD
    {
        set
        {
            _canvasFHD = value;
            View = Instantiate(_viewPrefab, _canvasFHD.transform);
            View.MainMenuClicked += OnMainMenuClicked;
            View.ResumeClicked += OnResumeCliked;
        }
    }

    private void OnResumeCliked()
    {
        throw new System.NotImplementedException();
    }

    private void OnMainMenuClicked()
    {
        throw new System.NotImplementedException();
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
