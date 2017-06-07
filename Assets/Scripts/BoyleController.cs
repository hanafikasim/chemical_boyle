﻿using System.Collections;
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

    // Fire
    private Transform fireSpawn;
    public Transform fireSpawn_1, fireSpawn_2;
    public GameObject waterBullet;
    public GameObject saltBullet;
    public GameObject acidBullet;
    //public GameObject water, salt, acid;
    private GameObject bullet;

    // Audio
    public AudioSource walkSound;
    public AudioSource shootSound;
    public AudioSource absorbSound;

    // Absorb
    public bool canAbsorb;
    private Collider2D temp;

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
            if (!walkSound.isPlaying)
                walkSound.Play();
        }

        if (btnRight)
        {
            Move(1);
            if (!walkSound.isPlaying)
                walkSound.Play();
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
            {
                Climb(1);
                if (!walkSound.isPlaying)
                    walkSound.Play();
            }
                
            else if (btnDown)
            {
                Climb(-1);
                if (!walkSound.isPlaying)
                    walkSound.Play();
            }
                
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

    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.name == "H")
        //{
        //    canAbsorb = true;
        //    ElementsController.elementList.Add(other.gameObject);
        //    ElementsController.hydrogen++;
        //    other.gameObject.SetActive(false);
        //}
        //else if (other.gameObject.name == "O")
        //{
        //    ElementsController.elementList.Add(other.gameObject);
        //    ElementsController.oxygen++;
        //    other.gameObject.SetActive(false);
        //}
        //else if (other.gameObject.name == "Na")
        //{
        //    ElementsController.elementList.Add(other.gameObject);
        //    ElementsController.sodium++;
        //    other.gameObject.SetActive(false);
        //}
        //else if (other.gameObject.name == "Cl")
        //{
        //    ElementsController.elementList.Add(other.gameObject);
        //    ElementsController.chlorine++;
        //    other.gameObject.SetActive(false);
        //}

        //if(other.gameObject.tag == "Elements")
        //{
        //    if (!absorbSound.isPlaying)
        //        absorbSound.Play();
        //}

        if(other.tag == "Elements")
        {
            canAbsorb = true;
            temp = other;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Elements")
        {
            canAbsorb = false;
            temp = null;
        }
    }

    public void Absorb()
    {
        if (canAbsorb)
        {
            if(temp.name == "H")
            {
                ElementsController.elementList.Add(temp.gameObject);
                ElementsController.hydrogen++;
                temp.gameObject.SetActive(false);
            }
            else if (temp.name == "O")
            {
                ElementsController.elementList.Add(temp.gameObject);
                ElementsController.oxygen++;
                temp.gameObject.SetActive(false);
            }
            else if (temp.name == "Na")
            {
                ElementsController.elementList.Add(temp.gameObject);
                ElementsController.sodium++;
                temp.gameObject.SetActive(false);
            }
            else if (temp.name == "Cl")
            {
                ElementsController.elementList.Add(temp.gameObject);
                ElementsController.chlorine++;
                temp.gameObject.SetActive(false);
            }

            if (!absorbSound.isPlaying)
                absorbSound.Play();
        }
    }

    public void Fire()
    {
        if (gameObject.GetComponent<SpriteRenderer>().flipX == true)
        {
            fireSpawn = fireSpawn_2;
            BulletController.speed = -8;
        }
        else if (gameObject.GetComponent<SpriteRenderer>().flipX == false)
        {
            fireSpawn = fireSpawn_1;
            BulletController.speed = 8;
        }

        if (ElementsController.compoundTxt.text == "Water")
        {
            if (!shootSound.isPlaying)
                shootSound.Play();
            bullet = Instantiate(waterBullet, fireSpawn.position, fireSpawn.rotation);
        }

        else if (ElementsController.compoundTxt.text == "Salt")
        {
            if (!shootSound.isPlaying)
                shootSound.Play();
            bullet = Instantiate(saltBullet, fireSpawn.position, fireSpawn.rotation);
        }

        else if (ElementsController.compoundTxt.text == "Acid")
        {
            if (!shootSound.isPlaying)
                shootSound.Play();
            bullet = Instantiate(acidBullet, fireSpawn.position, fireSpawn.rotation);
        }

        Destroy(bullet, 1);
    }
}
