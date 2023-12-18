using TMPro;
using UnityEngine;

public class ThiefInteraction : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private GameObject _interactionUI;
    [SerializeField] private TextMeshProUGUI _interactionText;

    private void Update()
    {
        InterectRayDoor();
    }

    private void InterectRayDoor()
    {
        float iteractionDistace = 2f;
        float dividerForCameraDirection = 2f;

        Vector3 cameraDirection = Vector3.one / dividerForCameraDirection;

        Ray ray = _playerCamera.ViewportPointToRay(cameraDirection);
        RaycastHit hit;

        bool isHitting = false;

        if(Physics.Raycast(ray, out hit, iteractionDistace))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if(interactable != null)
            {
                isHitting = true;
                _interactionText.text = interactable.GetDescription();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
            }
        }

        _interactionUI.SetActive(isHitting);
    }
}