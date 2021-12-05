using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHUDView : BaseView, IGameHUDView
{
    public Slider healthBar;
    public Slider reloadBar;
    public Text AmmoCounter;
    public Text MaxAmmo;
    public Text Score;
    public Transform TaskHolder;

    public Text HP;
    public Text ST;
    public Text RS;
    public Text MS;
    public Text AC;

    public List<Image> WeaponImages;

    private IResourcesManager _resourcesManager;

    private Dictionary<ITask, ITaskWidget> _taskWidgets = new Dictionary<ITask, ITaskWidget>();

    private void Awake()
    {
        _resourcesManager = ServiceLocator.GetResourcesManager();
    }

    public void CreateTaskWidget(ITask task)
    {
        var taskWidget = _resourcesManager.GetInstance<UIViews, TaskWidget>(UIViews.TaskWidget);
        var widgetTransform = taskWidget.transform;

        _taskWidgets.Add(task, taskWidget);

        taskWidget.Show();        
        widgetTransform.SetParent(TaskHolder, false);

        UpdateTaskView(task);
    }

    public void RemoveTaskWidget(ITask task)
    {
        var taskWidget = _taskWidgets[task];
        taskWidget.Hide();
        _taskWidgets.Remove(task);
    }

    public void UpdateTaskWidget(ITask task)
    {
        UpdateTaskView(task);
    }

    public void SetAmmo(int count)
    {
        AmmoCounter.text = count.ToString();
    }

    public void SetMaxHP(float amount)
    {
        healthBar.maxValue = amount;
        healthBar.value = amount;
    }

    public void SetHP(float amount)
    {
        healthBar.value = amount;
    }

    public void SetReloadTime(float amount)
    {
        reloadBar.maxValue = amount;
        reloadBar.value = amount;
    }

    public void SetReloadStatus(float amount)
    {
        reloadBar.value = amount;
    }

    public void SetMaxAmmo(float amount)
    {
        MaxAmmo.text = amount.ToString();
    }

    public void ShowWeaponIcon(int index)
    {
        WeaponImages[index].enabled = true;
    }

    public void HideWeaponIcon(int index)
    {
        WeaponImages[index].enabled = false;
    }

    public void SetCharacteristic(CharacteristicsNames name, float count)
    {
        switch (name)
        {
            case CharacteristicsNames.Accuracy:
                AC.text = count.ToString();
                return;
            case CharacteristicsNames.Health:
                HP.text = count.ToString();
                return;
            case CharacteristicsNames.MoveSpeed:
                MS.text = count.ToString();
                return;
            case CharacteristicsNames.ReloadSpeed:
                RS.text = count.ToString();
                return;
            case CharacteristicsNames.Stamina:
                ST.text = count.ToString();
                return;
            default: throw new Exception("Characteristic does not exist");
        }
    }

    public void SetScore(float score)
    {
        Score.text = score.ToString();
    }

    private void UpdateTaskView(ITask task)
    {
        var taskView = _taskWidgets[task];

        taskView.SetName(task.Name);
        taskView.SetDescription(task.Description);
        taskView.SetCheckMark(task.IsDone);
    }

}
