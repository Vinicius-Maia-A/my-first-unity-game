using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private int MOVE_SPEED = 5;
    [SerializeField] private int JUMP_FORCE = 3;

    private bool facingRight = true;
    private float moveDirection;

    private Rigidbody2D rb;
    private isGroundedChecker isGroundedChecker;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        isGroundedChecker = GetComponent<isGroundedChecker>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        // Subscribe to the jump event from the input manager
        GameManager.Instance.inputManager.OnJump += HandleJump;
    }

    // Update is called once per frame
    private void Update()
    {
        MovePlayer();    
    }

    // This method handles the player's movement based on input
    private void MovePlayer()
    {
        // Get the movement input from the input manager
        moveDirection = GameManager.Instance.inputManager.Movement;
        // moves the player left or right based on input
        rb.linearVelocity = new Vector2(moveDirection * MOVE_SPEED, rb.linearVelocity.y);

        // Check if the player needs to flip based on movement direction
        if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
    }

    // Flips the character by changing its local scale
    public void FlipCharacter()
    {
        // Toggle the facing direction
        facingRight = !facingRight;

        // Get the current local scale
        Vector3 currentScale = transform.localScale;

        // Multiply the X-scale by -1 to flip horizontally
        currentScale.x *= -1;

        // Apply the new scale to the transform
        transform.localScale = currentScale;
    }

    // This method handles the jump action
    private void HandleJump()
    {
        if (isGroundedChecker.IsGrounded() == false) return;
        rb.linearVelocity += Vector2.up * JUMP_FORCE;
    }
}