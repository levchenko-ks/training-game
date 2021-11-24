using UnityEngine;

public class SplashScreen : MonoBehaviour, IScreen
{
    private IResourcesManager _resourcesManager;
    private Canvas _canvasFHD;
    private ISplashScreenView View;

    private IScreen _mainMenuScreen;

    private void Awake()
    {
        _resourcesManager = ServiceLocator.GetResourcesManager();
        _canvasFHD = ServiceLocator.GetCanvas();

        View = _resourcesManager.GetInstance<UIViews, SplashScreenView>(UIViews.SplashScreen);
        View.SetCanvas(_canvasFHD);
        View.Clicked += OnStartClicked;

        Hide();
    }

    private void Start()
    {
        var MMgo = new GameObject(UIViews.MainMenuScreen.ToString(), typeof(MainMenuScreen));
        _mainMenuScreen = MMgo.GetComponent<MainMenuScreen>();
    }
    private void OnDestroy()
    {
        View.Clicked -= OnStartClicked;
    }

    private void OnStartClicked()
    {
        Hide();
        
        _mainMenuScreen.Show();            
    }

    public void Hide()
    {
        View.Hide();
    }

    public void Show() => View.Show();
}
