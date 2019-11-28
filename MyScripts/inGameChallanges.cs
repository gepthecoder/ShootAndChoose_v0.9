using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class inGameChallanges : MonoBehaviour
{
    #region Challange Animation
    private Animator anime;
    public Text challangeNum_txt;

    private int currentNumOfKills;

    private int challangeOne_kills = 10;
    private int challangeTwo_kills = 20;
    private int challangeThree_kills = 30;
    private int challangeFour_kills = 50;
    private int challangeFive_kills = 70;
    private int challangeSix_kills = 100;
    private int challangeSeven_kills = 200;
    private int challangeEight_kills = 500;

    public int Challange_1_Animated = 0;
    public int Challange_2_Animated = 0;
    public int Challange_3_Animated = 0;
    public int Challange_4_Animated = 0;
    public int Challange_5_Animated = 0;
    public int Challange_6_Animated = 0;
    public int Challange_7_Animated = 0;
    public int Challange_8_Animated = 0;

    private static inGameChallanges instance;
    public static inGameChallanges Instance { get { return instance; } }
    #endregion

    public GameObject fireWorks;

 
    private float duration = 1.5f;
    public Transform pos1;
    public Transform pos2;

    void Awake()
    {
        anime = GetComponent<Animator>();

        if (PlayerPrefs.HasKey("challangeOne_complete"))
        {
            Challange_1_Animated = PlayerPrefs.GetInt("Challange_1_Animated", 0);
            Challange_2_Animated = PlayerPrefs.GetInt("Challange_2_Animated", 0);
            Challange_3_Animated = PlayerPrefs.GetInt("Challange_3_Animated", 0);
            Challange_4_Animated = PlayerPrefs.GetInt("Challange_4_Animated", 0);
            Challange_5_Animated = PlayerPrefs.GetInt("Challange_5_Animated", 0);
            Challange_6_Animated = PlayerPrefs.GetInt("Challange_6_Animated", 0);
            Challange_7_Animated = PlayerPrefs.GetInt("Challange_7_Animated", 0);
            Challange_8_Animated = PlayerPrefs.GetInt("Challange_8_Animated", 0);
        }else
        {
            //save
            Save();
        }
    }

    private void Save()
    {
        PlayerPrefs.SetInt("Challange_1_Animated", Challange_1_Animated);
        PlayerPrefs.SetInt("Challange_2_Animated", Challange_2_Animated);
        PlayerPrefs.SetInt("Challange_3_Animated", Challange_3_Animated);
        PlayerPrefs.SetInt("Challange_4_Animated", Challange_4_Animated);
        PlayerPrefs.SetInt("Challange_5_Animated", Challange_5_Animated);
        PlayerPrefs.SetInt("Challange_6_Animated", Challange_6_Animated);
        PlayerPrefs.SetInt("Challange_7_Animated", Challange_7_Animated);
        PlayerPrefs.SetInt("Challange_8_Animated", Challange_8_Animated);

    }

    void Update()
    {
        currentNumOfKills = PlayerPrefs.GetInt("totalKills", 0);
        ManageChallanges_ComplitedChallanges(currentNumOfKills);

        
    }

    public void ManageChallanges_ComplitedChallanges(int numOfKills)
    {
        ChallangeHandler(numOfKills);
    }

    public void ChallangeHandler(int numOfKills)
    {
        if ((numOfKills >= challangeOne_kills) && (PlayerPrefs.GetInt("challangeOne_complete", 0) == 0))
        {
            challangeNum_txt.text = "1";
            PlayerPrefs.SetInt("challangeOne_complete", 1);

            //play anime once
            if (PlayerPrefs.GetInt("Challange_1_Animated", 0) == 0)
            {
                anime.SetTrigger("showChallangeCompleted");
                PlayerPrefs.SetInt("Challange_1_Animated", 1);
                Debug.Log("Challange 1 complete!" + PlayerPrefs.GetInt("challangeOne_complete"));
            }
        }

        if ((numOfKills >= challangeTwo_kills) && (PlayerPrefs.GetInt("challangeTwo_complete", 0) == 0))
        {
            challangeNum_txt.text = "2";
            PlayerPrefs.SetInt("challangeTwo_complete", 1);
            //play anime once
            if (PlayerPrefs.GetInt("Challange_2_Animated", 0) == 0)
            {
                anime.SetTrigger("showChallangeCompleted");
                PlayerPrefs.SetInt("Challange_2_Animated", 1);

                Debug.Log("Challange 2 complete!" + PlayerPrefs.GetInt("challangeTwo_complete"));
            }
        }

        if ((numOfKills >= challangeThree_kills) && (PlayerPrefs.GetInt("challangeThree_complete", 0) == 0))
        {
            challangeNum_txt.text = "3";
            PlayerPrefs.SetInt("challangeThree_complete", 1);
            //play anime once
            if (PlayerPrefs.GetInt("Challange_3_Animated", 0) == 0)
            {
                anime.SetTrigger("showChallangeCompleted");
                PlayerPrefs.SetInt("Challange_3_Animated", 1);

                Debug.Log("Challange 3 complete!" + PlayerPrefs.GetInt("challangeThree_complete"));
            }
        }

        if ((numOfKills >= challangeFour_kills) && (PlayerPrefs.GetInt("challangeFour_complete", 0) == 0))
        {
            challangeNum_txt.text = "4";
            PlayerPrefs.SetInt("challangeFour_complete", 1);
            //play anime once
            if (PlayerPrefs.GetInt("Challange_4_Animated", 0) == 0)
            {
                anime.SetTrigger("showChallangeCompleted");
                PlayerPrefs.SetInt("Challange_4_Animated", 1);

                Debug.Log("Challange 4 complete!" + PlayerPrefs.GetInt("challangeFour_complete"));
            }
        }

        if ((numOfKills >= challangeFive_kills) && (PlayerPrefs.GetInt("challangeFive_complete", 0) == 0))
        {
            challangeNum_txt.text = "5";
            PlayerPrefs.SetInt("challangeFive_complete", 1);
            //play anime once
            if (PlayerPrefs.GetInt("Challange_5_Animated", 0) == 0)
            {
                anime.SetTrigger("showChallangeCompleted");
                PlayerPrefs.SetInt("Challange_5_Animated", 1);

                Debug.Log("Challange 5 complete!" + PlayerPrefs.GetInt("challangeFive_complete"));
            }
        }

        if ((numOfKills >= challangeSix_kills) && (PlayerPrefs.GetInt("challangeSix_complete", 0) == 0))
        {
            challangeNum_txt.text = "6";
            PlayerPrefs.SetInt("challangeSix_complete", 1);
            //play anime once
            if (PlayerPrefs.GetInt("Challange_6_Animated", 0) == 0)
            {
                anime.SetTrigger("showChallangeCompleted");
                PlayerPrefs.SetInt("Challange_6_Animated", 1);

                Debug.Log("Challange 6 complete!" + PlayerPrefs.GetInt("challangeSix_complete"));
            }
        }

        if ((numOfKills >= challangeSeven_kills) && (PlayerPrefs.GetInt("challangeSeven_complete", 0) == 0))
        {
            challangeNum_txt.text = "7";
            PlayerPrefs.SetInt("challangeSeven_complete", 1);
            //play anime once
            if (PlayerPrefs.GetInt("Challange_7_Animated", 0) == 0)
            {
                anime.SetTrigger("showChallangeCompleted");
                PlayerPrefs.SetInt("Challange_7_Animated", 1);

                Debug.Log("Challange 7 complete!" + PlayerPrefs.GetInt("challangeSeven_complete"));
            }
        }

        if ((numOfKills >= challangeEight_kills) && (PlayerPrefs.GetInt("challangeEight_complete", 0) == 0))
        {
            challangeNum_txt.text = "8";
            PlayerPrefs.SetInt("challangeEight_complete", 1);
            //play anime once
            if (PlayerPrefs.GetInt("Challange_8_Animated", 0) == 0)
            {
                anime.SetTrigger("showChallangeCompleted");
                PlayerPrefs.SetInt("Challange_8_Animated", 1);

                Debug.Log("Challange 8 complete!" + PlayerPrefs.GetInt("challangeEight_complete"));
            }
        }
    }

    public void playFX_challangeDone()
    {
        GameObject funGO1 = Instantiate(fireWorks, pos1.position, Quaternion.identity);
        Destroy(funGO1, duration);

        GameObject funGO2 = Instantiate(fireWorks, pos2.position, Quaternion.identity);
        Destroy(funGO2, duration);
    }


}
