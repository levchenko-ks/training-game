using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacteristicControl
{
    public List<Characteristic> CharacteristicsList { get; }
    public Characteristic GetCharacteristic(CharacteristicsNames Name);
    public void AddCharacteristic(CharacteristicsNames Name, float BaseValue);
    public void RemoveCharacteristic(CharacteristicsNames Name);
    public float CalculateAmount(CharacteristicsNames Name);
    public void AddModifier(CharacteristicsNames Name, Modifier modifier);
    public void RemoveModifier(CharacteristicsNames Name, Modifier modifier);

}
