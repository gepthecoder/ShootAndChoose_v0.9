using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class audioManager : MonoBehaviour
{

    #region BG Music
    public AudioClip startLevelClip;
    public AudioSource startLevelSource;

    public AudioClip _arcadeFantasy; //level 1-4
    public AudioClip _puzzleDreams; //level 5-9
    public AudioClip _creepingBob; //level 10-14
    public AudioClip _defendingPrincess; //level 15-19
    public AudioClip _steamTechMayhem; //level 20
    public AudioClip _urbanJungle; //level 21

    public AudioSource backGroundMusic;
    private int amountOfLevels = 21;

    private IEnumerator waitAndPlayBG_music()
    {
        yield return new WaitForSeconds(0.3f);
        LevelStartSound(startLevelSource, startLevelClip);
        yield return new WaitForSeconds(2f);
        backGroundMusic.Play();
    }

    private void LevelStartSound(AudioSource aSource, AudioClip aClip)
    {
        aSource.volume = .1f;
        aSource.PlayOneShot(aClip);
        Debug.Log("Game Started!");
    }

    private void setBG_audio()
    {
        for (int i = 1; i <= amountOfLevels; i++)
        {
            if (SceneManager.GetActiveScene().name == "Level"+ i)
            {
               if(i <= 4)
                {
                    //playsound
                    backGroundMusic.clip = _arcadeFantasy;
                    backGroundMusic.volume = 0.1f;
                    StartCoroutine(waitAndPlayBG_music());
                }else if (i > 4 && i <= 9)
                {
                    //playsound
                    backGroundMusic.clip = _puzzleDreams;
                    backGroundMusic.volume = 0.1f;
                    StartCoroutine(waitAndPlayBG_music());
                }
                else if(i > 9 && i <= 14)
                {
                    //playsound
                    backGroundMusic.clip = _creepingBob;
                    backGroundMusic.volume = 0.1f;
                    StartCoroutine(waitAndPlayBG_music());
                }
                else if (i > 14 && i <= 19)
                {
                    //playsound
                    backGroundMusic.clip = _defendingPrincess;
                    backGroundMusic.volume = 0.1f;
                    StartCoroutine(waitAndPlayBG_music());
                }
                else if (i == 20)
                {
                    //playsound
                    backGroundMusic.clip = _steamTechMayhem;
                    backGroundMusic.volume = 0.1f;
                    StartCoroutine(waitAndPlayBG_music());
                }
                else if (i == 21)
                {
                    //playsound
                    backGroundMusic.clip = _urbanJungle;
                    backGroundMusic.volume = 0.1f;
                    StartCoroutine(waitAndPlayBG_music());
                }
            }
        }  
    }
    #endregion

    #region GameSoundFX

    #region PlatformArrived
    public AudioSource PlatformArrivedASource;
    public AudioClip platformArrivedClip;

    #region Static Values
    public static bool PlatformHasArrived;
    public static bool PlatformHasArrived1;
    public static bool PlatformHasArrived2;
    public static bool PlatformHasArrived3;
    public static bool PlatformHasArrived4;
    public static bool PlatformHasArrived5;
    public static bool PlatformHasArrived6;
    public static bool PlatformHasArrived7;
    public static bool PlatformHasArrived8;
    public static bool PlatformHasArrived9;
    public static bool PlatformHasArrived10;
    public static bool PlatformHasArrived11;
    public static bool PlatformHasArrived12;
    public static bool PlatformHasArrived13;
    public static bool PlatformHasArrived14;
    public static bool PlatformHasArrived15;
    public static bool PlatformHasArrived16;
    public static bool PlatformHasArrived17;
    public static bool PlatformHasArrived18;
    public static bool PlatformHasArrived19;
    public static bool PlatformHasArrived20;
    public static bool PlatformHasArrived21;
    public static bool PlatformHasArrived22;
    public static bool PlatformHasArrived23;
    public static bool PlatformHasArrived24;
    public static bool PlatformHasArrived25;
    public static bool PlatformHasArrived26;
    public static bool PlatformHasArrived27;
    public static bool PlatformHasArrived28;
    public static bool PlatformHasArrived29;
    public static bool PlatformHasArrived30;
    public static bool PlatformHasArrived31;
    public static bool PlatformHasArrived32;
    public static bool PlatformHasArrived33;
    public static bool PlatformHasArrived34;
    public static bool PlatformHasArrived35;
    public static bool PlatformHasArrived36;
    public static bool PlatformHasArrived37;
    public static bool PlatformHasArrived38;
    public static bool PlatformHasArrived39;
    public static bool PlatformHasArrived40;
    public static bool PlatformHasArrived41;
    public static bool PlatformHasArrived42;
    public static bool PlatformHasArrived43;
    public static bool PlatformHasArrived44;
    public static bool PlatformHasArrived45;
    public static bool PlatformHasArrived46;
    public static bool PlatformHasArrived47;
    public static bool PlatformHasArrived48;
    #endregion

    #region Values
    public static int playOnce;
    public static int playOnce1;
    public static int playOnce2;
    public static int playOnce3;
    public static int playOnce4;
    public static int playOnce5;
    public static int playOnce6;
    public static int playOnce7;
    public static int playOnce8;
    public static int playOnce9;
    public static int playOnce10;
    public static int playOnce11;
    public static int playOnce12;
    public static int playOnce13;
    public static int playOnce14;
    public static int playOnce15;
    public static int playOnce16;
    public static int playOnce17;
    public static int playOnce18;
    public static int playOnce19;
    public static int playOnce20;
    public static int playOnce21;
    public static int playOnce22;
    public static int playOnce23;
    public static int playOnce24;
    public static int playOnce25;
    public static int playOnce26;
    public static int playOnce27;
    public static int playOnce28;
    public static int playOnce29;
    public static int playOnce30;
    public static int playOnce31;
    public static int playOnce32;
    public static int playOnce33;
    public static int playOnce34;
    public static int playOnce35;
    public static int playOnce36;
    public static int playOnce37;
    public static int playOnce38;
    public static int playOnce39;
    public static int playOnce40;
    public static int playOnce41;
    public static int playOnce42;
    public static int playOnce43;
    public static int playOnce44;
    public static int playOnce45;
    public static int playOnce46;
    public static int playOnce47;
    public static int playOnce48;
    #endregion

    private void set_playOnceToDefault()
    {
        playOnce = 0;
        playOnce1 = 0;
        playOnce2 = 0;
        playOnce3 = 0;
        playOnce4 = 0;
        playOnce5 = 0;
        playOnce6 = 0;
        playOnce7 = 0;
        playOnce8 = 0;
        playOnce9 = 0;
        playOnce10 = 0;
        playOnce11 = 0;
        playOnce12 = 0;
        playOnce13 = 0;
        playOnce14 = 0;
        playOnce15 = 0;
        playOnce16 = 0;
        playOnce17 = 0;
        playOnce18 = 0;
        playOnce19 = 0;
        playOnce20 = 0;
        playOnce21 = 0;
        playOnce22 = 0;
        playOnce23 = 0;
        playOnce24 = 0;
        playOnce25 = 0;
        playOnce26 = 0;
        playOnce27 = 0;
        playOnce28 = 0;
        playOnce29 = 0;
        playOnce30 = 0;
        playOnce31 = 0;
        playOnce32 = 0;
        playOnce33 = 0;
        playOnce34 = 0;
        playOnce35 = 0;
        playOnce36 = 0;
        playOnce37 = 0;
        playOnce38 = 0;
        playOnce39 = 0;
        playOnce40 = 0;
        playOnce41 = 0;
        playOnce42 = 0;
        playOnce43 = 0;
        playOnce44 = 0;
        playOnce45 = 0;
        playOnce46 = 0;
        playOnce47 = 0;
        playOnce48 = 0;

    }

    private IEnumerator WaitAndPlayOneShot()
    {
        yield return new WaitForSeconds(1.5f);
        PlatformArrivedASource.PlayOneShot(platformArrivedClip);
    }

    public void setPlatformArrived_audio()
    {
        if (PlatformHasArrived && playOnce == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived = false;
            playOnce++;
        }else if (PlatformHasArrived1 && playOnce1 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived1 = false;
            playOnce1++;
        }
        else if (PlatformHasArrived2 && playOnce2 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived2 = false;
            playOnce2++;
        }
        else if (PlatformHasArrived3 && playOnce3 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived3 = false;
            playOnce3++;
        }
        else if (PlatformHasArrived4 && playOnce4 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived4 = false;
            playOnce4++;
        }
        else if (PlatformHasArrived5 && playOnce5 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived5 = false;
            playOnce5++;
        }
        else if (PlatformHasArrived6 && playOnce6 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived6 = false;
            playOnce6++;
        }
        else if (PlatformHasArrived7 && playOnce7 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived7 = false;
            playOnce7++;
        }
        else if (PlatformHasArrived8 && playOnce8 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived8 = false;
            playOnce8++;
        }
        else if (PlatformHasArrived9 && playOnce9 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived9 = false;
            playOnce9++;
        }
        else if (PlatformHasArrived10 && playOnce10 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived10 = false;
            playOnce10++;
        }
        else if (PlatformHasArrived11 && playOnce11 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived11 = false;
            playOnce11++;
        }
        else if (PlatformHasArrived12 && playOnce12 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived12 = false;
            playOnce12++;
        }
        else if (PlatformHasArrived13 && playOnce13 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived13 = false;
            playOnce13++;
        }
        else if (PlatformHasArrived14 && playOnce14 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived14 = false;
            playOnce14++;
        }
        else if (PlatformHasArrived15 && playOnce15 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived15 = false;
            playOnce15++;
        }
        else if (PlatformHasArrived16 && playOnce16 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived16 = false;
            playOnce16++;
        }
        else if (PlatformHasArrived17 && playOnce17 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived17 = false;
            playOnce17++;
        }
        else if (PlatformHasArrived18 && playOnce18 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived18 = false;
            playOnce18++;
        }
        else if (PlatformHasArrived19 && playOnce19 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived19 = false;
            playOnce19++;
        }
        else if (PlatformHasArrived20 && playOnce20 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived20 = false;
            playOnce20++;
        }
        else if (PlatformHasArrived21 && playOnce21 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived21 = false;
            playOnce21++;
        }
        else if (PlatformHasArrived22 && playOnce22 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived22 = false;
            playOnce22++;
        }
        else if (PlatformHasArrived23 && playOnce23 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived23 = false;
            playOnce23++;
        }
        else if (PlatformHasArrived24 && playOnce24 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived24 = false;
            playOnce24++;
        }
        else if (PlatformHasArrived25 && playOnce25 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived25 = false;
            playOnce25++;
        }
        else if (PlatformHasArrived26 && playOnce26 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived26 = false;
            playOnce26++;
        }
        else if (PlatformHasArrived27 && playOnce27 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived27 = false;
            playOnce27++;
        }
        else if (PlatformHasArrived28 && playOnce28 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived28 = false;
            playOnce28++;
        }
        else if (PlatformHasArrived29 && playOnce29 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived29 = false;
            playOnce29++;
        }
        else if (PlatformHasArrived30 && playOnce30 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived30 = false;
            playOnce30++;
        }
        else if (PlatformHasArrived31 && playOnce31 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived31 = false;
            playOnce31++;
        }
        else if (PlatformHasArrived32 && playOnce32 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived32 = false;
            playOnce32++;
        }
        else if (PlatformHasArrived33 && playOnce33 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived33 = false;
            playOnce33++;
        }
        else if (PlatformHasArrived34 && playOnce34 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived34 = false;
            playOnce34++;
        }
        else if (PlatformHasArrived35 && playOnce35 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived35 = false;
            playOnce35++;
        }
        else if (PlatformHasArrived36 && playOnce36 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived36 = false;
            playOnce36++;
        }
        else if (PlatformHasArrived37 && playOnce37 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived37 = false;
            playOnce37++;
        }
        else if (PlatformHasArrived38 && playOnce38 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived38 = false;
            playOnce38++;
        }
        else if (PlatformHasArrived39 && playOnce39 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived39 = false;
            playOnce39++;
        }
        else if (PlatformHasArrived40 && playOnce40 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived40 = false;
            playOnce40++;
        }
        else if (PlatformHasArrived41 && playOnce41 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived41 = false;
            playOnce41++;
        }
        else if (PlatformHasArrived42 && playOnce42 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived42 = false;
            playOnce42++;
        }
        else if (PlatformHasArrived43 && playOnce43 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived43 = false;
            playOnce43++;
        }
        else if (PlatformHasArrived44 && playOnce44 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived44 = false;
            playOnce44++;
        }
        else if (PlatformHasArrived45 && playOnce45 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived45 = false;
            playOnce45++;
        }
        else if (PlatformHasArrived46 && playOnce46 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived46 = false;
            playOnce46++;
        }
        else if (PlatformHasArrived47 && playOnce47 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived47 = false;
            playOnce47++;
        }
        else if (PlatformHasArrived48 && playOnce48 == 0)
        {
            StartCoroutine(WaitAndPlayOneShot());
            PlatformHasArrived48 = false;
            playOnce48++;
        }
     
    }
    #endregion

    #region MultiplyerEffect

    public AudioSource multiplyASource;
    public AudioClip queBodUp;

    public static bool multiply;

    public void setMultiply_audio()
    {
        if (multiply)
        {
            Debug.Log("multiplied!!!");
            multiplyASource.PlayOneShot(queBodUp);
            multiply = false;
            StartCoroutine(waitXthenResetVolume(1.5f));
        }
    }

    private IEnumerator waitXthenResetVolume(float X)
    {
        yield return new WaitForSeconds(X);
        backGroundMusic.volume = 0.2f;

    }

    private void setMultiplySettings(bool bin)
    {
        multiply = bin;
    }

    #endregion

    #region ChestEffect

    public static bool chestSoundPlay;
    public static bool clickOnCardPlay;

    public AudioSource chestASource;

    public AudioClip chestAClip;
    public AudioClip clickOnCard;

    private void setChestSoundPlay_audio(bool bin)
    {
        chestSoundPlay = bin;
    }

    private void ConfigureChestSound(bool playSound)
    {
        if (playSound)
        {
            StartCoroutine(playWithDelay(0.5f));
            chestSoundPlay = false;

        }
    }

    private IEnumerator playWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        chestASource.PlayOneShot(chestAClip);
    }

    private void manageClickOnCard(bool play)
    {
        if (play)
        {
            chestASource.PlayOneShot(clickOnCard);
            clickOnCardPlay = false;
        }
    }

    private void setClickOnCard_audio(bool bin)
    {
        clickOnCardPlay = bin;
    }

    #endregion

    #region ExtraLife

    public static bool giveExtraLife;

    public AudioSource extraLifeASource;
    public AudioClip extraLife_audio;

    float delayTime = 0.35f;

    float playSoundOnce = 0;

    private void HandleExtraLife_audio(bool extraLife)
    {
        if (extraLife && playSoundOnce == 0)
        {
            StartCoroutine(pauseAndExecute(delayTime));
            extraLife = false;
            playSoundOnce++;
        }
    }

    private IEnumerator pauseAndExecute(float timeToExecute)
    {
        yield return new WaitForSeconds(timeToExecute);
        extraLifeASource.PlayOneShot(extraLife_audio);
    }

    private void setGiveExtraLife(bool val)
    {
        giveExtraLife = val;
    }

    #endregion

    #region ScorePointsEffect

    public static bool scoreEffect;

    public AudioSource scoreASource;
    public AudioClip scoreEffectClip;

    private void setScoreEffect_var(bool bin)
    {
        scoreEffect = bin;
    }

    private void playScoreEffect_audio(bool playEffect)
    {
        if (playEffect)
        {
            StartCoroutine(waitAndExecute(0.45f));
            scoreEffect = false;
        }

    }

    private IEnumerator waitAndExecute(float time)
    {
        yield return new WaitForSeconds(time);
        scoreASource.PlayOneShot(scoreEffectClip);
    }

    #endregion

    #region GetMoreLives

    public static bool getMoreLives_click;

    public AudioSource canvasASource;
    public AudioClip clickEffect_clip;

    private void setGetMoreLives(bool bin)
    {
        getMoreLives_click = bin;
    }

    private void handleGetMoreLivesEffect_audio(bool getMoreLives)
    {
        if (getMoreLives)
        {
            canvasASource.PlayOneShot(clickEffect_clip);
            getMoreLives_click = false;
        }
    }

    #endregion

    #region ClickFunctions


    public AudioSource clickAudioSource;
    public AudioClip clickSound;

    public static bool purchaseHappend;
    public static bool purchaseDeclined;

    public AudioClip purchaseSound;
    public AudioClip purchaseDeclinedSound;

    public void PlayAudio_click()
    {
        clickAudioSource.PlayOneShot(clickSound);
    }

    public void BuySound()
    {
        if (purchaseHappend)
        {
            canvasASource.PlayOneShot(purchaseSound);
            purchaseHappend = false;
        }
    }

    public void YouAintGotNoMoneySound()
    {
        if (purchaseDeclined)
        {
            canvasASource.PlayOneShot(purchaseDeclinedSound);
            purchaseDeclined = false;
        }
    }

    private void setPurchaseHappend(bool val)
    {
        purchaseHappend = val;
        purchaseDeclined = val;
    }


    #endregion

    #region EnemyAttck

    public static bool canPlaySound_punch;
    private AudioSource enemyAsource;
    public AudioClip enemyAclip;


    private void setCanPlaySound_audio(bool bin)
    {
        canPlaySound_punch = bin;
    }

    private void HandlePunchSound_audio(bool canPlaySound)
    {
        if (canPlaySound)
        {
            StartCoroutine(waitAndPlayPunchSound(EnemyAttck.enemyAttck.potentialEnemy()));
            canPlaySound_punch = false;
        }
    }

    private IEnumerator waitAndPlayPunchSound(GameObject potentialEnemy)
    {    
        yield return new WaitForSeconds(1.5f);
        enemyAsource = potentialEnemy.GetComponent<AudioSource>();
        enemyAsource.PlayOneShot(enemyAclip);
        
    }

    #endregion

   

    #endregion

    void Awake()
    {
        setBG_audio();
    }

    void Start()
    {
        set_playOnceToDefault();
        setMultiplySettings(false);
        setChestSoundPlay_audio(false);
        setClickOnCard_audio(false);
        setScoreEffect_var(false);
        setGiveExtraLife(false);
        setGetMoreLives(false);
        setPurchaseHappend(false);
        //setCanPlaySound_audio(false);
    }

    void Update()
    {
        setPlatformArrived_audio();
        setMultiply_audio();
        ConfigureChestSound(chestSoundPlay);
        manageClickOnCard(clickOnCardPlay);
        playScoreEffect_audio(scoreEffect);
        HandleExtraLife_audio(giveExtraLife);
        handleGetMoreLivesEffect_audio(getMoreLives_click);
        BuySound();
        YouAintGotNoMoneySound();
        //HandlePunchSound_audio(canPlaySound_punch);
    }


}
