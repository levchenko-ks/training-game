using UnityEngine;

public class HealCollider : MonoBehaviour
{
    public float HealAmount;

    private void OnTriggerEnter(Collider other)
    {
        IPlayer player = other.GetComponent<IPlayer>();
        if (player == null) { return; }

        player.TakeHeal(HealAmount);
        Destroy(gameObject);
    }
}
