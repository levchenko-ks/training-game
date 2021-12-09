using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : IResourcesManager
{
    private Dictionary<string, List<GameObject>> _objectPools = new Dictionary<string, List<GameObject>>();

    public T GetInstance<E, T>(E item) where T : Object
    {

        var path = $"{typeof(E).Name}/{item}";
        var res = Resources.Load<T>(path);
        var instance = GameObject.Instantiate(res);

        return instance;
    }

    public T GetPrefab<E, T>(E item) where T : Object
    {
        var path = $"{typeof(E).Name}/{item}";
        var res = Resources.Load<T>(path);

        return res;
    }

    public GameObject GetPooledObject<E>(E item)
    {
        //TODO: Create keys Dictionary<MyStruct, string>

        var key = $"{typeof(E).Name}.{item}";

        if (_objectPools.ContainsKey(key) == false)
        {
            _objectPools.Add(key, new List<GameObject>());
        }

        var pool = _objectPools[key];

        foreach (GameObject go in pool)
        {
            if (go.activeSelf == false)
            {
                return go;
            }
        }

        var newgo = GetInstance<E, GameObject>(item);
        pool.Add(newgo);
        return newgo;
    }
}
