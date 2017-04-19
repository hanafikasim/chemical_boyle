using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//Player's rigidbody
	private Rigidbody2D rb2d;

	// Player's move speed and jump height
	public float moveSpeed;
	public float jumpHeight;

	// Player on ground check
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	// Turn on player's double jump
	private bool doubleJumped;

	//Player's animation
	public Animator playerAnime;

	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		playerAnime = gameObject.GetComponent<Animator> ();
	}

	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}

	// Update is called once per frame
	void Update () {

		if (grounded)
			doubleJumped = false;

		if (Input.GetKeyDown (KeyCode.Space) && grounded) {
			Jump ();
		}

		if (Input.GetKeyDown (KeyCode.Space) && !doubleJumped && !grounded) {
			Jump ();
			doubleJumped = true;
		}

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
			
		if (!Input.anyKey) {
			playerAnime.Play ("player_idle");
		}
	}

	public void Jump(){
		rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpHeight);
	}

	public void MoveRight(){
		rb2d.velocity = new Vector2 (moveSpeed, rb2d.velocity.y);
	}

	public void MoveLeft(){
		rb2d.velocity = new Vector2 (-moveSpeed, rb2d.velocity.y);
	}
}
