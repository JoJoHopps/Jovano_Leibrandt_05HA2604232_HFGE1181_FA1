using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private CapsuleCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField]private float MoveSpeed = 7f;
    [SerializeField]private float JumpForce = 14f;
    [SerializeField]private float JumpPadForce = 20f;
    private enum MovementState { idle, running, jumping, falling }
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(dirX * MoveSpeed, rb.linearVelocity.y);

            if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x ,JumpForce);
        }
           UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.linearVelocity.y > .1f)
        {
            state = MovementState.jumping;

        }
        else if (rb.linearVelocity.y < -.1f)
        {
            state = MovementState.falling;
        }
            anim.SetInteger("state", (int)state);
        
    }

    private bool IsGrounded()
    {
        CapsuleCollider2D capsule = (CapsuleCollider2D)coll;
        return Physics2D.CapsuleCast(capsule.bounds.center, capsule.size,capsule.direction, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("JumpPad"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpPadForce);
            collision.gameObject.GetComponent<JumpPadAnimator>().PlayBounceAnimation();
        }

    }
}
