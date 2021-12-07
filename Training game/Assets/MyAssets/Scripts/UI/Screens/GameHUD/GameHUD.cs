using System;
using UnityEngine;

public class GameHUD : MonoBehaviour, IGameHUD
{
    public event Action Hided;

    private IResourcesManager _resourcesManager;
    private ITaskManager _taskManager;
    private ILevelScore _levelScore;

    private IPlayer _player;
    private Canvas _canvasFHD;
    private IGameHUDView View;
    private readonly int _numberOfWeapons = 1;


    private void Awake()
    {
        _resourcesManager = ServiceLocator.GetResourcesManager();
        _taskManager = ServiceLocator.GetTaskManager();
        _player = ServiceLocator.GetPlayer();
        _levelScore = ServiceLocator.GetLevelScore();
        _canvasFHD = ServiceLocator.GetCanvas();

        View = _resourcesManager.GetInstance<UIViews, GameHUDView>(UIViews.GameHUDView);
        View.SetCanvas(_canvasFHD);        

        _player.MaxHPChanged += SetMaxHP;
        _player.CurrentHPChanged += SetHP;
        _player.CharacteristicChanged += SetCharacteristic;
        _player.WeaponAdded += WeaponRegister;

        _levelScore.ScoreChanged += SetScore;

        _taskManager.TaskAdded += CreateTaskWidget;
        _taskManager.TaskRemoved += RemoveTaskWidget;
        _taskManager.TaskUpdated += UpdateTaskWidget;
    }

    public void SetHolder(Transform holder)
    {
        transform.SetParent(holder, false);
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

    public void UpdateTaskWidget(ITask task) => View.UpdateTaskWidget(task);

    public void RemoveTaskWidget(ITask task) => View.RemoveTaskWidget(task);

    public void CreateTaskWidget(ITask task) => View.CreateTaskWidget(task);

    private void WeaponRegister(IWeapon weapon)
    {
        weapon.CurrentAmmoChanged += SetAmmo;
        weapon.MaxAmmoChanged += SetMaxAmmo;
        weapon.ReloadStatusChanged += SetReloadStatus;
        weapon.ReloadTimeChanged += SetReloadTime;
        weapon.WeaponIconUpdate += SetWeaponIcon;
    }
}
