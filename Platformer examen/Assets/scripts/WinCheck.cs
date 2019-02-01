using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCheck : MonoBehaviour {

    public GameObject boss;
    public GameObject winScreen;
    public GameObject victoryTheme;

    // Update is called once per frame
    void Update()
    {
        if (boss == null)
        {
            winScreen.SetActive(true);
            victoryTheme.SetActive(true);
        }
    }
}
