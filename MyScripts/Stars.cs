using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Stars : MonoBehaviour
{
    public Image star1;
    public Image star2;
    public Image star3;

    public AudioClip _getStar;
    private AudioSource aSource;
    private Animator anime;

    public int value;

    private bool soundPlayed;
    private bool soundPlayed1;
    private bool soundPlayed2;

    public int finnalNumOfStars = 0;


    void Awake()
    {
        aSource = GetComponent<AudioSource>();
        anime = GetComponent<Animator>();

        soundPlayed = false;
        soundPlayed1 = false;
        soundPlayed2 = false;

        finnalNumOfStars = 0;
    }

    void Update()
    {
        value = Shoot.valueForStars;

        if(WinLevel.display == true)
        {
            if (value >= 0 && value <= 2) {
                StartCoroutine(PushThreeColors());
               
            }
            else if (value > 2 && value <= 4) {
                StartCoroutine(PushTwoColors());
            }
            else if (value > 4 && value <= 9) {
                StartCoroutine(PushOneColor());
            }

            WinLevel.display = false;
            Debug.Log("Number of stars: " + finnalNumOfStars);
            for (int i = 1; i < 22; i++)
            {
                if (SceneManager.GetActiveScene().name == "Level" + i.ToString())
                {
                    PlayerPrefs.SetInt("stars_lvl" + i.ToString(), finnalNumOfStars);
                    PlayerPrefs.Save();
                }
            }
            
           
        }
    }

    public IEnumerator PlaySound(int starNum)
    {
        if(starNum == 1)
        {
            yield return new WaitForSeconds(1f);
            aSource.PlayOneShot(_getStar);

            yield break;
        }
        else if(starNum == 2)
        {
            yield return new WaitForSeconds(1f);
            aSource.PlayOneShot(_getStar);

            yield return new WaitForSeconds(1f);
            aSource.PlayOneShot(_getStar);

            yield break;
        }
        else if (starNum == 3)
        {
            yield return new WaitForSeconds(1f);
            aSource.PlayOneShot(_getStar);

            yield return new WaitForSeconds(1f);
            aSource.PlayOneShot(_getStar);

            yield return new WaitForSeconds(1f);
            aSource.PlayOneShot(_getStar);

            yield break;
        }
    }


    IEnumerator PushThreeColors()
    {
        yield return new WaitForSeconds(1f);
        star1.color = new Color(255, 255, 0, 255);
        anime.SetTrigger("star");
        if (!soundPlayed)
        {
            aSource.PlayOneShot(_getStar);
            soundPlayed = true;
            finnalNumOfStars++;

        }

        yield return new WaitForSeconds(1f);
        star2.color = new Color(255, 255, 0, 255);
        anime.SetTrigger("star1");
        if (!soundPlayed1)
        {
            aSource.PlayOneShot(_getStar);
            soundPlayed1 = true;
            finnalNumOfStars++;
        }

        yield return new WaitForSeconds(1f);
        star3.color = new Color(255, 255, 0, 255);
        anime.SetTrigger("star2");

        if (!soundPlayed2)
        {
            aSource.PlayOneShot(_getStar);
            soundPlayed2 = true;
            finnalNumOfStars++;
        }
    }

    IEnumerator PushTwoColors()
    {
        yield return new WaitForSeconds(1f);
        star1.color = new Color(255, 255, 0, 255);
        anime.SetTrigger("star");
        if (!soundPlayed)
        {
            aSource.PlayOneShot(_getStar);
            soundPlayed = true;
            finnalNumOfStars++;

        }

        yield return new WaitForSeconds(1f);
        star2.color = new Color(255, 255, 0, 255);
        anime.SetTrigger("star1");
        if (!soundPlayed1)
        {
            aSource.PlayOneShot(_getStar);
            soundPlayed1 = true;
            finnalNumOfStars++;

        }
    }

    IEnumerator PushOneColor()
    {
        yield return new WaitForSeconds(1f);
        star1.color = new Color(255, 255, 0, 255);
        anime.SetTrigger("star");
        if (!soundPlayed)
        {
            aSource.PlayOneShot(_getStar);
            soundPlayed = true;
            finnalNumOfStars++;

        }

    }

  
}
