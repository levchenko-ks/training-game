using UnityEngine;

public class MainMenuControls : MonoBehaviour
{
    public Canvas CanvasFHD;
    public UIController UIController;

    private Canvas _canvasFHD;
    private UIController _UIController;

    private static bool IsFirstStart = true;

    private void Start()
    {
        _canvasFHD = Instantiate(CanvasFHD);
        _UIController = Instantiate(UIController);
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
