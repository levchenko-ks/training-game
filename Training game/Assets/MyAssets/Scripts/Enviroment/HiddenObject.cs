using UnityEngine;

public class HiddenObject : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player == null) { return; }

        player.FindObject(EnvironmentComponents.HiddenObject);
        Destroy(gameObject);
    }
}
