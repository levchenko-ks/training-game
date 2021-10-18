using UnityEngine;

public class MainMenuControls : MonoBehaviour
{
    public Canvas CanvasFHD;
    public UIController UIController;

    private Canvas _canvasFHD;
    private UIController _UIController;

    private void Start()
    {
        _canvasFHD = Instantiate(CanvasFHD);
        _UIController = Instantiate(UIController);
        _UIController.CanvasFHD = _canvasFHD;

        _UIController.CreateSplashScreen();
        _UIController.CreateMainMenu();

        _UIController.Show(_UIController.SplashScreen);
    }
}
