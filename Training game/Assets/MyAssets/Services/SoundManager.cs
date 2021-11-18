using UnityEngine;

public class SoundManager : MonoBehaviour, ISoundManager
{
    private IResourcesManager _resourcesManager;

    // private AudioSource AK_74_Fire;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        _resourcesManager = ServiceLocator.GetResourcesManagerStatic();
    }
    public void PlaySound(Sounds sound)
    {
        var go = _resourcesManager.GetInstance<Sounds, AudioSource>(sound);
        go.transform.SetParent(transform, false);
    }
}
