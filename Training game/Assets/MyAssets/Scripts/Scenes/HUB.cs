using UnityEngine;

public class HUB : MonoBehaviour
{
    private void Start()
    {
        new GameObject(UIViews.HUBScreen.ToString(), typeof(HUBScreen));
    }
}
