using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSoundZone : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _minVolume = 0f;
    private float _maxVolume = 1f;
    private float _delta = 0.05f;
    private float _delay = 0.5f; 
    private Coroutine _coroutine;

    private void Awake()
    {
        _audioSource.volume = _minVolume;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _audioSource.Play();

        _coroutine = StartCoroutine(VolumeBoost(_delay, _audioSource.volume, _maxVolume, _delta));
    }

    private void OnTriggerExit(Collider other)
    {
        if ( _coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(VolumeBoost(_delay, _audioSource.volume, _minVolume, _delta));
    }

    private IEnumerator VolumeBoost(float delay, float currentVolume, float targetVolume, float delta)
    {
        var wait = new WaitForSeconds(delay);

        while (currentVolume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(currentVolume, targetVolume, delta);

            currentVolume = _audioSource.volume;

            yield return wait;
        }

        if (currentVolume == _minVolume)
            _audioSource.Stop();
        
        StopCoroutine(_coroutine);
    }
}
