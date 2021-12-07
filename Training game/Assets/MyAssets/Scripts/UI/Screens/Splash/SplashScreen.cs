using System;
using UnityEngine;

public class SplashScreen : MonoBehaviour, IScreen
{
    public event Action Hided;
    
    private IResourcesManager _resourcesManager;
    private Canvas _canvasFHD;
    private ISplashScreenView View;    

    private void Awake()
    {
        _resourcesManager = ServiceLocator.GetResourcesManager();
        _canvasFHD = ServiceLocator.GetCanvas();

        View = _resourcesManager.GetInstance<UIViews, SplashScreenView>(UIViews.SplashScreenView);
        View.SetCanvas(_canvasFHD);
        View.Clicked += OnStartClicked;        
    }

    private void OnDestroy()
    {
        View.Clicked -= OnStartClicked;
    }

    public void SetHolder(Transform holder)
    {
        transform.SetParent(holder, false);
    }        

    public void Hide() => View.Hide();

    public void Show() => View.Show();

    private void OnStartClicked()
    {
        Hide();
        Hided?.Invoke();
    }
}
