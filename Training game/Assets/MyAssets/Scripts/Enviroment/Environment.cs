using UnityEngine;

public class Environment : MonoBehaviour
{
    private IResourcesManager _resourcesManager;

    private Transform _bonusHolder;

    private GameObject _floorTilePref;
    private EnvModifier _HP_CubePref;
    private EnvModifier _MS_SpherePref;
    private Heal _heal_CubePref;

    private int _length = 20; // Real size x2
    private int _width = 20; // Real size x2

    private void Awake()
    {
        _resourcesManager = ServiceLocator.GetResourcesManager();

        _floorTilePref = _resourcesManager.GetPrefab<EnvironmentComponents, GameObject>(EnvironmentComponents.FloorTile);
        _HP_CubePref = _resourcesManager.GetPrefab<EnvironmentComponents, EnvModifier>(EnvironmentComponents.HP_Cube);
        _MS_SpherePref = _resourcesManager.GetPrefab<EnvironmentComponents, EnvModifier>(EnvironmentComponents.MS_Sphere);
        _heal_CubePref = _resourcesManager.GetPrefab<EnvironmentComponents, Heal>(EnvironmentComponents.Heal_Cube);

        _bonusHolder = new GameObject(PlaceHolders.BonusesHolder.ToString()).transform;
    }

    private void Start()
    {
        CreatePlane();
        CreateBonuses();
    }

    public void CreatePlane()
    {
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _length; j++)
            {
                Instantiate(_floorTilePref, new Vector3(i, 0f, j), Quaternion.identity, transform);
                if (i != 0) { Instantiate(_floorTilePref, new Vector3(-i, 0f, j), Quaternion.identity, transform); }
                if (j != 0) { Instantiate(_floorTilePref, new Vector3(i, 0f, -j), Quaternion.identity, transform); }
                if (i != 0 && j != 0) { Instantiate(_floorTilePref, new Vector3(-i, 0f, -j), Quaternion.identity, transform); }
            }
        }

    }

    public void CreateBonuses()
    {
        for (int i=0; i < 3; i++)
        {
            CreateBonus(_HP_CubePref.gameObject);
            CreateBonus(_MS_SpherePref.gameObject);
            CreateBonus(_heal_CubePref.gameObject);
        }

    }

    private void CreateBonus(GameObject bonus)
    {
        Vector2 radiusPos = Random.insideUnitCircle * 20;
        var spawnPos = new Vector3(radiusPos.x, 1f, radiusPos.y);

        Instantiate(bonus, spawnPos, Quaternion.identity, _bonusHolder);
    }
}
