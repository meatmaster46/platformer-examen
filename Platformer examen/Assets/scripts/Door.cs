using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public GameObject winMenu;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<PlayerMovement>())
        {
            if (col.gameObject.GetComponent<PlayerMovement>().keys >= 2)
            {
                winMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}