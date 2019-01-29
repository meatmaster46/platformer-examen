using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public int damage = 3;
    public int speed = 2;

    private void Update()
    {
        this.gameObject.transform.position += transform.position = Vector2.right * speed * Time.deltaTime;
        //this.gameObject.GetComponent<Rigidbody2D>
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            gameObject.SetActive(false);
        }
    }
}