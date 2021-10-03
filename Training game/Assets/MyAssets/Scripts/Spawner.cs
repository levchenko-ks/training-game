using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Enemy Zombie;
    public GameObject Player;

    public Transform Placeholder;

    public float SpawnInterval = 5f;

    private Vector3 _spawnPos;
    private float _timeToSpawn = 0f;

    void Update()
    {
        if (Time.time >= _timeToSpawn)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        Vector2 radiusPos = Random.insideUnitCircle * 20;
        _spawnPos = Player.transform.position + new Vector3(radiusPos.x, 0f, radiusPos.y);
        _timeToSpawn = Time.time + SpawnInterval;

        var enemy = Instantiate(Zombie, _spawnPos, Quaternion.identity, Placeholder);
        enemy.SetTarget(Player.transform);
    }
}
