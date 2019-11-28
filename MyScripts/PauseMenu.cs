using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public Animator anime;

    public GoPlay fader;

    public Shoot shoot;


   public void OpenResumeMenu()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else { Pause(); }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        anime.SetTrigger("Close");
        GameIsPaused = false;
        shoot.enabled = true;
    }

    public void Pause()
    {
        anime.SetTrigger("Open");
        GameIsPaused = true;
        shoot.enabled = false;
    }

    public void OpenMainMenu()
    {
        Time.timeScale = 1f;
        fader.FadeToLevel(1);
    }

    public void OpenShop()
    {
        Time.timeScale = 1f;
        fader.OpenMainShop();
    }

}
