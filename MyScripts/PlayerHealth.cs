using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private static PlayerHealth instance;
    public static PlayerHealth Instance { get { return instance; } }

    public Text liveCountText;

    public int playerHealth = 4;

    public GameObject[] hearts;

    public GameObject loseLifePoint;

    public GameObject VFX_BROKEN_HEART;
    public Transform location_broken_heart;


    private void ConfigureHearts() {

        for (int i = 0; i < hearts.Length; i++)
        {
            if(playerHealth == 4)
            {
                hearts[0].SetActive(true);
                hearts[1].SetActive(true);
                hearts[2].SetActive(true);
                hearts[3].SetActive(true);
            }else if(playerHealth == 3)
            {
                hearts[0].SetActive(false);
                hearts[1].SetActive(true);
                hearts[2].SetActive(true);
                hearts[3].SetActive(true);
            }else if (playerHealth == 2)
            {
                hearts[0].SetActive(false);
                hearts[1].SetActive(false);
                hearts[2].SetActive(true);
                hearts[3].SetActive(true);
            }else if (playerHealth == 1)
            {
                hearts[0].SetActive(false);
                hearts[1].SetActive(false);
                hearts[2].SetActive(false);
                hearts[3].SetActive(true);
            }else if (playerHealth <= 0)
            {
                hearts[0].SetActive(false);
                hearts[1].SetActive(false);
                hearts[2].SetActive(false);
                hearts[3].SetActive(false);
            }
        }

    }

    private bool playerIsAlive;

    //private AudioSource aSource;
    //public AudioClip deathClip;

    void Awake()
    {
        instance = this;

        if (PlayerPrefs.HasKey("playerHealth"))
        {
            //we had a previous session
            playerHealth = PlayerPrefs.GetInt("playerHealth", 4);
        }
        else
        {
            //its a new game
            SavePlayerHealth();
        }
    }

    public void SavePlayerHealth()
    {
        PlayerPrefs.SetInt("playerHealth", playerHealth);
    }

    void Start()
    {
        //aSource = GetComponent<AudioSource>();
        playerIsAlive = true;
        ConfigureHearts();
    }

    void Update()
    {
        SavePlayerHealth();
        liveCountText.text = PlayerPrefs.GetInt("playerHealth", 0).ToString();
        ConfigureHearts();


        if (isDead())
        {
            Dead();
        }

       
    }

    private void PlayBrokenHeart()
    {
        Instantiate(VFX_BROKEN_HEART, location_broken_heart, false);
        Debug.Log(location_broken_heart.transform.position + "  Broken heart position");
    }

    public void TakeDamage(int damage, int strenght)
    {
        if (!playerIsAlive) { return; }

        Instance.playerHealth -= damage;
        ConfigureHearts();

        loseLifePoint.GetComponent<Text>().text = "-" + strenght;
        Animator anime = loseLifePoint.GetComponent<Animator>();
        if(anime != null)
        {
            anime.SetTrigger("lifePoint");
        }
        //gameStats.Instance.Save();
        //gameStats.Instance.totalDeaths += 1;
        //gameStats.Instance.Save();  //9.8.2019 19:45
        PlayBrokenHeart();

        if (isDead())
        {
            Dead();
        }
    }

    private bool isDead()
    {
        return PlayerPrefs.GetInt("playerHealth") <= 0;
    }

    public void Dead()
    {
        GameOverManager.GameOver = true;
        //aSource.PlayOneShot(deathClip);
        playerIsAlive = false;
    }
}
