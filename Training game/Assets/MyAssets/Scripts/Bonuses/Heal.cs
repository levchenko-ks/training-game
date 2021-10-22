using UnityEngine;

public class Heal : MonoBehaviour
{
    public float HealAmount;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player == null) { return; }

        player.TakeHeal(HealAmount);
        Destroy(gameObject);
    }
}
