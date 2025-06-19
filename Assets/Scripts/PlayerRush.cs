using UnityEngine;

public class PlayerRush : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    public float dashSpeed = 10f;
    public float dashDuration = 0.9f;

    private Vector2 dashDirection;
    private bool isDashing = false;
    private float dashTimer;

    private PlayerController playerController; 

    void Start()
    {

        playerController = GetComponent<PlayerController>();

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); // Asumsinya player pakai Rigidbody2D
    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        if (!isDashing && Input.GetKeyDown(KeyCode.Space) && (inputX != 0 || inputY != 0))
        {
            dashDirection = new Vector2(inputX, inputY).normalized;

            animator.SetBool("Dash", true);
            isDashing = true;
            dashTimer = dashDuration;

            rb.linearVelocity = dashDirection * dashSpeed;
            playerController.ReduceBreath(5);
        }

        if (isDashing)
        {
            dashTimer -= Time.deltaTime;

            if (dashTimer <= 0f)
            {
                isDashing = false;
                rb.linearVelocity = Vector2.zero;
                animator.SetBool("Dash", false);
            }
        }
    }

}
