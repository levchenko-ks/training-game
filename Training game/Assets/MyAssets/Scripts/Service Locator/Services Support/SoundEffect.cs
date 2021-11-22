using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    private AudioSource _audioSource;
    private float _timer;

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
        _timer = _audioSource.clip.length;
        StartCoroutine(SelfDestroy());
    }

    private IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(_timer);
        gameObject.SetActive(false);
    }
}
