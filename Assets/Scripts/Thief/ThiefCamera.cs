using UnityEngine;

public class ThiefCamera : MonoBehaviour
{
    [SerializeField] private float _sensetivity;

    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";
    private float minYangle = -80;
    private float maxYAngle = 80;
    private float _rotationX = 0.0f;

    private void Update()
    {
        float mouseX = Input.GetAxis(MouseX);
        float mouseY = Input.GetAxis(MouseY);

        transform.parent.Rotate(eulers: Vector3.up * mouseX * _sensetivity);

        _rotationX -= mouseY * _sensetivity;
        _rotationX = Mathf.Clamp(value: _rotationX, minYangle, maxYAngle);
        transform.localRotation = Quaternion.Euler(_rotationX, 0,0);
    }
}