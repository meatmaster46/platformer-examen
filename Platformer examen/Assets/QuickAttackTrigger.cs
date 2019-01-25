using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickAttackTrigger : MonoBehaviour {

    public int damage = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit something");
        if (collision.gameObject.GetComponent<Enemy>())
        {
            Debug.Log("hit enemy");
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
