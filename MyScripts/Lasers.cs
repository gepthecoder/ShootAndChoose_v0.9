using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasers : MonoBehaviour
{
    public GameObject[] lasers;

    void Update()
    {
        ConfigureLaserScales();
    }

    private void ConfigureLaserScales()
    {
        #region Configure
        for (int i = 0; i < lasers.Length; i++)
        {
            if (lasers[i].gameObject.name.Contains("1"))
            {
                #region RedScaler
                //REDS
                if (PlayerPrefs.GetInt("redLevel") == 1)
                {
                    lasers[i].transform.localScale = new Vector3(0.006f, 0.004f, 0.01f);
                }
                else if (PlayerPrefs.GetInt("redLevel") == 2)
                {
                    lasers[i].transform.localScale = new Vector3(0.0064f, 0.0044f, 0.01f);
                }
                else if (PlayerPrefs.GetInt("redLevel") == 3)
                {
                    lasers[i].transform.localScale = new Vector3(0.0068f, 0.0048f, 0.01f);
                }
                else if (PlayerPrefs.GetInt("redLevel") > 3 && PlayerPrefs.GetInt("redLevel") < 6)
                {
                    lasers[i].transform.localScale = new Vector3(0.0075f, 0.0075f, 0.01f);
                }
                else if (PlayerPrefs.GetInt("redLevel") >= 6 && PlayerPrefs.GetInt("redLevel") < 10)
                {
                    lasers[i].transform.localScale = new Vector3(0.0085f, 0.0085f, 0.01f);
                }
                else if (PlayerPrefs.GetInt("redLevel") >= 10 && PlayerPrefs.GetInt("redLevel") < 15)
                {
                    lasers[i].transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                }
                else if (PlayerPrefs.GetInt("redLevel") >= 15 && PlayerPrefs.GetInt("redLevel") < 20)
                {
                    lasers[i].transform.localScale = new Vector3(0.015f, 0.015f, 0.01f);
                }
                else if (PlayerPrefs.GetInt("redLevel") >= 20)
                {
                    lasers[i].transform.localScale = new Vector3(0.023f, 0.023f, 0.01f);
                }
                #endregion
            }

            if (lasers[i].gameObject.name.Contains("2"))
            {
                if (PlayerPrefs.GetInt("boughtGreen") == 1)
                {
                    #region GreenScalar
                    //GREENS
                    if (PlayerPrefs.GetInt("greenLevel") == 1)
                    {
                        lasers[i].transform.localScale = new Vector3(0.006f, 0.004f, 0.01f);
                    }
                    else if (PlayerPrefs.GetInt("greenLevel") == 2)
                    {
                        lasers[i].transform.localScale = new Vector3(0.0064f, 0.0044f, 0.01f);
                    }
                    else if (PlayerPrefs.GetInt("greenLevel") == 3)
                    {
                        lasers[i].transform.localScale = new Vector3(0.0068f, 0.0048f, 0.01f);
                    }
                    else if (PlayerPrefs.GetInt("greenLevel") > 3 && PlayerPrefs.GetInt("redLevel") < 6)
                    {
                        lasers[i].transform.localScale = new Vector3(0.0071f, 0.0051f, 0.01f);
                    }
                    else if (PlayerPrefs.GetInt("greenLevel") >= 6 && PlayerPrefs.GetInt("redLevel") < 10)
                    {
                        lasers[i].transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                    }
                    else if (PlayerPrefs.GetInt("greenLevel") >= 10 && PlayerPrefs.GetInt("redLevel") < 15)
                    {
                        lasers[i].transform.localScale = new Vector3(0.02f, 0.02f, 0.01f);
                    }
                    else if (PlayerPrefs.GetInt("greenLevel") >= 15 && PlayerPrefs.GetInt("redLevel") < 20)
                    {
                        lasers[i].transform.localScale = new Vector3(0.04f, 0.04f, 0.01f);
                    }

                    if (PlayerPrefs.GetInt("greenLevel") >= 20)
                    {
                        lasers[i].transform.localScale = new Vector3(0.06f, 0.06f, 0.01f);
                    }


                    #endregion
                }
            }

            if (lasers[i].gameObject.name.Contains("3"))
            {
                if (PlayerPrefs.GetInt("boughtBlue") == 1)
                {
                    #region BlueScaler
                    //BLUE
                    if (PlayerPrefs.GetInt("blueLevel") == 1)
                    {
                        lasers[i].transform.localScale = new Vector3(0.006f, 0.004f, 0.01f);
                    }
                    else if (PlayerPrefs.GetInt("blueLevel") == 2)
                    {
                        lasers[i].transform.localScale = new Vector3(0.0064f, 0.0044f, 0.01f);
                    }
                    else if (PlayerPrefs.GetInt("blueLevel") == 3)
                    {
                        lasers[i].transform.localScale = new Vector3(0.0068f, 0.0048f, 0.01f);
                    }
                    else if (PlayerPrefs.GetInt("blueLevel") > 3 && PlayerPrefs.GetInt("redLevel") < 6)
                    {
                        lasers[i].transform.localScale = new Vector3(0.0071f, 0.0051f, 0.01f);
                    }
                    else if (PlayerPrefs.GetInt("blueLevel") >= 6 && PlayerPrefs.GetInt("redLevel") < 10)
                    {
                        lasers[i].transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                    }
                    else if (PlayerPrefs.GetInt("blueLevel") >= 10 && PlayerPrefs.GetInt("redLevel") < 15)
                    {
                        lasers[i].transform.localScale = new Vector3(0.02f, 0.02f, 0.01f);
                    }
                    else if (PlayerPrefs.GetInt("blueLevel") >= 15 && PlayerPrefs.GetInt("redLevel") < 20)
                    {
                        lasers[i].transform.localScale = new Vector3(0.04f, 0.04f, 0.01f);
                    }

                    else if (PlayerPrefs.GetInt("blueLevel") >= 20)
                    {
                        lasers[i].transform.localScale = new Vector3(0.06f, 0.06f, 0.01f);
                    }

                    #endregion
                }
            }

            if (lasers[i].gameObject.name.Contains("4"))
            {
                if (PlayerPrefs.GetInt("boughtPurple") == 1)
                {
                    #region PurpleScaler
                    //PURPLE
                    if (PlayerPrefs.GetInt("purpleLevel") == 1)
                    {
                        lasers[i].transform.localScale = new Vector3(0.006f, 0.004f, 0.01f);
                    }
                    else if (PlayerPrefs.GetInt("purpleLevel") == 2)
                    {
                        lasers[i].transform.localScale = new Vector3(0.0064f, 0.0044f, 0.01f);
                    }
                    else if (PlayerPrefs.GetInt("purpleLevel") == 3)
                    {
                        lasers[i].transform.localScale = new Vector3(0.0068f, 0.0048f, 0.01f);
                    }
                    else if (PlayerPrefs.GetInt("purpleLevel") > 3 && PlayerPrefs.GetInt("redLevel") < 6)
                    {
                        lasers[i].transform.localScale = new Vector3(0.0071f, 0.0051f, 0.01f);
                    }
                    else if (PlayerPrefs.GetInt("purpleLevel") >= 6 && PlayerPrefs.GetInt("redLevel") < 10)
                    {
                        lasers[i].transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                    }
                    else if (PlayerPrefs.GetInt("purpleLevel") >= 10 && PlayerPrefs.GetInt("redLevel") < 15)
                    {
                        lasers[i].transform.localScale = new Vector3(0.02f, 0.02f, 0.01f);
                    }
                    else if (PlayerPrefs.GetInt("purpleLevel") >= 15 && PlayerPrefs.GetInt("redLevel") < 20)
                    {
                        lasers[i].transform.localScale = new Vector3(0.04f, 0.04f, 0.01f);
                    }
                    else if (PlayerPrefs.GetInt("purpleLevel") >= 20)
                    {
                        lasers[i].transform.localScale = new Vector3(0.06f, 0.06f, 0.01f);
                    }

                    #endregion
                }
            }

            if (lasers[i].gameObject.name.Contains("5"))
            {
                if (PlayerPrefs.GetInt("boughtGolden") == 1)
                {
                    #region GoldenScaler
                    //GOLDEN
                    if (PlayerPrefs.GetInt("goldenLevel") == 1)
                    {
                        lasers[i].transform.localScale = new Vector3(0.006f, 0.004f, 0.01f);
                    }
                    else if (PlayerPrefs.GetInt("goldenLevel") == 2)
                    {
                        lasers[i].transform.localScale = new Vector3(0.0064f, 0.0044f, 0.01f);
                    }
                    else if (PlayerPrefs.GetInt("goldenLevel") == 3)
                    {
                        lasers[i].transform.localScale = new Vector3(0.0068f, 0.0048f, 0.01f);
                    }
                    else if (PlayerPrefs.GetInt("goldenLevel") > 3 && PlayerPrefs.GetInt("redLevel") < 6)
                    {
                        lasers[i].transform.localScale = new Vector3(0.0071f, 0.0051f, 0.01f);
                    }
                    else if (PlayerPrefs.GetInt("goldenLevel") >= 6 && PlayerPrefs.GetInt("redLevel") < 10)
                    {
                        lasers[i].transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                    }
                    else if (PlayerPrefs.GetInt("goldenLevel") >= 10 && PlayerPrefs.GetInt("redLevel") < 15)
                    {
                        lasers[i].transform.localScale = new Vector3(0.02f, 0.02f, 0.01f);
                    }
                    else if (PlayerPrefs.GetInt("goldenLevel") >= 15 && PlayerPrefs.GetInt("redLevel") < 20)
                    {
                        lasers[i].transform.localScale = new Vector3(0.04f, 0.04f, 0.01f);
                    }
                    else if (PlayerPrefs.GetInt("goldenLevel") >= 20)
                    {
                        lasers[i].transform.localScale = new Vector3(0.06f, 0.06f, 0.01f);
                    }

                    #endregion
                }
            }
        }
        #endregion
    }
}
