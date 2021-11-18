using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour, IObjectPooler
{
    private IResourcesManager _resourcesManager;

    private Dictionary<string, List<GameObject>> _objectPools;

    private void Awake()
    {
        _resourcesManager = ServiceLocator.GetResourcesManagerStatic();

        _objectPools = new Dictionary<string, List<GameObject>>();
    }

    public GameObject GetObject<E, T>(E item) where T : Object
    {
        if (_objectPools.ContainsKey(item.ToString()) == false)
        {
            _objectPools.Add(item.ToString(), new List<GameObject>());
        }

        var pool = _objectPools[item.ToString()];

        foreach (GameObject go in pool)
        {
            if (go.activeSelf == false)
            {
                return go;
            }
        }

        var newgo = _resourcesManager.GetInstance<E, GameObject>(item);
        pool.Add(newgo);
        return newgo;
    }

}
