using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool jumpKeyPressed;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField]private float moveSpeed = 3f;           // serialize to edit in editor
    [SerializeField]private float jumpForce = 7f;

    // enum to hold movement states from 0-3
    private enum MovementState { idle, running, jumping, falling }


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        

    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");   // float to hold horizontal input    "raw" = back to 0 immediately, no drag
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);    // horizontal input = *5 horizontal vel., keep current y value

        if (Input.GetButtonDown("Jump") && IsGrounded()) // check for space pressed down AND if we're on ground
        {
            jumpKeyPressed = true;  // then its true
        }

        UpdateAnimState();
        
    }

    private void FixedUpdate()
    {
       if (jumpKeyPressed) // if bool = true then increase y axis velocity
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);   // keep current x value
            jumpKeyPressed = false; // reset to false
        }
    }

    // method to update movement state
    private void UpdateAnimState()
    {
        MovementState state;

        if (dirX > 0f) // if moving right
        {
            state = MovementState.running;     // set state for animation
            sprite.flipX = false;               // flip  back

        }

        else if (dirX < 0f) // if moving left
        {
            state = MovementState.running;      // set state for animation
            sprite.flipX = true;                // flip sprite to face left
        }
        else
        {
            state = MovementState.idle;     // set back to idle
        }

        if (rb.velocity.y > .05f)    // check for y velocity
        {
            state = MovementState.jumping;
        }

        else if (rb.velocity.y < -.1f)  // check for downward velocity
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    // method to check if we're on the ground and can jump again
    private bool IsGrounded()
    {
        //  create box at same pos of player box collider, check if intersects with ground layer
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .05f, jumpableGround);
    }
}
