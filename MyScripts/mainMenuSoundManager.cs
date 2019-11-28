using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuSoundManager : MonoBehaviour
{
    public static bool play_Click;
    public static bool levels_Click;
    public static bool back_Click;
    public static bool exit_Click;
    public static bool other_Click;

    public static bool chestOpen_Click;
    public static bool chestDenied_Click;


    public AudioSource aSource_clickEvents;
    public AudioSource aSource_BackgroundMusic;

    #region BG Music
    public AudioClip aClip_BGmusic;
    public void PlaySoundtrack()
    {
        aSource_BackgroundMusic.clip = aClip_BGmusic;
        aSource_BackgroundMusic.Play();
    }
    #endregion

    #region Play Click
    public AudioClip aClip_PlayButtonPress;
    public void setPlay_Click() { play_Click = false; }
    public void ManagePlayClickSound()
    {
        if (play_Click)
        {
            //play a sound
            aSource_clickEvents.PlayOneShot(aClip_PlayButtonPress);
            setPlay_Click();
        }
    }
    #endregion

    #region Levels Click
    public AudioClip aClip_LevelsButtonPress;
    public void setLevels_Click() { levels_Click = false; }
    public void ManageLevelsClickSound()
    {
        if (levels_Click)
        {
            //play sound
            aSource_clickEvents.PlayOneShot(aClip_LevelsButtonPress);
            setLevels_Click();
        }
       
    }
    #endregion

    #region Back Click
    public AudioClip aClip_BackButtonPress;
    public void setBack_Click() { back_Click = false; }
    public void ManageBackClickSound()
    {
        if (back_Click)
        {
            aSource_clickEvents.PlayOneShot(aClip_BackButtonPress);
            setBack_Click();
        }
    }

    #endregion

    #region Exit Click
    public AudioClip aClip_ExitButtonPress;
    public void setExit_Click() { exit_Click = false; }
    public void ManageExitClickSound()
    {
        if (exit_Click)
        {
            //play sound
            aSource_clickEvents.PlayOneShot(aClip_ExitButtonPress);
            setExit_Click();
        }
    }

    #endregion

    #region Other Click
    public AudioClip aClip_OtherStuffButtonPress;
    public void setOther_Click() { other_Click = false; }
    public void ManageOtherClickSound()
    {
        if (other_Click)
        {
            aSource_clickEvents.PlayOneShot(aClip_OtherStuffButtonPress);
            setOther_Click();
        }
    }

    #endregion

    #region Chest Click
    //open chest
    public AudioClip aClip_Chest;
    //denied
    public AudioClip aClip_ChestDenied;

    private void setChest_Click()
    {
        chestOpen_Click = false;
    }

    private void setDeniedChest_Click()
    {
        chestDenied_Click = false;
    }

    private void ManageOpenChestClickSound()
    {
        if (chestOpen_Click)
        {
            aSource_clickEvents.PlayOneShot(aClip_Chest);
            setChest_Click();
        }
    }

    private void ManageChestDeniedClickSound()
    {
        if (chestDenied_Click)
        {
            aSource_clickEvents.PlayOneShot(aClip_ChestDenied);
            setDeniedChest_Click();
        }
    }



    #endregion


    void Awaik(){
        setPlay_Click();
        setLevels_Click();
        setBack_Click();
        setExit_Click();
        setOther_Click();
        setChest_Click();
        setDeniedChest_Click();
    }

    void Start()
    {
        PlaySoundtrack();
    }

    void Update()
    {
        ManagePlayClickSound();
        ManageLevelsClickSound();
        ManageBackClickSound();
        ManageExitClickSound();
        ManageOtherClickSound();
        ManageOpenChestClickSound();
        ManageChestDeniedClickSound();
    }
}
