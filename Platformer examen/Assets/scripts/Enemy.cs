using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;

    public LayerMask playerLayer;
    public float sightRange;
    public bool seesPlayer;

    private GameObject player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    void Update()
    {
        ////los ray attempt
        //Ray ray = new Ray(transform.position, player.transform.position - transform.position);
        //Debug.DrawRay(this.transform.position, player.transform.position - transform.position, Color.red);
        //RaycastHit hit;

        //if (Physics.Raycast(ray, out hit, LOS))
        //{
        //    seesPlayer = true;
        //}

        //los overlapcircle attempt
        seesPlayer = Physics2D.OverlapCircle(this.transform.position, sightRange, playerLayer);

        
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
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}