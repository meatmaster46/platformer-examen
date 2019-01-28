using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickAttackTrigger : MonoBehaviour {

    public int damage = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
