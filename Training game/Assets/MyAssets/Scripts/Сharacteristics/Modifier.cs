public class Modifier
{
    private ModifiersTypes _type;
    private float _value;
    private object _source;

    public ModifiersTypes Type { get => _type; }
    public float Value { get => _value; }
    public object Source { get => _source; }

    public Modifier(ModifiersTypes Type, float Value, object Source)
    {
        _type = Type;
        _value = Value;
        _source = Source;
    }

    public Modifier(ModifiersTypes Type, float Value) : this(Type, Value, null) { }
}
