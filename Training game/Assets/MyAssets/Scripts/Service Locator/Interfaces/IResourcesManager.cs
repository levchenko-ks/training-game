using UnityEngine;

public interface IResourcesManager
{
    T GetInstance<E, T>(E item) where T : Object;
    T GetPrefab<E, T>(E item) where T : Object;
    GameObject GetPooledObject<E>(E item);    
}
