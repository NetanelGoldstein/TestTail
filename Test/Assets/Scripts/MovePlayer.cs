using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    //container for the object
    Rigidbody2D _rb;
    public Rigidbody2D jumpRB;
    // NG Test Change
    // Hey this ones for you
    float _playerSpeed = 5f;
    //do you see this change?

    //when we grab input using horizontal - means going to left, and positive number means right
    float _inputHorizontal;


    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        jumpRB = gameObject.GetComponent<Rigidbody2D>();
    }


    public float jumpAmount = 1.5f;
    public bool isJumping;
    //bool isGrounded;
    // public Transform groundCheck;
    // public LayerMask groundlayer;


    void Update()
    {


        _inputHorizontal = Input.GetAxisRaw("Horizontal");

        if (_inputHorizontal != 0)
        {
            //moves player left and right
            _rb.AddForce(new Vector2(_inputHorizontal * _playerSpeed, 0f));
            //isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundlayer);

        }



        if (Input.GetKeyDown(KeyCode.Space) && isJumping ==false)
        {
            Jump();
            // if (isGrounded == true)
            //{
               // Jump();
            //}
            //jumpRB.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);

        }

    }

    void Jump()
    {
        jumpRB.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {

            isJumping = false;

        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))

        {
            isJumping = true;
        }

    }
}
