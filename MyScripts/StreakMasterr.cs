using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StreakMasterr : MonoBehaviour
{
    public Slider streakMaster;
    private Animator anime;

    public Text longestStreakText;
    public Text multiplierText;

    public int killStreak;
    public int longestStreakValue;

    public int maxStreak;

    void Awake()
    {
        anime = streakMaster.GetComponent<Animator>();
    }

    void Start()
    {
        longestStreakValue = 0;
        SetMaxStreakForLevel(streakMaster);
    }

    void Update()
    {

        killStreak = Shoot.killStreak;

        if(killStreak > longestStreakValue)
        {
            longestStreakValue = killStreak;
            //if(longestStreakValue > gameStats.Instance.bestKillStreak)
            //{
            //    gameStats.Instance.bestKillStreak = longestStreakValue;
            //    gameStats.Instance.Save();
            //}
        }

        StreakMasterFX();

        streakMaster.value = killStreak;

        multiplierText.text = killStreak.ToString();
        longestStreakText.text = "Streak: " + longestStreakValue.ToString();


    }

    int a;
    int b;
    int c;

    private void SetAmountOfEfficiency(string level)
    {
        if(level == "Level1")
        {
            a = 5;
            b = 8;
            c = 10;
        }else if (level == "Level2")
        {
            a = 9;
            b = 12;
            c = 14;
        }else if (level == "Level3")
        {
            a = 13;
            b = 16;
            c = 20;
        }else if(level == "Level4")
        {
            a = 19;
            b = 24;
            c = 26;
        }
        else if (level == "Level5")
        {
            a = 25;
            b = 30;
            c = 32;
        }
        else if (level == "Level6")
        {
            a = 29;
            b = 34;
            c = 36;
        }
    }

    private void StreakMasterFX()
    {
        if (killStreak >= a && killStreak < b)
        {
            anime.SetTrigger("streak1");
        }
        else if (killStreak >= b && killStreak < c)
        {
            anime.SetTrigger("streak2");
        }
        else if (killStreak >= c)
        {
            anime.SetTrigger("streak3");
        }
    }

    private void SetMaxStreakForLevel(Slider slider)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        maxStreak = enemies.Length;

        slider.maxValue = maxStreak;   
    }
}
