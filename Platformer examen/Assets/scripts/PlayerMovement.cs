using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //player movement
    public float walkSpeed;
    public float sprintSpeed;
    private float curSpeed;

    public int health;

    //physics
    private Rigidbody2D rb;

    //jump
    public bool grounded = false;
    public bool doubleJump = true;
    public float jumpForce;
    public Transform groundedA;
    public Transform groundedB;
    public LayerMask ground;
    public bool hasDoubleJump = false;

    //animation
    private Animator animator;

    //sound
    public AudioSource audioSource;
    public AudioClip deathSound;

    //hiboxes
    public bool attacking = false;
    public Collider2D quickAttackHitbox;
    public Collider2D strongAttackHitbox;

    //range
    public bool hasRange = false;
    public GameObject projectile;
    public Transform projectileStart;

    public GameObject gameOverMenu;

    public int keys = 0;

    void Start () {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        curSpeed = walkSpeed;

        animator = GetComponent<Animator>();

        audioSource = gameObject.GetComponent<AudioSource>();
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
        if (Input.GetKeyDown("space")  && grounded == true)
        {
            Jump();
        }
        //double jump
        if (Input.GetKeyDown("space") && grounded == false && hasDoubleJump == true && doubleJump == true)
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

        if (Input.GetKeyDown("z") && attacking == false)
        {
            QuickAttack();
        }
        if (Input.GetKeyDown("x") && attacking == false)
        {
            StrongAttack();
        }
    }
    //collision with items
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<RangedPotion>())
        {
            hasRange = true;
            col.gameObject.SetActive(false);
        }
        if (col.gameObject.GetComponent<HealthPotion>())
        {
            health += 10;
            col.gameObject.SetActive(false);
        }
        if (col.gameObject.GetComponent<JumpPotion>())
        {
            hasDoubleJump = true;
            col.gameObject.SetActive(false);
        }
        if (col.gameObject.GetComponent<Spikes>())
        {
            GameOver();
        }
        if (col.gameObject.GetComponent<Key>())
        {
            col.gameObject.SetActive(false);
            keys++;
        }
    }


    void Jump()
    {
        rb.AddForce(transform.up * jumpForce);
    }
    void QuickAttack()
    {
        attacking = true;
        animator.SetBool("quickAttack" , true);
        quickAttackHitbox.gameObject.SetActive(true);
        Invoke("QuickAttackEnd", 0.2f);
    }
    void QuickAttackEnd()
    {
        animator.SetBool("quickAttack", false);
        quickAttackHitbox.gameObject.SetActive(false);
        attacking = false;
    }
    void StrongAttack()
    {
        attacking = true;
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
        Invoke("StrongAttackEnd", 0.5f);
    }
    void StrongAttackEnd()
    {
        animator.SetBool("strongAttack", false);
        strongAttackHitbox.gameObject.SetActive(false);
        attacking = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        audioSource.Play();
        if (health <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        this.gameObject.SetActive(false);
        gameOverMenu.SetActive(true);
    }
}