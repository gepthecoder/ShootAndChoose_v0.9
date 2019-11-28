using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Challanges : MonoBehaviour
{

    #region Show/Exit UI
    public Animator anime_Challanges;
    public Animator anime_DarkenLighten;

    public void ShowcaseChallanges_UI()
    {
        anime_DarkenLighten.SetTrigger("darken");
        anime_Challanges.SetTrigger("showUI");
        StartCoroutine(ShowSideBars());
    }

    public void CloseChallanges_UI()
    {
        ExitKillCounter(KillCounterSideBarAnime);
        ExitCoinsNum(CoinsSideBarAnime);

        anime_DarkenLighten.SetTrigger("lighten");
        anime_Challanges.SetTrigger("closeUI");
    }

    private IEnumerator ShowSideBars()
    {
        yield return new WaitForSeconds(2.5f);
        ShowKillCounter(KillCounterSideBarAnime);
        ShowCoinsNum(CoinsSideBarAnime);
    }

    #endregion

    private static Challanges instance;
    public static Challanges Instance { get { return instance; } }

    //current challange completed values
    public int challangeOne_complete = 0;
    public int challangeTwo_complete = 0;
    public int challangeThree_complete = 0;
    public int challangeFour_complete = 0;
    public int challangeFive_complete = 0;
    public int challangeSix_complete = 0; 
    public int challangeSeven_complete = 0;
    public int challangeEight_complete = 0;

    private int currentKills;

    //num of kill required
    private int challangeOne_kills = 10;
    private int challangeTwo_kills = 20;
    private int challangeThree_kills = 30;
    private int challangeFour_kills = 50;
    private int challangeFive_kills = 70;
    private int challangeSix_kills = 100;
    private int challangeSeven_kills = 200;
    private int challangeEight_kills = 500;

    //opened status
    public int gift_1_opened = 0;
    public int gift_2_opened = 0;
    public int gift_3_opened = 0;
    public int gift_4_opened = 0;
    public int gift_5_opened = 0;
    public int gift_6_opened = 0;
    public int gift_7_opened = 0;
    public int gift_8_opened = 0;

    //coin reward
    private int challange_1_reward = 100;
    private int challange_2_reward = 200;
    private int challange_3_reward = 300;
    private int challange_4_reward = 500;
    private int challange_5_reward = 700;
    private int challange_6_reward = 1000;
    private int challange_7_reward = 2000;
    private int challange_8_reward = 5000;

    //lists
    private GameObject[] GIFTS;
    private GameObject[] REWARDS;
    private GameObject[] PROGRESS_IMGS;

    //images
    public Sprite checkmark_sprite;

    //collect all rewards
    private bool claim_challange1 = false;
    private bool claim_challange2 = false;
    private bool claim_challange3 = false;
    private bool claim_challange4 = false;

    private bool claim_challange5 = false;
    private bool claim_challange6 = false;
    private bool claim_challange7 = false;
    private bool claim_challange8 = false;

    public int ClaimedAll = 0;

    //side bars animators (coins & kills)
    public Animator CoinsSideBarAnime;
    public Animator KillCounterSideBarAnime;

    private Text numOfCoins;
    private Text numOfKills;

    //Audio
    private LevelAudioManager sounds;


    

    void Awake()
    {
        instance = this;

        if (PlayerPrefs.HasKey("challangeOne_complete"))
        {
            challangeOne_complete = PlayerPrefs.GetInt("challangeOne_complete", 0);
            challangeTwo_complete = PlayerPrefs.GetInt("challangeTwo_complete", 0);
            challangeThree_complete = PlayerPrefs.GetInt("challangeThree_complete", 0);
            challangeFour_complete = PlayerPrefs.GetInt("challangeFour_complete", 0);
            challangeFive_complete = PlayerPrefs.GetInt("challangeFive_complete", 0);
            challangeSix_complete = PlayerPrefs.GetInt("challangeSix_complete", 0);
            challangeSeven_complete = PlayerPrefs.GetInt("challangeSeven_complete", 0);
            challangeEight_complete = PlayerPrefs.GetInt("challangeEight_complete", 0);

            gift_1_opened = PlayerPrefs.GetInt("gift_1_opened", 0);
            gift_2_opened = PlayerPrefs.GetInt("gift_2_opened", 0);
            gift_3_opened = PlayerPrefs.GetInt("gift_3_opened", 0);
            gift_4_opened = PlayerPrefs.GetInt("gift_4_opened", 0);

            gift_5_opened = PlayerPrefs.GetInt("gift_5_opened", 0);
            gift_6_opened = PlayerPrefs.GetInt("gift_6_opened", 0);
            gift_7_opened = PlayerPrefs.GetInt("gift_7_opened", 0);
            gift_8_opened = PlayerPrefs.GetInt("gift_8_opened", 0);
            ClaimedAll = PlayerPrefs.GetInt("ClaimedAll", 0);
        }
        else
        {
            Save();
        }

    }

    void Start()
    {
        GIFTS = GameObject.FindGameObjectsWithTag("gifts");
        REWARDS = GameObject.FindGameObjectsWithTag("ChallangeReward");
        PROGRESS_IMGS = GameObject.FindGameObjectsWithTag("ChallangeDone");

        currentKills = PlayerPrefs.GetInt("totalKills", 0);
        Debug.Log(currentKills + " current kills" + "    rewards num: " + REWARDS.Length);

        GiftManager();
        numOfCoins = CoinsSideBarAnime.gameObject.GetComponentInChildren<Text>();
        numOfKills = KillCounterSideBarAnime.gameObject.GetComponentInChildren<Text>();

        ManageTxtValue_Coins(PlayerPrefs.GetInt("coins", 0));

        ManageTxtValue_Kills(PlayerPrefs.GetInt("totalKills", 0));

        sounds = GameObject.FindGameObjectWithTag("BGMusic").GetComponent<LevelAudioManager>();

        Instance.ClaimedAll = 0;
        Instance.Save();


    }

    void Update()
    {      
        ManageChallanges_ComplitedChallanges();
        ManageChallanges_AvailableGift();
    }

    private void StartStuff()
    {
        GIFTS = GameObject.FindGameObjectsWithTag("gifts");
        REWARDS = GameObject.FindGameObjectsWithTag("ChallangeReward");
        PROGRESS_IMGS = GameObject.FindGameObjectsWithTag("ChallangeDone");

        currentKills = PlayerPrefs.GetInt("totalKills", 0);
        Debug.Log(currentKills + " current kills" + "    rewards num: " + REWARDS.Length);

        GiftManager();
    }

    private void Save()
    {
        PlayerPrefs.SetInt("challangeOne_complete", challangeOne_complete);
        PlayerPrefs.SetInt("challangeTwo_complete", challangeTwo_complete);
        PlayerPrefs.SetInt("challangeThree_complete", challangeThree_complete);
        PlayerPrefs.SetInt("challangeFour_complete", challangeFour_complete);
        PlayerPrefs.SetInt("challangeFive_complete", challangeFive_complete);
        PlayerPrefs.SetInt("challangeSix_complete", challangeSix_complete);
        PlayerPrefs.SetInt("challangeSeven_complete", challangeSeven_complete);
        PlayerPrefs.SetInt("challangeEight_complete", challangeEight_complete);

        PlayerPrefs.SetInt("gift_1_opened", gift_1_opened);
        PlayerPrefs.SetInt("gift_2_opened", gift_2_opened);
        PlayerPrefs.SetInt("gift_3_opened", gift_3_opened);
        PlayerPrefs.SetInt("gift_4_opened", gift_4_opened);

        PlayerPrefs.SetInt("gift_5_opened", gift_5_opened);
        PlayerPrefs.SetInt("gift_6_opened", gift_6_opened);
        PlayerPrefs.SetInt("gift_7_opened", gift_7_opened);
        PlayerPrefs.SetInt("gift_8_opened", gift_8_opened);

        PlayerPrefs.SetInt("ClaimedAll", ClaimedAll);


    }

    public void ManageChallanges_ComplitedChallanges()
    {       
       
        if (Instance.currentKills >= challangeOne_kills)
        {
            Instance.challangeOne_complete = 1;
            Instance.Save();
            Debug.Log("Challange 1 complete!");

            if (Instance.currentKills >= challangeTwo_kills)
            {
                Instance.challangeTwo_complete = 1;
                Instance.Save();
                Debug.Log("Challange 2 complete!");

                if (Instance.currentKills >= challangeThree_kills)
                {
                    Instance.challangeThree_complete = 1;
                    Instance.Save();
                    Debug.Log("Challange 3 complete!");

                    if (Instance.currentKills >= challangeFour_kills)
                    {
                        Instance.challangeFour_complete = 1;
                        Instance.Save();
                        Debug.Log("Challange 4 complete!");

                        if (Instance.currentKills >= challangeFive_kills)
                        {
                            Instance.challangeFive_complete = 1;
                            Instance.Save();
                            Debug.Log("Challange 5 complete!");

                            if (Instance.currentKills >= challangeSix_kills)
                            {
                                Instance.challangeSix_complete = 1;
                                Instance.Save();
                                Debug.Log("Challange 6 complete!");

                                if (Instance.currentKills >= challangeSeven_kills)
                                {
                                    Instance.challangeSeven_complete = 1;
                                    Instance.Save();
                                    Debug.Log("Challange 7 complete!");

                                    if (Instance.currentKills >= challangeEight_kills)
                                    {
                                        Instance.challangeEight_complete = 1;
                                        Instance.Save();
                                        Debug.Log("Challange 8 complete!");

                                    }
                                }
                            }
                        }                    
                    }
                }
            }
        }
    }

    public void ManageChallanges_AvailableGift()
    {
        for (int i = 0; i < GIFTS.Length; i++)
        {
            #region Challange 1
            //gift is available if the challange is completed and if we didnt open the gift yet
            //if the gift is available it must show effect and must be interactable othwerwise not
            if (challangeOne_complete == 1 && gift_1_opened == 0)
            {
                //gift is available --> show anime gift tripping
                Animator anime_TRIP = GIFTS[0].GetComponentInChildren<Animator>();
                anime_TRIP.SetTrigger("getYourGift");
                Debug.Log("claim gift 1");
                Button btn_Gift = GIFTS[0].GetComponentInChildren<Button>();
                btn_Gift.interactable = true;
                claim_challange1 = true;
            }

            else
            {
                //we did not finnish the challange yet
                Button btn_Gift = GIFTS[0].GetComponentInChildren<Button>();
                btn_Gift.interactable = false;
            }
            #endregion

            #region Challange 2
            //gift is available if the challange is completed and if we didnt open the gift yet
            //if the gift is available it must show effect and must be interactable othwerwise not
            if (challangeTwo_complete == 1 && gift_2_opened == 0)
            {
                //gift is available --> show anime gift tripping
                Animator anime_TRIP = GIFTS[1].GetComponentInChildren<Animator>();
                anime_TRIP.SetTrigger("getYourGift");
                Debug.Log("claim gift 2");

                Button btn_Gift = GIFTS[1].GetComponentInChildren<Button>();
                btn_Gift.interactable = true;
                claim_challange2 = true;

            }
            else
            {
                //we did not finnish the challange yet
                Button btn_Gift = GIFTS[1].GetComponentInChildren<Button>();
                btn_Gift.interactable = false;
            }
            #endregion

            #region Challange 3         
            if (challangeThree_complete == 1 && gift_3_opened == 0)
            {
                //gift is available --> show anime gift tripping
                Animator anime_TRIP = GIFTS[2].GetComponentInChildren<Animator>();
                anime_TRIP.SetTrigger("getYourGift");
                Debug.Log("claim gift 3");

                Button btn_Gift = GIFTS[2].GetComponentInChildren<Button>();
                btn_Gift.interactable = true;
                claim_challange3 = true;

            }

            else
            {
                //we did not finnish the challange yet
                Button btn_Gift = GIFTS[2].GetComponentInChildren<Button>();
                btn_Gift.interactable = false;
            }
            #endregion

            #region Challange 4
            //gift is available if the challange is completed and if we didnt open the gift yet
            //if the gift is available it must show effect and must be interactable othwerwise not
            if (challangeFour_complete == 1 && gift_4_opened == 0)
            {
                //gift is available --> show anime gift tripping
                Animator anime_TRIP = GIFTS[3].GetComponentInChildren<Animator>();
                anime_TRIP.SetTrigger("getYourGift");
                Debug.Log("claim gift 4");
                Button btn_Gift = GIFTS[3].GetComponentInChildren<Button>();
                btn_Gift.interactable = true;
                claim_challange4 = true;

            }
            else
            {
                //we did not finnish the challange yet
                Button btn_Gift = GIFTS[3].GetComponentInChildren<Button>();
                btn_Gift.interactable = false;
                Debug.Log("gift 4 not interactable");

            }
            #endregion

            #region Challange 5
            //gift is available if the challange is completed and if we didnt open the gift yet
            //if the gift is available it must show effect and must be interactable othwerwise not
            if (challangeFive_complete == 1 && gift_5_opened == 0)
            {
                //gift is available --> show anime gift tripping
                Animator anime_TRIP = GIFTS[4].GetComponentInChildren<Animator>();
                anime_TRIP.SetTrigger("getYourGift");
                Button btn_Gift = GIFTS[4].GetComponentInChildren<Button>();
                btn_Gift.interactable = true;
                claim_challange5 = true;

            }
            else if (gift_5_opened == 1)
            {
                //we allready opened the gift
                Button btn_Gift = GIFTS[4].GetComponentInChildren<Button>();
                btn_Gift.interactable = false;
            }
            else
            {
                //we did not finnish the challange yet
                Button btn_Gift = GIFTS[4].GetComponentInChildren<Button>();
                btn_Gift.interactable = false;
            }
            #endregion

            #region Challange 6
            //gift is available if the challange is completed and if we didnt open the gift yet
            //if the gift is available it must show effect and must be interactable othwerwise not
            if (challangeSix_complete == 1 && gift_6_opened == 0)
            {
                //gift is available --> show anime gift tripping
                Animator anime_TRIP = GIFTS[5].GetComponentInChildren<Animator>();
                anime_TRIP.SetTrigger("getYourGift");
                Button btn_Gift = GIFTS[5].GetComponentInChildren<Button>();
                btn_Gift.interactable = true;
                claim_challange6 = true;

            }
            else if (gift_6_opened == 1)
            {
                //we allready opened the gift
                Button btn_Gift = GIFTS[5].GetComponentInChildren<Button>();
                btn_Gift.interactable = false;
            }
            else
            {
                //we did not finnish the challange yet
                Button btn_Gift = GIFTS[5].GetComponentInChildren<Button>();
                btn_Gift.interactable = false;
            }
            #endregion

            #region Challange 7
            //gift is available if the challange is completed and if we didnt open the gift yet
            //if the gift is available it must show effect and must be interactable othwerwise not
            if (challangeSeven_complete == 1 && gift_7_opened == 0)
            {
                //gift is available --> show anime gift tripping
                Animator anime_TRIP = GIFTS[6].GetComponentInChildren<Animator>();
                anime_TRIP.SetTrigger("getYourGift");
                Button btn_Gift = GIFTS[6].GetComponentInChildren<Button>();
                btn_Gift.interactable = true;
                claim_challange7 = true;

            }
            else if (gift_7_opened == 1)
            {
                //we allready opened the gift
                Button btn_Gift = GIFTS[6].GetComponentInChildren<Button>();
                btn_Gift.interactable = false;
            }
            else
            {
                //we did not finnish the challange yet
                Button btn_Gift = GIFTS[6].GetComponentInChildren<Button>();
                btn_Gift.interactable = false;
            }
            #endregion

            #region Challange 8
            //gift is available if the challange is completed and if we didnt open the gift yet
            //if the gift is available it must show effect and must be interactable othwerwise not
            if (challangeEight_complete == 1 && gift_8_opened == 0)
            {
                //gift is available --> show anime gift tripping
                Animator anime_TRIP = GIFTS[7].GetComponentInChildren<Animator>();
                anime_TRIP.SetTrigger("getYourGift");
                Button btn_Gift = GIFTS[7].GetComponentInChildren<Button>();
                btn_Gift.interactable = true;
                claim_challange8 = true;

            }
            else if (gift_8_opened == 1)
            {
                //we allready opened the gift
                Button btn_Gift = GIFTS[7].GetComponentInChildren<Button>();
                btn_Gift.interactable = false;
            }
            else
            {
                //we did not finnish the challange yet
                Button btn_Gift = GIFTS[7].GetComponentInChildren<Button>();
                btn_Gift.interactable = false;
            }
            #endregion
        }

    }

    // GIFT BUTTON CALLS

    public Animator anime_Coininator_1;
    public Animator anime_Claimed_1;
    public Animator anime_Coininator_2;
    public Animator anime_Claimed_2;
    public Animator anime_Coininator_3;
    public Animator anime_Claimed_3;
    public Animator anime_Coininator_4;
    public Animator anime_Claimed_4;

    public Animator anime_Coininator_5;
    public Animator anime_Claimed_5;
    public Animator anime_Coininator_6;
    public Animator anime_Claimed_6;
    public Animator anime_Coininator_7;
    public Animator anime_Claimed_7;
    public Animator anime_Coininator_8;
    public Animator anime_Claimed_8;


    private void GetCoins(int challange)
    {
        if(challange == 1)
        {
            int coins = PlayerPrefs.GetInt("coins", 0);
            coins += challange_1_reward;
            PlayerPrefs.SetInt("coins", coins);
            ManageTxtValue_Coins(PlayerPrefs.GetInt("coins", 0));

        }
        if (challange == 2)
        {
            int coins = PlayerPrefs.GetInt("coins", 0);
            coins += challange_2_reward;
            PlayerPrefs.SetInt("coins", coins);
            ManageTxtValue_Coins(PlayerPrefs.GetInt("coins", 0));

        }
        if (challange == 3)
        {
            int coins = PlayerPrefs.GetInt("coins", 0);
            coins += challange_2_reward;
            PlayerPrefs.SetInt("coins", coins);
            ManageTxtValue_Coins(PlayerPrefs.GetInt("coins", 0));

        }
        if (challange == 4)
        {
            int coins = PlayerPrefs.GetInt("coins", 0);
            coins += challange_3_reward;
            PlayerPrefs.SetInt("coins", coins);
            ManageTxtValue_Coins(PlayerPrefs.GetInt("coins", 0));

        }
        if (challange == 5)
        {
            int coins = PlayerPrefs.GetInt("coins", 0);
            coins += challange_4_reward;
            PlayerPrefs.SetInt("coins", coins);
            ManageTxtValue_Coins(PlayerPrefs.GetInt("coins", 0));

        }
        if (challange == 6)
        {
            int coins = PlayerPrefs.GetInt("coins", 0);
            coins += challange_5_reward;
            PlayerPrefs.SetInt("coins", coins);
            ManageTxtValue_Coins(PlayerPrefs.GetInt("coins", 0));

        }
        if (challange == 7)
        {
            int coins = PlayerPrefs.GetInt("coins", 0);
            coins += challange_6_reward;
            PlayerPrefs.SetInt("coins", coins);
            ManageTxtValue_Coins(PlayerPrefs.GetInt("coins", 0));

        }
        if (challange == 8)
        {
            int coins = PlayerPrefs.GetInt("coins", 0);
            coins += challange_7_reward;
            PlayerPrefs.SetInt("coins", coins);
            ManageTxtValue_Coins(PlayerPrefs.GetInt("coins", 0));

        }

    }
   
    private void GiftIsOpened(int challange)
    {
        if(challange == 1)
        {
            Instance.gift_1_opened = 1;
            Instance.Save();
        }
        if (challange == 2)
        {
            Instance.gift_2_opened = 1;
            Instance.Save();
        }
        if (challange == 3)
        {
            Instance.gift_3_opened = 1;
            Instance.Save();
        }
        if (challange == 4)
        {
            Instance.gift_4_opened = 1;
            Instance.Save();
        }
        if (challange == 5)
        {
            Instance.gift_5_opened = 1;
            Instance.Save();
        }
        if (challange == 6)
        {
            Instance.gift_6_opened = 1;
            Instance.Save();
        }
        if (challange == 7)
        {
            Instance.gift_7_opened = 1;
            Instance.Save();
        }
        if (challange == 8)
        {
            Instance.gift_8_opened = 1;
            Instance.Save();
        }

    }

    private void AnimateCoins(int challange)
    {
        if(challange == 1)
        {
            //play animation for get coins
            if(anime_Coininator_1.gameObject.activeSelf != true)
            {
                anime_Coininator_1.gameObject.SetActive(true);
            }
            anime_Coininator_1.SetTrigger("coininator");

        }

        if (challange == 2)
        {
            //play animation for get coins
            if (anime_Coininator_2.gameObject.activeSelf != true)
            {
                anime_Coininator_2.gameObject.SetActive(true);
            }
            anime_Coininator_2.SetTrigger("coininator");

        }

        if (challange == 3)
        {
            //play animation for get coins
            if (anime_Coininator_3.gameObject.activeSelf != true)
            {
                anime_Coininator_3.gameObject.SetActive(true);
            }
            anime_Coininator_3.SetTrigger("coininator");

        }

        if (challange == 4)
        {
            //play animation for get coins
            if (anime_Coininator_4.gameObject.activeSelf != true)
            {
                anime_Coininator_4.gameObject.SetActive(true);
            }
            anime_Coininator_4.SetTrigger("coininator");

        }

        if (challange == 5)
        {
            //play animation for get coins
            if (anime_Coininator_5.gameObject.activeSelf != true)
            {
                anime_Coininator_5.gameObject.SetActive(true);
            }
            anime_Coininator_5.SetTrigger("coininator");

        }

        if (challange == 6)
        {
            //play animation for get coins
            if (anime_Coininator_6.gameObject.activeSelf != true)
            {
                anime_Coininator_6.gameObject.SetActive(true);
            }
            anime_Coininator_6.SetTrigger("coininator");

        }

        if (challange == 7)
        {
            //play animation for get coins
            if (anime_Coininator_7.gameObject.activeSelf != true)
            {
                anime_Coininator_7.gameObject.SetActive(true);
            }
            anime_Coininator_7.SetTrigger("coininator");

        }

        if (challange == 8)
        {
            //play animation for get coins
            if (anime_Coininator_8.gameObject.activeSelf != true)
            {
                anime_Coininator_8.gameObject.SetActive(true);
            }
            anime_Coininator_8.SetTrigger("coininator");

        }

    }

    private IEnumerator GiftIsClaimed(int reward)
    {
        sounds.CHALLANGES_SOUNDS_GetReward();
        yield return new WaitForSeconds(2.2f);
        REWARDS[reward].gameObject.SetActive(false);
        if(reward == 0) { anime_Claimed_1.SetTrigger("claimGift"); }
        else if(reward == 1) { anime_Claimed_2.SetTrigger("claimGift"); }
        else if(reward == 2) { anime_Claimed_3.SetTrigger("claimGift"); }
        else if(reward == 3) { anime_Claimed_4.SetTrigger("claimGift"); }
        else if(reward == 4) { anime_Claimed_5.SetTrigger("claimGift"); }
        else if(reward == 4) { anime_Claimed_6.SetTrigger("claimGift"); }
        else if(reward == 6) { anime_Claimed_7.SetTrigger("claimGift"); }
        else if(reward == 7) { anime_Claimed_8.SetTrigger("claimGift"); }

        yield return new WaitForSeconds(.5f);
        Image progress_Img = PROGRESS_IMGS[reward].GetComponent<Image>();
        progress_Img.sprite = checkmark_sprite;
    }

    private void GiftManager()
    {
        if(gift_1_opened == 1)
        {
            REWARDS[0].gameObject.SetActive(false);
            anime_Claimed_1.SetTrigger("claimGift");
            Image progress_Img = PROGRESS_IMGS[0].GetComponent<Image>();
            progress_Img.sprite = checkmark_sprite;
        }

        if (gift_2_opened == 1)
        {
            REWARDS[1].gameObject.SetActive(false);
            anime_Claimed_2.SetTrigger("claimGift");
            Image progress_Img = PROGRESS_IMGS[1].GetComponent<Image>();
            progress_Img.sprite = checkmark_sprite;
        }

        if (gift_3_opened == 1)
        {
            REWARDS[2].gameObject.SetActive(false);
            anime_Claimed_3.SetTrigger("claimGift");
            Image progress_Img = PROGRESS_IMGS[2].GetComponent<Image>();
            progress_Img.sprite = checkmark_sprite;
        }

        if (gift_4_opened == 1)
        {
            REWARDS[3].gameObject.SetActive(false);
            anime_Claimed_4.SetTrigger("claimGift");
            Image progress_Img = PROGRESS_IMGS[3].GetComponent<Image>();
            progress_Img.sprite = checkmark_sprite;
        }

        if (gift_5_opened == 1)
        {
            REWARDS[4].gameObject.SetActive(false);
            anime_Claimed_5.SetTrigger("claimGift");
            Image progress_Img = PROGRESS_IMGS[4].GetComponent<Image>();
            progress_Img.sprite = checkmark_sprite;
        }

        if (gift_6_opened == 1)
        {
            REWARDS[5].gameObject.SetActive(false);
            anime_Claimed_6.SetTrigger("claimGift");
            Image progress_Img = PROGRESS_IMGS[5].GetComponent<Image>();
            progress_Img.sprite = checkmark_sprite;
        }

        if (gift_7_opened == 1)
        {
            REWARDS[6].gameObject.SetActive(false);
            anime_Claimed_7.SetTrigger("claimGift");
            Image progress_Img = PROGRESS_IMGS[6].GetComponent<Image>();
            progress_Img.sprite = checkmark_sprite;
        }

        if (gift_8_opened == 1)
        {
            REWARDS[7].gameObject.SetActive(false);
            anime_Claimed_8.SetTrigger("claimGift");
            Image progress_Img = PROGRESS_IMGS[7].GetComponent<Image>();
            progress_Img.sprite = checkmark_sprite;
        }
    }

    public void ClickEvent_Gift_1()
    {
        if(Instance.challangeOne_complete == 1)
        {
            AnimateCoins(1);
            GetCoins(1);
            StartCoroutine(GiftIsClaimed(0));
            GiftIsOpened(1);            
        }
      
    }
    public void ClickEvent_Gift_2()
    {
        if (Instance.challangeTwo_complete == 1)
        {
            AnimateCoins(2);
            GetCoins(2);
            StartCoroutine(GiftIsClaimed(1));
            GiftIsOpened(2);
        }
            
    }
    public void ClickEvent_Gift_3()
    {
        if (Instance.challangeThree_complete == 1)
        {
            AnimateCoins(3);
            GetCoins(3);
            StartCoroutine(GiftIsClaimed(2));
            GiftIsOpened(3);
        }
           
    }
    public void ClickEvent_Gift_4()
    {
        if (Instance.challangeFour_complete == 1)
        {
            AnimateCoins(4);
            GetCoins(4);
            StartCoroutine(GiftIsClaimed(3));
            GiftIsOpened(4);
        }
          
    }
    public void ClickEvent_Gift_5()
    {
        if (Instance.challangeFive_complete == 1)
        {
            AnimateCoins(5);
            GetCoins(5);
            StartCoroutine(GiftIsClaimed(4));
            GiftIsOpened(5);
        }         
    }
    public void ClickEvent_Gift_6()
    {
        if (Instance.challangeSix_complete == 1)
        {
            AnimateCoins(6);
            GetCoins(6);
            StartCoroutine(GiftIsClaimed(5));
            GiftIsOpened(6);
        }
            
    }
    public void ClickEvent_Gift_7()
    {
        if (Instance.challangeSeven_complete == 1)
        {
            AnimateCoins(7);
            GetCoins(7);
            StartCoroutine(GiftIsClaimed(6));
            GiftIsOpened(7);
        }          
    }
    public void ClickEvent_Gift_8()
    {
        if (Instance.challangeEight_complete == 1)
        {
            AnimateCoins(8);
            GetCoins(8);
            StartCoroutine(GiftIsClaimed(7));
            GiftIsOpened(8);
        }         
    }

    // Next Challanges
    public GameObject UI_slide1;
    public GameObject UI_slide2;

    public void ClickEvent_NextChallanges()
    {
        if(UI_slide2.activeSelf != true)
        {
            UI_slide2.SetActive(true);
            UI_slide1.SetActive(false);
        }
        else
        {
            UI_slide1.SetActive(true);
            UI_slide2.SetActive(false);
        }
    }

    // Collect All rewards
    public void ClickEvent_CollectAllRewards()
    {
        if(Instance.ClaimedAll == 0)
        {
            ClaimAllGifts();
            Debug.Log("All gifts are claimed.. ");
            sounds.CHALLANGES_SOUNDS_CollectAll();
            Instance.ClaimedAll = 1;
            Instance.Save();
        }
       
    }


    private IEnumerator playCoinAnimations()
    {
        if(Instance.gift_1_opened == 1)
        {
            anime_Coininator_1.SetTrigger("coininator");
            GetCoins(1);
        }
        if (Instance.gift_2_opened == 1)
        {
            anime_Coininator_2.SetTrigger("coininator");
            GetCoins(2);

        }
        if (Instance.gift_3_opened == 1)
        {
            anime_Coininator_3.SetTrigger("coininator");
            GetCoins(3);

        }
        if (Instance.gift_4_opened == 1)
        {
            anime_Coininator_4.SetTrigger("coininator");
            GetCoins(4);

        }
        if (Instance.gift_5_opened == 1)
        {
            anime_Coininator_5.SetTrigger("coininator");
            GetCoins(5);

        }
        if (Instance.gift_6_opened == 1)
        {
            anime_Coininator_6.SetTrigger("coininator");
            GetCoins(6);

        }
        if (Instance.gift_7_opened == 1)
        {
            anime_Coininator_7.SetTrigger("coininator");
            GetCoins(7);

        }
        if (Instance.gift_8_opened == 1)
        {
            anime_Coininator_8.SetTrigger("coininator");
            GetCoins(8);
        }
        yield return new WaitForSeconds(1.5f);

        ManageDisableRewards();
        Debug.Log("hahaha ?? ");
    }

    private void AnimateClaimed(int challange)
    {
        if(challange == 1)
        {
            anime_Claimed_1.SetTrigger("claimGift");
        }
        if (challange == 2)
        {
            anime_Claimed_2.SetTrigger("claimGift");
        }
        if (challange == 3)
        {
            anime_Claimed_3.SetTrigger("claimGift");
        }
        if (challange == 4)
        {
            anime_Claimed_4.SetTrigger("claimGift");
        }
        if (challange == 5)
        {
            anime_Claimed_5.SetTrigger("claimGift");
        }
        if (challange == 6)
        {
            anime_Claimed_6.SetTrigger("claimGift");
        }
        if (challange == 7)
        {
            anime_Claimed_7.SetTrigger("claimGift");
        }
        if (challange == 8)
        {
            anime_Claimed_8.SetTrigger("claimGift");
        }
    }

    private void ClaimAllGifts()
    {
        //for each button gift check if interactable then do stuff
        for (int i = 0; i < GIFTS.Length; i++)
        {
            if (claim_challange1)
            {
                Button GIFT_BTN = GIFTS[0].GetComponentInChildren<Button>();
                GIFT_BTN.interactable = false;
                GiftIsOpened(1);
                AnimateClaimed(1);
                SetStatusImg(0);
            }
            if (claim_challange2)
            {
                Button GIFT_BTN = GIFTS[1].GetComponentInChildren<Button>();
                GIFT_BTN.interactable = false;
                GiftIsOpened(2);
                AnimateClaimed(2);
                SetStatusImg(1);           

            }
            if (claim_challange3)
            {
                Button GIFT_BTN = GIFTS[2].GetComponentInChildren<Button>();
                GIFT_BTN.interactable = false;
                GiftIsOpened(3);
                AnimateClaimed(3);
                SetStatusImg(2);
            }
            if (claim_challange4)
            {
                Button GIFT_BTN = GIFTS[3].GetComponentInChildren<Button>();
                GIFT_BTN.interactable = false;
                GiftIsOpened(4);
                AnimateClaimed(4);
                SetStatusImg(3);
            }
            if (claim_challange5)
            {
                Button GIFT_BTN = GIFTS[4].GetComponentInChildren<Button>();
                GIFT_BTN.interactable = false;
                GiftIsOpened(5);
                AnimateClaimed(5);
                SetStatusImg(4);
            }
            if (claim_challange6)
            {
                Button GIFT_BTN = GIFTS[5].GetComponentInChildren<Button>();
                GIFT_BTN.interactable = false;
                GiftIsOpened(6);
                AnimateClaimed(6);
                SetStatusImg(5);
            }
            if (claim_challange7)
            {
                Button GIFT_BTN = GIFTS[6].GetComponentInChildren<Button>();
                GIFT_BTN.interactable = false;
                GiftIsOpened(7);
                AnimateClaimed(7);
                SetStatusImg(6);
            }
            if (claim_challange8)
            {
                Button GIFT_BTN = GIFTS[7].GetComponentInChildren<Button>();
                GIFT_BTN.interactable = false;
                GiftIsOpened(8);
                AnimateClaimed(8);
                SetStatusImg(7);
            }
        }

        StartCoroutine(playCoinAnimations());
       

    }

    private void ManageDisableRewards()
    {
        if (Instance.gift_1_opened == 1) { DisableReward(0); }
        if (Instance.gift_2_opened == 1) { DisableReward(1); }
        if (Instance.gift_3_opened == 1) { DisableReward(2); }
        if (Instance.gift_4_opened == 1) { DisableReward(3); }
        if (Instance.gift_5_opened == 1) { DisableReward(4); }
        if (Instance.gift_6_opened == 1) { DisableReward(5); }
        if (Instance.gift_7_opened == 1) { DisableReward(6); }
        if (Instance.gift_8_opened == 1) { DisableReward(7); }
    }

    private void DisableReward(int challange)
    {
        for (int i = 0; i < REWARDS.Length; i++)
        {
            if (challange == i)
            {
                if(REWARDS[i].activeSelf == true)
                    REWARDS[i].SetActive(false);
            }
        }
      
    }


    //side bars coins / kills
    // KILL COUNTER
    private void ShowKillCounter(Animator anime)
    {
        anime.SetTrigger("showKills");
    }

    private void ExitKillCounter(Animator anime)
    {
        anime.SetTrigger("exitKills");
    }
    // COINS
    private void ShowCoinsNum(Animator anime)
    {
        anime.SetTrigger("showCoins");
    }

    private void ExitCoinsNum(Animator anime)
    {
        anime.SetTrigger("exitCoins");
    }

    //set kill txt and coins txt
    private void ManageTxtValue_Coins(int coins)
    {
        numOfCoins.text = coins.ToString();
    }

    private void ManageTxtValue_Kills(int kills)
    {
        numOfKills.text = kills.ToString();
    }


    //change sprite img of status section
    private void SetStatusImg(int challange)
    {
        for (int i = 0; i < PROGRESS_IMGS.Length; i++)
        {
            if(challange == i)
            {
                Image newImg = PROGRESS_IMGS[i].GetComponent<Image>();
                newImg.sprite = checkmark_sprite;
            }
        }
    }


}
