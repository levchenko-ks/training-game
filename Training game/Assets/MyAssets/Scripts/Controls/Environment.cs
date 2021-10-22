using UnityEngine;

public class Environment : MonoBehaviour
{    
    public int length = 20; // Real size x2
    public int width = 20; // Real size x2

    public GameObject FloorTile;
    public EnvModifier HP_Cube;
    public EnvModifier MS_Sphere;
    public Heal Heal_Cube;
    
    public void CreatePlane()
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

    public void CreateBonuses()
    {
        for (int i=0; i < 3; i++)
        {
            CreateBonus(HP_Cube.gameObject);
            CreateBonus(MS_Sphere.gameObject);
            CreateBonus(Heal_Cube.gameObject);
        }

    }

    private void CreateBonus(GameObject bonus)
    {
        Vector2 radiusPos = Random.insideUnitCircle * 20;
        var spawnPos = new Vector3(radiusPos.x, 1f, radiusPos.y);

        Instantiate(bonus, spawnPos, Quaternion.identity);
    }
}
