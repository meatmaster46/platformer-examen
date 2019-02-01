using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public GameObject pauseMenu;

    public void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ButtonRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void ButtonExit()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void ButtonContinue()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}