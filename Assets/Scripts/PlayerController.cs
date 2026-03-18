using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundMask;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private float moveInputX;
    private float moveInputY;
    private bool onJumpPad = false;
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim =GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInputX = Input.GetAxis("Horizontal");
        moveInputY = Input.GetAxis("Vertical");
       
        if (moveInputX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInputX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);
       
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody2D>().linearVelocity = new Vector3(0, 10, 0);
        }
        
        if (moveInputX != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

     
    }

    private void FixedUpdate()
    {
        if (onJumpPad)
        {
            
           
        }
        else
        {
            rb.linearVelocity = new Vector2( moveInputX * moveSpeed, rb.linearVelocity.y);
        }
    }

    public void SetJumpPadStatus(bool currentState)
    {
        onJumpPad = currentState;
    }
   
}
