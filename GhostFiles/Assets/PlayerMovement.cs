using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f; // Jump strength
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isGrounded;

    public Transform groundCheck; // Empty GameObject at the player's feet
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer; // LayerMask for ground detection

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Input for horizontal movement
        movement.x = Input.GetAxisRaw("Horizontal");

        // Jump if the player is grounded and presses Space
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        // Apply horizontal movement
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);

        // Ensure grounded check works as expected
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }



    // Visualize the ground check in the editor
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
