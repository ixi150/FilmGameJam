using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpMultiplier = 10.0f;

    public float groundThreshold = 0.1f;

    public float aimSpeed = 5.0f;
    public float headArc = 70;
    public Transform arm, head;

    public float inputThreshold = 0.1f;

    public GameObject[] spritesX;
    public GameObject[] spritesY;

    public string jumpButton;

    public int specialWeapon = 0;

    float armAngle;

    Rigidbody2D rb;

    float horizontal;
    float vertical;

    Animator animator;
    Vector2 lastInput = new Vector2(1, 0);

    public string horizontalAxis, verticalAxis;

    public bool isFirstPlayer;
    public GameObject timer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        GetInput();
        Move();
        Aim();
        UpdateAnimator();
    }

    void GetInput()
    {
        horizontal = Input.GetAxis(horizontalAxis);
        vertical = Input.GetAxis(verticalAxis);
    }

    void Move()
    {
        var velocity = rb.velocity;
        velocity.x = horizontal * moveSpeed;

        if (Input.GetKeyDown(jumpButton) && Grounded())
        {
            velocity.y = jumpMultiplier * (-Physics2D.gravity.y * rb.mass);
        }
        rb.velocity = velocity;
    }

    void Aim()
    {
        var isRightSided = RightSided(armAngle);
        if (InputIsActive())
        {
            UpdateLastInput();
        }
        var direction = lastInput;
        armAngle = (Mathf.Atan2(direction.y, direction.x) * 180.0f / Mathf.PI);
        arm.rotation = Quaternion.RotateTowards(arm.rotation, Quaternion.Euler(0, 0, armAngle), aimSpeed * Time.deltaTime);
        
        var headRotation = Quaternion.Euler(0, 0, armAngle).eulerAngles.z;
        if (isRightSided)
        {
            headRotation = headRotation < 180 ?
                Mathf.Clamp(headRotation, 0, headArc / 2) :
                Mathf.Clamp(headRotation, 360 - headArc / 2, 360);
        }
        else
        {
            headRotation = Mathf.Clamp(headRotation, 180 - headArc / 2, 180 + headArc / 2);
        }
        head.rotation = Quaternion.RotateTowards(head.rotation, Quaternion.Euler(0, 0, headRotation), aimSpeed * Time.deltaTime / 3);

        float scaleFactor = isRightSided ? 1 : -1;
        foreach (var sprite in spritesX)
        {
            sprite.transform.localScale = new Vector3(scaleFactor, 1, 1);
        }

        foreach (var sprite in spritesY)
        {
            sprite.transform.localScale = new Vector3(1, scaleFactor, 1);
        }


    }

    void UpdateLastInput()
    {
        lastInput = new Vector2(horizontal, vertical);
    }

    void UpdateAnimator()
    {
        animator.SetFloat("Horizontal", Mathf.Abs(horizontal));
        animator.SetFloat("Vertical", rb.velocity.y);
        animator.SetBool("Grounded", Grounded());
    }

    bool Grounded()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, groundThreshold);
        if (cols.Length > 1)
            return true;
        else
            return false;
    }

    bool InputIsActive()
    {
        if ((Mathf.Abs(horizontal) > inputThreshold) || (Mathf.Abs(vertical) > inputThreshold))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void WarpPlayer(Vector2 target)
    {
        transform.position = target;
    }

    bool RightSided(float angle)
    {
        if (angle < 0)
            angle = 360 + angle;
        if (angle > 90 && angle < 270)
            return false;
        else
            return true;
    }

    public void DealDmg(float ammount)
    {
        if (isFirstPlayer)
        {
            timer.GetComponent<Timer>().moveIndicator(true, ammount);
        }
        else timer.GetComponent<Timer>().moveIndicator(false, ammount);
    }
}
