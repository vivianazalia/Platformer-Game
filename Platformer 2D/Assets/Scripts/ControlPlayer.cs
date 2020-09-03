using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    Rigidbody2D playerRb;
    public Animator animator;
    private float movementDirectionX;
    private float facingValue;

    public float moveSpeed;
    public float jumpForce;
    private bool isJumping;
   
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        GetInput();

        if (isJumping && playerRb.velocity.y == 0)
        {
            Jump();
        }

        if(playerRb.velocity.y < 0)
        {
            IsFalling();
        } 
        else if(playerRb.velocity == Vector2.zero)
        {
            OnGrounded();
        } 
        else if(playerRb.velocity.y > 0)
        {
            IsJumping();
        }

        if(Mathf.Abs(playerRb.velocity.x) > 0)
        {
            IsRunning();
        } 
    }

    void FixedUpdate()
    {
        playerRb.velocity = new Vector2(movementDirectionX * moveSpeed, playerRb.velocity.y);
    }

    void LateUpdate()
    {
        FacingPlayer();
    }

    void GetInput()
    {
        movementDirectionX = Input.GetAxisRaw("Horizontal");
        isJumping = Input.GetButtonDown("Jump");

        animator.SetFloat("Horizontal", movementDirectionX);
    }

    void FacingPlayer()
    {
        if (movementDirectionX > 0 || movementDirectionX < 0)
        {
            facingValue = movementDirectionX;
        }

        animator.SetFloat("Facing", facingValue);
    }

    void IsRunning()
    {
        animator.SetBool("isRunning", true);
    }

    void Jump()
    {
        playerRb.AddForce(new Vector2(0, jumpForce));
    }

    void IsJumping()
    {
        animator.SetBool("isJumping", true);
    }

    void IsFalling()
    {
        animator.SetBool("isJumping", false);
        animator.SetBool("isFalling", true);
    }

    void OnGrounded()
    {
        animator.SetBool("isJumping", false);
        animator.SetBool("isFalling", false);
        animator.SetBool("isRunning", false);
    }
}
