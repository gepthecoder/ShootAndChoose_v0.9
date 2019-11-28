using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    private static bool gameOver;
    public static bool GameOver { get { return gameOver; } set { gameOver = value; } }

    public Animator anime;
    public Shoot shoot;
    public GoPlay fader;
    public PlayerHealth health;

    public GameObject gameOverGUI;

    private GameObject[] enemies;

    private AudioSource gameOverSound;
    public AudioClip aClip_gameOverSound;
    private int counter = 0;

    void Awake()
    {
        gameOver = false;
        gameOverGUI.SetActive(false);
    }

    void Start()
    {
        gameOverSound = GetComponent<AudioSource>();
        counter = 0;
    }

    void Update()
    {
        if (GameOver == true)
        {
            if (anime != null) {
                StartCoroutine(EndGameInStyle());
            }

            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies != null)
            {
                foreach (GameObject enemy in enemies)
                {
                    enemy.GetComponent<EnemyAttck>().enabled = false;
                }
            }

          
        }
    }

    

    private IEnumerator EndGameInStyle()
    {
        gameOverGUI.SetActive(true);
        yield return new WaitForSeconds(2f);
        if(counter == 0)
        {
            gameOverSound.PlayOneShot(aClip_gameOverSound);
            counter++;
        }
        anime.SetTrigger("gameover");
        shoot.enabled = false;
        gameOver = false;
        

    }

    public void StartOver()
    {
        PlayerPrefs.SetInt("a3", 1);
        health.playerHealth += 4;
        health.SavePlayerHealth();
        fader.OpenLevel1();
        Debug.Log("START OVER!!");
    
    }

    public void GoToMenu()
    {
        PlayerPrefs.SetInt("a3", 1);
        PlayerPrefs.SetInt("playerHealth", 1);
        fader.ReturnToMenu();
    }

    public void GetMoreLives()
    {
        //Open SHOP FOR LIVES <-- TO:DO
    }

}
