using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausemenu;
    public bool pause = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause)
            {
                pausemenu.SetActive(true);
                pause = true;
            }
            else if (pause == true)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    pausemenu.SetActive(false);
                    pause = false;
                }
            }
        }
    }
    public void Pause()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
