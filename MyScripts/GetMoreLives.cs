using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetMoreLives : MonoBehaviour
{
    public static bool userBoughtItem; //he may continue playing

    public GameObject buttonStartOver;
    public GameObject buttonRestartLevel;
    public Text startOverText;

    public Animator getMoreLivesAnime;

    public void clickEventGetMoreLives()
    {
        getMoreLivesAnime.SetTrigger("getMoreLives");
        audioManager.getMoreLives_click = true;
    }

    public void clickCloseGetMoreLives()
    {
        getMoreLivesAnime.SetTrigger("backout");
    }

    private void HandleBoughtOption()
    {
        startOverText.fontSize = startOverText.fontSize - 2;
        startOverText.text = "Repeat Level";
        buttonStartOver.SetActive(false);
        buttonRestartLevel.SetActive(true);
       
    }

    private void ManageContinueOption()
    {
        if (userBoughtItem)
        {
            //he may continue playing next level
            HandleBoughtOption();
            userBoughtItem = false;
        }
    }

    void Update()
    {
        ManageContinueOption();
    }
}
