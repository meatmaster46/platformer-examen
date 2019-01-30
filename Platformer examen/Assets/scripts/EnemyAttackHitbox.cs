using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackHitbox : MonoBehaviour {

    public int damage = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage(damage);
        }
    }
}
