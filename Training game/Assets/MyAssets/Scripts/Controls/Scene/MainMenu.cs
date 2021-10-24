using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Canvas CanvasFHDPref;
    public UIController UIControllerPref;

    private Canvas _canvasFHD;
    private UIController _UIController;

    private static bool IsFirstStart = true;

    private void Start()
    {
        _canvasFHD = Instantiate(CanvasFHDPref);
        _UIController = Instantiate(UIControllerPref);
        _UIController.CanvasFHD = _canvasFHD;

        _UIController.CreateSplashScreen();
        _UIController.CreateMainMenu();

        if (IsFirstStart)
        {
            _UIController.Show(_UIController.SplashScreen);
            IsFirstStart = false;
        }
        else
        {
            _UIController.Show(_UIController.MainMenu);
        }
    }
}
