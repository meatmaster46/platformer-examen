using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //player movement
    public float walkSpeed;
    public float sprintSpeed;
    private float curSpeed;

    //jump
    public bool grounded = false;
    public float jumpForce;
    public Transform groundedA;
    public Transform groundedB;

    private Rigidbody2D rb;

    



    void Start () {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        curSpeed = walkSpeed;
	}
	
	void FixedUpdate () {

        //Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal") * walkSpeed, 0);
        //rb.velocity = movement;
        //rb.AddForce(transform.right * movement * curSpeed - rb.velocity * VelBreak);

        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), 0) * Time.deltaTime;
        this.gameObject.transform.position += transform.position = movement * curSpeed;

        if (Input.GetKey("left shift"))
        {
            curSpeed = sprintSpeed;
        }
        else
        {
            curSpeed = walkSpeed;
        }
        

        if (Input.GetKeyDown("space") && grounded == true)
        {
            rb.AddForce(transform.up * jumpForce);
        }
        
        //grounded = Physics2D.OverlapArea(groundedA, groundedB, );

    }
}