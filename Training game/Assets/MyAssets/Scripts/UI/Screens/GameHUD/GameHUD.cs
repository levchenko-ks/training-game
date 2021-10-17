using UnityEngine;

public class GameHUD : MonoBehaviour, IGameHUD, IScreen
{
    public GameHUDView _viewPrefab;

    private Canvas _canvasFHD;
    private IGameHUDView View;

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

    public void SetAmmo(int count) => View.SetAmmo(count);

    public void SetHP(float amount) => View.SetHP(amount);

    public void SetMaxAmmo(float amount) => View.SetMaxAmmo(amount);

    public void SetMaxHP(float amount) => View.SetMaxHP(amount);

    public void SetReloadStatus(float amount) => View.SetReloadStatus(amount);

    public void SetReloadTime(float amount) => View.SetReloadTime(amount);

    public void SetWeaponIcon(int count) => View.SetWeaponIcon(count);


}
