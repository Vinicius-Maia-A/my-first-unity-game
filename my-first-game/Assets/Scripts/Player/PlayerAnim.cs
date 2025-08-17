using UnityEngine;

public class PlayerAnim : MonoBehaviour
{

    private Animator animator;
    private isGroundedChecker isGroundedChecker;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        isGroundedChecker = GetComponent<isGroundedChecker>();
    }

    private void Start()
    {
        GameManager.Instance.inputManager.OnRun += HandleRun;
        animator.SetBool("isWalking", false);
        animator.SetBool("isJumping", false);
        animator.SetBool("isRunning", false);
    }

    private void Update()
    {
        bool isWalking = GameManager.Instance.inputManager.Movement != 0;
        animator.SetBool("isWalking", isWalking);

        bool isJumping = isGroundedChecker.IsGrounded() == false;
        animator.SetBool("isJumping", isJumping);

        //bool isRunning = GameManager.Instance.inputManager.IsRunning;
        //animator.SetBool("isRunning", isRunning);

    }

    private void HandleRun(bool isRunning)
    {
        animator.SetBool("isRunning", isRunning);
    }
}
