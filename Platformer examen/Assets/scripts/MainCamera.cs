using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    private GameObject player;
    public Vector3 offset;

	void Start () {
        player = FindObjectOfType<PlayerMovement>().gameObject;
	}
	
	void Update () {
        this.transform.position = player.transform.position + offset;
	}
}