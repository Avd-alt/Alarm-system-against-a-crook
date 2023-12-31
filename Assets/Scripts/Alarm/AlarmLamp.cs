using System.Collections;
using UnityEngine;

public class AlarmLamp : MonoBehaviour
{
    [SerializeField] private Light _lamp;

    private float _blinkInterval = 1f;
    private bool _isBlinking;

    public void ActivateLamp()
    {
        _isBlinking = true;

        StartCoroutine(BlinkLight());
    }

    public void DeactivateLamp()
    {
        _isBlinking = false;

        StopCoroutine(BlinkLight());
    }

    private IEnumerator BlinkLight()
    {
        WaitForSeconds blinkDelay = new WaitForSeconds(_blinkInterval);

        while (_isBlinking)
        {
            yield return blinkDelay;

            _lamp.enabled = !_lamp.enabled;
        }

        _lamp.enabled = false;
    }
}