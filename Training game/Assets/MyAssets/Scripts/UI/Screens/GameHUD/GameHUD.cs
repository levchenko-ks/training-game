using UnityEngine;

public class GameHUD : MonoBehaviour, IGameHUD
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

    public void SetWeaponIcon(int index) => View.ShowWeaponIcon(index);

    public void ShowWeaponIcon(int index) => View.ShowWeaponIcon(index);

    public void HideWeaponIcon(int index) => View.HideWeaponIcon(index);

    public void SetCharacteristic(CharacteristicsNames name, float count) => View.SetCharacteristic(name, count);

    public void SetScore(float count) => View.SetScore(count);
}
