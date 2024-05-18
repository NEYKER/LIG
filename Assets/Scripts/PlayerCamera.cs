using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] float mouseSensitivity;
    [SerializeField] Transform playerBody;
    readonly float raycastRange = 10;

    float xRotation;

    public static PlayerCamera Instance { get; set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

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

    public GameObject GetObjectLookingAt()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, raycastRange))
        {
            return hit.collider.gameObject;
        }

        return null;
    }
}