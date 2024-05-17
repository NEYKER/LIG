using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float jumpCooldown;
    [SerializeField] float airMultiplier;
    [SerializeField] float dragForce;
    [SerializeField] float playerHeight;
    [SerializeField] LayerMask floorLayer;

    bool isOnFloor;
    bool canJump;
    Rigidbody playerRigidbody;
    float horizontalInput;
    float verticalInput;
    Vector3 direction;

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.freezeRotation = true;
    }

    void Start()
    {
        ResetJump();
    }

    void Update()
    {
        CheckIfOnGround();
        
        if (Input.GetKey(KeyCode.Space) && isOnFloor && canJump)
        {
            canJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
            
        SpeedControl();
    }

    void FixedUpdate()
    {
        Move();
    }

    void SetInputs()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void ResetJump()
    {
        canJump = true;
    }

    void Move()
    {
        SetInputs();

        direction = transform.forward * verticalInput + transform.right * horizontalInput;

        if(isOnFloor) playerRigidbody.AddForce(direction.normalized * 10 * movementSpeed, ForceMode.Force);
        else if (!isOnFloor) playerRigidbody.AddForce(direction.normalized * 10 * movementSpeed * airMultiplier, ForceMode.Force);
    }

    void Jump()
    {
        playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, 0, playerRigidbody.velocity.z);

        playerRigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    void SpeedControl()
    {
        Vector3 velocity = new Vector3(playerRigidbody.velocity.x, 0, playerRigidbody.velocity.z);

        if(velocity.magnitude > movementSpeed)
        {
            Vector3 limitedVelocity = velocity.normalized * movementSpeed;
            playerRigidbody.velocity = new Vector3(limitedVelocity.x, playerRigidbody.velocity.y, limitedVelocity.z);
        }
    }

    void CheckIfOnGround()
    {
        isOnFloor = Physics.Raycast(transform.position + new Vector3(0, 0.05f, 0), Vector3.down, playerHeight * 0.5f + 0.3f, floorLayer);

        if (isOnFloor) playerRigidbody.drag = dragForce;
        else playerRigidbody.drag = 0;
    }
}
