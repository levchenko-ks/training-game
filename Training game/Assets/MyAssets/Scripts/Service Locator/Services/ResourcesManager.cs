using UnityEngine;

public class ResourcesManager : IResourcesManager
{
    public T GetInstance<E, T>(E item) where T : Object
    {
        var path = typeof(E).Name + "/" + item.ToString();
        Debug.Log("Try instansiate: " + path);

        var res = Resources.Load<T>(path);
        var instance = GameObject.Instantiate(res);
        Debug.Log(path + " Instantiated");

        return instance;
    }

    public T GetPrefab<E, T>(E item) where T : Object
    {
        var path = typeof(E).Name + "/" + item.ToString();
        var res = Resources.Load<T>(path);

        return res;
    }

}
