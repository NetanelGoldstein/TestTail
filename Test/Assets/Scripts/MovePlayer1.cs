using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer1 : MonoBehaviour

{
    public float speed = 300;

    Rigidbody2D rb;
    float horizontalValue;
    Animator animator;
    bool faceingRight = true;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate() 
    {
        Move(horizontalValue);
    }
    
    void Move (float dir)
    {
        float xVal = dir * speed * Time.deltaTime;
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
    }
}


