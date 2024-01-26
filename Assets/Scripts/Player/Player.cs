using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 friction = new Vector2(-.1f, 0);

    [Header("MOVIMENTO PLAYER")]
    public float speed = 10f;
    public float speedRun = 5f;

    private float _currentSpeed;

    [Header("CONTROLE JUMP")]
    public float forceJump = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
    }
    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            _currentSpeed = speedRun;
        else
            _currentSpeed = speed;
        
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(_currentSpeed, rb.velocity.y);
            //rb.MovePosition(rb.position + velocity * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A)){
            rb.velocity = new Vector2(-_currentSpeed, rb.velocity.y);
            //rb.MovePosition(rb.position - velocity * Time.deltaTime);
        }
        //Friction sides
        if(rb.velocity.x > 0)
        {
            rb.velocity += friction;
        }else if(rb.velocity.x < 0)
        {
            rb.velocity -= friction;
        }

    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * forceJump;
        }
    }
}
