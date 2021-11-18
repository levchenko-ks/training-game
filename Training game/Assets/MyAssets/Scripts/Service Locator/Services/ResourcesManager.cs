using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : IResourcesManager
{
    private Dictionary<string, List<GameObject>> _objectPools = new Dictionary<string, List<GameObject>>();

    public T GetInstance<E, T>(E item) where T : Object
    {
        var path = typeof(E).Name + "/" + item.ToString();
        //Debug.Log("Try instansiate: " + path);

        var res = Resources.Load<T>(path);
        var instance = GameObject.Instantiate(res);
        //Debug.Log(path + " Instantiated");

        return instance;
    }

    public T GetPrefab<E, T>(E item) where T : Object
    {
        var path = typeof(E).Name + "/" + item.ToString();
        var res = Resources.Load<T>(path);

        return res;
    }

    public GameObject GetPooledObject<E, T>(E item) where T : Object
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

        var newgo = GetInstance<E, GameObject>(item);
        pool.Add(newgo);
        return newgo;
    }
}
