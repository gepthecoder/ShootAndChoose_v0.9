using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public Text emeraldNameText;
    public Text amountText;

    public GameObject rewardCard;
    private Animator anime;

    public Sprite[] allEmeralds;

    int index;

    public Image reward;
    public Image emeraldCardReward;
    

    public string rewardNameSprite;
    public string rewardName;
    public string rewardAmount;

    public int goldenCount = 0;
    public int blueCount = 0;
    public int roseCount = 0;
    public int redCount = 0;
    public int greenCount = 0;

    void Awake()
    {
        anime = rewardCard.GetComponent<Animator>();
    }


    public void FlyChestFly()
    {
        anime.SetTrigger("goCard");

        index = Random.Range(0, allEmeralds.Length);

        rewardNameSprite = allEmeralds[index].name;

        if(rewardNameSprite == "emerald") {
            int r = Random.Range(1, 4);
            goldenCount += r;
            rewardName = "Golden Emerald";
            rewardAmount = r.ToString();
            PlayerPrefs.SetInt("EmeraldGold", PlayerPrefs.GetInt("EmeraldGold") + goldenCount);
            Debug.Log(PlayerPrefs.GetInt("EmeraldGold") + "   " + goldenCount);
        }
        else if(rewardNameSprite == "emerald1"){
            int r = Random.Range(10, 30);
            redCount += r;
            rewardName = "Red Emerald";
            rewardAmount = r.ToString();
            PlayerPrefs.SetInt("EmeraldRed", PlayerPrefs.GetInt("EmeraldRed") + redCount);
            Debug.Log(PlayerPrefs.GetInt("EmeraldRed") + "   " + redCount);
        }
        else if (rewardNameSprite == "emerald2")
        {
            int r = Random.Range(3, 7);
            roseCount += r;
            rewardName = "Purple-Rose Emerald";
            rewardAmount = r.ToString();
            PlayerPrefs.SetInt("EmeraldPurple", PlayerPrefs.GetInt("EmeraldPurple") + roseCount);
            Debug.Log(PlayerPrefs.GetInt("EmeraldPurple") + "   " + roseCount);
        }
        else if (rewardNameSprite == "emerald3")
        {
            int r = Random.Range(3, 7);
            greenCount += r;
            rewardName = "Green Emerald";
            rewardAmount = r.ToString();
            PlayerPrefs.SetInt("EmeraldGreen", PlayerPrefs.GetInt("EmeraldGreen") + greenCount);
            Debug.Log(PlayerPrefs.GetInt("EmeraldGreen") + "   " + greenCount);
        }
        else if (rewardNameSprite == "emerald4")
        {
            int r = Random.Range(4, 7);
            blueCount += r;
            rewardName = "Blue Emerald";
            rewardAmount = r.ToString();
            PlayerPrefs.SetInt("EmeraldBlue", PlayerPrefs.GetInt("EmeraldBlue") + blueCount);
            Debug.Log(PlayerPrefs.GetInt("EmeraldBlue") + "   " + blueCount);
        }


        emeraldCardReward.GetComponent<Image>().sprite = allEmeralds[index];
        reward.GetComponent<Image>().sprite = allEmeralds[index];
        emeraldNameText.text = rewardName;
        amountText.text = "x " + rewardAmount;

    }

    public void FlyCardMenuFly()
    {
        anime.SetTrigger("FlyCard");

        index = Random.Range(0, allEmeralds.Length);

        rewardNameSprite = allEmeralds[index].name;

        if (rewardNameSprite == "emerald")
        {
            int r = Random.Range(1, 4);
            goldenCount += r;
            rewardName = "Golden Emerald";
            rewardAmount = r.ToString();
            PlayerPrefs.SetInt("EmeraldGold", PlayerPrefs.GetInt("EmeraldGold") + goldenCount);
            Debug.Log(PlayerPrefs.GetInt("EmeraldGold") + "   " +  goldenCount);
        }
        else if (rewardNameSprite == "emerald1")
        {
            int r = Random.Range(10, 30);
            redCount += r;
            rewardName = "Red Emerald";
            rewardAmount = r.ToString();
            PlayerPrefs.SetInt("EmeraldRed", PlayerPrefs.GetInt("EmeraldRed") + redCount);
            Debug.Log(PlayerPrefs.GetInt("EmeraldRed") + "   " + redCount);
        }
        else if (rewardNameSprite == "emerald2")
        {
            int r = Random.Range(3, 7);
            roseCount += r;
            rewardName = "Purple-Rose Emerald";
            rewardAmount = r.ToString();
            PlayerPrefs.SetInt("EmeraldPurple", PlayerPrefs.GetInt("EmeraldPurple") + roseCount);
            Debug.Log(PlayerPrefs.GetInt("EmeraldPurple") + "   " + roseCount);
        }
        else if (rewardNameSprite == "emerald3")
        {
            int r = Random.Range(3, 7);
            greenCount += r;
            rewardName = "Green Emerald";
            rewardAmount = r.ToString();
            PlayerPrefs.SetInt("EmeraldGreen", PlayerPrefs.GetInt("EmeraldGreen") + greenCount);
            Debug.Log(PlayerPrefs.GetInt("EmeraldGreen") + "   " + greenCount);
        }
        else if (rewardNameSprite == "emerald4")
        {
            int r = Random.Range(4, 7);
            blueCount += r;
            rewardName = "Blue Emerald";
            rewardAmount = r.ToString();
            PlayerPrefs.SetInt("EmeraldBlue", PlayerPrefs.GetInt("EmeraldBlue") + blueCount);
            Debug.Log(PlayerPrefs.GetInt("EmeraldBlue") + "   " + blueCount);
        }


        emeraldCardReward.GetComponent<Image>().sprite = allEmeralds[index];
        reward.GetComponent<Image>().sprite = allEmeralds[index];
        emeraldNameText.text = rewardName;
        amountText.text = "x " + rewardAmount;

    }
}
