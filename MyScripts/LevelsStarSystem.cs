using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsStarSystem : MonoBehaviour
{
    public GameObject[] Stars;

    public Sprite emptyStar_sprite;

    private void Awake()
    {
        Stars = GameObject.FindGameObjectsWithTag("stars");
        Debug.Log(Stars.Length + " num of objects --> stars");

    }

    private void Start()
    {
        FetchStarsAndManageColors();
        ManageEmptyStars();
    }


    public void FetchStarsAndManageColors()
    {
        foreach (GameObject star in Stars)
        {
            for (int i = 1; i <= PlayerPrefs.GetInt("a3", 1); i++)
            {       
                //show active stars for unlocked levels
                star.SetActive(true);

                //show colored stars for each level
                if (star.name.Contains("lvl" + i.ToString()) && star.name.Substring(0, 1) != "<")
                {
                    Image[] star_imgs = star.GetComponentsInChildren<Image>();
                    //get data and show golden stars
                    int numOfStars = PlayerPrefs.GetInt("stars_lvl" + i.ToString());

                    if (numOfStars == 3)
                    {
                        foreach (Image star_img in star_imgs)
                        {
                            //Show 3 stars..
                            star_img.color = Color.yellow;
                        }
                    }
                    else if (numOfStars == 2)
                    {
                        for (int j = 0; j <= numOfStars; j++)
                        {
                            for (int x = 0; x <= star_imgs.Length; x++)
                            {
                                //show 2 stars
                                Debug.Log("Show two stars " + star_imgs[0].color);
                                star_imgs[0].color = Color.yellow;
                                star_imgs[1].color = Color.yellow;
                            }
                        }
                    }
                    else if (numOfStars == 1)
                    {
                        for (int j = 0; j <= numOfStars; j++)
                        {
                            for (int x = 0; x <= star_imgs.Length; x++)
                                ////show 1 stars
                                star_imgs[0].color = Color.yellow;
                        }
                    }
                } else if(i > 9 && star.name.Substring(0,1) == "<")
                {
                    if (star.name.Contains("lvl" + i.ToString()))
                    {
                        Image[] star_imgs = star.GetComponentsInChildren<Image>();
                        //get data and show golden stars
                        int numOfStars = PlayerPrefs.GetInt("stars_lvl" + i.ToString());

                        if (numOfStars == 3)
                        {
                            foreach (Image star_img in star_imgs)
                            {
                                //Show 3 stars..
                                star_img.color = Color.yellow;
                            }
                        }
                        else if (numOfStars == 2)
                        {
                            for (int j = 0; j <= numOfStars; j++)
                            {
                                for (int x = 0; x <= star_imgs.Length; x++)
                                {
                                    //show 2 stars
                                    Debug.Log("Show two stars " + star_imgs[0].color);
                                    star_imgs[0].color = Color.yellow;
                                    star_imgs[1].color = Color.yellow;
                                }
                            }
                        }
                        else if (numOfStars == 1)
                        {
                            for (int j = 0; j <= numOfStars; j++)
                            {
                                for (int x = 0; x <= star_imgs.Length; x++)
                                    ////show 1 stars
                                    star_imgs[0].color = Color.yellow;
                            }
                        }
                    }
                }
            }
        }       
    }

    public void ManageEmptyStars()
    {
        for (int i = 0; i < Stars.Length; i++)
        {
            for (int j = PlayerPrefs.GetInt("a3", 1); j < 22; j++)
            {
                Image[] stars = Stars[j].GetComponentsInChildren<Image>();
                {
                    //change sprites
                    foreach(Image starImg in stars)
                    {
                        starImg.sprite = emptyStar_sprite;                   
                    }

                    if(j == 21)
                    {
                        Debug.Log("Finnished Unlocking :)");
                        return;
                    }
                }

            }
        }
    }


}
