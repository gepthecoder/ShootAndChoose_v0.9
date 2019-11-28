using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    public Animator anime_ResetGame;
    public Animator anime_DarkenLighten;

    private GameObject[] slides_levels;
    private float timer;
    private float repeatTime = 0.2f;

    void Start()
    {
        //slides_levels = GameObject.FindGameObjectsWithTag("slides");
        //timer = 0;
    }

    public void executeBeforeReset()
    {
        anime_DarkenLighten.SetTrigger("darken");
        anime_ResetGame.SetTrigger("resetGame");
    }

    public void NO_option()
    {
        anime_DarkenLighten.SetTrigger("lighten");
        anime_ResetGame.SetTrigger("noOption");
    }

    public void YES_option()
    {
        ResetLevels();
        anime_DarkenLighten.SetTrigger("lighten");
        anime_ResetGame.SetTrigger("noOption");

    }

    public void ResetLevels()
    {
        PlayerPrefs.SetInt("a3", 1);
    }

   //mark last level
    public void LastAccomplishedLevel(float timer)
    {
        int lastAccomplishedLevel = PlayerPrefs.GetInt("a3", 1);
        float randomSize = Random.Range(5,13);
        Color a = Color.red;
        Color b = Color.green;

        for (int i = 0; i <= slides_levels.Length; i++)
        {
            if(i == lastAccomplishedLevel)
            {
                //we know we are on the last played level
                Outline slide_Outline = slides_levels[i].GetComponent<Outline>();
                if(timer > repeatTime)
                {
                    slide_Outline.effectDistance.Set(randomSize, randomSize);
                    slide_Outline.effectColor = Color.Lerp(a, b, 0.5f);
                    Debug.Log("OUTLINEEEE");
                    timer = 0;
                }

            }
        }
    }

    void Update()
    {
        //timer += Time.deltaTime;
        //LastAccomplishedLevel(timer);
    }

}
