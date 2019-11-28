using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using EZCameraShake;

public class MoveUpwards : MonoBehaviour
{
    public static bool killConfirmed;
    public static bool bossKillConfirmed;

    public static bool PlatformMoves;
    public static bool levelCompleted;

    public static int currentKills;
    public static int bossLivesCount;

    public string nextLevel = "Level2";
    public static int levelToReach = 2;

    #region LevelLimit
    public int lvl1Limit = 12;
    public int lvl2Limit = 16;
    public int lvl3Limit = 20;
    public int lvl4Limit = 26;
    public int lvl5Limit = 32;
    public int lvl6Limit = 36;
    public int lvl7Limit = 42;
    public int lvl8Limit = 46;
    public int lvl9Limit = 48;
    public int lvl10Limit = 54;
    public int lvl11Limit = 60;
    public int lvl12Limit = 66;
    public int lvl13Limit = 72;
    public int lvl14Limit = 78;
    public int lvl15Limit = 80;
    public int lvl16Limit = 82;
    public int lvl17Limit = 84;
    public int lvl18Limit = 88;
    public int lvl19Limit = 90;
    public int lvl20Limit = 92;
    public int lvl21Limit = 94;

    public int levelLimit;
    #endregion

    public static int FloorNum;
    public int floorNum;

    private int startValue = 0;
    public int currentValue;

    private Vector3 startPosition;
    private Vector3 endPosition;

    private float time;

    public GameObject turrent;

    public GameObject cam;

    public GameObject fader;

    public GameObject[] Enemies;
    public static GameObject[] allEnemies;


    public List<string> gameObjectsNames = new List<string>();
    public List<GameObject> gameObjects = new List<GameObject>();

    private bool canMove;
    private bool playSound;

    public Animator FloorTxt;
    public int allFloorsNum;

    private GameObject shootGO;
    private Shoot shoot;

    public GameObject HeartPosition_Transform;

    #region Floor Attempts
    private int floorNumAttempt1;
    private int floorNumAttempt2;
    private int floorNumAttempt3;
    private int floorNumAttempt4;
    private int floorNumAttempt5;
    private int floorNumAttempt6;
    private int floorNumAttempt7;
    private int floorNumAttempt8;
    private int floorNumAttempt9;
    private int floorNumAttempt10;
    private int floorNumAttempt11;
    private int floorNumAttempt12;
    private int floorNumAttempt13;
    private int floorNumAttempt14;
    private int floorNumAttempt15;
    private int floorNumAttempt16;
    private int floorNumAttempt17;
    private int floorNumAttempt18;
    private int floorNumAttempt19;
    private int floorNumAttempt20;
    private int floorNumAttempt21;
    private int floorNumAttempt22;
    private int floorNumAttempt23;
    private int floorNumAttempt24;
    private int floorNumAttempt25;
    private int floorNumAttempt26;
    private int floorNumAttempt27;
    private int floorNumAttempt28;
    private int floorNumAttempt29;
    private int floorNumAttempt30;
    private int floorNumAttempt31;
    private int floorNumAttempt32;
    private int floorNumAttempt33;
    private int floorNumAttempt34;
    private int floorNumAttempt35;
    private int floorNumAttempt36;
    private int floorNumAttempt37;
    private int floorNumAttempt38;
    private int floorNumAttempt39;
    private int floorNumAttempt40;
    private int floorNumAttempt41;
    private int floorNumAttempt42;
    private int floorNumAttempt43;
    private int floorNumAttempt44;
    private int floorNumAttempt45;
    private int floorNumAttempt46;
    private int floorNumAttempt47;

    void SetFloorNumAttempts()
    {
        floorNumAttempt1 = 0;
        floorNumAttempt2 = 0;
        floorNumAttempt3 = 0;
        floorNumAttempt4 = 0;
        floorNumAttempt5 = 0;
        floorNumAttempt6 = 0;
        floorNumAttempt7 = 0;
        floorNumAttempt8 = 0;
        floorNumAttempt9 = 0;
        floorNumAttempt10 = 0;
        floorNumAttempt11 = 0;
        floorNumAttempt12 = 0;
        floorNumAttempt13 = 0;
        floorNumAttempt14 = 0;
        floorNumAttempt15 = 0;
        floorNumAttempt16 = 0;
        floorNumAttempt17 = 0;
        floorNumAttempt18 = 0;
        floorNumAttempt19 = 0;
        floorNumAttempt20 = 0;
        floorNumAttempt21 = 0;
    }

    #endregion

    #region Values

    #region PLAYER PLATFORM VALUES
    //#####################---->PLAYER PLATFORM VALUES<----###############################
    //level1
    private int FloorOneValue = 2;
    private int FloorTwoValue = 4;
    private int FloorThreeValue = 6;
    private int FloorFourValue = 8;
    //
    //level2
    private int FloorFiveValue = 10;
    private int FloorSixValue = 12;
    //
    //level3
    private int FloorSevenValue = 14;
    private int FloorEightValue = 16;
    //
    //level4
    private int FloorNineValue = 18;
    private int FloorTenValue = 20;
    private int FloorElevenValue = 22;
    //
    //level5
    private int FloorTwelveValue = 24;
    private int FloorThirteenValue = 26;
    private int FloorFourteenValue = 28;
    //
    //level6
    private int FloorFivteenValue = 30;
    private int FloorSixteenValue = 32;
    //
    //level7
    private int FloorSeventeenValue = 34;
    private int FloorEightteenValue = 36;
    private int FloorNineteenValue = 38;
    //
    //level8
    private int FloorTwentyValue = 40;
    //
    //level9
    private int FloorTwentyoneValue = 42;
    private int FloorTwentytwoValue = 44;
    //
    //level10
    private int FloorTwentythreeValue = 46;
    private int FloorTwentyfourValue = 48;
    private int FloorTwentyfiveValue = 50;
    //
    //level11
    private int FloorTwentysixValue = 52;
    private int FloorTwentysevenValue = 54;
    private int FloorTwentyeightValue = 56;
    //
    //level12
    private int FloorTwentynineValue = 58;
    private int FloorThirtyValue = 60;
    private int FloorThirtyoneValue = 62;
    //
    //level13
    private int FloorThirtytwoValue = 64;
    private int FloorThirtythreeValue = 66;
    private int FloorThirtyfourValue = 68;
    //
    //level14
    private int FloorThirtyfiveValue = 70;
    private int FloorThirtysixValue = 72;
    private int FloorThirtysevenValue = 74;
    //
    //level15
    private int FloorThirtyeightValue = 76;
    //
    //level16
    private int FloorThirtynineValue = 78;
    //
    //level17
    private int FloorFourtyValue = 80;
    //
    //level18
    private int FloorFourtyoneValue = 82;
    private int FloorFourtytwoValue = 84;
    //
    //level19
    private int FloorFourtythreeValue = 86;
    private int FloorFourtyfourValue = 88;
    //
    //level20
    private int FloorFourtyfiveValue = 90;
    //
    //level21
    private int FloorFourtysixValue = 92;
    //
    //level22
    private int FloorFourtysevenValue = 94;
    //
    ////level23
    //private int FloorFourtyeightValue = 100;
    ////
    ////level24
    //private int FloorFourtynineValue = 102;
    ////
    ////level25
    //private int FloorFiftyValue = 104;
    //#########################################################################################
    #endregion

    #region PLAYER PLATFORM Y POSITIONS
    //#####################---->PLAYER PLATFORM Y POSITIONS<----###############################
    //level1
    private float FloorOneHeight = 1.93f;
    private float FloorTwoHeight = 3.9f;
    private float FloorThreeHeight = 5.82f;
    private float FloorFourHeight = 7.81f;
    //
    //level2
    private float FloorFiveHeight = 9.89f;
    private float FloorSixHeight = 11.9f;
    //
    //level3
    private float FloorSevenHeight = 13.87f;
    private float FloorEightHeight = 15.91f;
    //      
    //level4 
    private float FloorNineHeight = 17.9f;
    private float FloorTenHeight = 19.9f;
    private float FloorElevenHeight = 21.9f;
    //      
    //level5
    private float FloorTwelveHeight = 23.87f;
    private float FloorThirteenHeight = 25.76f;
    private float FloorFourteenHeight = 27.87f;
    //      
    //level6
    private float FloorFivteenHeight = 29.89f;
    private float FloorSixteenHeight = 31.83f;
    //      
    //level7
    private float FloorSeventeenHeight = 33.88f;
    private float FloorEightteenHeight = 35.79f;
    private float FloorNineteenHeight = 37.8f;
    //    
    //level8
    private float FloorTwentyHeight = 39.79f;
    //      
    //level9
    private float FloorTwentyoneHeight = 41.86f;
    private float FloorTwentytwoHeight = 43.67f;
    //
    //level10
    private float FloorTwentythreeHeight = 45.6f;
    private float FloorTwentyfourHeight = 47.6f;
    private float FloorTwentyfiveHeight = 49.69f;
    //
    //level11
    private float FloorTwentysixHeight = 51.72f;
    private float FloorTwentysevenHeight = 53.7f;
    private float FloorTwentyeightHeight = 55.81f;
    //
    //level12
    private float FloorTwentynineHeight = 57.75f;
    private float FloorThirtyHeight = 59.75f;
    private float FloorThirtyoneHeight = 61.8f;
    //
    //level13
    private float FloorThirtytwoHeight = 63.76f;
    private float FloorThirtythreeHeight = 65.8f;
    private float FloorThirtyfourHeight = 67.68f;
    //
    //level14
    private float FloorThirtyfiveHeight = 69.7f;
    private float FloorThirtysixHeight = 71.65f;
    private float FloorThirtysevenHeight = 73.75f;
    //
    //level15
    private float FloorThirtyeightHeight = 75.8f;
    //
    //level16
    private float FloorThirtynineHeight = 77.78f;
    //
    //level17
    private float FloorFourtyHeight = 79.82f;
    //
    //level18
    private float FloorFourtyoneHeight = 81.76f;
    private float FloorFourtytwoHeight = 83.8f;
    //
    //level19
    private float FloorFourtythreeHeight = 85.78f;
    private float FloorFourtyfourHeight = 87.8f;
    //
    //level20
    private float FloorFourtyfiveHeight = 89.75f;
    //
    //level21
    private float FloorFourtysixHeight = 91.77f;
    //
    //level22
    private float FloorFourtysevenHeight = 93.75f;
    //################################################################################
    #endregion

    #region CAMERA Y POSITIONS
    //#####################---->CAMERA Y POSITIONS<----###############################
    //level1
    private float CamOneHeight = 3f;
    private float CamTwoHeight = 4.88f;
    private float CamThreeHeight = 6.99f;
    private float CamFourHeight = 9.12f;
    //
    //level2
    private float CamFiveHeight = 11.3f;
    private float CamSixHeight = 13.2f;
    //
    //level3
    private float CamSevenHeight = 15.2f;
    private float CamEightHeight = 17.2f;
    //
    //level4
    private float CamNineHeight = 19.2f;
    private float CamTenHeight = 21.2f;
    private float CamElevenHeight = 23.2f;
    //
    //level5
    private float CamTwelveHeight = 25.2f;
    private float CamThirteenHeight = 27.2f;
    private float CamFourteenHeight = 29.2f;
    //
    //level6
    private float CamFivteenHeight = 31.2f;
    private float CamSixteenHeight = 33.2f;
    //
    //level7
    private float CamSeventeenHeight = 35.2f;
    private float CamEightteenHeight = 37.2f;
    private float CamNineteenHeight = 39.2f;
    //
    //level8
    private float CamTwentyHeight = 41.2f;
    //
    //level9
    private float CamTwentyOneHeight = 43.2f;
    private float CamTwentyTwoHeight = 45.2f;
    //
    //level10
    private float CamTwentyThreeHeight = 47.2f;
    private float CamTwentyFourHeight = 49.2f;
    private float CamTwentyFiveHeight = 51.2f;
    //
    //level11
    private float CamTwentySixHeight = 53.2f;
    private float CamTwentySevenHeight = 55.2f;
    private float CamTwentyEightHeight = 57.2f;
    //
    //level12
    private float CamTwentyNineHeight = 59.2f;
    private float CamThirtyHeight = 61.2f;
    private float CamThirtyOneHeight = 63.2f;
    //
    //level13
    private float CamThirtyTwoHeight = 65.2f;
    private float CamThirtyThreeHeight = 67.2f;
    private float CamThirtyFourHeight = 69.2f;
    //
    //level14
    private float CamThirtyFiveHeight = 71.2f;
    private float CamThirtySixHeight = 73.2f;
    private float CamThirtySevenHeight = 75.2f;
    //
    //level15
    private float CamThirtyEightHeight = 77.2f;
    //
    //level16
    private float CamThirtyNineHeight = 79.2f;
    //
    //level17
    private float CamFourtyHeight = 81.2f;
    //
    //level18
    private float CamFourtyOneHeight = 83.2f;
    private float CamFourtyTwoHeight = 85.2f;
    //
    //level19
    private float CamFourtyThreeHeight = 87.2f;
    private float CamFourtyFourHeight = 89.2f;
    //
    //level20
    private float CamFourtyFiveHeight = 91.2f;
    //
    //level21
    private float CamFourtySixHeight = 93.2f;
    //
    //level22
    private float CamFourtySevenHeight = 95.2f;


    //################################################################################
    #endregion


    private float startYpostionOfTurrent;

    private int levelToLoad;

    public string currentLevel;

    public int numOfFloors;

    #endregion

    void Awake()
    {
        SetLevelLimit();

        currentValue = startValue;
        currentKills = startValue;

        startYpostionOfTurrent = turrent.transform.position.y;

        PlatformMoves = false;

        FloorNum = 1;

        levelCompleted = false;

        bossLivesCount = 2;

        currentLevel = SceneManager.GetActiveScene().name;

        shootGO = GameObject.FindGameObjectWithTag("canon");

    }

    void Start()
    {
        SetFloorNumAttempts();
        SetFloorTxt(FloorNum);
        SetEnemiesValue(); //5.9.2019 11:48 SunnyDay Tržič HomeAlone "FinnishinTheGame"

        shoot = shootGO.GetComponent<Shoot>();
    }

    private bool MoveTo(int platform)
    {
        return currentValue == platform;
    }

    private GameObject[] FillEnemies()
    {
        for (int i = 0; i < Enemies.Length; i++)
        {
            for (int j = 0; j < Enemies.Length; j++)
            {
                Enemies[i] = allEnemies[j];
            }
        }

        return allEnemies;

    }

    private void ResetMissedShots()
    {
        Shoot.missedRightShots = 0;
        Shoot.missedLeftShots = 0;
    }

    private void CheckFloor()
    {
        #region Level 1
        if (currentKills == FloorOneValue)
        {
            FloorNum = 2;

        }
        else if (currentKills == FloorTwoValue)
        {
            FloorNum = 3;

        }
        else if (currentKills == FloorThreeValue)
        {
            FloorNum = 4;

        }
        else if (currentKills == FloorFourValue)
        {
            FloorNum = 5;

        }
        #endregion

        #region Level 2
        else if (currentKills == FloorFiveValue && currentLevel != "Level1")
        {
            FloorNum = 6;
            //Debug.Log(currentKills + "--> kills          currentValue <--" + currentValue + "  currentLevel --->" + currentLevel +
            //             "  level limit -->" + levelLimit);

        }
        else if (currentKills == FloorSixValue && currentLevel != "Level1")
        {
            FloorNum = 7;
        }
        #endregion

        #region Level 3
        else if (currentKills == FloorSevenValue && currentLevel != "Level1" && currentLevel != "Level2")
        {
            FloorNum = 8;
        }
        else if (currentKills == FloorEightValue && currentLevel != "Level1" && currentLevel != "Level2")
        {
            FloorNum = 9;
        }
        else if (currentKills == FloorNineValue && currentLevel != "Level1" && currentLevel != "Level2")
        {
            FloorNum = 10;
        }
        #endregion

        #region Level 4
        else if (currentKills == FloorTenValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3")
        {
            FloorNum = 11;
        }
        else if (currentKills == FloorElevenValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3")
        {
            FloorNum = 12;
        }
        else if (currentKills == FloorTwelveValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3")
        {
            FloorNum = 13;
        }
        #endregion

        #region Level 5
        else if (currentKills == FloorThirteenValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4")
        {
            FloorNum = 14;
        }
        else if (currentKills == FloorFourteenValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4")
        {
            FloorNum = 15;
        }
        else if (currentKills == FloorFivteenValue&& currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4")
        {
            FloorNum = 16;
        }
        #endregion

        #region Level 6
        else if (currentKills == FloorSixteenValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5")
        {
            FloorNum = 17;
        }
        else if (currentKills == FloorSeventeenValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5")
        {
            FloorNum = 18;
        }
        #endregion

        #region Level 7
        else if (currentKills == FloorEightteenValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6")
        {
            FloorNum = 19;
        }
        else if (currentKills == FloorNineteenValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6")
        {
            FloorNum = 20;
        }
        else if (currentKills == FloorTwentyValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6")
        {
            FloorNum = 21;
        }
        #endregion

        #region Level 8
        else if (currentKills == FloorTwentyoneValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7")
        {
            FloorNum = 22;
        }
        #endregion

        #region Level 9
        else if (currentKills == FloorTwentytwoValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8")
        {
            FloorNum = 23;
        }
        else if (currentKills == FloorTwentythreeValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8")
        {
            FloorNum = 24;
        }
        #endregion

        #region Level 10
        else if (currentKills == FloorTwentyfourValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9")
        {
            FloorNum = 25;
        }
        else if (currentKills == FloorTwentyfiveValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9")
        {
            FloorNum = 26;
        }
        else if (currentKills == FloorTwentysixValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9")
        {
            FloorNum = 27;
        }
        #endregion

        #region Level 11
        else if (currentKills == FloorTwentysevenValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10")
        {
            FloorNum = 28;
        }
        else if (currentKills == FloorTwentyeightValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10")
        {
            FloorNum = 29;
        }
        else if (currentKills == FloorTwentynineValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10")
        {
            FloorNum = 30;
        }
        #endregion

        #region Level 12
        else if (currentKills == FloorThirtyValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11")
        {
            FloorNum = 31;
        }
        else if (currentKills == FloorThirtyoneValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11")
        {
            FloorNum = 32;
        }
        else if (currentKills == FloorThirtytwoValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11")
        {
            FloorNum = 33;
        }
        #endregion

        #region Level 13
        else if (currentKills == FloorThirtythreeValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11" && currentLevel != "Level12")
        {
            FloorNum = 34;
        }
        else if (currentKills == FloorThirtyfourValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11" && currentLevel != "Level12")
        {
            FloorNum = 35;
        }
        else if (currentKills == FloorThirtyfiveValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11" && currentLevel != "Level12")
        {
            FloorNum = 36;
        }
        #endregion

        #region Level 14
        else if (currentKills == FloorThirtysixValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11" && currentLevel != "Level12" && currentLevel != "Level13")
        {
            FloorNum = 37;
        }
        else if (currentKills == FloorThirtysevenValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11" && currentLevel != "Level12" && currentLevel != "Level13")
        {
            FloorNum = 38;
        }
        else if (currentKills == FloorThirtyeightValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11" && currentLevel != "Level12" && currentLevel != "Level13")
        {
            FloorNum = 39;
        }
        #endregion

        #region Level 15
        else if (currentKills == FloorThirtynineValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11" && currentLevel != "Level12" && currentLevel != "Level13" && currentLevel != "Level14")
        {
            FloorNum = 40;
        }
        #endregion

        #region Level 16
        else if (currentKills == FloorFourtyValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11" && currentLevel != "Level12" && currentLevel != "Level13" && currentLevel != "Level14" && currentLevel != "Level15")
        {
            FloorNum = 41;
        }
        #endregion

        #region Level 17
        else if (currentKills == FloorFourtyoneValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11" && currentLevel != "Level12" && currentLevel != "Level13" && currentLevel != "Level14" && currentLevel != "Level15" && currentLevel != "Level16")
        {
            FloorNum = 42;
        }
        #endregion

        #region Level 18
        else if (currentKills == FloorFourtytwoValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11" && currentLevel != "Level12" && currentLevel != "Level13" && currentLevel != "Level14" && currentLevel != "Level15" && currentLevel != "Level16" && currentLevel != "Level17")
        {
            FloorNum = 43;
        }
        else if (currentKills == FloorFourtythreeValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11" && currentLevel != "Level12" && currentLevel != "Level13" && currentLevel != "Level14" && currentLevel != "Level15" && currentLevel != "Level16" && currentLevel != "Level17")
        {
            FloorNum = 44;
        }
        #endregion

        #region Level 19
        else if (currentKills == FloorFourtyfourValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11" && currentLevel != "Level12" && currentLevel != "Level13" && currentLevel != "Level14" && currentLevel != "Level15" && currentLevel != "Level16" && currentLevel != "Level17" && currentLevel != "Level18")
        {
            FloorNum = 45;
        }
        else if (currentKills == FloorFourtyfiveValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11" && currentLevel != "Level12" && currentLevel != "Level13" && currentLevel != "Level14" && currentLevel != "Level15" && currentLevel != "Level16" && currentLevel != "Level17" && currentLevel != "Level18")
        {
            FloorNum = 46;
        }
        #endregion

        #region Level 20
        else if (currentKills == FloorFourtysixValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11" && currentLevel != "Level12" && currentLevel != "Level13" && currentLevel != "Level14" && currentLevel != "Level15" && currentLevel != "Level16" && currentLevel != "Level17" && currentLevel != "Level18" && currentLevel != "Level19")
        {
            FloorNum = 47;
        }
        #endregion

        #region Level 21
        else if (currentKills == FloorFourtysevenValue && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11" && currentLevel != "Level12" && currentLevel != "Level13" && currentLevel != "Level14" && currentLevel != "Level15" && currentLevel != "Level16" && currentLevel != "Level17" && currentLevel != "Level18" && currentLevel != "Level19" && currentLevel != "Level20")
        {
            FloorNum = 48;
        }     
        #endregion
        
    }

    private void SetEnemiesValue()
    {
        Shoot.LeftEnemyCount = 0;
        Shoot.RightEnemyCount = 0;
    }

    void Update()
    {
        ConfirmKill();
        ConfirmBossKill();

        currentKills = currentValue;
        CheckFloor();

        floorNum = FloorNum;
        Debug.Log("floor num: " + floorNum + "  currentValue: " + currentValue);
        #region Platform Movement Manager
        if (currentValue % 2 == 0 && currentValue != 0)
        {
            ManageElevatorMovement();
        }
        #endregion

        if (LevelCompleted(currentKills))
        {
            Debug.Log("Level Completed --> true");
            levelCompleted = true;           
        }

        if (FloorNum <= shoot.lastFloor)
        {
            ManageFloorNumAnimations();
        }

      
    }

    private int SceneValue(int x)
    {
        return x;
    }

    public void ConfirmKill()
    {
        if (killConfirmed)
        {
            currentValue += 1;
            Debug.Log("kill confirmed");
            Manager.activateScorePoints = true;
            killConfirmed = false;
            PlayerPrefs.SetInt("totalKills", PlayerPrefs.GetInt("totalKills") + 1);

        }
    }

    public void ConfirmBossKill()
    {
        if (bossKillConfirmed)
        {
            bossLivesCount--;
            currentValue += 1;
            bossKillConfirmed = false;
        }
    }

    private bool ShowFloorLvl;

    public IEnumerator MovePlatform(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;
        
    }

    public IEnumerator MoveMissile(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;
    }

    public IEnumerator MoveCamera(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.GetComponent<CameraShaker>().RestPositionOffset;
        while (elapsedTime < seconds)
        {
            objectToMove.GetComponent<CameraShaker>().RestPositionOffset = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.GetComponent<CameraShaker>().RestPositionOffset = end;
    }

    public IEnumerator MoveHeartPosition(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;
    }

    public void SetLevelLimit()
    {        
        if(SceneManager.GetActiveScene().name == "Level1") { levelLimit = lvl1Limit; }
            else if (SceneManager.GetActiveScene().name == "Level2") { levelLimit = lvl2Limit; }
                else if (SceneManager.GetActiveScene().name == "Level3") { levelLimit = lvl3Limit; }
                    else if (SceneManager.GetActiveScene().name == "Level4") { levelLimit = lvl4Limit; }
                        else if (SceneManager.GetActiveScene().name == "Level5") { levelLimit = lvl5Limit; }
                            else if (SceneManager.GetActiveScene().name == "Level6") { levelLimit = lvl6Limit; }
                                else if (SceneManager.GetActiveScene().name == "Level7") { levelLimit = lvl7Limit; }
                                    else if (SceneManager.GetActiveScene().name == "Level8") { levelLimit = lvl8Limit; }
                                        else if (SceneManager.GetActiveScene().name == "Level9") { levelLimit = lvl9Limit; }
                                            else if (SceneManager.GetActiveScene().name == "Level10") { levelLimit = lvl10Limit; }
                                                else if (SceneManager.GetActiveScene().name == "Level11") { levelLimit = lvl11Limit; }
                                                    else if (SceneManager.GetActiveScene().name == "Level12") { levelLimit = lvl12Limit; }
                                                        else if (SceneManager.GetActiveScene().name == "Level13") { levelLimit = lvl13Limit; }
                                                            else if (SceneManager.GetActiveScene().name == "Level14") { levelLimit = lvl14Limit; }
                                                                else if (SceneManager.GetActiveScene().name == "Level15") { levelLimit = lvl15Limit; }
                                                                    else if (SceneManager.GetActiveScene().name == "Level16") { levelLimit = lvl16Limit; }
                                                                        else if (SceneManager.GetActiveScene().name == "Level17") { levelLimit = lvl17Limit; }
                                                                            else if (SceneManager.GetActiveScene().name == "Level18") { levelLimit = lvl18Limit; }
                                                                                else if (SceneManager.GetActiveScene().name == "Level19") { levelLimit = lvl19Limit; }
                                                                                    else if (SceneManager.GetActiveScene().name == "Level20") { levelLimit = lvl20Limit; }
                                                                                        else if (SceneManager.GetActiveScene().name == "Level21") { levelLimit = lvl21Limit; }

        Debug.Log(levelLimit + "   limit");        
    }

    private bool LevelCompleted(int kills)
    {
        bool completed = false;

        if(kills == levelLimit)
        {         
            completed = true;
        }

        return completed;
    }

    public static int ReturnNumberOfKills()
    {
        return currentKills;
    }

    private void SetParent(GameObject newParent)
    {
        turrent.transform.parent = newParent.transform;
        Debug.Log("Player's Parent: " + turrent.transform.parent.name);

        // Check if the new parent has a parent GameObject.
        if (newParent.transform.parent != null)
        {
            //Display the name of the grand parent of the player.
            Debug.Log("Player's Grand parent: " + turrent.transform.parent.parent.name);
        }
    }

    public void DetachFromParent(GameObject go)
    {
        // Detaches the transform from its parent.
        go.transform.parent = null;
    }

    void SetFloorTxt(int floorNum)
    {
        FloorTxt.GetComponent<Text>().text = floorNum.ToString();
        FloorTxt.SetTrigger("floorText");
    }

    void ManageFloorNumAnimations()
    {
        if (FloorNum == 1 && floorNumAttempt1 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt1++;
        }
        else if (FloorNum == 2 && floorNumAttempt2 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt2++;
        }
        else if (FloorNum == 3 && floorNumAttempt3 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt3++;
        }
        else if (FloorNum == 4 && floorNumAttempt4 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt4++;
        }
        else if (FloorNum == 5 && floorNumAttempt5 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt5++;
        }
        else if (FloorNum == 6 && floorNumAttempt6 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt6++;
        }
        else if (FloorNum == 7 && floorNumAttempt7 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt7++;
        }
        else if (FloorNum == 8 && floorNumAttempt8 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt8++;
        }
        else if (FloorNum == 9 && floorNumAttempt9 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt9++;
        }
        else if (FloorNum == 10 && floorNumAttempt10 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt10++;
        }
        else if (FloorNum == 11 && floorNumAttempt11 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt11++;
        }
        else if (FloorNum == 12 && floorNumAttempt12 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt12++;
        }
        else if (FloorNum == 13 && floorNumAttempt13 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt13++;
        }
        else if (FloorNum == 14 && floorNumAttempt14 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt14++;
        }
        else if (FloorNum == 15 && floorNumAttempt15 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt15++;
        }
        else if (FloorNum == 16 && floorNumAttempt16 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt16++;
        }
        else if (FloorNum == 17 && floorNumAttempt17 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt17++;
        }
        else if (FloorNum == 18 && floorNumAttempt18 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt18++;
        }
        else if (FloorNum == 19 && floorNumAttempt19 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt19++;
        }
        else if (FloorNum == 20 && floorNumAttempt20 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt20++;
        }
        else if (FloorNum == 21 && floorNumAttempt21 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt21++;
        }
        else if (FloorNum == 22 && floorNumAttempt22 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt22++;
        }
        else if (FloorNum == 23 && floorNumAttempt23 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt23++;
        }
        else if (FloorNum == 24 && floorNumAttempt24 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt24++;
        }
        else if (FloorNum == 25 && floorNumAttempt25 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt25++;
        }
        else if (FloorNum == 26 && floorNumAttempt26 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt26++;
        }
        else if (FloorNum == 27 && floorNumAttempt27 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt27++;
        }
        else if (FloorNum == 28 && floorNumAttempt28 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt28++;
        }
        else if (FloorNum == 29 && floorNumAttempt29 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt29++;
        }
        else if (FloorNum == 30 && floorNumAttempt30 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt30++;
        }
        else if (FloorNum == 31 && floorNumAttempt31 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt31++;
        }
        else if (FloorNum == 32 && floorNumAttempt32 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt32++;
        }
        else if (FloorNum == 33 && floorNumAttempt33 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt33++;
        }
        else if (FloorNum == 34 && floorNumAttempt34 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt34++;
        }
        else if (FloorNum == 35 && floorNumAttempt35 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt35++;
        }
        else if (FloorNum == 36 && floorNumAttempt36 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt36++;
        }
        else if (FloorNum == 37 && floorNumAttempt37 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt37++;
        }
        else if (FloorNum == 38 && floorNumAttempt38 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt38++;
        }
        else if (FloorNum == 39 && floorNumAttempt39 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt39++;
        }
        else if (FloorNum == 40 && floorNumAttempt40 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt40++;
        }
        else if (FloorNum == 41 && floorNumAttempt41 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt41++;
        }
        else if (FloorNum == 42 && floorNumAttempt42 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt42++;
        }
        else if (FloorNum == 43 && floorNumAttempt43 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt43++;
        }
        else if (FloorNum == 44 && floorNumAttempt44 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt44++;
        }
        else if (FloorNum == 45 && floorNumAttempt45 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt45++;
        }
        else if (FloorNum == 46 && floorNumAttempt46 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt46++;
        }
        else if (FloorNum == 47 && floorNumAttempt47 == 0)
        {
            SetFloorTxt(FloorNum);
            floorNumAttempt47++;
        }
    }

    private float diffCam = .7f;
    private float diffPlatformMissile = .55f;

    private void ManageElevatorMovement()
    {
        if (MoveTo(FloorOneValue))
        {
            Debug.Log("First sound attempt for elevator");
            SetEnemiesValue();
            Testing.playSoundAttempt1 = true;
            audioManager.PlatformHasArrived = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorOneHeight, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorOneHeight + startYpostionOfTurrent, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamOneHeight, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorOneHeight, HeartPosition_Transform.transform.position.z), 1f));
        }
        else if (MoveTo(FloorTwoValue))
        {
            SetEnemiesValue();
            Testing.playSoundAttempt2 = true;
            audioManager.PlatformHasArrived1 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorTwoHeight, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorTwoHeight + startYpostionOfTurrent, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamTwoHeight, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorTwoHeight, HeartPosition_Transform.transform.position.z), 1f));


        }
        else if (MoveTo(FloorThreeValue))
        {
            SetEnemiesValue();
            Testing.playSoundAttempt3 = true;
            audioManager.PlatformHasArrived2 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorThreeHeight, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorThreeHeight + startYpostionOfTurrent, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamThreeHeight, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorThreeHeight, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorFourValue))
        {
            SetEnemiesValue();
            Testing.playSoundAttempt4 = true;
            audioManager.PlatformHasArrived3 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorFourHeight, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorFourHeight + startYpostionOfTurrent, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamFourHeight, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorFourHeight, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorFiveValue) && currentLevel != "Level1")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt5 = true;
            audioManager.PlatformHasArrived4 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorFiveHeight, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorFiveHeight + startYpostionOfTurrent, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamFiveHeight, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorFiveHeight, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorSixValue) && currentLevel != "Level1")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt6 = true;
            audioManager.PlatformHasArrived5 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorSixHeight, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorSixHeight + startYpostionOfTurrent, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamSixHeight, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorSixHeight, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorSevenValue) && currentLevel != "Level1" && currentLevel != "Level2")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt7 = true;
            audioManager.PlatformHasArrived6 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorSevenHeight, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorSevenHeight + startYpostionOfTurrent, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamSevenHeight, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorSevenHeight, HeartPosition_Transform.transform.position.z), 1f));


        }
        else if (MoveTo(FloorEightValue) && currentLevel != "Level1" && currentLevel != "Level2")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt8 = true;
            audioManager.PlatformHasArrived7 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorEightHeight, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorEightHeight + startYpostionOfTurrent, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamEightHeight, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorEightHeight, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorNineValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt9 = true;
            audioManager.PlatformHasArrived8 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorNineHeight, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorNineHeight + startYpostionOfTurrent, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamNineHeight, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorNineHeight, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorTenValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt10 = true;
            audioManager.PlatformHasArrived9 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorTenHeight, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorTenHeight + startYpostionOfTurrent, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamTenHeight, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorTenHeight, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorElevenValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt11 = true;
            audioManager.PlatformHasArrived10 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorElevenHeight, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorElevenHeight + startYpostionOfTurrent, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamElevenHeight, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorElevenHeight, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorTwelveValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt12 = true;
            audioManager.PlatformHasArrived11 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorTwelveHeight, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorTwelveHeight + startYpostionOfTurrent, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamTwelveHeight, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorTwelveHeight, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorThirteenValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt13 = true;
            audioManager.PlatformHasArrived12 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorThirteenHeight, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorThirteenHeight + startYpostionOfTurrent, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamThirteenHeight, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorThirteenHeight, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorFourteenValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt14 = true;
            audioManager.PlatformHasArrived13 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorFourteenHeight, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorFourteenHeight + startYpostionOfTurrent, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamFourteenHeight, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorFourteenHeight, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorFivteenValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt15 = true;
            audioManager.PlatformHasArrived14 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorFivteenHeight, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorFivteenHeight + startYpostionOfTurrent, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamFivteenHeight, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorFivteenHeight, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorSixteenValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt16 = true;
            audioManager.PlatformHasArrived15 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorSixteenHeight, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorSixteenHeight + startYpostionOfTurrent, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamSixteenHeight, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorSixteenHeight, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorSeventeenValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt17 = true;
            audioManager.PlatformHasArrived16 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorSeventeenHeight, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorSeventeenHeight + startYpostionOfTurrent, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamSeventeenHeight, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorSeventeenHeight, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorEightteenValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt18 = true;
            audioManager.PlatformHasArrived17 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorEightteenHeight, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorEightteenHeight + startYpostionOfTurrent, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamEightteenHeight, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorEightteenHeight, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorNineteenValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt19 = true;
            audioManager.PlatformHasArrived18 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorNineteenHeight, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorNineteenHeight + startYpostionOfTurrent, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamNineteenHeight, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorNineteenHeight, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorTwentyValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt20 = true;
            audioManager.PlatformHasArrived19 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorTwentyHeight, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorTwentyHeight + startYpostionOfTurrent, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamTwentyHeight, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorTwentyHeight, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorTwentyoneValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt21 = true;
            audioManager.PlatformHasArrived20 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorTwentyoneHeight, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorTwentyoneHeight + startYpostionOfTurrent, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamTwentyOneHeight, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorTwentyoneHeight, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorTwentytwoValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt22 = true;
            audioManager.PlatformHasArrived21 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorTwentytwoHeight, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorTwentytwoHeight + startYpostionOfTurrent, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamTwentyTwoHeight, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorTwentytwoHeight, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorTwentythreeValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt23 = true;
            audioManager.PlatformHasArrived22 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorTwentythreeHeight, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorTwentythreeHeight + startYpostionOfTurrent, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamTwentyThreeHeight, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorTwentythreeHeight, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorTwentyfourValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt24 = true;
            audioManager.PlatformHasArrived23 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorTwentyfourHeight, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorTwentyfourHeight + startYpostionOfTurrent, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamTwentyFourHeight, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorTwentyfourHeight, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorTwentyfiveValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt25 = true;
            audioManager.PlatformHasArrived24 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorTwentyfiveHeight, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorTwentyfiveHeight + startYpostionOfTurrent, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamTwentyFiveHeight, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorTwentyfiveHeight, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorTwentysixValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt26 = true;
            audioManager.PlatformHasArrived25 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorTwentysixHeight - diffPlatformMissile, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorTwentysixHeight + startYpostionOfTurrent - diffPlatformMissile, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamTwentySixHeight - diffCam, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorTwentysixHeight - diffPlatformMissile, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorTwentysevenValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt27 = true;
            audioManager.PlatformHasArrived26 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorTwentysevenHeight - diffPlatformMissile, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorTwentysevenHeight + startYpostionOfTurrent - diffPlatformMissile, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamTwentySevenHeight - diffCam, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorTwentysevenHeight - diffPlatformMissile, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorTwentyeightValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt28 = true;
            audioManager.PlatformHasArrived27 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorTwentyeightHeight - diffPlatformMissile, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorTwentyeightHeight + startYpostionOfTurrent - diffPlatformMissile, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamTwentyEightHeight - diffCam, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorTwentyeightHeight - diffPlatformMissile, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorTwentynineValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt29 = true;
            audioManager.PlatformHasArrived28 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorTwentynineHeight - diffPlatformMissile, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorTwentynineHeight + startYpostionOfTurrent - diffPlatformMissile, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamTwentyNineHeight - diffCam, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorTwentynineHeight - diffPlatformMissile, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorThirtyValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt30 = true;
            audioManager.PlatformHasArrived29 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorThirtyHeight - diffPlatformMissile, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorThirtyHeight + startYpostionOfTurrent - diffPlatformMissile, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamThirtyHeight - diffCam, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorThirtyHeight - diffPlatformMissile, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorThirtyoneValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt31 = true;
            audioManager.PlatformHasArrived30 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorThirtyoneHeight - diffPlatformMissile, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorThirtyoneHeight + startYpostionOfTurrent - diffPlatformMissile, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamThirtyOneHeight - diffCam, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorThirtyoneHeight - diffPlatformMissile, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorThirtytwoValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11" && currentLevel != "Level12")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt32 = true;
            audioManager.PlatformHasArrived31 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorThirtytwoHeight - diffPlatformMissile, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorThirtytwoHeight + startYpostionOfTurrent - diffPlatformMissile, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamThirtyTwoHeight - diffCam, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorThirtytwoHeight - diffPlatformMissile, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorThirtythreeValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11" && currentLevel != "Level12")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt33 = true;
            audioManager.PlatformHasArrived32 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorThirtythreeHeight - diffPlatformMissile, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorThirtythreeHeight + startYpostionOfTurrent - diffPlatformMissile, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamThirtyThreeHeight - diffCam, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorThirtythreeHeight - diffPlatformMissile, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorThirtyfourValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11" && currentLevel != "Level12")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt34 = true;
            audioManager.PlatformHasArrived33 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorThirtyfourHeight - diffPlatformMissile, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorThirtyfourHeight + startYpostionOfTurrent - diffPlatformMissile, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamThirtyFourHeight - diffCam, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorThirtyfourHeight - diffPlatformMissile, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorThirtyfiveValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11" && currentLevel != "Level12" && currentLevel != "Level13")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt35 = true;
            audioManager.PlatformHasArrived34 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorThirtyfiveHeight - diffPlatformMissile, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorThirtyfiveHeight + startYpostionOfTurrent - diffPlatformMissile, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamThirtyFiveHeight - diffCam, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorThirtyfiveHeight - diffPlatformMissile, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorThirtysixValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11" && currentLevel != "Level12" && currentLevel != "Level13")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt36 = true;
            audioManager.PlatformHasArrived35 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorThirtysixHeight - diffPlatformMissile, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorThirtysixHeight + startYpostionOfTurrent - diffPlatformMissile, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamThirtySixHeight - diffCam, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorThirtysixHeight - diffPlatformMissile, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorThirtysevenValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11" && currentLevel != "Level12" && currentLevel != "Level13")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt37 = true;
            audioManager.PlatformHasArrived36 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorThirtysevenHeight - diffPlatformMissile, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorThirtysevenHeight + startYpostionOfTurrent - diffPlatformMissile, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamThirtySevenHeight - diffCam, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorThirtysevenHeight - diffPlatformMissile, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorThirtyeightValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11" && currentLevel != "Level12" && currentLevel != "Level13" && currentLevel != "Level14")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt38 = true;
            audioManager.PlatformHasArrived37 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorThirtyeightHeight - diffPlatformMissile, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorThirtyeightHeight + startYpostionOfTurrent - diffPlatformMissile, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamThirtyEightHeight - diffCam, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorThirtyeightHeight - diffPlatformMissile, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorThirtynineValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11" && currentLevel != "Level12" && currentLevel != "Level13" && currentLevel != "Level14" && currentLevel != "Level15")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt39 = true;
            audioManager.PlatformHasArrived38 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorThirtynineHeight - diffPlatformMissile, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorThirtynineHeight + startYpostionOfTurrent - diffPlatformMissile, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamThirtyNineHeight - diffCam, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorThirtynineHeight - diffPlatformMissile, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorFourtyValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11" && currentLevel != "Level12" && currentLevel != "Level13" && currentLevel != "Level14" && currentLevel != "Level15" && currentLevel != "Level16")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt40 = true;
            audioManager.PlatformHasArrived39 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorFourtyHeight - diffPlatformMissile, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorFourtyHeight + startYpostionOfTurrent - diffPlatformMissile, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamFourtyHeight - diffCam, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorFourtyHeight - diffPlatformMissile, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorFourtyoneValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11" && currentLevel != "Level12" && currentLevel != "Level13" && currentLevel != "Level14" && currentLevel != "Level15" && currentLevel != "Level16" && currentLevel != "Level17")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt41 = true;
            audioManager.PlatformHasArrived40 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorFourtyoneHeight - diffPlatformMissile, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorFourtyoneHeight + startYpostionOfTurrent - diffPlatformMissile, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamFourtyOneHeight - diffCam, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorFourtyoneHeight - diffPlatformMissile, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorFourtytwoValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11" && currentLevel != "Level12" && currentLevel != "Level13" && currentLevel != "Level14" && currentLevel != "Level15" && currentLevel != "Level16" && currentLevel != "Level17")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt42 = true;
            audioManager.PlatformHasArrived41 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorFourtytwoHeight - diffPlatformMissile, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorFourtytwoHeight + startYpostionOfTurrent - diffPlatformMissile, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamFourtyTwoHeight - diffCam, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorFourtytwoHeight - diffPlatformMissile, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorFourtythreeValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11" && currentLevel != "Level12" && currentLevel != "Level13" && currentLevel != "Level14" && currentLevel != "Level15" && currentLevel != "Level16" && currentLevel != "Level17" && currentLevel != "Level18")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt43 = true;
            audioManager.PlatformHasArrived42 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorFourtythreeHeight - diffPlatformMissile, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorFourtythreeHeight + startYpostionOfTurrent - diffPlatformMissile, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamFourtyThreeHeight - diffCam, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorFourtythreeHeight - diffPlatformMissile, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorFourtyfourValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11" && currentLevel != "Level12" && currentLevel != "Level13" && currentLevel != "Level14" && currentLevel != "Level15" && currentLevel != "Level16" && currentLevel != "Level17" && currentLevel != "Level18")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt44 = true;
            audioManager.PlatformHasArrived43 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorFourtyfourHeight - diffPlatformMissile, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorFourtyfourHeight + startYpostionOfTurrent - diffPlatformMissile, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamFourtyFourHeight - diffCam, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorFourtyfourHeight - diffPlatformMissile, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorFourtyfiveValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11" && currentLevel != "Level12" && currentLevel != "Level13" && currentLevel != "Level14" && currentLevel != "Level15" && currentLevel != "Level16" && currentLevel != "Level17" && currentLevel != "Level18" && currentLevel != "Level19")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt45 = true;
            audioManager.PlatformHasArrived44 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorFourtyfiveHeight - diffPlatformMissile, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorFourtyfiveHeight + startYpostionOfTurrent - diffPlatformMissile, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamFourtyFiveHeight - diffCam, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorFourtyfiveHeight - diffPlatformMissile, HeartPosition_Transform.transform.position.z), 1f));

        }
        else if (MoveTo(FloorFourtysixValue) && currentLevel != "Level1" && currentLevel != "Level2" && currentLevel != "Level3" && currentLevel != "Level4" && currentLevel != "Level5" && currentLevel != "Level6" && currentLevel != "Level7" && currentLevel != "Level8" && currentLevel != "Level9" && currentLevel != "Level10" && currentLevel != "Level11" && currentLevel != "Level12" && currentLevel != "Level13" && currentLevel != "Level14" && currentLevel != "Level15" && currentLevel != "Level16" && currentLevel != "Level17" && currentLevel != "Level18" && currentLevel != "Level19" && currentLevel != "Level20")
        {
            SetEnemiesValue();
            Testing.playSoundAttempt46 = true;
            audioManager.PlatformHasArrived45 = true;
            StartCoroutine(MovePlatform(gameObject, new Vector3(transform.position.x, FloorFourtysixHeight - diffPlatformMissile, transform.position.z), 1f));
            StartCoroutine(MoveMissile(turrent, new Vector3(turrent.transform.position.x, FloorFourtysixHeight + startYpostionOfTurrent - diffPlatformMissile, turrent.transform.position.z), 1f));
            StartCoroutine(MoveCamera(cam, new Vector3(cam.transform.position.x, CamFourtySixHeight - diffCam, cam.transform.position.z), 1.8f));
            StartCoroutine(MoveHeartPosition(HeartPosition_Transform, new Vector3(HeartPosition_Transform.transform.position.x, FloorFourtysixHeight - diffPlatformMissile, HeartPosition_Transform.transform.position.z), 1f));

        }


    }
}
