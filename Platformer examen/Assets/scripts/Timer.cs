using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float timeLeft;
    private int timeLeftINT;
    public Text timeText;
    public int playerHealth;
    public Text playerHealthText;

    private PlayerMovement player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        timeLeftINT = Mathf.RoundToInt(timeLeft);

        timeText.text = timeLeftINT.ToString();

        if(timeLeft <= 0)
        {
            player.GameOver();
        }
        playerHealth = player.health;
        playerHealthText.text = playerHealth.ToString() + "HP";
    }
}