using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //player movement
    public float walkSpeed;
    public float sprintSpeed;
    private float curSpeed;

    //physics
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

    //hiboxes
    public Collider2D quickAttackHitbox;
    public Collider2D strongAttackHitbox;

    //range
    public bool hasRange = false;
    public GameObject projectile;
    public Transform projectileStart;

    void Start () {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        curSpeed = walkSpeed;

        animator = GetComponent<Animator>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	void FixedUpdate () {

        //Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal") * walkSpeed, 0);
        //rb.velocity = movement;
        //rb.AddForce(transform.right * movement * curSpeed - rb.velocity * VelBreak);

        //movement
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), 0) * Time.deltaTime;
        this.gameObject.transform.position += transform.position = movement * curSpeed;

        //sprint
        if (Input.GetKey("left shift"))
        {
            curSpeed = sprintSpeed;
        }
        else
        {
            curSpeed = walkSpeed;
        }
        //rotate player if turned around
        if (movement.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
        if (movement.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
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
        if (Input.GetKeyDown("x"))
        {
            StrongAttack();
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<RangedPotion>())
        {
            hasRange = true;
            col.gameObject.SetActive(false);
        }
    }



    void Jump()
    {
        rb.AddForce(transform.up * jumpForce);
    }
    void QuickAttack()
    {
        animator.SetBool("quickAttack" , true);
        quickAttackHitbox.gameObject.SetActive(true);
        Invoke("QuickAttackEnd", 0.2f);
    }
    void QuickAttackEnd()
    {
        animator.SetBool("quickAttack", false);
        quickAttackHitbox.gameObject.SetActive(false);
    }
    void StrongAttack()
    {
        animator.SetBool("strongAttack", true);
        
        Invoke("StrongAttackActive", 0.5f);
    }
    void StrongAttackActive()
    {
        strongAttackHitbox.gameObject.SetActive(true);
        if (hasRange == true)
        {
            Instantiate(projectile, projectileStart.transform.position, transform.rotation);
        }
        Invoke("StrongAttackEnd", 0.1f);
    }
    void StrongAttackEnd()
    {
        animator.SetBool("strongAttack", false);
        strongAttackHitbox.gameObject.SetActive(false);
    }
}