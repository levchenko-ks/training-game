using UnityEngine;

public class SoundManager : MonoBehaviour, ISoundManager
{
    private IResourcesManager _resourcesManager;

    private Transform _sceneSoundHolder = null;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        _resourcesManager = ServiceLocator.GetResourcesManager();        
    }
    public void PlayMusic(Sounds sound)
    {
        var go = _resourcesManager.GetInstance<Sounds, AudioSource>(sound);
        go.transform.SetParent(transform, false);
    }

    public void PlayEffect(Sounds sound)
    {
        var go = _resourcesManager.GetPooledObject(sound);

        if (_sceneSoundHolder == null)
        {
            _sceneSoundHolder = new GameObject(PlaceHolders.SoundsHolder.ToString()).transform;
        }

        go.transform.SetParent(_sceneSoundHolder, false);
        go.SetActive(true);
    }

}
