using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class ManagerForShop : MonoBehaviour
{
    #region VideoPreview

    public GameObject red1;
    public Animator animeRed1;

    public GameObject green1;
    public Animator animeGreen1;

    public GameObject blue1;
    public Animator animeBlue1;


    public void PlayRedLaser()
    {
        animeRed1.SetTrigger("red1");
        StartCoroutine(WaitAndDisable(red1));
    }

    public void PlayGreenLaser()
    {
        animeGreen1.SetTrigger("red1");
        StartCoroutine(WaitAndDisable(green1));
    }

    public void PlayBlueLaser()
    {
        animeBlue1.SetTrigger("red1");
        StartCoroutine(WaitAndDisable(blue1));
    }

    public IEnumerator WaitAndDisable(GameObject obj)
    {
        yield return new WaitForSeconds(8.2f);
        Debug.Log("Disaaaaabled");
        obj.SetActive(false);
    }

    #endregion

    #region Transition to Menu

    public GoPlay fader;

    public void BackToMenu()
    {
        ShopAudioManager.playClickSound_other = true;
        fader.ReturnToMenu();
    }

    #endregion

    #region Currency Amount Text

    public Text goldTxt;
    public Text blueTxt;
    public Text redTxt;
    public Text purpleTxt;
    public Text greenTxt;

    public void SetText()
    {
        goldTxt.text = Instance.emeraldGold.ToString();
        blueTxt.text = Instance.emeraldBlue.ToString();
        redTxt.text = Instance.emeraldRed.ToString();
        purpleTxt.text = Instance.emeraldPurple.ToString();
        greenTxt.text = Instance.emeraldGreen.ToString();

    }

    #endregion

    #region Toggles On/Off

    public Toggle[] toggles;

    private void ManageToggles()
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            if (Instance.currentLaserIndex == 0) { toggles[0].isOn = true; }
            else { toggles[0].isOn = false; }

            if (Instance.currentLaserIndex == 1) { toggles[1].isOn = true; }
            else { toggles[1].isOn = false; }

            if (Instance.currentLaserIndex == 2) { toggles[2].isOn = true; }
            else { toggles[2].isOn = false; }

            if (Instance.currentLaserIndex == 3) { toggles[3].isOn = true; }
            else { toggles[3].isOn = false; }

            if (Instance.currentLaserIndex == 4) { toggles[4].isOn = true; }
            else { toggles[4].isOn = false; }
        }
    }

    #endregion

    #region Lock State

    public Image[] lockImages;

    public int greenBought = 0;
    public int blueBought = 0;
    public int purpleBought = 0;
    public int goldBought = 0;

    private void ManageLockImages()
    {
        for (int i = 0; i < lockImages.Length; i++)
        {
            if(Instance.greenBought == 1) { lockImages[0].enabled = false; }
            else { lockImages[0].enabled = true; }

            if (Instance.blueBought == 1) { lockImages[1].enabled = false; }
            else { lockImages[1].enabled = true; }

            if (Instance.purpleBought == 1) { lockImages[2].enabled = false; }
            else { lockImages[2].enabled = true; }

            if (Instance.goldBought == 1) { lockImages[3].enabled = false; }
            else { lockImages[3].enabled = true; }
        }
    }


    #endregion

    #region LaserUpgrade

    //Laser Level
    public int redLaserLevel = 1;
    public int greenLaserLevel = 1;
    public int blueLaserLevel = 1;

    public int purpleLaserLevel = 1;
    public int goldLaserLevel = 1;

    public Text redLaserTxt;
    public Text greenLaserTxt;
    public Text blueLaserTxt;

    public Text purpleLaserTxt;
    public Text goldenLaserTxt;

    //XP Boost
    public int redLaserXpBoost = 1;
    public int greenLaserXpBoost = 4;
    public int blueLaserXpBoost = 6;

    public int purpleLaserXpBoost = 8;
    public int goldenLaserXpBoost = 10;

    public Text redXpBoostTxt;
    public Text greenXpBoostTxt;
    public Text blueXpBoostTxt;

    public Text purpleXpBoostTxt;
    public Text goldenXpBoostTxt;

    //Price
    public Text redPriceTxt;
    public Text greenPriceTxt;
    public Text bluePriceTxt;

    public Text purplePriceTxt;
    public Text goldenPriceTxt;

    private int redUpgradePrice = 35;

    private int greenPrice = 30;
    private int greenUpgradePrice = 45;
    private int greenPriceToUse;

    private int bluePrice = 50;
    private int blueUpgradePrice = 65;
    private int bluePriceToUse;

    private int purplePrice = 70;
    private int purpleUpgradePrice = 85;
    private int purplePriceToUse;


    private int goldenPrice = 90;
    private int goldenUpgradePrice = 105;
    private int goldenPriceToUse;



    private void SetPriceToUse()
    {
        if(greenBought == 1) { greenPriceToUse = greenUpgradePrice; }
        else { greenPriceToUse = greenPrice; }

        if (blueBought == 1) { bluePriceToUse = blueUpgradePrice; }
        else { bluePriceToUse = bluePrice; }

        if (purpleBought == 1) { purplePriceToUse = purpleUpgradePrice; }
        else { purplePriceToUse = purplePrice; }

        if (goldBought == 1) { goldenPriceToUse = goldenUpgradePrice; }
        else { goldenPriceToUse = goldenPrice; }

    }


    public void SetLevelAndXpBoostText()
    {
        redLaserTxt.text = "LEVEL " + PlayerPrefs.GetInt("redLevel", 1);
        greenLaserTxt.text = "LEVEL " + PlayerPrefs.GetInt("greenLevel", 1);
        blueLaserTxt.text = "LEVEL " + PlayerPrefs.GetInt("blueLevel", 1);

        purpleLaserTxt.text = "LEVEL " + PlayerPrefs.GetInt("purpleLevel", 1);
        goldenLaserTxt.text = "LEVEL " + PlayerPrefs.GetInt("goldenLevel", 1);

        redXpBoostTxt.text = "x" + PlayerPrefs.GetInt("redBoost");
        greenXpBoostTxt.text = "x" + PlayerPrefs.GetInt("greenBoost");
        blueXpBoostTxt.text = "x" + PlayerPrefs.GetInt("blueBoost");

        purpleXpBoostTxt.text = "x" + PlayerPrefs.GetInt("purpleBoost");
        goldenXpBoostTxt.text = "x" + PlayerPrefs.GetInt("goldenBoost");

        redPriceTxt.text = "x " + redUpgradePrice;
        greenPriceTxt.text = "x " + greenPriceToUse;
        bluePriceTxt.text = "x " + bluePriceToUse;
        purplePriceTxt.text = "x " + purplePriceToUse;
        goldenPriceTxt.text = "x " + goldenPriceToUse;


    }

    #endregion

    #region Buttons

    public GameObject buyGreen;
    public GameObject buyBlue;
    public GameObject buyPurple;
    public GameObject buyGolden;
           
    public GameObject upgradeGreen;
    public GameObject upgradeBlue;
    public GameObject upgradePurple;
    public GameObject upgradeGolden;


    private void SetButtons()
    {
        if(Instance.greenBought == 1)
        {
            buyGreen.SetActive(false);
            upgradeGreen.SetActive(true);
        }
        if(Instance.blueBought == 1)
        {
            buyBlue.SetActive(false);
            upgradeBlue.SetActive(true);
        }
        if (Instance.purpleBought == 1)
        {
            buyPurple.SetActive(false);
            upgradePurple.SetActive(true);
        }
        if (Instance.goldBought == 1)
        {
            buyGolden.SetActive(false);
            upgradeGolden.SetActive(true);
        }
    }

    #endregion

    private static ManagerForShop instance;
    public static ManagerForShop Instance { get { return instance; } }

    public int currentLaserIndex = 0;

    public int emeraldRed = 0;
    public int emeraldGreen = 0;
    public int emeraldBlue = 0;
    public int emeraldPurple = 0;
    public int emeraldGold = 0;

    public int laserAvailability = 1;

    private int counterSound = 0;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);

        //is there any current laser in our registry 
        if (PlayerPrefs.HasKey("CurrentLaser"))
        {
            //we had a previous session
            currentLaserIndex = PlayerPrefs.GetInt("CurrentLaser");

            emeraldRed = PlayerPrefs.GetInt("EmeraldRed");
            emeraldGreen = PlayerPrefs.GetInt("EmeraldGreen");
            emeraldBlue = PlayerPrefs.GetInt("EmeraldBlue");
            emeraldPurple = PlayerPrefs.GetInt("EmeraldPurple");
            emeraldGold = PlayerPrefs.GetInt("EmeraldGold");

            greenBought = PlayerPrefs.GetInt("boughtGreen");
            blueBought = PlayerPrefs.GetInt("boughtBlue");
            purpleBought = PlayerPrefs.GetInt("boughtPurple");
            goldBought = PlayerPrefs.GetInt("boughtGolden");


            laserAvailability = PlayerPrefs.GetInt("LaserAvailability");

            //Laser Levels
            redLaserLevel = PlayerPrefs.GetInt("redLevel", 1);
            greenLaserLevel = PlayerPrefs.GetInt("greenLevel", 1);
            blueLaserLevel = PlayerPrefs.GetInt("blueLevel", 1);

            purpleLaserLevel = PlayerPrefs.GetInt("purpleLevel", 1);
            goldLaserLevel = PlayerPrefs.GetInt("goldenLevel", 1);

            //Laser XP boost
            redLaserXpBoost = PlayerPrefs.GetInt("redBoost", 1);
            greenLaserXpBoost = PlayerPrefs.GetInt("greenBoost", 4);
            blueLaserXpBoost = PlayerPrefs.GetInt("blueBoost", 6);

            purpleLaserXpBoost = PlayerPrefs.GetInt("purpleBoost", 8);
            goldenLaserXpBoost = PlayerPrefs.GetInt("goldenBoost", 10);


        }
        else
        {
            //new game
            Save();
        }
    }

    void Start()
    {
        ChangeLaserSkin(Instance.currentLaserIndex);          
        ManageLockImages();
        SetButtons();
        SetPriceToUse();
        SetLevelAndXpBoostText();
    }

    void Update()
    {
        SetText();
        ManageToggles();
        ManageLockImages();
        SetPriceToUse();
        SetLevelAndXpBoostText();
        SetButtons();
      
    }

    public void Save() {

        PlayerPrefs.SetInt("CurrentLaser", currentLaserIndex);

        PlayerPrefs.SetInt("EmeraldRed", emeraldRed);
        PlayerPrefs.SetInt("EmeraldGreen", emeraldGreen);
        PlayerPrefs.SetInt("EmeraldBlue", emeraldBlue);
        PlayerPrefs.SetInt("EmeraldPurple", emeraldPurple);
        PlayerPrefs.SetInt("EmeraldGold", emeraldGold);

        PlayerPrefs.SetInt("boughtGreen", greenBought);
        PlayerPrefs.SetInt("boughtBlue", blueBought);
        PlayerPrefs.SetInt("boughtPurple", purpleBought);
        PlayerPrefs.SetInt("boughtGold", goldBought);

        PlayerPrefs.SetInt("LaserAvailability", laserAvailability);

        PlayerPrefs.SetInt("redLevel", redLaserLevel);
        PlayerPrefs.SetInt("greenLevel", greenLaserLevel);
        PlayerPrefs.SetInt("blueLevel", blueLaserLevel);
        PlayerPrefs.SetInt("purpleLevel", purpleLaserLevel);
        PlayerPrefs.SetInt("goldenLevel", goldLaserLevel);

        PlayerPrefs.SetInt("redBoost", redLaserXpBoost);
        PlayerPrefs.SetInt("greenBoost", greenLaserXpBoost);
        PlayerPrefs.SetInt("blueBoost", blueLaserXpBoost);
        PlayerPrefs.SetInt("purpleBoost", purpleLaserXpBoost);
        PlayerPrefs.SetInt("goldenBoost", goldenLaserXpBoost);



    }

    public void ChangeLaserSkin(int index)
    {
        if((Instance.laserAvailability & 1 << index) == 1 << index)
        {
            Debug.Log(1 << index);
            Instance.currentLaserIndex = index;
            Instance.Save();
            counterSound++;
            if (counterSound > 1) { ShopAudioManager.playSelectSound = true; }

        }
        Debug.Log("Counter sound: " + counterSound);

    }

    public void Buy_greenLaser(int index)
    {
        int greenLaserCost = 30;

        if(Instance.emeraldGreen >= greenLaserCost)
        {
            //play bought sound
            ShopAudioManager.playBuyUpgradeClickSound = true;
            Instance.emeraldGreen -= greenLaserCost;
            Instance.laserAvailability += 1 << index;
            Instance.greenBought = 1;
            Instance.Save();
        }
        else
        {
            //play sound etc..
            Debug.Log("No money");
            ShopAudioManager.playDenyBuyUpgradeClickSound = true;
        }
    }

    public void Buy_blueLaser(int index)
    {
        int blueLaserCost = 50;

        if (Instance.emeraldBlue >= blueLaserCost)
        {
            ShopAudioManager.playBuyUpgradeClickSound = true;
            Instance.emeraldBlue -= blueLaserCost;
            Instance.laserAvailability += 1 << index;
            Instance.blueBought = 1;
            Instance.Save();
        }
        else
        {
            //play sound etc..
            Debug.Log("No money");
            ShopAudioManager.playDenyBuyUpgradeClickSound = true;
        }
    }

    public void Buy_purpleLaser(int index)
    {
        int purpleLaserCost = 70;

        if (Instance.emeraldPurple >= purpleLaserCost)
        {
            ShopAudioManager.playBuyUpgradeClickSound = true;
            Instance.emeraldPurple -= purpleLaserCost;
            Instance.laserAvailability += 1 << index;
            Instance.purpleBought = 1;
            Instance.Save();
        }
        else
        {
            //play sound etc..
            Debug.Log("No money");
            ShopAudioManager.playDenyBuyUpgradeClickSound = true;
        }
    }

    public void Buy_goldenLaser(int index)
    {
        int goldenLaserCost = 90;

        if (Instance.emeraldGold >= goldenLaserCost)
        {
            ShopAudioManager.playBuyUpgradeClickSound = true;
            Instance.emeraldGold -= goldenLaserCost;
            Instance.laserAvailability += 1 << index;
            Instance.goldBought = 1;
            Instance.Save();
        }
        else
        {
            //play sound etc..
            Debug.Log("No money");
            ShopAudioManager.playDenyBuyUpgradeClickSound = true;
        }
    }


    public void upgrade_RedLaser()
    {
        int redLaserUpgradePrice = 35;

        if(Instance.emeraldRed >= redLaserUpgradePrice)
        {
            for (int i = 0; i < 1; i++)
            {
                ShopAudioManager.playBuyUpgradeClickSound = true;
                Instance.redLaserLevel += 1;
                Instance.emeraldRed -= redLaserUpgradePrice;
                Instance.redLaserXpBoost += 1;
            }
            Instance.Save();

        }
        else
        {
            Debug.Log("You have no money!");
            ShopAudioManager.playDenyBuyUpgradeClickSound = true;
        }
    }

    public void upgrade_GreenLaser()
    {
        int greenLaserUpgradePrice = 45;

        if (Instance.emeraldGreen >= greenLaserUpgradePrice)
        {
            for (int i = 0; i < 1; i++)
            {
                ShopAudioManager.playBuyUpgradeClickSound = true;
                Instance.greenLaserLevel += 1;
                Instance.emeraldGreen -= greenLaserUpgradePrice;
                Instance.greenLaserXpBoost += 4;
            }
            Instance.Save();
        }
        else
        {
            Debug.Log("You have no money!");
            ShopAudioManager.playDenyBuyUpgradeClickSound = true;
        }
    }

    public void upgrade_BlueLaser()
    {
        int blueLaserUpgradePrice = 65;

        if (Instance.emeraldBlue >= blueLaserUpgradePrice)
        {
            for (int i = 0; i < 1; i++)
            {
                ShopAudioManager.playBuyUpgradeClickSound = true;
                Instance.blueLaserLevel += 1;
                Instance.emeraldBlue -= blueLaserUpgradePrice;
                Instance.blueLaserXpBoost += 6;
            }
            Instance.Save();
        }
        else
        {
            Debug.Log("You have no money!");
            ShopAudioManager.playDenyBuyUpgradeClickSound = true;
        }
    }

    public void upgrade_PurpleLaser()
    {
        int purpleLaserUpgradePrice = 85;

        if (Instance.emeraldPurple >= purpleLaserUpgradePrice)
        {
            for (int i = 0; i < 1; i++)
            {
                ShopAudioManager.playBuyUpgradeClickSound = true;
                Instance.purpleLaserLevel += 1;
                Instance.emeraldPurple -= purpleLaserUpgradePrice;
                Instance.blueLaserXpBoost += 8;
            }
            Instance.Save();
        }
        else
        {
            Debug.Log("You have no money!");
            ShopAudioManager.playDenyBuyUpgradeClickSound = true;
        }
    }

    public void upgrade_GoldenLaser()
    {
        int goldenLaserUpgradePrice = 105;

        if (Instance.emeraldGold >= goldenLaserUpgradePrice)
        {
            for (int i = 0; i < 1; i++)
            {
                ShopAudioManager.playBuyUpgradeClickSound = true;
                Instance.goldLaserLevel += 1;
                Instance.emeraldGold -= goldenLaserUpgradePrice;
                Instance.goldenLaserXpBoost += 10;
            }
            Instance.Save();
        }
        else
        {
            Debug.Log("You have no money!");
            ShopAudioManager.playDenyBuyUpgradeClickSound = true;
        }
    }

    

}






























/* if (Instance.greenBought == 1)
        {
            if(lockImgGreen != null)
                lockImgGreen.enabled = false;
        }
        else if (Instance.blueBought == 1)
        {
            if (lockImgBlue != null)
                lockImgBlue.enabled = false;
        }
        else if (Instance.purpleBought == 1)
        {
            if (lockImgPurple != null)
                lockImgPurple.enabled = false;
        }
        else if (Instance.goldBought == 1)
        {
            if (lockImgGold != null)
                lockImgGold.enabled = false;
        }*/
