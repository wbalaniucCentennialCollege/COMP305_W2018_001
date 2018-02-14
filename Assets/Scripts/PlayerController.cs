using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Public variables
    public float maxSpeed = 10.0f;

    // Private variables
    private Rigidbody2D rBody;
    private SpriteRenderer sRend;
    private Animator animator;

	// Use this for initialization
	void Start () {
        rBody = GetComponent<Rigidbody2D>();
        sRend = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
	}
	
	// Guarenteed to be called at defined time intervals. USE FOR PHYSICS!!!
	void FixedUpdate () {
        float moveHoriz = Input.GetAxis("Horizontal");

        // Debug.Log("Horizontal value= " + moveHoriz);
        animator.SetFloat("Speed", Mathf.Abs(moveHoriz));

        rBody.velocity = new Vector2(moveHoriz * maxSpeed, rBody.velocity.y);

        if(moveHoriz > 0)
        {
            sRend.flipX = false;
        } else if (moveHoriz < 0)
        {
            sRend.flipX = true;
        }
	}
}
