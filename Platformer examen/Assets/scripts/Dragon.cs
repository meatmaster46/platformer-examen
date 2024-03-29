﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{

    public int health;
    public float speed;

    public LayerMask playerLayer;
    public float sightRange;
    public bool seesPlayer;

    //attack
    public bool attacking = false;
    public GameObject attackHitbox;

    private GameObject player;
    private Transform playerPos;
    private Animator animator;

    public AudioSource audioSource;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
        animator = GetComponent<Animator>();
        attackHitbox = GetComponentInChildren<CircleCollider2D>().gameObject;
        //attackHitbox.gameObject.SetActive(false);
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, player.transform.position , speed);
        if (attacking != true && seesPlayer == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, transform.position.y), speed * Time.deltaTime);
        }

        if (Vector2.Distance(this.transform.position, player.transform.position) < 0.6f && attacking == false)
        {
            Attack();
        }

        //rotate towards player
        if (player.transform.position.x < this.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
        if (player.transform.position.x > this.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        //los ray attempt
        //Ray ray = new Ray(transform.position, player.transform.position - transform.position);
        //Debug.DrawRay(this.transform.position, player.transform.position - transform.position, Color.red);
        //RaycastHit hit;

        //if (Physics.Raycast(ray, out hit, sightRange))
        //{
        //    seesPlayer = true;
        //}

        //los overlapcircle attempt
        seesPlayer = Physics2D.OverlapCircle(this.transform.position, sightRange, playerLayer);
        //if (Physics2D.OverlapCircle(this.transform.position, sightRange, playerLayer))
        //{
        //    Debug.Log("works");
        //}
        //this.gameObject.SetActive(true);

    }
    //los trigger attempt
    //private void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.GetComponent<PlayerMovement>())
    //    {
    //        seesPlayer = true;
    //        Debug.Log("lol");
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<Spikes>())
        {
            Destroy(this.gameObject);
        }
    }


    void Attack()
    {

        animator.SetBool("attacking", true);
        attacking = true;
        Invoke("AttackActive", 0.52f);
    }
    void AttackActive()
    {
        attackHitbox.gameObject.SetActive(true);
        animator.SetBool("attacking", false);
        Invoke("AttackEnd", 0.5f);
    }
    void AttackEnd()
    {
        attackHitbox.gameObject.SetActive(false);
        attacking = false;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        audioSource.Play();
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}