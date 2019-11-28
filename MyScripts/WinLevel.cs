using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class WinLevel : MonoBehaviour
{
    public static bool display;

    public GoPlay fader;

    public Animator openChestAnime;
    public Animator fadeLevelCompleted;
    public Animator LevelCompleteUI;

    public Shoot Shooting;

    public ParticleSystem fireWorks1;
    public ParticleSystem fireWorks2;

    public AudioClip winLevelSound;
    private AudioSource aSource;

    public PlayerHealth health;

    private int playSoundAttempts;

    public Button chest;
    public Button extraLife;

    private AudioSource bgMusicAS;

    void Start()
    {
        playSoundAttempts = 0;
        aSource = GetComponent<AudioSource>();
        bgMusicAS = GameObject.FindGameObjectWithTag("BGMusic").GetComponent<AudioSource>();
        
    }

    void Update()
    {
        if (MoveUpwards.levelCompleted)
        {
            ScoreManager.trigger = true;
            //PlayAnimations for opening WinLevelUI
            fadeLevelCompleted.SetTrigger("levelCompleted");
            LevelCompleteUI.SetTrigger("MoveUI");
            //DISABLE SHOOTING
            Shooting.enabled = false;
            //lower bg music audio
            bgMusicAS.volume = .05f;
            Debug.Log("player shooting is off");
            StartCoroutine(ShootFireworks());
            StartCoroutine(ShowCaseStars());

            if (playSoundAttempts == 0)
            {
                int a3 = PlayerPrefs.GetInt("a3", 1);
                PlayerPrefs.SetInt("a3", a3 + 1);
                Debug.Log("Level won!" + " nextLevel:" + PlayerPrefs.GetInt("a3") + " /t level to reach:" + a3 + 1);
                PlayWinSound();
            }
        }
    }



    public void PlayAnimationOpenChest()
     {
         openChestAnime.SetTrigger("open");
         extraLife.enabled = false;
         audioManager.chestSoundPlay = true;
     }

    private IEnumerator ShootFireworks()
    {
        yield return new WaitForSeconds(1f);
        fireWorks1.Play();
        fireWorks2.Play();

        yield return new WaitForSeconds(1f);
        fireWorks1.Stop();
        fireWorks2.Stop();
    }

    private void PlayWinSound()
    {
        aSource.PlayOneShot(winLevelSound);
        playSoundAttempts++;
    }

    public void NextLevelPlease()
    {
        audioManager.clickOnCardPlay = true;
        PlayAds_levelComplited();
      
    }

    public Animator extraLifeAnime;

    public void ExtraLifeYeeaBoy()
    {
        health.playerHealth += 1;
        health.SavePlayerHealth();
        audioManager.giveExtraLife = true;
        extraLifeAnime.SetTrigger("extraLife");
        chest.enabled = false;

    }

    IEnumerator ShowCaseStars()
    {
        yield return new WaitForSeconds(2f);
        display = true;
    }

    public void PlayAds_levelComplited()
    {
        if(PlayerPrefs.GetInt("boughtNoAds", 0) == 0)
        {
            if (Advertisement.IsReady("rewardedVideo"))
            {
                Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResult });

            }
        }
       
    }

    private void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                fader.OpenLevels();
                break;
            case ShowResult.Skipped:
                fader.OpenLevels();
                break;
            case ShowResult.Failed:
                Debug.Log("Ad failed to load! Check internet connection!");
                break;
        }
    }

}
