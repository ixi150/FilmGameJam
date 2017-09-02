using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpMultiplier = 10.0f;

    public float groundThreshold = 0.1f;

    Rigidbody2D rb;

    float horizontal;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        GetInput();
        Move();
	}

    void GetInput ()
    {
        horizontal = Input.GetAxis("Horizontal");
    }

    void Move ()
    {
        var velocity = rb.velocity;
        velocity.x = horizontal * moveSpeed;

        if (Input.GetButtonDown("Jump") && Grounded())
        {
            velocity.y = jumpMultiplier * (-Physics2D.gravity.y * rb.mass);
        }
        rb.velocity = velocity;
    }

    bool Grounded()
    {
        Collider2D [] cols = Physics2D.OverlapCircleAll(transform.position, groundThreshold);
        if (cols.Length > 1)
            return true;
        else
            return false;
    }

    public void WarpPlayer(Vector2 target)
    {
        transform.position = target;
    }
}
