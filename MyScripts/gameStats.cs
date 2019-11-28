using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameStats : MonoBehaviour
{
    //NEED TO GET INFO ABOUT:
    // - TOTAL KILLS            - CURRENT LEVEL
    // - TOTAL DEATHS           - BEST KILLSTREAK
    // - K/D                    - HIGH SCORE

    #region Texts
    public Text totalKillsTxt;
    public Text totalDeathsTxt;
    public Text killDeathRatioTxt;

    public Text totalHitsTxt;
    public Text totalMissesTxt;
    public Text accuracyTxt;

    public Text currentLevelTxt;
    public Text bestKillStreakTxt;
    public Text highScoreTxt;


  
    #endregion

    public Animator darkenAnime;
    public Animator StatsPanelAnime;

    public GameObject StatsPanelGUI;

    public int totalKills = 0;
    public int totalDeaths = 0; //total lives lost
    public float killDeathRatio = 0;

    public int currentLevel = 1;
    public int bestKillStreak = 0;
    public int highScore = 0;

    public int totalHits = 0;
    public int totalMisses = 0;
    public float accuracy = 0f;


    private static gameStats instance;
    public static gameStats Instance { get { return instance; } }

    private void Awake()
    {
        instance = this;

        if (PlayerPrefs.HasKey("bestKillStreak"))
        {
            //we had a previous session
            totalKills = PlayerPrefs.GetInt("totalKills");
            totalDeaths = PlayerPrefs.GetInt("totalDeaths");
            killDeathRatio = PlayerPrefs.GetFloat("killDeathRatio");

            totalHits = PlayerPrefs.GetInt("totalHits");
            totalMisses = PlayerPrefs.GetInt("totalMisses");
            accuracy = PlayerPrefs.GetInt("accuracy");

            currentLevel = PlayerPrefs.GetInt("currentLevelIndex");
            bestKillStreak = PlayerPrefs.GetInt("bestKillStreak");
            highScore = PlayerPrefs.GetInt("highScore");
        }
        else
        {
            //we have a new game
            Save();
        }
    }

    private void Start()
    {
        darkenAnime.gameObject.SetActive(false);

        //kill/death ratio
        if (Instance.totalDeaths > 0)
        {
            //Debug.Log(killDeathRatio + ",  KD:  " + Instance.totalKills + " / " + Instance.totalDeaths);

            killDeathRatio = Instance.totalKills / Instance.totalDeaths;
            if (killDeathRatio != 0)
                Instance.Save();

        }

        if(Instance.totalMisses > 0)
        {
            accuracy = Instance.totalHits / Instance.totalMisses;
            if (accuracy != 0)
                instance.Save();
        }



        int currentLvl = PlayerPrefs.GetInt("a3", 1);
        Instance.currentLevel = currentLvl;
        Instance.Save();

        SetTextForStats();
    }

    public void Save()
    {
        PlayerPrefs.SetInt("totalKills", totalKills);
        PlayerPrefs.SetInt("totalDeaths", totalDeaths);
        PlayerPrefs.SetFloat("killDeathRatio", killDeathRatio);

        PlayerPrefs.SetInt("totalHits", totalHits);
        PlayerPrefs.SetInt("totalMisses", totalMisses);
        PlayerPrefs.SetFloat("accuracy", accuracy);

        PlayerPrefs.SetInt("currentLevelIndex", currentLevel);
        PlayerPrefs.SetInt("bestKillStreak", bestKillStreak);
        PlayerPrefs.SetInt("highScore", highScore);
    }

    public void ShowGameStatistics()
    {
        //darken & show statistics
        darkenAnime.gameObject.SetActive(true);
        darkenAnime.SetTrigger("darken");
        StartCoroutine(waitAndShow());
        
    }
    public IEnumerator waitAndShow()
    {
        yield return new WaitForSeconds(0.4f);
        StatsPanelAnime.SetTrigger("windowShow");    
    }

    public void ExitStats()
    {
        if(StatsPanelGUI.activeSelf == true)
        {
            StatsPanelAnime.SetTrigger("windowGo");
            darkenAnime.SetTrigger("lighten");
        }
    }

    public void disableStatsPanel()
    {
        darkenAnime.gameObject.SetActive(false);
    }

    private void SetTextForStats()
    {
        //Debug.Log(instance.totalKills.ToString());
        totalKillsTxt.text = instance.totalKills.ToString();
        totalDeathsTxt.text = PlayerPrefs.GetInt("totalDeaths", 0).ToString();
        killDeathRatioTxt.text = PlayerPrefs.GetFloat("killDeathRatio", 0).ToString();

        totalHitsTxt.text = PlayerPrefs.GetFloat("totalHits", 0).ToString();
        totalMissesTxt.text = PlayerPrefs.GetFloat("totalMisses", 0).ToString();
        accuracyTxt.text = PlayerPrefs.GetFloat("accuracy", 0).ToString();

        currentLevelTxt.text = PlayerPrefs.GetInt("currentLevelIndex", 1).ToString();
        bestKillStreakTxt.text = PlayerPrefs.GetInt("bestKillStreak", 0).ToString();
        highScoreTxt.text = PlayerPrefs.GetInt("highScore", 0).ToString();

    }
}
