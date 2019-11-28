using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 
     TRANSITION TO THE NEXT SCENE      
     
*/

public class GoPlay : MonoBehaviour
{
    public Animator anime;

    private int levelToLoad;
    public string levelToLoadtxt;

    private int lvl2Value = 10;

    public void Play()
    {
        FadeToTheNextLevel();
    }

    public void FadeToTheNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToSpecificLevel(string levelname)
    {
        FadeToLevelTxt(levelname);
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        anime.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }


    public void FadeToLevelTxt(string levelName)
    {
        levelToLoadtxt = levelName;
        anime.SetTrigger("FadeOut");
    }

    public void StartGame() {
        FadeToTheNextLevel();
    }

    public void ReturnToMenu()
    {
        FadeToLevel(1);
    }

    public void OpenLevels() {
        FadeToLevel(23);
    }

    public void OpenLevel1() {
        FadeToLevel(2);
    }
    public void OpenLevel2() {
        FadeToLevel(3);
    }
    public void OpenLevel3() {
        FadeToLevel(4);
    }
    public void OpenLevel4()
    {
        FadeToLevel(5);
    }
    public void OpenLevel5()
    {
        FadeToLevel(6);
    }
    public void OpenLevel6()
    {
        FadeToLevel(7);
    }
    public void OpenLevel7()
    {
        FadeToLevel(8);
    }
    public void OpenLevel8()
    {
        FadeToLevel(9);
    }
    public void OpenLevel9()
    {
        FadeToLevel(10);
    }
    public void OpenLevel10()
    {
        FadeToLevel(11);
    }
    public void OpenLevel11()
    {
        FadeToLevel(12);
    }
    public void OpenLevel12()
    {
        FadeToLevel(13);
    }
    public void OpenLevel13()
    {
        FadeToLevel(14);
    }
    public void OpenLevel14()
    {
        FadeToLevel(15);
    }
    public void OpenLevel15()
    {
        FadeToLevel(16);
    }
    public void OpenLevel16()
    {
        FadeToLevel(17);
    }
    public void OpenLevel17()
    {
        FadeToLevel(18);
    }
    public void OpenLevel18()
    {
        FadeToLevel(19);
    }
    public void OpenLevel19()
    {
        FadeToLevel(20);
    }
    public void OpenLevel20()
    {
        FadeToLevel(21);
    }
    public void OpenLevel21()
    {
        FadeToLevel(22);
    }


    public void GoToLastPlayedLevel()
    {
        if (PlayerPrefs.GetString("lastScene") == "Level1") { OpenLevel1(); }
        else if (PlayerPrefs.GetString("lastScene") == "Level2") { OpenLevel2(); }
        else if (PlayerPrefs.GetString("lastScene") == "Level3") { OpenLevel3(); }
        else if (PlayerPrefs.GetString("lastScene") == "Level4") { OpenLevel4(); }
        else if (PlayerPrefs.GetString("lastScene") == "Level5") { OpenLevel5(); }
        else if (PlayerPrefs.GetString("lastScene") == "Level6") { OpenLevel6(); }
        else if (PlayerPrefs.GetString("lastScene") == "Level7") { OpenLevel7(); }
        else if (PlayerPrefs.GetString("lastScene") == "Level8") { OpenLevel8(); }
        else if (PlayerPrefs.GetString("lastScene") == "Level9") { OpenLevel9(); }
        else if (PlayerPrefs.GetString("lastScene") == "Level10") { OpenLevel10(); }
        else if (PlayerPrefs.GetString("lastScene") == "Level11") { OpenLevel11(); }
        else if (PlayerPrefs.GetString("lastScene") == "Level12") { OpenLevel12(); }
        else if (PlayerPrefs.GetString("lastScene") == "Level13") { OpenLevel13(); }
        else if (PlayerPrefs.GetString("lastScene") == "Level14") { OpenLevel14(); }
        else if (PlayerPrefs.GetString("lastScene") == "Level15") { OpenLevel15(); }
        else if (PlayerPrefs.GetString("lastScene") == "Level16") { OpenLevel16(); }
        else if (PlayerPrefs.GetString("lastScene") == "Level17") { OpenLevel17(); }
        else if (PlayerPrefs.GetString("lastScene") == "Level18") { OpenLevel18(); }
        else if (PlayerPrefs.GetString("lastScene") == "Level19") { OpenLevel19(); }
        else if (PlayerPrefs.GetString("lastScene") == "Level20") { OpenLevel20(); }
        else if (PlayerPrefs.GetString("lastScene") == "Level21") { OpenLevel21(); }

        //Debug.Log("Last scene is: " + PlayerPrefs.GetString("lastScene"));
        //ADD CODE..
    }

    public void OpenWeaponShop()
    {
        FadeToLevel(25);
        //Debug.Log("Weapon shop opened!");
    }

    public void OpenCharacterShop()
    {
        FadeToLevel(26);
    }

    public void OpenPurchaseShop()
    {
        FadeToLevel(27);

    }

    public void ReloadLevel()
    {
        GoToLastPlayedLevel();
    }

    public void openSelectLevel()
    {
        FadeToLevel(23);
    }

    public void OpenLaserShop()
    {
        FadeToLevel(24);
    }

    public void OpenMainShop()
    {
        FadeToLevel(28);
    }
}
