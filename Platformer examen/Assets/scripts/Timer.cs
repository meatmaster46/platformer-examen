using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float timeLeft;
    private int timeLeftINT;
    public Text timeText;

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        timeLeftINT = Mathf.RoundToInt(timeLeft);

        timeText.text = timeLeftINT.ToString();
    }
}