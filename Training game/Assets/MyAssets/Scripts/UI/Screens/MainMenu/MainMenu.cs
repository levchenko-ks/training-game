using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour, IMainMenu, IScreen
{
    public MainMenuView _viewPrefab;

    private Canvas _canvasFHD;
    private IMainMenuView View;

    public Canvas CanvasFHD
    {
        set
        {
            _canvasFHD = value;
            View = Instantiate(_viewPrefab, _canvasFHD.transform);
        }
    }

    public void Hide() => View.Hide();

    public void Show() => View.Show();
    
}
