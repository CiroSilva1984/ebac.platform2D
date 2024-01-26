using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 velocity;
    public float speed = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            //rb.MovePosition(rb.position + velocity * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A)){
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            //rb.MovePosition(rb.position - velocity * Time.deltaTime);
        }
    }
}
