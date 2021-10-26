using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacteristicControl : MonoBehaviour, ICharacteristicControl
{
    private readonly List<Characteristic> _characteristicsList = new List<Characteristic>();

    public List<Characteristic> CharacteristicsList
    {
        get
        {
            return _characteristicsList;
        }
    }

    public void AddCharacteristic(CharacteristicsNames Name, float BaseValue)
    {
        Characteristic characteristic = new Characteristic(Name, BaseValue);
        _characteristicsList.Add(characteristic);
    }

    public float CalculateAmount(CharacteristicsNames Name)
    {
        Characteristic characteristic = _characteristicsList.Find(x => x.Name == Name);

        switch (characteristic.Name)
        {
            case CharacteristicsNames.Accuracy: return CalculateAccuracy(characteristic.Value);
            case CharacteristicsNames.Health: return CalculateHealth(characteristic.Value);
            case CharacteristicsNames.MeleeDamage: return CalculateMeleeDamge(characteristic.Value);
            case CharacteristicsNames.MoveSpeed: return CalculateMoveSpeed(characteristic.Value);
            case CharacteristicsNames.ReloadSpeed: return CalculateReloadSpeed(characteristic.Value);
            case CharacteristicsNames.Stamina: return CalculateStamina(characteristic.Value);
            default: throw new Exception("Characteristic does not exist");
        }
    }

    public Characteristic GetCharacteristic(CharacteristicsNames Name)
    {
        return _characteristicsList.Find(x => x.Name == Name);
    }

    public void RemoveCharacteristic(CharacteristicsNames Name)
    {
        Characteristic characteristic = _characteristicsList.Find(x => x.Name == Name);
        _characteristicsList.Remove(characteristic);
    }

    public void AddModifier(CharacteristicsNames Name, Modifier modifier)
    {
        Characteristic characteristic = _characteristicsList.Find(x => x.Name == Name);
        characteristic.AddModifier(modifier);
    }

    public void RemoveModifier(CharacteristicsNames Name, Modifier modifier)
    {
        Characteristic characteristic = _characteristicsList.Find(x => x.Name == Name);
        characteristic.RemoveModifier(modifier);
    }

    private float CalculateStamina(float value)
    {
        return value * 25;
    }

    private float CalculateReloadSpeed(float value)
    {
        var percent = 1 - value * 5;
        return Mathf.Clamp(percent, 0.1f, 1f);
    }

    private float CalculateMoveSpeed(float value)
    {
        return 1f + value / 2f;
    }

    private float CalculateMeleeDamge(float value)
    {
        return value * 5;
    }

    private float CalculateHealth(float value)
    {
        return 50 + value * 10;
    }

    private float CalculateAccuracy(float value)
    {
        var percent = 1 - value * 5;
        return Mathf.Clamp(percent, 0.1f, 1f);
    }

}
