using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyleController : MonoBehaviour {


    //Player's rigidbody
    private Rigidbody2D rb2d;

    // Player's move speed and jump height
    public float moveSpeed;
    public float jumpHeight;
    private float moveVelocity;

    // Player on ground check
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    // Turn on player's double jump
    private bool doubleJumped;

    //Player's climbing
    public bool onLadder;
    public float climbSpeed;
    private float climbVelocity;
    private float gravityStore;

    //Android UI button bool
    public bool btnLeft, btnRight, btnJump, btnUp, btnDown;

    //Boyle's Animator
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();

        gravityStore = rb2d.gravityScale;

        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    // Update is called once per frame
    void Update()
    {

        rb2d.velocity = new Vector2(moveVelocity, rb2d.velocity.y);

        if (grounded)
            doubleJumped = false;



#if UNITY_STANDALONE || UNITY_WEBPLAYER

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !grounded)
        {
            Jump();
            doubleJumped = true;
        }

        Move(Input.GetAxisRaw("Horizontal"));

        if (onLadder)
        {
            rb2d.gravityScale = 0.0f;
            Climb(Input.GetAxisRaw("Vertical"));
        }

        if (!onLadder)
        {
            rb2d.gravityScale = gravityStore;
        }

#endif

#if UNITY_ANDROID

        if (btnLeft)
        {
            Move(-1);
        }

        if (btnRight)
        {
            Move(1);
        }

        if (btnJump)
        {
            Jump();
        }

        if (!btnLeft && !btnRight )
        {
            Move(0);
        }

        //if (btnLeft == true && btnJump == true)
        //{
        //    Move(-1);
        //    Jump();
        //}

        //if (btnRight == true && btnJump == true)
        //{
        //    Move(1);
        //    Jump();
        //}

        if (onLadder)
        {
            rb2d.gravityScale = 0.0f;

            if (btnUp)
                Climb(1);
            else if (btnDown)
                Climb(-1);
            else
                Climb(0);
        }

        else if (!onLadder)
        {
            rb2d.gravityScale = gravityStore;
        }

#endif        
    }

    public void Jump()
    {

        if (grounded)
        {
            //Jump();
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);
        }

        if (!doubleJumped && !grounded)
        {
            //Jump();
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);
            doubleJumped = true;
        }
    }

    public void Move(float moveInput)
    {
        moveVelocity = moveSpeed * moveInput;
        
        if (moveInput < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(moveInput > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        anim.SetFloat("speed", Mathf.Abs(rb2d.velocity.x));
    }

    public void Climb(float climbInput)
    {
        //climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");
        climbVelocity = climbSpeed * climbInput;
        rb2d.velocity = new Vector2(rb2d.velocity.x, climbVelocity);
        anim.SetFloat("speed", Mathf.Abs(rb2d.velocity.y));
    }
}
