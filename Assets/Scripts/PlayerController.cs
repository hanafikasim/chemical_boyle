using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

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

	//Player's animation
	public Animator playerAnime;

    //Player's climbing
    public bool onLadder;
    public float climbSpeed;
    private float climbVelocity;
    private float gravityStore;

	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		playerAnime = gameObject.GetComponent<Animator> ();

        gravityStore = rb2d.gravityScale;
	}

	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}

	// Update is called once per frame
	void Update () {

		if (grounded)
			doubleJumped = false;

        if (!grounded)
        {
            playerAnime.Play("player_jump");
        }

        if (Input.GetKeyDown (KeyCode.Space) && grounded) {
			Jump ();
            
            
        }

        if (Input.GetKeyDown (KeyCode.Space) && !doubleJumped && !grounded) {
			Jump ();
			doubleJumped = true;
        }

        moveVelocity = 0f;

		if (Input.GetKey (KeyCode.D)) {
			MoveRight ();
			gameObject.GetComponent<SpriteRenderer> ().flipX = false;
			if(grounded)
				playerAnime.Play ("player_run");
		}

		if (Input.GetKey (KeyCode.A)) {
			MoveLeft ();
			gameObject.GetComponent<SpriteRenderer> ().flipX = true;
			if(grounded)
				playerAnime.Play ("player_run");
		}

        rb2d.velocity = new Vector2(moveVelocity, rb2d.velocity.y);
			
		if (!Input.anyKey) {
			playerAnime.Play ("player_idle");
		}

        if (onLadder)
        {
            rb2d.gravityScale = 0.0f;
            climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");
            rb2d.velocity = new Vector2(rb2d.velocity.x, climbVelocity);
        }

        if (!onLadder)
        {
            rb2d.gravityScale = gravityStore;
        }
	}

	public void Jump(){
		rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpHeight);
        
    }

	public void MoveRight(){
        //rb2d.velocity = new Vector2 (moveSpeed, rb2d.velocity.y);
        moveVelocity = moveSpeed;
	}

	public void MoveLeft(){
        //rb2d.velocity = new Vector2 (-moveSpeed, rb2d.velocity.y);
        moveVelocity = -moveSpeed;
    }
}
