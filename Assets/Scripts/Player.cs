using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform weaponHandPosition;
    IWeapon holdedWeapon;
    readonly float pushForce = 2;

    public static Player Instance { get; set; }

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
        GameObject objectThatIsLooked = PlayerCamera.Instance.GetObjectLookingAt();
        if (objectThatIsLooked && objectThatIsLooked.TryGetComponent(out IWeapon weapon) && Input.GetKeyDown(KeyCode.E))
        {
            HoldWeapon(weapon);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            ThrowHoldedWeapon();
        }

        if (Input.GetMouseButton(0))
        {
            holdedWeapon?.Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            holdedWeapon?.Reload();
        }
    }

    void HoldWeapon(IWeapon weapon)
    {
        if (holdedWeapon != null)
        {
            ThrowHoldedWeapon();
        }
        weapon.transform.parent = weaponHandPosition;
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localEulerAngles = Vector3.zero;
        holdedWeapon = weapon;
        holdedWeapon.RigidBody.isKinematic = true;
        holdedWeapon.RigidBody.freezeRotation = true;
        holdedWeapon.RigidBody.interpolation = RigidbodyInterpolation.None;
        holdedWeapon.RigidBody.collisionDetectionMode = CollisionDetectionMode.Discrete;
        holdedWeapon.MeshCollider.enabled = false;
        holdedWeapon.InitializeWeapon();
    }

    void ThrowHoldedWeapon()
    {
        if (holdedWeapon == null)
        {
            return;
        }
        holdedWeapon.transform.parent = null;
        holdedWeapon.RigidBody.isKinematic = false;
        holdedWeapon.RigidBody.freezeRotation = false;
        holdedWeapon.RigidBody.interpolation = RigidbodyInterpolation.Interpolate;
        holdedWeapon.RigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        holdedWeapon.MeshCollider.enabled = true;
        Vector3 pushDirection = transform.forward;
        holdedWeapon.RigidBody.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        holdedWeapon = null;
    }
}
