using UnityEngine;
using UnityEngine.Events;

public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _hit;
    [SerializeField] private UnityEvent _thiefLeft;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out ThiefMover thiefMover))
        {
            _hit?.Invoke();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<ThiefMover>(out ThiefMover thiefMover))
        {
            _thiefLeft?.Invoke();
        }
    }
}
