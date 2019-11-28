using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Manager : MonoBehaviour
{
    public static int scoreValue;

    public Animator multiplyAnime;
    private Text multiplyText;

    public GameObject hitScoreParent;
    public Text hitScoreText;

    public Transform leftPosForScoreTxt;
    public Transform rightPosForScoreTxt;

    private Transform ScorePosition;

    private string popUpValueCactus;

    private int streak2 = 0;
    private int streak4 = 0;
    private int streak6 = 0;
    private int streak8 = 0;
    private int streak10 = 0;
    private int streak14 = 0;
    private int streak18 = 0;
    private int streak22 = 0;
    private int streak26 = 0;
    private int streak30 = 0;
    private int streak35 = 0;
    private int streak40 = 0;


    private int multiplierx2 = 2;
    private int multiplierx4 = 4;
    private int multiplierx6 = 6;
    private int multiplierx8 = 8;
    private int multiplierx10 = 10;

    //last played scene
    private string currentScene;
    public string lastScene;


    public static bool activateScorePoints;


    void Awake()
    {
        if (PlayerPrefs.HasKey("lastScene"))
        {
            lastScene = PlayerPrefs.GetString("lastScene");
        }
        else
        {
            currentScene = SceneManager.GetActiveScene().name;
            lastScene = currentScene;
            PlayerPrefs.SetString("lastScene", lastScene);
        }

    }

    void Start()
    {
        multiplyText = multiplyAnime.GetComponent<Text>();
        hitScoreParent.SetActive(false);
        scoreValue = 0;

    }

    void Update()
    {
        ManageScoreValue();

        CheckPosition();

        if (activateScorePoints)
        {
            hitScoreParent.SetActive(true);
            hitScoreParent.GetComponentInChildren<Animator>().SetTrigger("score");
            hitScoreText.text = "+" + Shoot.scorePoints.ToString();
            hitScoreParent.transform.position = ScorePosition.position;
            audioManager.scoreEffect = true;
            activateScorePoints = false;

        }
    }

    private void CheckPosition()
    {
        if (Shoot.LeftShotHit)
        {
            ScorePosition = leftPosForScoreTxt;
            Shoot.LeftShotHit = false;
        }
        else if (Shoot.RightShotHit)
        {
            ScorePosition = rightPosForScoreTxt;
            Shoot.RightShotHit = false;
        }

    }

    private void ManageScoreValue()
    {
        //ATOMIC MISSILE LAUNCHER
        #region Atomic Launcher
        if(PlayerPrefs.GetInt("currentWeaponIndex") == 0)
        {
            multiplyText.text = "x2";

            if (Shoot.killStreak == 0)
            {
                Shoot.scorePoints = PlayerPrefs.GetInt("atomicDamage");
            }
            else if (Shoot.killStreak == 2 && streak2 == 0)
            {
                Shoot.scorePoints *= multiplierx2;
                multiplyAnime.SetTrigger("multiply");
                audioManager.multiply = true;
                Shoot.IncreaseSpeedOfLauncher = true;
                Shoot.diffSoundEffect = true;

                streak2++;
            }
            else if (Shoot.killStreak == 4 && streak4 == 0)
            {
                Shoot.scorePoints *= multiplierx2;
                multiplyAnime.SetTrigger("multiply");
                audioManager.multiply = true;
                Shoot.IncreaseSpeedOfLauncher = true;
                Shoot.diffSoundEffect = true;


                streak4++;
            }
            else if (Shoot.killStreak == 6 && streak6 == 0)
            {
                Shoot.scorePoints *= multiplierx2;
                multiplyAnime.SetTrigger("multiply");
                audioManager.multiply = true;
                Shoot.IncreaseSpeedOfLauncher = true;
                Shoot.diffSoundEffect = true;


                streak6++;
            }
            else if (Shoot.killStreak == 8 && streak8 == 0)
            {
                Shoot.scorePoints *= multiplierx2;
                multiplyAnime.SetTrigger("multiply");
                audioManager.multiply = true;
                Shoot.IncreaseSpeedOfLauncher = true;
                Shoot.diffSoundEffect = true;


                streak8++;
            }
            else if (Shoot.killStreak == 10 && streak10 == 0)
            {
                Shoot.scorePoints *= multiplierx2;
                multiplyAnime.SetTrigger("multiply");
                audioManager.multiply = true;
                Shoot.IncreaseSpeedOfLauncher = true;
                Shoot.diffSoundEffect = true;

                streak10++;
            }
            else if (Shoot.killStreak == 14 && streak14 == 0)
            {
                Shoot.scorePoints *= multiplierx2;
                multiplyAnime.SetTrigger("multiply");
                audioManager.multiply = true;
                Shoot.IncreaseSpeedOfLauncher = true;
                Shoot.diffSoundEffect = true;

                streak14++;
            }
            else if (Shoot.killStreak == 18 && streak18 == 0)
            {
                Shoot.scorePoints *= multiplierx2;
                multiplyAnime.SetTrigger("multiply");
                audioManager.multiply = true;
                Shoot.IncreaseSpeedOfLauncher = true;
                Shoot.diffSoundEffect = true;

                streak18++;
            }
            else if (Shoot.killStreak == 22 && streak22 == 0)
            {
                Shoot.scorePoints *= multiplierx2;
                multiplyAnime.SetTrigger("multiply");
                audioManager.multiply = true;
                Shoot.IncreaseSpeedOfLauncher = true;
                Shoot.diffSoundEffect = true;

                streak22++;
            }
            else if (Shoot.killStreak == 26 && streak26 == 0)
            {
                Shoot.scorePoints *= multiplierx2;
                multiplyAnime.SetTrigger("multiply");
                audioManager.multiply = true;
                Shoot.IncreaseSpeedOfLauncher = true;
                Shoot.diffSoundEffect = true;

                streak26++;
            }
            else if (Shoot.killStreak == 30 && streak30 == 0)
            {
                Shoot.scorePoints *= multiplierx2;
                multiplyAnime.SetTrigger("multiply");
                audioManager.multiply = true;
                Shoot.IncreaseSpeedOfLauncher = true;
                Shoot.diffSoundEffect = true;

                streak30++;
            }
            else if (Shoot.killStreak == 35 && streak35 == 0)
            {
                Shoot.scorePoints *= multiplierx2;
                multiplyAnime.SetTrigger("multiply");
                audioManager.multiply = true;
                Shoot.IncreaseSpeedOfLauncher = true;
                Shoot.diffSoundEffect = true;

                streak35++;
            }
            else if (Shoot.killStreak == 40 && streak40 == 0)
            {
                Shoot.scorePoints *= multiplierx2;
                multiplyAnime.SetTrigger("multiply");
                audioManager.multiply = true;
                Shoot.IncreaseSpeedOfLauncher = true;
                Shoot.diffSoundEffect = true;

                streak40++;
            }
        }
        #endregion

        //TRIPLE THREAD MISSILE LAUNCHER
        #region Triple Launcher
        else if (PlayerPrefs.GetInt("currentWeaponIndex") == 1)
        {
            multiplyText.text = "x2";

            if (Shoot.killStreak == 0)
            {
                Shoot.scorePoints = PlayerPrefs.GetInt("tripleDamage"); ;
            }
            else if (Shoot.killStreak == 2 && streak2 == 0)
            {
                Shoot.scorePoints *= multiplierx2;
                multiplyAnime.SetTrigger("multiply");
                streak2++;
            }
            else if (Shoot.killStreak == 4 && streak4 == 0)
            {
                Shoot.scorePoints *= multiplierx2;
                multiplyAnime.SetTrigger("multiply");
                streak4++;
            }
            else if (Shoot.killStreak == 6 && streak6 == 0)
            {
                Shoot.scorePoints *= multiplierx2;
                multiplyAnime.SetTrigger("multiply");
                streak6++;
            }
            else if (Shoot.killStreak == 8 && streak8 == 0)
            {
                Shoot.scorePoints *= multiplierx2;
                multiplyAnime.SetTrigger("multiply");
                streak8++;
            }
            else if (Shoot.killStreak == 10 && streak10 == 0)
            {
                Shoot.scorePoints *= multiplierx2;
                multiplyAnime.SetTrigger("multiply");
                streak10++;
            }
        }
        #endregion

        //SUPER SONIC MISSILE LAUNCHER
        #region Super Sonic Launcher
        else if (PlayerPrefs.GetInt("CurrentLaser") == 2)
        {
            multiplyText.text = "x2";

            if (Shoot.killStreak == 0)
            {
                Shoot.scorePoints = PlayerPrefs.GetInt("atomicDamage");
            }
            else if (Shoot.killStreak == 2 && streak2 == 0)
            {
                Shoot.scorePoints *= multiplierx2;
                multiplyAnime.SetTrigger("multiply");
                streak2++;
            }
            else if (Shoot.killStreak == 4 && streak4 == 0)
            {
                Shoot.scorePoints *= multiplierx2;
                multiplyAnime.SetTrigger("multiply");
                streak4++;
            }
            else if (Shoot.killStreak == 6 && streak6 == 0)
            {
                Shoot.scorePoints *= multiplierx2;
                multiplyAnime.SetTrigger("multiply");
                streak6++;
            }
            else if (Shoot.killStreak == 8 && streak8 == 0)
            {
                Shoot.scorePoints *= multiplierx2;
                multiplyAnime.SetTrigger("multiply");
                streak8++;
            }
            else if (Shoot.killStreak == 10 && streak10 == 0)
            {
                Shoot.scorePoints *= multiplierx2;
                multiplyAnime.SetTrigger("multiply");
                streak10++;
            }
        }
        #endregion
    }

}