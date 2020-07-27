using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Rigidbody2D rb;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGroud;
    private bool onGround;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update() {
        rb.velocity = new Vector2(1, rb.velocity.y);
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGroud);

        if (Input.GetMouseButtonDown(0) && onGround) 
        {
            rb.velocity = new Vector2(rb.velocity.x, 3);
        }
	}
}
