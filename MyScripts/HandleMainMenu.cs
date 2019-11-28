using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using UnityEngine.Audio;
using System;


/*
    TO:DO ----> MODIFY SCRIPT   
     
     */
public class HandleMainMenu : MonoBehaviour
{
    public GameObject SoundMixer;
    public GameObject Settings;
    public GameObject SecondBaseShop;

    public GameObject Fader;

    public string levelToLoad;

    public Animator anime;
    public Animator chestAnime;
    public Animator cardAnime;

    private bool open_state;


    public GameObject coinNum;
    private Text coinNumTxt;

    private int priceOfChest = 550;

    public GameObject numOfLives;
    private Text numOfLivesTxt;

    private int health;

    //exit game popUP

    public Animator anime_Exit;
    bool exit_window_open;

    //SETTINGS
    public Image music_btn;
    public Sprite musicOFF;
    public Sprite musicON;

    public Image sound_btn;
    public Sprite soundOFF;
    public Sprite soundON;

    public AudioMixer audioMixer;

    public Slider musicSlider;
    public Slider sfxSlider; 

    //REWARD SYSTEM
    public Button chestButton;
    public static ulong lastChestOpen;
    public float msToWait = 5000;
    public Text chestTimer;
    public Animator BaseGiftAlert;

    private bool alertStatus;
    public Text chestText;

    void Start()
    {
        CheckSceneAndSetTrigger();

        open_state = false;
        exit_window_open = false;
        coinNumTxt = coinNum.GetComponent<Text>();
        numOfLivesTxt = numOfLives.GetComponent<Text>();
        chestText = chestButton.GetComponentInChildren<Text>();

        UpdateIconAndSound_SFX();
        UpdateIconAndSound_BG();

        //SetBGMusicVolume(PlayerPrefs.GetFloat("MusicVolume", 0));
        //SetSFXvolume(PlayerPrefs.GetFloat("SFXVolume", 0));

        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0);

        lastChestOpen = ulong.Parse(PlayerPrefs.GetString("LastChestOpen"));
        alertStatus = false;

        if (!IsChestReady())
        {
            chestButton.interactable = false;
            chestText.text = "Not Ready";
        }
    }

    void Update()
    {
        coinNumTxt.text = PlayerPrefs.GetInt("coins").ToString();
        numOfLivesTxt.text = PlayerPrefs.GetInt("playerHealth", 4).ToString();

        if (!chestButton.IsInteractable())
        {
            if (IsChestReady())
            {
                chestButton.interactable = true;
                return;
            }

            alertStatus = false;
            // Set the timer
            ulong diff = ((ulong)DateTime.Now.Ticks - lastChestOpen);
            ulong m = diff / TimeSpan.TicksPerMillisecond;

            float secondsLeft = (float)(msToWait - m) / 1000.0f;

            string r = "";
            // Hours
            r += ((int)secondsLeft / 3600).ToString() + "h ";
            secondsLeft -= ((int)secondsLeft / 3600) * 3600;
            // Minutes
            r += ((int)secondsLeft / 60).ToString("00") + "m ";
            // Seconds
            r += (secondsLeft % 60).ToString("00") + "s"; ;
            chestTimer.fontSize = 61;
            chestTimer.text = r;
        }

        if (alertStatus)
        {
            BaseGiftAlert.SetTrigger("rewardReady");
        }

        if (!IsChestReady())
        {
            chestText.text = "Not Ready";
        }
           

    }

    private void OnDisable()
    {
        float musicVolume = 0;
        float sfxVolume = 0;

        audioMixer.GetFloat("MusicVolume", out musicVolume);
        audioMixer.GetFloat("SFXVolume", out sfxVolume);

        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
        PlayerPrefs.Save();
    }

    private void CheckSceneAndSetTrigger()
    {
        if(SceneManager.GetActiveScene().name == "MainShop")
        {
            anime.SetTrigger("openShopAddOn");
        }
    }

    public void GoBack() {

        if(SecondBaseShop.activeSelf == true)
        {
            SecondBaseShop.SetActive(false);
            anime.SetTrigger("closeShopAddOn");
            open_state = false;
            mainMenuSoundManager.back_Click = true;
            return;
        }

        else if (SoundMixer.activeSelf == true) {
            SoundMixer.SetActive(false);
            mainMenuSoundManager.back_Click = true;
            return;
        }
        else if(Settings.activeSelf == true && SoundMixer.activeSelf == false) {
            Settings.SetActive(false);
            mainMenuSoundManager.back_Click = true;
            return;
        }     
        else {
            Fader.GetComponent<GoPlay>().FadeToSpecificLevel("BeforeIntro");
            //swuush sound
            mainMenuSoundManager.other_Click = true;
        }

    }

    public void ShopCategories()
    {
        mainMenuSoundManager.other_Click = true;
        anime.SetTrigger("openShopAddOn");
        SecondBaseShop.SetActive(true);
        open_state = true;
       
    }

    public void OpenLaserShop()
    {
        mainMenuSoundManager.other_Click = true;
        Fader.GetComponent<GoPlay>().OpenLaserShop();
    }

    public void OpenChest()
    {
        //check coin availability 
        if(PlayerPrefs.GetInt("coins") >= priceOfChest)
        {
            //play sound
            mainMenuSoundManager.chestOpen_Click = true;

            chestAnime.SetTrigger("openChestMenu");
            for (int i = 0; i < 1; i++)
            {
                int coins = PlayerPrefs.GetInt("coins");
                coins -= priceOfChest;
                PlayerPrefs.SetInt("coins", coins);
            }
        }
        else
        {
            //play sound
            mainMenuSoundManager.chestDenied_Click = true;
            //Debug.Log("Cannot Buy...");
            return;
        }

    }

    public void show_Exit_UI()
    {
        mainMenuSoundManager.exit_Click = true;
        anime_Exit.SetTrigger("darkenExit");
        exit_window_open = true;
    }

    public void option_No()
    {
        if (exit_window_open)
        {
            //other sound
            mainMenuSoundManager.other_Click = true;
            anime_Exit.SetTrigger("closeDarkenExit");
            exit_window_open = false;
        }

    }

    public void option_Yes()
    {
        //Debug.Log("Application is closing..");
        mainMenuSoundManager.exit_Click = true;
        Application.Quit();
    }

    public void FlyAwayCard()
    {
        //reset
        cardAnime.SetTrigger("OffYouGo");
    }

    public void RewardVideo()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResult });
           
        }
    }

    private void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:             
                int health = PlayerPrefs.GetInt("playerHealth");
                health += 1;
                PlayerPrefs.SetInt("playerHealth", health);
                break;
            case ShowResult.Skipped:
                Debug.Log("Ad was skipped");
                break;           
        }
    }

    public void PlayLastLevel()
    {
        mainMenuSoundManager.play_Click = true;
        GoPlay go = Fader.GetComponent<GoPlay>();
        go.GoToLastPlayedLevel();
    }

    public void GoToLevels()
    {
        mainMenuSoundManager.levels_Click = true;
        GoPlay go = Fader.GetComponent<GoPlay>();
        go.OpenLevels();
    }

    public void toggleBGmusic()
    {
        if(PlayerPrefs.GetInt("MutedBG", 0) == 0)
        {
            //bg music is on
            PlayerPrefs.SetInt("MutedBG", 1);
        }
        else
        {
            //it is off
            PlayerPrefs.SetInt("MutedBG", 0);
        }
    }

    public void toggleSoundFX()
    {
        if (PlayerPrefs.GetInt("MutedSFX", 0) == 0)
        {
            //SFX --> ON
            PlayerPrefs.SetInt("MutedSFX", 1);
        }
        else
        {
            //SFX --> OFF
            PlayerPrefs.SetInt("MutedSFX", 0);
        }
    }

    public void UpdateIconAndSound_BG()
    {
        if(PlayerPrefs.GetInt("MutedBG", 0) == 0)
        {
            //change image sprite
            music_btn.sprite = musicON;
            //activate bg music volume
            audioMixer.SetFloat("MusicVolume", VolumeToNormal(0));
        }
        else
        {
            music_btn.sprite = musicOFF;
            //mute audio for bg music
            audioMixer.SetFloat("MusicVolume", VolumeToZero());
        }
    }

    public void UpdateIconAndSound_SFX()
    {
        if (PlayerPrefs.GetInt("MutedSFX", 0) == 0)
        {
            //change image sprite
            sound_btn.sprite = soundON;
            //set volume off SFX to normal
            audioMixer.SetFloat("SFXVolume", VolumeToNormal(1));
        }
        else
        {
            sound_btn.sprite = soundOFF;
            //mute audio for SFX
            audioMixer.SetFloat("SFXVolume", VolumeToZero());
        }
    }

    public void toggleBGmusic_clickEvent()
    {
        toggleBGmusic();
        UpdateIconAndSound_BG();
    }

    public void toggleSFX_clickEvent()
    {
        toggleSoundFX();
        UpdateIconAndSound_SFX();
    }

    float VolumeToZero()
    {
        return -80f;
    }

    float VolumeToNormal(int option)
    {
        float val = (option == 0) ? val = 0 : val = 0;
        //Debug.Log(val);
        return val;
    }


    //SLIDER CONTROLLER
    public void SetBGMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void SetSFXvolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
    }

    //REWARD SYSTEM
    private bool IsChestReady()
    {     
        ulong diff = ((ulong)DateTime.Now.Ticks - lastChestOpen);
        ulong m = diff / TimeSpan.TicksPerMillisecond;

        float secondsLeft = (float)(msToWait - m) / 1000.0f;

        if (secondsLeft < 0)
        {
            chestTimer.fontSize = 37;
            chestTimer.text = "Collect your reward!";
            chestText.text = "Open";
            alertStatus = true;
            return true;
        }

        return false;      
    }
  

    #region Snippets

    ////if it is open --> close else open
    //if (open_state)
    //{
    //    anime.SetTrigger("closeShopAddOn");
    //    open_state = false;
    //}
    //else
    //{
    //    anime.SetTrigger("openShopAddOn");
    //    SecondBaseShop.SetActive(true);
    //    open_state = true;
    //}
    #endregion
}
