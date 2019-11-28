using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponShop : MonoBehaviour
{
    public GameObject coinCount;
    private Text coinCountTxt;

    public int coins = 0;

    public int currentWeaponIndex = 0;

    public int WeaponAvailability = 1;

    private static WeaponShop instance;
    public static WeaponShop Instance { get { return instance; } }

    #region WeaponUpgrade

    public int atomicMissileLevel = 1;
    public int tripleThreadMissileLevel = 1;
    public int superSonicMissileLevel = 1;
    
    public Text atomicLevelTxt;
    public Text tripleLevelTxt;
    public Text sonicLevelTxt;

    public int atomicMissileDamage = 10;
    public int tripleThreadMissileDamage = 60;
    public int superSonicMissileDamage = 100;

    public Text atomicDamageTxt;
    public Text tripleDamageTxt;
    public Text sonicDamageTxt;

    public void SetLevelTextAndDamageText()
    {
        atomicLevelTxt.text = "lvl " + PlayerPrefs.GetInt("atomicLevel").ToString();
        tripleLevelTxt.text = "lvl " + PlayerPrefs.GetInt("tripleLevel").ToString();
        sonicLevelTxt.text = "lvl " + PlayerPrefs.GetInt("sonicLevel").ToString();

        atomicDamageTxt.text = PlayerPrefs.GetInt("atomicDamage").ToString();
        tripleDamageTxt.text = PlayerPrefs.GetInt("tripleDamage").ToString();
        sonicDamageTxt.text = PlayerPrefs.GetInt("sonicDamage").ToString();

    }

    #endregion

    #region ButtonManager

    public GameObject buy_tripleMissile;
    public GameObject buy_sonicMissile;

    public GameObject upgrade_tripleMissile;
    public GameObject upgrade_sonicMissile;

    public void ManageButtons(GameObject btn_BuyTriple, GameObject btn_BuySonic, GameObject upgrade_Triple, GameObject upgrade_Sonic)
    {
        if (PlayerPrefs.GetInt("tripleBought") == 1)
        {
            btn_BuyTriple.SetActive(false);
            upgrade_Triple.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("sonicBought") == 1)
        {
            btn_BuySonic.SetActive(false);
            upgrade_Sonic.SetActive(true);
        }
    }

    #endregion

    void Awake()
    {
        instance = this;
        coinCountTxt = coinCount.GetComponent<Text>();

        DontDestroyOnLoad(gameObject);

        if (PlayerPrefs.HasKey("coins"))
        {
            //we had a previous session
            coins = PlayerPrefs.GetInt("coins", 0);
            currentWeaponIndex = PlayerPrefs.GetInt("currentWeaponIndex", 0);
            WeaponAvailability = PlayerPrefs.GetInt("weaponAvailability", 1);
            tripleBought = PlayerPrefs.GetInt("tripleBought", 0);
            sonicBought = PlayerPrefs.GetInt("sonicBought", 0);

            //Weapon Levels
            atomicMissileLevel = PlayerPrefs.GetInt("atomicLevel", 1);
            tripleThreadMissileLevel = PlayerPrefs.GetInt("tripleLevel", 1);
            superSonicMissileLevel = PlayerPrefs.GetInt("sonicLevel", 1);

            //Weapon Damages
            atomicMissileDamage = PlayerPrefs.GetInt("atomicDamage", 10);
            tripleThreadMissileDamage = PlayerPrefs.GetInt("tripleDamage", 60);
            superSonicMissileDamage = PlayerPrefs.GetInt("sonicDamage", 100);


        }
        else { Save(); }
    }

    void Start()
    {
        ChangeWeaponSkin(Instance.currentWeaponIndex);
        ManageToggles();
        ManageLockImages();
        ManageButtons(buy_tripleMissile, buy_sonicMissile, upgrade_tripleMissile, upgrade_sonicMissile);

    }

    void Update()
    {
        coinCountTxt.text = PlayerPrefs.GetInt("coins").ToString();

        SetLevelTextAndDamageText();
        ManageToggles();
        ManageLockImages();
        ManageButtons(buy_tripleMissile, buy_sonicMissile, upgrade_tripleMissile, upgrade_sonicMissile);
       
    }

    public void Save()
    {
        PlayerPrefs.SetInt("coins", coins);
        PlayerPrefs.SetInt("currentWeaponIndex", currentWeaponIndex);
        PlayerPrefs.SetInt("weaponAvailability", WeaponAvailability);

        PlayerPrefs.SetInt("tripleBought", tripleBought);
        PlayerPrefs.SetInt("sonicBought", sonicBought);

        PlayerPrefs.SetInt("atomicLevel", atomicMissileLevel);
        PlayerPrefs.SetInt("tripleLevel", tripleThreadMissileLevel);
        PlayerPrefs.SetInt("sonicLevel", superSonicMissileLevel);

        PlayerPrefs.SetInt("atomicDamage", atomicMissileDamage);
        PlayerPrefs.SetInt("tripleDamage", tripleThreadMissileDamage);
        PlayerPrefs.SetInt("sonicDamage", superSonicMissileDamage);


    }

    private int counterSwitch = 0;

    public void ChangeWeaponSkin(int index)
    {
        if ((Instance.WeaponAvailability & 1 << index) == 1 << index)
        {
            Debug.Log(1 << index);
            Instance.currentWeaponIndex = index;
            Instance.Save();
            counterSwitch++;
            if(counterSwitch > 1) { ShopAudioManager.playSelectSound = true; }
        }

    }

    public Toggle[] toggles;

    private void ManageToggles()
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            if (Instance.currentWeaponIndex == 0) { toggles[0].isOn = true; }
            else { toggles[0].isOn = false; }

            if (Instance.currentWeaponIndex == 1) { toggles[1].isOn = true; }
            else { toggles[1].isOn = false; }

            if (Instance.currentWeaponIndex == 2) { toggles[2].isOn = true; }
            else { toggles[2].isOn = false; }
            
        }
    }

    public Image[] lockImages;

    public int tripleBought = 0;
    public int sonicBought = 0;
   

    private void ManageLockImages()
    {
        for (int i = 0; i < lockImages.Length; i++)
        {
            if (Instance.tripleBought == 1) { lockImages[0].enabled = false; }
            else { lockImages[0].enabled = true; }

            if (Instance.sonicBought == 1) { lockImages[1].enabled = false; }
            else { lockImages[1].enabled = true; }

        }
    }


    public int tripleThreadPrice = 25000;

    public void BuyTripleWeapon(int index)
    {
        if(Instance.coins >= tripleThreadPrice)
        {
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < tripleThreadPrice; j++)
                {
                    Instance.coins -= 1;
                }
            }

            Instance.WeaponAvailability += 1 << index;
            Instance.tripleBought = 1;
            Instance.Save();
            ShopAudioManager.playBuyUpgradeClickSound = true;

        }
        else
        {
            //play sound etc..
            Debug.Log("No money");
            ShopAudioManager.playDenyBuyUpgradeClickSound = true;
        }
    }


    public int superSonicPrice = 100000;

    public void BuySonicWeapon(int index)
    {
        if (Instance.coins >= superSonicPrice)
        {
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < superSonicPrice; j++)
                {
                    Instance.coins -= 1;
                }
            }

            Instance.WeaponAvailability += 1 << index;
            Instance.sonicBought = 1;
            Instance.Save();
            ShopAudioManager.playBuyUpgradeClickSound = true;

        }
        else
        {
            //play sound etc..
            Debug.Log("No money");
            ShopAudioManager.playDenyBuyUpgradeClickSound = true;

        }
    }


    public GoPlay fader;

    public void BackToMenu()
    {
        ShopAudioManager.playClickSound_other = true;
        fader.ReturnToMenu();
    }

    public void UpgradeAtomicMissile()
    {
        int atomicUpgradePrice = 1500;

        if(Instance.coins >= atomicUpgradePrice)
        {
            //play sound for bought upgrade
            for (int i = 0; i < 1; i++) {
                Instance.atomicMissileLevel += 1;
                Instance.coins -= atomicUpgradePrice;
                Instance.atomicMissileDamage += 5;
            }
            Instance.Save();
            ShopAudioManager.playBuyUpgradeClickSound = true;

        }
        else { Debug.Log("You have no money!!");
            ShopAudioManager.playDenyBuyUpgradeClickSound = true;
        }
    }

    public void UpgradeTripleThreadMissile()
    {
        int tripleThreadUpgradePrice = 25000;

        if (Instance.coins >= tripleThreadUpgradePrice)
        {
            //play sound for bought upgrade
            for (int i = 0; i < 1; i++)
            {
                Instance.tripleThreadMissileLevel += 1;
                Instance.coins -= tripleThreadUpgradePrice;
                Instance.tripleThreadMissileDamage += 10;
            }
            Instance.Save();
            ShopAudioManager.playBuyUpgradeClickSound = true;

        }
        else { Debug.Log("You have no money!!");
            ShopAudioManager.playDenyBuyUpgradeClickSound = true;
        }
    }

    public void UpgradeSuperSonicMissile()
    {
        int superSonicUpgradePrice = 100000;

        if (Instance.coins >= superSonicUpgradePrice)
        {
            //play sound for bought upgrade
            for (int i = 0; i < 1; i++)
            {
                Instance.superSonicMissileLevel += 1;
                Instance.coins -= superSonicUpgradePrice;
                Instance.superSonicMissileDamage += 20;
            }
            Instance.Save();
            ShopAudioManager.playBuyUpgradeClickSound = true;

        }
        else { Debug.Log("You have no money!!");
            ShopAudioManager.playDenyBuyUpgradeClickSound = true;
        }
    }

   
}
