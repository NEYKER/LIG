using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] float mouseSensitivity;
    [SerializeField] Transform playerBody;

    float xRotation;

    void Update()
    {
        if (GameManager.Instance.Pause)
        {
            return;
        }
        Rotate();
    }

    void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
