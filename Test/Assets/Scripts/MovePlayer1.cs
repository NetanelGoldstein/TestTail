using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer1 : MonoBehaviour

{
    public float speed = 300;

    Rigidbody2D rb;
    const float groundCheckRadius = 0.2f;
    [SerializeField]Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float jumpPower = 300;

    float horizontalValue;
    Animator animator;
    bool faceingRight = true;
    [SerializeField] bool isGrounded;
    bool jump;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            jump = false;
        }
        

    }

    void FixedUpdate() 
    {
        GroundCheck();
        Move(horizontalValue, jump);
    }

    void GroundCheck()
    {
        isGrounded = false;//not grounded is the default state

        //Check if the GroundCheckObject is colliding with other
        //2D Colliders that are in the "Ground" Layer
        //If yes (isGrounded true) else (isGrounded false)

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
        {
            isGrounded = true;
        }
    }



    void Move (float dir, bool jumpFlag)
    {

        //If player is grounded and presses space, jump
        if (isGrounded && jumpFlag)
        {
            isGrounded = true;
            jumpFlag = false;
            rb.AddForce(new Vector2(0f, jumpPower));
        }

        #region Move and Run
        float xVal = dir * speed * Time.fixedDeltaTime;
        Vector2 targetVelocity = new Vector2(xVal, rb.velocity.y);
        rb.velocity = targetVelocity;


        //if looking right, click left, flip left
        if (faceingRight && dir < 0)
        {
            transform.localScale = new Vector3 (-2,3,2); //flip right to left
            faceingRight = false;
        }

        //if looking left, click right, flip right
        else if (!faceingRight && dir > 0)
        {
            transform.localScale = new Vector3(2, 3, 2); ; //flip right
            faceingRight = true;
        }

        //0 idle, 4 running
        //Set the float xVelocity accoding to the x value of the
        //RigidBody2D velocity
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        #endregion
    }
}


