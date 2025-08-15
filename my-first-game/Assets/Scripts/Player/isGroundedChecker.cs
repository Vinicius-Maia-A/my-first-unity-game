using UnityEngine;

public class isGroundedChecker : MonoBehaviour
{
    // Serialized fields to set the position and size of the ground check area in the inspector
    [SerializeField] private Transform checkerPosition;
    [SerializeField] private Vector2 checkerSize;
    [SerializeField] private LayerMask groundLayer;

    // Checks if the player is grounded by checking for collisions with the ground layer
    public bool IsGrounded()
    {
        return Physics2D.OverlapBox(checkerPosition.position, checkerSize, 0f, groundLayer);
    }

    // Draws a gizmo in the editor to visualize the grounded check area
    private void OnDrawGizmos()
    {
        if (checkerPosition == null) return;
        if (IsGrounded())
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }
        Gizmos.DrawWireCube(checkerPosition.position, checkerSize);
    }

}