using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Collision coll;
    private Rigidbody2D rb;
    private Animator myAnimator;

    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpForce = 20.0f;
    [SerializeField] private float startDashTime;
    [SerializeField] private float dashSpeed = 20.0f;
    [SerializeField] private int startDashAmount = 1;
    [SerializeField] private int startExtraJump = 0;

    private string runningBool = "isRunning";
    private string dashingBool = "isDashing";
    private string jumpingBool = "isJumping";



    private int direction;
    private float dashTime;
    private int dashAmount;
    private int extraJump;


    private void Start()
    {
        coll = GetComponent<Collision>();
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
        dashAmount = startDashAmount;
        extraJump = startExtraJump;
        myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 dir = new Vector2(x, y);
        Walk(dir);

        if (coll.onGround)
        {
            extraJump = startExtraJump;
            dashAmount = startDashAmount;
        }

        Jump();
        Dash();
        FlipSprite();
    }


    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1.0f);
        }
    }


    private void Dash()
    {
        bool isDashing = false;
        myAnimator.SetBool(dashingBool, isDashing);

        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.Q) && dashAmount > 0)
            {
                direction = 1;
                dashAmount--;
            }
            else if (Input.GetKeyDown(KeyCode.E) && dashAmount > 0)
            {
                direction = 2;
                dashAmount--;
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;

                isDashing = true;
                myAnimator.SetBool(dashingBool, isDashing);

                if (direction == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;

                }
                else if (direction == 2)
                {
                    rb.velocity = Vector2.right * dashSpeed;

                }
            }
        }
    }

    private void Walk(Vector2 dir)
    {
        rb.velocity = (new Vector2(dir.x * speed, rb.velocity.y));
        bool isRunning = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool(runningBool, isRunning);
    }

    private void Jump()
    {

        if (Input.GetButtonDown("Jump") && extraJump > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity += Vector2.up * jumpForce;
            extraJump--;
        }
        else if(Input.GetButtonDown("Jump") && extraJump == 0 && coll.onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity += Vector2.up * jumpForce;
        }
        bool isJumping = Mathf.Abs(rb.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool(jumpingBool, isJumping);
    }
}

