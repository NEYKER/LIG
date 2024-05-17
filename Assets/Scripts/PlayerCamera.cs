using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float xSensitivity;
    [SerializeField] private float ySensitivity;
    [SerializeField] private float xRotation;
    [SerializeField] private float yRotation;
    [SerializeField] private Transform Player;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float xAxis = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xSensitivity;      
        float yAxis = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ySensitivity;

        xRotation -= yAxis;
        yRotation += xAxis;

        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        Player.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
