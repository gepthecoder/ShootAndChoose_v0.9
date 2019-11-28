using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gift : MonoBehaviour
{
    private Animator anime_GiftCard;
    private bool open_state_GiftCard;

    public Animator anime_OpenGift;

    //REWARD SYSTEM
    public Button chestButton;
    // SOUNDS
    public AudioSource aSource_ClickEvents;
    public AudioClip aClip_ShowGiftCard;
    public AudioClip aClip_CloseGiftCard;
    public AudioClip aClip_OpenGift;
    public AudioClip aClip_CannotOpenGift;


    private void Start()
    {
        open_state_GiftCard = false;
        anime_GiftCard = GetComponent<Animator>();
    }

    //show gift card when clicked on gift button
    public void ShowGiftCard()
    {
        open_state_GiftCard = true;
        aSource_ClickEvents.PlayOneShot(aClip_ShowGiftCard);
        anime_GiftCard.SetTrigger("ShowGiftCard");
    }

    //open gift button click
    public void OpenGift()
    {
        if(anime_OpenGift != null)
        {
            anime_OpenGift.SetTrigger("openGift");
            HandleMainMenu.lastChestOpen = (ulong)DateTime.Now.Ticks;
            PlayerPrefs.SetString("LastChestOpen", HandleMainMenu.lastChestOpen.ToString());
            chestButton.interactable = false;
            aSource_ClickEvents.PlayOneShot(aClip_OpenGift);
            ManageRewardSystem();
        }
    }

    //Close Gift Card
    public void CloseGiftCard()
    {
        open_state_GiftCard = false;
        aSource_ClickEvents.PlayOneShot(aClip_CloseGiftCard);
        anime_GiftCard.SetTrigger("byebyeGiftCard");
    }

    //REWARD MANAGER

    // main reward image on card
    public Image reward_Img;
    public Image rewardCard_Img;
    // spites for reward & cardReward
    public Sprite[] rewardImages;
    private int index;
    // stringValues
    public string rewardNameSprite;
    public string rewardName;
    public string rewardAmount;
    // intValues
    public int goldenCount = 0;
    public int blueCount = 0;
    public int roseCount = 0;
    public int redCount = 0;
    public int greenCount = 0;
    public int coins = 0;
    // text UI values
    public Text itemName_text;
    public Text itemAmount_text;

    public void ManageRewardSystem()
    {
        index = UnityEngine.Random.Range(0, rewardImages.Length);

        rewardNameSprite = rewardImages[index].name;

        if (rewardNameSprite == "emerald")
        {
            int r = UnityEngine.Random.Range(4, 12);
            goldenCount += r;
            rewardName = "Golden Emerald";
            rewardAmount = r.ToString();
            PlayerPrefs.SetInt("EmeraldGold", PlayerPrefs.GetInt("EmeraldGold") + goldenCount);
            //Debug.Log(PlayerPrefs.GetInt("EmeraldGold") + "   " + goldenCount);
        }
        else if (rewardNameSprite == "emerald1")
        {
            int r = UnityEngine.Random.Range(20, 48);
            redCount += r;
            rewardName = "Red Emerald";
            rewardAmount = r.ToString();
            PlayerPrefs.SetInt("EmeraldRed", PlayerPrefs.GetInt("EmeraldRed") + redCount);
            //Debug.Log(PlayerPrefs.GetInt("EmeraldRed") + "   " + redCount);
        }
        else if (rewardNameSprite == "emerald2")
        {
            int r = UnityEngine.Random.Range(8, 16);
            roseCount += r;
            rewardName = "Purple-Rose Emerald";
            rewardAmount = r.ToString();
            PlayerPrefs.SetInt("EmeraldPurple", PlayerPrefs.GetInt("EmeraldPurple") + roseCount);
            //Debug.Log(PlayerPrefs.GetInt("EmeraldPurple") + "   " + roseCount);
        }
        else if (rewardNameSprite == "emerald3")
        {
            int r = UnityEngine.Random.Range(10, 29);
            greenCount += r;
            rewardName = "Green Emerald";
            rewardAmount = r.ToString();
            PlayerPrefs.SetInt("EmeraldGreen", PlayerPrefs.GetInt("EmeraldGreen") + greenCount);
            //Debug.Log(PlayerPrefs.GetInt("EmeraldGreen") + "   " + greenCount);
        }
        else if (rewardNameSprite == "emerald4")
        {
            int r = UnityEngine.Random.Range(10, 22);
            blueCount += r;
            rewardName = "Blue Emerald";
            rewardAmount = r.ToString();
            PlayerPrefs.SetInt("EmeraldBlue", PlayerPrefs.GetInt("EmeraldBlue") + blueCount);
            //Debug.Log(PlayerPrefs.GetInt("EmeraldBlue") + "   " + blueCount);
        }
        if (rewardNameSprite == "coins")
        {
            int r = UnityEngine.Random.Range(50, 350);
            coins += r;
            rewardName = "Coins";
            rewardAmount = r.ToString();
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + coins);

            rewardCard_Img.sprite = rewardImages[index];
            reward_Img.sprite = rewardImages[index];
            rewardCard_Img.transform.localScale = new Vector3(.5f, .5f, .5f);

            itemName_text.text = rewardName;
            itemAmount_text.text = "x " + rewardAmount;

            //Debug.Log(PlayerPrefs.GetInt("coins") + "   " + coins);
        }
        else
        {
            rewardCard_Img.sprite = rewardImages[index];
            reward_Img.sprite = rewardImages[index];

            itemName_text.text = rewardName;
            itemAmount_text.text = "x " + rewardAmount;
        }     
    }
    

}
