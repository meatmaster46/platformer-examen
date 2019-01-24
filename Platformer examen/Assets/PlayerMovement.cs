using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //player movement
    public float walkSpeed;
    public float sprintSpeed;
    private float curSpeed;
    private Rigidbody2D rb;

    //jump
    public bool grounded = false;
    public bool doubleJump = true;
    public float jumpForce;
    public Transform groundedA;
    public Transform groundedB;
    public LayerMask ground;

    //animation
    private Animator animator;


    void Start () {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        curSpeed = walkSpeed;

        animator = GetComponent<Animator>();
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
    }
    void Update()
    {
        //jump
        if (Input.GetKeyDown("space") && grounded == true)
        {
            Jump();
        }
        //double jump
        if (Input.GetKeyDown("space") && grounded == false && doubleJump == true)
        {
            rb.velocity = new Vector2(0, 0);
            Jump();
            doubleJump = false;
        }
        if (grounded == true)
        {
            doubleJump = true;
        }

        //ground check
        grounded = Physics2D.OverlapArea(groundedA.transform.position, groundedB.transform.position, ground);

        if (Input.GetKeyDown("z"))
        {
            QuickAttack();
        }
        if (Input.GetKeyDown("s"))
        {
            StrongAttack();
        }
    }
    void QuickAttackEnd()
    {
        animator.SetBool("quickAttack", false);
    }
    void Jump()
    {
        rb.AddForce(transform.up * jumpForce);
    }
    void QuickAttack()
    {
        animator.SetBool("quickAttack" , true);
    }
    void StrongAttack()
    {

    }
}