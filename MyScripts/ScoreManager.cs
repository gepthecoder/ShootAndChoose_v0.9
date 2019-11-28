using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Animator animeBonus;
    public static bool trigger;
    public static int Score;

    public Text scoreText;
    public Text scoreTextWin;
    public Text coinsText;

    private int firstTry = 0;

    public static int coins = 0;
    public static int totalCoins = 0;


    void Awake()
    {
        totalCoins = PlayerPrefs.GetInt("coins", 0);
    }

    void Start()
    {
        numOfCoinsWithBonus.text = string.Empty;
    }

    void Update()
    {
        Score = Manager.scoreValue;

        scoreText.text = "Score:  " + Score.ToString();
        scoreTextWin.text = "Score: " + Score.ToString();

        coins = (int)(Score / 5);

        if (trigger)
        {
            StartCoroutine(AddBonus());
            Save();
            trigger = false;
        }
        
    }

    void Save()
    {
        if(firstTry == 0)
        {
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + coins);
            firstTry++;
        }
       
    }

    public Text bonusText;
    public Text numOfCoinsWithBonus;

    private IEnumerator AddBonus()
    {
        int result = 0;
        ConfigureBonusFromLaser();
   
        coinsText.text = coins.ToString();

        Debug.Log("before bonus: " + coins);
        yield return new WaitForSeconds(4.0f);
        coinsText.gameObject.SetActive(false);
        numOfCoinsWithBonus.gameObject.SetActive(true);

        animeBonus.SetTrigger("bonus");
        bonusText.text = "x " + bonusMultiplyer;

        result = coins * bonusMultiplyer;
        numOfCoinsWithBonus.text = result.ToString();
        Debug.Log("after bonus: " + result);

         

    }

    private int bonusMultiplyer = 1;
    private void ConfigureBonusFromLaser()
    {     
        if(PlayerPrefs.GetInt("CurrentLaser") == 0)
        {
            //RED
            Debug.Log("red boost!!");
            bonusMultiplyer = PlayerPrefs.GetInt("redBoost", 1);
        }
        else if(PlayerPrefs.GetInt("CurrentLaser") == 1)
        {
            //GREEN
            bonusMultiplyer = PlayerPrefs.GetInt("greenBoost", 4);
        }
        else if (PlayerPrefs.GetInt("CurrentLaser") == 2)
        {
            //BLUE
            bonusMultiplyer = PlayerPrefs.GetInt("blueBoost", 6);
        }
        else if (PlayerPrefs.GetInt("CurrentLaser") == 3)
        {
            //PURPLE
            bonusMultiplyer = PlayerPrefs.GetInt("purpleBoost", 8);
        }
        else if (PlayerPrefs.GetInt("CurrentLaser") == 4)
        {
            //GOLDEN
            bonusMultiplyer = PlayerPrefs.GetInt("goldenBoost", 10);
        }
        else { bonusMultiplyer = 1; }
    }
}
