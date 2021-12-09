using UnityEngine;

public class Environment : MonoBehaviour, IEnvironment
{
    private IResourcesManager _resourcesManager;

    private Transform _bonusHolder;

    private GameObject _floorTilePref;
    private GameObject _bonus_MS;    
    private GameObject _heal_CubePref;
    private GameObject _hiddenObject;

    private int _length = 30; // Real size x2
    private int _width = 30; // Real size x2

    private readonly string _holderName = PlaceHolders.BonusesHolder.ToString();


    private void Awake()
    {
        _resourcesManager = ServiceLocator.GetResourcesManager();

        _floorTilePref = _resourcesManager.GetPrefab<EnvironmentComponents, GameObject>(EnvironmentComponents.FloorTile);
        _bonus_MS = _resourcesManager.GetPrefab<EnvironmentComponents, GameObject>(EnvironmentComponents.Bonus_MS);     
        _heal_CubePref = _resourcesManager.GetPrefab<EnvironmentComponents, GameObject>(EnvironmentComponents.Heal_Cube);
        _hiddenObject = _resourcesManager.GetPrefab<EnvironmentComponents, GameObject>(EnvironmentComponents.HiddenObject);

        _bonusHolder = new GameObject(_holderName).transform;
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
        for (int i = 0; i < 3; i++)
        {
            CreateRandomPos(_bonus_MS);            
            CreateRandomPos(_heal_CubePref);
        }

    }

    public void CreateHiddenObject()
    {
        CreateRandomPos(_hiddenObject);
    }

    private void CreateRandomPos(GameObject obj)
    {
        Vector2 radiusPos = Random.insideUnitCircle * 20;
        var spawnPos = new Vector3(radiusPos.x, 1f, radiusPos.y);

        Instantiate(obj, spawnPos, Quaternion.identity, _bonusHolder);
    }
}
