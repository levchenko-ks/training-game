using UnityEngine;

public abstract class LevelBonusChar : MonoBehaviour
{
    protected CharacteristicsNames Name;
    protected ModifiersTypes Type;
    protected float Amount;    

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<IPlayer>();
        if (player == null) { return; }

        var modifier = new Modifier(Type, Amount);

        player.CollectBonus(Name, modifier);
        Destroy(gameObject);
    }

}
