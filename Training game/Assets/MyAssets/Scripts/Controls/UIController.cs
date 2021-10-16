using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public Canvas CanvasFHD;
    private SplashScreen SplashScreen;

    private Canvas _canvasFHD;
    private SplashScreen _splashScreen;

    private void Awake()
    {
        _canvasFHD = Instantiate(CanvasFHD);

        var SplashObject = new GameObject("SplashScreen", typeof(RectTransform), typeof(SplashScreen));
        SplashObject.transform.SetParent(_canvasFHD.transform, false);
        _splashScreen = SplashObject.GetComponent<SplashScreen>();

        // _splashScreen = Instantiate(SplashScreen, _canvasFHD.transform);
    }
}
