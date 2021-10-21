using System.Collections.Generic;

public class Characteristic
{
    private CharacteristicsNames _name;
    private float _baseValue;
    private float _lastValue;
    private bool isChanged = true;
    private List<Modifier> _modifierList;

    public CharacteristicsNames Name { get => _name; }
    public float Value
    {
        get
        {
            if (isChanged)
            { return CalculateValue(); }
            else
            { return _lastValue; }

        }
    }

    public Characteristic(CharacteristicsNames Name, float BaseValue)
    {
        _name = Name;
        _baseValue = BaseValue;
        _modifierList = new List<Modifier>();
    }


    public void AddModifier(Modifier modifier)
    {
        isChanged = true;
        _modifierList.Add(modifier);
    }


    public void RemoveModifier(Modifier modifier)
    {
        isChanged = true;
        _modifierList.Remove(modifier);
    }


    private float CalculateValue()
    {
        if (_modifierList.Count == 0)
        { return _baseValue; }

        float finalValue = _baseValue;
        float percentAdd = 0f;
        float percentMult = 1f;

        foreach (Modifier modifier in _modifierList)
        {
            if (modifier.Type == ModifiersTypes.Flat)
            {
                finalValue += modifier.Value;
            }
            else if (modifier.Type == ModifiersTypes.PercentAdd)
            {
                percentAdd += modifier.Value;
            }
            else if (modifier.Type == ModifiersTypes.PercentMult)
            {
                percentMult *= 1 + modifier.Value;
            }
        }
        finalValue *= 1 + percentAdd;
        finalValue *= percentMult;

        _lastValue = finalValue;
        isChanged = false;
        return finalValue;
    }
}
