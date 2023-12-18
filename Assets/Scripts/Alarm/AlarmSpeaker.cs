using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSpeaker : MonoBehaviour
{
    [SerializeField] private float _recoveryRate;

    private AudioSource _audioSource;
    private Coroutine _activeCoroutine;
    private float _minVolume = 0f;
    private float _maxVolume = 1f;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Enable()
    {
        if (_activeCoroutine != null)
        {
            StopCoroutine(_activeCoroutine);
        }

        _audioSource.Play();

        _activeCoroutine = StartCoroutine(ChangeVolume(_maxVolume));
    }

    public void Disable()
    {
        if (_activeCoroutine != null)
        {
            StopCoroutine(_activeCoroutine);
        }

        _activeCoroutine = StartCoroutine(ChangeVolume(_minVolume));
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        while (!Mathf.Approximately(_audioSource.volume, targetVolume))
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _recoveryRate * Time.deltaTime);

            yield return null;
        }
    }
}