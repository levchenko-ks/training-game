using UnityEngine;

public class HiddenObject : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<IPlayer>();
        if (player == null) { return; }

        player.FindObject(EnvironmentComponents.HiddenObject);
        Destroy(gameObject);
    }
}
