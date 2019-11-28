using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    #region Inicialization

    public GoPlay fader;

    public Button[] levelButtons;

    public GameObject LockImglvl2;
    public GameObject LockImglvl3;

    public GameObject LockImglvl4;
    public GameObject LockImglvl5;

    public GameObject LockImglvl6;
    public GameObject LockImglvl7;

    public GameObject LockImglvl8;
    public GameObject LockImglvl9;

    public GameObject LockImglvl10;
    public GameObject LockImglvl11;

    public GameObject LockImglvl12;
    public GameObject LockImglvl13;

    public GameObject LockImglvl14;
    public GameObject LockImglvl15;

    public GameObject LockImglvl16;
    public GameObject LockImglvl17;

    public GameObject LockImglvl18;
    public GameObject LockImglvl19;

    public GameObject LockImglvl20;
    public GameObject LockImglvl21;

    #endregion

    void Awake()
    {
        int levelReached = PlayerPrefs.GetInt("a3", 1);
        //Debug.Log(levelReached);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;

                if(levelButtons[1].interactable == false) { LockImglvl2.SetActive(true); }
                else { LockImglvl2.SetActive(false); }

                if (levelButtons[2].interactable == false) { LockImglvl3.SetActive(true); }
                else { LockImglvl3.SetActive(false); }

                if (levelButtons[3].interactable == false) { LockImglvl4.SetActive(true); }
                else { LockImglvl4.SetActive(false); }

                if (levelButtons[4].interactable == false) { LockImglvl5.SetActive(true); }
                else { LockImglvl5.SetActive(false); }

                if (levelButtons[5].interactable == false) { LockImglvl6.SetActive(true); }
                else { LockImglvl6.SetActive(false); }

                if (levelButtons[6].interactable == false) { LockImglvl7.SetActive(true); }
                else { LockImglvl7.SetActive(false); }

                if (levelButtons[7].interactable == false) { LockImglvl8.SetActive(true); }
                else { LockImglvl8.SetActive(false); }

                if (levelButtons[8].interactable == false) { LockImglvl9.SetActive(true); }
                else { LockImglvl9.SetActive(false); }

                if (levelButtons[9].interactable == false) { LockImglvl10.SetActive(true); }
                else { LockImglvl10.SetActive(false); }

                if (levelButtons[10].interactable == false) { LockImglvl11.SetActive(true); }
                else { LockImglvl11.SetActive(false); }

                if (levelButtons[11].interactable == false) { LockImglvl12.SetActive(true); }
                else { LockImglvl12.SetActive(false); }

                if (levelButtons[12].interactable == false) { LockImglvl13.SetActive(true); }
                else { LockImglvl13.SetActive(false); }

                if (levelButtons[13].interactable == false) { LockImglvl14.SetActive(true); }
                else { LockImglvl14.SetActive(false); }

                if (levelButtons[14].interactable == false) { LockImglvl15.SetActive(true); }
                else { LockImglvl15.SetActive(false); }

                if (levelButtons[15].interactable == false) { LockImglvl16.SetActive(true); }
                else { LockImglvl16.SetActive(false); }

                if (levelButtons[16].interactable == false) { LockImglvl17.SetActive(true); }
                else { LockImglvl17.SetActive(false); }

                if (levelButtons[17].interactable == false) { LockImglvl18.SetActive(true); }
                else { LockImglvl18.SetActive(false); }

                if (levelButtons[18].interactable == false) { LockImglvl19.SetActive(true); }
                else { LockImglvl19.SetActive(false); }

                if (levelButtons[19].interactable == false) { LockImglvl20.SetActive(true); }
                else { LockImglvl20.SetActive(false); }

                if (levelButtons[20].interactable == false) { LockImglvl21.SetActive(true); }
                else { LockImglvl21.SetActive(false); }

            }
        }
    }


   public void Select(string levelName)
    {
        fader.FadeToSpecificLevel(levelName);
    }
  
    public void SET_PREF_ResetLevel()
    {
        PlayerPrefs.SetInt("a3", 1);
    }

}
