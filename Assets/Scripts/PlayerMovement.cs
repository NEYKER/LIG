using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    bool isInAJumpableSurface;

    Rigidbody rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.freezeRotation = true;
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.Pause)
        {
            return;
        }
        Move();
        Jump();
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 direction = transform.right * moveHorizontal + transform.forward * moveVertical;
        Vector3 velocity = direction * moveSpeed;

        velocity.y = rigidBody.velocity.y;
        rigidBody.velocity = velocity;
    }

    void Jump()
    {
        if (isInAJumpableSurface && Input.GetButtonDown("Jump")) 
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, jumpForce, rigidBody.velocity.z);
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("JumpableSurface"))
            isInAJumpableSurface = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("JumpableSurface"))
            isInAJumpableSurface = false;
    }
}