using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer1 : MonoBehaviour

{
    public float speed = 300;

    Rigidbody2D rb;
    float horizontalValue;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
    }
}


