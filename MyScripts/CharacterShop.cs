using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterShop : MonoBehaviour
{

    #region Inicialization

    public int currentCharacterIndex = 0;

    public int characterAvailability = 1;

    public int levelOfCharacterSoldierBoy = 1;
    public Text levelOfSoldierTxt;

    public int powerOfCharacterSoldierBoy = 10;
    public Text powerOfSoldierTxt;

    public int levelOfCharacterCyborg = 1;
    public Text levelOfCyborgTxt;

    public int powerOfCharacterCyborg = 60;
    public Text powerOfCyborgTxt;

    public int levelOfCharacterChan = 1;
    public Text levelOfChanTxt;

    public int powerOfCharacterChan = 100;
    public Text powerOfChanTxt;


    public int CyborgBought = 0;
    public int ChanBought = 0;

    public int upgradePriceCoins_Soldier = 5000;
    public Text upgradePriceSoldierTxt;

    public int upgradePriceEmeraldRed_Cyborg = 120;
    public Text upgradePriceCyborgTxt;

    public int upgradePriceEmeraldRed_Chan = 250;
    public Text upgradePriceChanTxt;

    #endregion


    private static CharacterShop instance;
    public static CharacterShop Instance { get { return instance; } }

    void SetTextValues()
    {
        levelOfSoldierTxt.text = "lvl " + PlayerPrefs.GetInt("levelSoldier").ToString();
        levelOfCyborgTxt.text = "lvl " + PlayerPrefs.GetInt("levelCyborg").ToString();
        levelOfChanTxt.text = "lvl " + PlayerPrefs.GetInt("levelChan").ToString();

        powerOfSoldierTxt.text = PlayerPrefs.GetInt("powerSoldier").ToString();
        powerOfCyborgTxt.text = PlayerPrefs.GetInt("powerCyborg").ToString();
        powerOfChanTxt.text = PlayerPrefs.GetInt("powerChan").ToString();

        if(Instance.levelOfCharacterSoldierBoy > 1) { upgradePriceSoldierTxt.text = "x " + PlayerPrefs.GetInt("UPGsoldier").ToString(); }
        else if (Instance.CyborgBought == 1) { upgradePriceCyborgTxt.text = "x " + PlayerPrefs.GetInt("UPGcyborg").ToString(); }
        else if (Instance.ChanBought == 1) { upgradePriceChanTxt.text = "x " + PlayerPrefs.GetInt("UPGchan").ToString(); }
    }


    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);

        if (PlayerPrefs.HasKey("characterIndex")) 
        {
            //we had a previous session
            currentCharacterIndex = PlayerPrefs.GetInt("characterIndex", 0);
            characterAvailability = PlayerPrefs.GetInt("characterAvailability", 1);

            levelOfCharacterSoldierBoy = PlayerPrefs.GetInt("levelSoldier", 1);
            powerOfCharacterSoldierBoy = PlayerPrefs.GetInt("powerSoldier", 10);

            levelOfCharacterCyborg = PlayerPrefs.GetInt("levelCyborg", 1);
            powerOfCharacterCyborg = PlayerPrefs.GetInt("powerCyborg", 55);

            levelOfCharacterChan = PlayerPrefs.GetInt("levelChan", 1);
            powerOfCharacterChan = PlayerPrefs.GetInt("powerChan", 99);

            CyborgBought = PlayerPrefs.GetInt("cyborgBought", 0);
            ChanBought = PlayerPrefs.GetInt("chanBought", 0); 

             upgradePriceCoins_Soldier = PlayerPrefs.GetInt("UPGsoldier", 5000);
            upgradePriceEmeraldRed_Cyborg = PlayerPrefs.GetInt("UPGcyborg", 120);
            upgradePriceEmeraldRed_Chan = PlayerPrefs.GetInt("UPGchan", 250);

        }
        else
        {
            Save();
        }
    }

    void Start()
    {
        ChangeCharacterSkin(Instance.currentCharacterIndex);
        ManageLockImages();
        ManageToggles();
        ManageButtonsCyborg(buy_Cyborg, upgrade_cyborg);
        ManageButtonsChan(buy_Chan, upgrade_chan);
        SetTextValues();

    }


    void Update()
    {
        SetTextValues();
        ManageLockImages();
        ManageToggles();
        ManageButtonsCyborg(buy_Cyborg, upgrade_cyborg);
        ManageButtonsChan(buy_Chan, upgrade_chan);

        Debug.Log(currentCharacterIndex + "   index of character");
    }

    void Save()
    {
        PlayerPrefs.SetInt("characterIndex", currentCharacterIndex);
        PlayerPrefs.SetInt("characterAvailability", characterAvailability);

        PlayerPrefs.SetInt("levelSoldier", levelOfCharacterSoldierBoy);
        PlayerPrefs.SetInt("powerSoldier", powerOfCharacterSoldierBoy);

        PlayerPrefs.SetInt("levelCyborg", levelOfCharacterCyborg);
        PlayerPrefs.SetInt("powerCyborg", powerOfCharacterCyborg);

        PlayerPrefs.SetInt("levelChan", levelOfCharacterChan);
        PlayerPrefs.SetInt("powerChan", powerOfCharacterChan);

        PlayerPrefs.SetInt("cyborgBought", CyborgBought);
        PlayerPrefs.SetInt("chanBought", ChanBought);

        PlayerPrefs.SetInt("UPGsoldier", upgradePriceCoins_Soldier);
        PlayerPrefs.SetInt("UPGcyborg", upgradePriceEmeraldRed_Cyborg);
        PlayerPrefs.SetInt("UPGchan", upgradePriceEmeraldRed_Chan);
    }

    public int counterSkin = 0;

    public void ChangeCharacterSkin(int index)
    {
        if ((Instance.characterAvailability & 1 << index) == 1 << index)
        {
            Debug.Log(1 << index);
            Instance.currentCharacterIndex = index;
            Instance.Save();
            counterSkin++;
            if(counterSkin > 1)
            {
                ShopAudioManager.playSelectSound = true;
            }
        }

    }


    public void BuyCharacter_Cyborg(int index)
    {
        int cyborgEmeraldPrice = 500;

        if (ManagerForShop.Instance.emeraldRed >= cyborgEmeraldPrice)
        {           
            for (int i = 0; i < 1; i++)
            {
                ManagerForShop.Instance.emeraldRed -= cyborgEmeraldPrice;
                Instance.characterAvailability += 1 << index;
                Instance.CyborgBought = 1;
                Instance.Save();
                ManagerForShop.Instance.Save();
                SetTextValues();
                Debug.Log("Item bought!!");
                ShopAudioManager.playBuyUpgradeClickSound = true;

            }

        }
        else
        {
            //play sound <-- TO:DO
            Debug.Log("You have no money!");
            ShopAudioManager.playDenyBuyUpgradeClickSound = true;
        }
    }

    public void BuyCharacter_Chan(int index)
    {
        int chanEmeraldPrice = 2500;

        if (ManagerForShop.Instance.emeraldRed >= chanEmeraldPrice)
        {
            for (int i = 0; i < 1; i++)
            {
                ManagerForShop.Instance.emeraldRed -= chanEmeraldPrice;
                Instance.characterAvailability += 1 << index;
                Instance.ChanBought = 1;              
                Instance.Save();
                ManagerForShop.Instance.Save();

                SetTextValues();
                Debug.Log("Item bought!!");
                ShopAudioManager.playBuyUpgradeClickSound = true;

            }
        }
        else
        {
            //play sound <-- TO:DO
            Debug.Log("You have no money!");
            ShopAudioManager.playDenyBuyUpgradeClickSound = true;

        }
    }


    public Toggle soldierToggle;
    public Toggle cyborgToggle;
    public Toggle chanToggle;

    public Image checkMarkSoldier;
    public Image checkMarkCyborg;
    public Image checkMarkChan;


    private void ManageToggles()
    {
        
        if (Instance.currentCharacterIndex == 0)
        {
            soldierToggle.isOn = true;
            var tempColor = checkMarkSoldier.color;
            tempColor.a = 1f;
            checkMarkSoldier.color = tempColor;
        }
        else
        {
            soldierToggle.isOn = false;
            var tempColor = checkMarkSoldier.color;
            tempColor.a = 0f;
            checkMarkSoldier.color = tempColor;
        }

        if (Instance.currentCharacterIndex == 1)
        {
            cyborgToggle.isOn = true;
            var tempColor = checkMarkCyborg.color;
            tempColor.a = 1f;
            checkMarkCyborg.color = tempColor;
        }
        else
        {
            cyborgToggle.isOn = false;
            var tempColor = checkMarkCyborg.color;
            tempColor.a = 0f;
            checkMarkCyborg.color = tempColor;
        }

        if (Instance.currentCharacterIndex == 2)
        {
            chanToggle.isOn = true;
            var tempColor = checkMarkChan.color;
            tempColor.a = 1f;
            checkMarkChan.color = tempColor;
        }
        else
        {
            chanToggle.isOn = false;
            var tempColor = checkMarkChan.color;
            tempColor.a = 0f;
            checkMarkChan.color = tempColor;
        }


    }


    public Image lockImgCyborg;
    public Image lockImgChan;


    private void ManageLockImages()
    {
       
        if (Instance.CyborgBought == 1) { lockImgCyborg.enabled = false; }
        else {lockImgCyborg.enabled = true; }

        if (Instance.ChanBought == 1) { lockImgChan.enabled = false; }
        else { lockImgChan.enabled = true; }
     
    }


    public void UpgradeCharacterSoldierBoy()
    {
        int soldierBoyUpgradePrice = 5000;

        if (WeaponShop.Instance.coins >= soldierBoyUpgradePrice)
        {
            //play sound for bought upgrade
            for (int i = 0; i < 1; i++)
            {
                Instance.levelOfCharacterSoldierBoy += 1;
                WeaponShop.Instance.coins -= soldierBoyUpgradePrice;
                Instance.powerOfCharacterSoldierBoy += 10;
                Instance.Save();
                WeaponShop.Instance.Save();
                Debug.Log("Item bought!!");
                ShopAudioManager.playBuyUpgradeClickSound = true;
            }
        }
        else { Debug.Log("You have no money!!");
            ShopAudioManager.playDenyBuyUpgradeClickSound = true;
        }
    }

    public void UpgradeCharacterCyborg()
    {
        int cyborgUpgradeEmeraldPrice = 120;

        if (ManagerForShop.Instance.emeraldRed >= cyborgUpgradeEmeraldPrice)
        {
            //play sound for bought upgrade
            for (int i = 0; i < 1; i++)
            {
                Instance.levelOfCharacterCyborg += 1;
                ManagerForShop.Instance.emeraldRed -= cyborgUpgradeEmeraldPrice;
                Instance.powerOfCharacterCyborg += 30;
                Instance.Save();
                ManagerForShop.Instance.Save();
                ShopAudioManager.playBuyUpgradeClickSound = true;
                Debug.Log("Item bought!!");


            }
        }
        else { Debug.Log("You have no money!!");
            ShopAudioManager.playDenyBuyUpgradeClickSound = true;
        }
    }

    public void UpgradeCharacterChan()
    {
        int chanUpgradeEmeraldPrice = 250;

        if (ManagerForShop.Instance.emeraldRed >= chanUpgradeEmeraldPrice)
        {
            //play sound for bought upgrade
            for (int i = 0; i < 1; i++)
            {
                Instance.levelOfCharacterChan += 1;
                ManagerForShop.Instance.emeraldRed -= chanUpgradeEmeraldPrice;
                Instance.powerOfCharacterChan += 50;
                Instance.Save();
                ManagerForShop.Instance.Save();
                Debug.Log("Item bought!!");
                ShopAudioManager.playBuyUpgradeClickSound = true;


            }
        }
        else { Debug.Log("You have no money!!");
            ShopAudioManager.playDenyBuyUpgradeClickSound = true;
        }
    }


    public GameObject buy_Cyborg;
    public GameObject buy_Chan;

    public GameObject upgrade_cyborg;
    public GameObject upgrade_chan;

    public void ManageButtonsCyborg(GameObject btn_BuyCyborg, GameObject upgrade_Cyborg)
    {
        if (PlayerPrefs.GetInt("cyborgBought") == 1)
        {
            btn_BuyCyborg.SetActive(false);
            upgrade_Cyborg.SetActive(true);
            Debug.Log("lets gooo  cyborg");
        }

    }

    public void ManageButtonsChan(GameObject btn_BuyChan, GameObject upgrade_Chan)
    {
        if (PlayerPrefs.GetInt("chanBought") == 1)
        {
            Debug.Log("lets gooo  chan");

            btn_BuyChan.SetActive(false);
            upgrade_Chan.SetActive(true);
        }
    }

}
