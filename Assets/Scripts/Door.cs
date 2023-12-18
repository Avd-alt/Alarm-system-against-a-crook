using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator _animator;
    [SerializeField] private UnityEvent _hit;

    private const string IsOpen = "isOpen";
    private bool _isOpen;

    public string GetDescription()
    {
        if(_isOpen)
        {
            return "Press [E] to <color=red>close</color> the door";
        }

        return "Press [E] to <color=green>open</color> the door";
    }

    public void Interact()
    {
        _isOpen = !_isOpen;

        _animator.SetBool(IsOpen, _isOpen);
    }
}