using UnityEngine;

public class EnvironmentScript : MonoBehaviour
{
    public UnityEngine.GameObject FloorTile;
    public int length = 3; // Real size x2
    public int width = 3; // Real size x2


    void Start()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < length; j++)
            {
                Instantiate(FloorTile, new Vector3(i, 0f, j), Quaternion.identity, transform);
                if (i != 0) { Instantiate(FloorTile, new Vector3(-i, 0f, j), Quaternion.identity, transform); }
                if (j != 0) { Instantiate(FloorTile, new Vector3(i, 0f, -j), Quaternion.identity, transform); }
                if (i != 0 && j != 0) { Instantiate(FloorTile, new Vector3(-i, 0f, -j), Quaternion.identity, transform); }
            }
        }

    }

}
