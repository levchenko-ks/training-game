using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUB : MonoBehaviour
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

        _UIController.CreateHUBScreen();
        _UIController.Show(_UIController.HUBScreen);
    }
}
