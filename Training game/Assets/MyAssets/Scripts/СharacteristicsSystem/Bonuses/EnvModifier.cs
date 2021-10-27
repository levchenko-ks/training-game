using UnityEngine;

public class EnvModifier : MonoBehaviour
{
    public CharacteristicsNames Name;
    public ModifiersTypes Type;
    public float Amount;

    private Modifier Modifier;

    private void Awake()
    {
        Modifier = new Modifier(Type, Amount);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if(player == null) { return; }

        player.CollectBonus(Name, Modifier);
        Destroy(gameObject);
    }

}
