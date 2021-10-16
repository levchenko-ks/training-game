using UnityEngine;

public class Environment : MonoBehaviour
{    
    public int length = 20; // Real size x2
    public int width = 20; // Real size x2

    private GameObject _floorTile;

    public GameObject FloorTile { set => _floorTile = value; }
    public void CreatePlane()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < length; j++)
            {
                Instantiate(_floorTile, new Vector3(i, 0f, j), Quaternion.identity, transform);
                if (i != 0) { Instantiate(_floorTile, new Vector3(-i, 0f, j), Quaternion.identity, transform); }
                if (j != 0) { Instantiate(_floorTile, new Vector3(i, 0f, -j), Quaternion.identity, transform); }
                if (i != 0 && j != 0) { Instantiate(_floorTile, new Vector3(-i, 0f, -j), Quaternion.identity, transform); }
            }
        }

    }

}
