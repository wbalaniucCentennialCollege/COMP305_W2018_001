using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    /*
    public float maxSpeed = 10;
    public float jumpForce = 700f;
    public float groundRadius = 0.2f;
    public Transform groundCheck;
    public LayerMask defineGround;
    */

    public PlayerStats stats;

    private Rigidbody2D rBody;
    private SpriteRenderer sRend;
    private Animator animator;

    private float moveH;
    private bool isRight = true;
    private bool isGrounded = false;
    private float distToGround;

    // Use this for initialization
    void Start () {
        rBody = GetComponent<Rigidbody2D>();
        sRend = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        distToGround = GetComponent<Collider2D>().bounds.extents.y;
        stats.groundCheck = transform.Find("GroundCheck");
	}
	
	// Update is called once per frame
	void Update () {
		if(isGrounded && Input.GetAxis("Jump") > 0)
        {
            animator.SetBool("Ground", false);
            rBody.AddForce(new Vector2(0, stats.jumpForce));
            isGrounded = false;
        }
	}

    // Do not need to use Time.deltaTime()
    void FixedUpdate()
    {
        // Checks whether character is grounded
        // isGrounded = Physics2D.OverlapCircle(stats.groundCheck.position, stats.groundCheckRadius, stats.defineGround);
        isGrounded = CheckIsGround();
        animator.SetBool("Ground", isGrounded);

        // Debug.Log("Grounded? " + isGrounded);

        // Pass vertical velocity to animator
        animator.SetFloat("vSpeed", rBody.velocity.y);

        // Read input
        moveH = Input.GetAxis("Horizontal");

        // Set speed variable in animator
        animator.SetFloat("Speed", Mathf.Abs(moveH));

        // Set character velocity
        rBody.velocity = new Vector2(moveH * stats.walkSpeed, rBody.velocity.y);

        if(moveH > 0 && !isRight)
        {
            Flip();
        } else if(moveH < 0 && isRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector3 temp = this.transform.localScale;
        temp.x *= -1;
        this.transform.localScale = temp;
        isRight = !isRight;
    }

    // Returns t/f is raycast intersects with an object on the "Floor" layer
    private bool CheckIsGround()
    {
        // TO-DO: Check "O.1f" to a PlayerStat entry
        return Physics2D.Raycast(transform.position, -Vector2.up, distToGround + 0.1f, stats.defineGround);
    }
}
