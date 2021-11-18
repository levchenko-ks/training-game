using UnityEngine;

public class GameHUD : MonoBehaviour, IGameHUD
{
    private IResourcesManager _resourcesManager;

    private Player _player;
    private Canvas _canvasFHD;
    private IGameHUDView View;
    private readonly int _numberOfWeapons = 1;


    private void Awake()
    {
        _resourcesManager = ServiceLocator.GetResourcesManagerStatic();
        _player = ServiceLocator.GetPlayerStatic();
        _canvasFHD = ServiceLocator.GetCanvasStatic();

        View = _resourcesManager.GetInstance<UIViews, GameHUDView>(UIViews.GameHUD);
        View.SetCanvas(_canvasFHD);
        Hide();

        _player.MaxHPChanged += SetMaxHP;
        _player.CurrentHPChanged += SetHP;
        _player.CharacteristicChanged += SetCharacteristic;
        _player.WeaponAdded += WeaponRegister;
    }

    private void Start()
    {
        for (int i = 0; i < _numberOfWeapons; i++)
        { HideWeaponIcon(i); }
    }

    private void WeaponRegister(Weapon weapon)
    {        
        weapon.CurrentAmmoChanged += SetAmmo;
        weapon.MaxAmmoChanged += SetMaxAmmo;
        weapon.ReloadStatusChanged += SetReloadStatus;
        weapon.ReloadTimeChanged += SetReloadTime;
        weapon.WeaponIconUpdate += SetWeaponIcon;
    }

    public void Hide() => View.Hide();

    public void Show() => View.Show();

    public void SetAmmo(int count) => View.SetAmmo(count);

    public void SetHP(float amount) => View.SetHP(amount);

    public void SetMaxAmmo(int amount) => View.SetMaxAmmo(amount);

    public void SetMaxHP(float amount) => View.SetMaxHP(amount);

    public void SetReloadStatus(float amount) => View.SetReloadStatus(amount);

    public void SetReloadTime(float amount) => View.SetReloadTime(amount);

    public void SetWeaponIcon(int index)
    {
        for (int i = 0; i < _numberOfWeapons; i++)
        {
            if (i == index)
            {
                View.ShowWeaponIcon(index);
            }
            else
            {
                View.HideWeaponIcon(index);
            }
        }
    }

    public void ShowWeaponIcon(int index) => View.ShowWeaponIcon(index);

    public void HideWeaponIcon(int index) => View.HideWeaponIcon(index);

    public void SetCharacteristic(CharacteristicsNames name, float count) => View.SetCharacteristic(name, count);

    public void SetScore(float count) => View.SetScore(count);
}
