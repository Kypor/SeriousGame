using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform orientation;
    public float groundColliderHeight = 0.025f;

    Animator animator;

    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;
    public float airDrag = 0f;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;

    [Header("Slope Handling")]
    public float maxSlopeAngle;
    private RaycastHit slopeHit;




    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;


    private Collider playerCollider;



    private void Start()
    {
        playerCollider = GetComponentInChildren<Collider>();
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();

        rb.freezeRotation = true;

        readyToJump = true;

    }

    private void Update()
    {
        float rayHeight = playerHeight * 0.5f + 0.2f;
        Vector3 origin = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        //grounded = Physics.Raycast(origin, Vector3.down, rayHeight, whatIsGround);

        Vector3 halfExtents = playerCollider.bounds.extents;
        halfExtents.y = groundColliderHeight;
        grounded = Physics.BoxCast(playerCollider.bounds.center, halfExtents, Vector3.down, transform.rotation, 1f, whatIsGround);


        //Debug.DrawRay(origin, Vector3.down * rayHeight);

        MyInput();
        SpeedControl();

        if (grounded)
            rb.linearDamping = groundDrag;
        else
            rb.linearDamping = airDrag;
    }

    private void FixedUpdate()
    {
        MovePlayer();

    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();


            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (OnSlope())
        {
            rb.AddForce(GetSlopeMoveDirection() * moveSpeed * 10f, ForceMode.Force);
        }


        else if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

        float currentSpeed = moveDirection.magnitude;

        if (currentSpeed > 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        animator.SetBool("isGrounded", grounded);
    }

    private void SpeedControl()
    {

        if (OnSlope())
        {
            if (rb.linearVelocity.magnitude > moveSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * moveSpeed;
            }
        }
        else
        {
            Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

            if (flatVel.magnitude > moveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
            }
        }

    }

    private void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    private bool OnSlope()
    {
        float rayHeight = playerHeight * 0.5f + 0.2f;
        Vector3 origin = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        if (Physics.Raycast(origin, Vector3.down, out slopeHit, rayHeight))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }





    void OnDrawGizmos()
    {

    }





}
