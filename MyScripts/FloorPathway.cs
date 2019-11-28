using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPathway : MonoBehaviour
{
    private GameObject[] floors;

    #region Values: Attempts
    private int attemptLeft;
    private int attemptRight;
    
    private int attemptLeft1;
    private int attemptRight1;

    private int attemptLeft2;
    private int attemptRight2;
    
    private int attemptLeft3;
    private int attemptRight3;
    
    private int attemptLeft4;
    private int attemptRight4;
    
    private int attemptLeft5;
    private int attemptRight5;
    
    private int attemptLeft6;
    private int attemptRight6;
    
    private int attemptLeft7;
    private int attemptRight7;
    
    private int attemptLeft8;
    private int attemptRight8;
    
    private int attemptLeft9;
    private int attemptRight9;
    
    private int attemptLeft10;
    private int attemptRight10;
    
    private int attemptLeft11;
    private int attemptRight11;
    
    private int attemptLeft12;
    private int attemptRight12;
    
    private int attemptLeft13;
    private int attemptRight13;
    
    private int attemptLeft14;
    private int attemptRight14;
    
    private int attemptLeft15;
    private int attemptRight15;
    
    private int attemptLeft16;
    private int attemptRight16;
    
    private int attemptLeft17;
    private int attemptRight17;
    
    private int attemptLeft18;
    private int attemptRight18;
    
    private int attemptLeft19;
    private int attemptRight19;
    
    private int attemptLeft20;
    private int attemptRight20;
    
    private int attemptLeft21;
    private int attemptRight21;

    private int attemptLeft22;
    private int attemptRight22;

    private int attemptLeft23;
    private int attemptRight23;

    private int attemptLeft24;
    private int attemptRight24;

    private int attemptLeft25;
    private int attemptRight25;

    private int attemptLeft26;
    private int attemptRight26;

    private int attemptLeft27;
    private int attemptRight27;

    private int attemptLeft28;
    private int attemptRight28;

    private int attemptLeft29;
    private int attemptRight29;

    private int attemptLeft30;
    private int attemptRight30;

    private int attemptLeft31;
    private int attemptRight31;

    private int attemptLeft32;
    private int attemptRight32;

    private int attemptLeft33;
    private int attemptRight33;

    private int attemptLeft34;
    private int attemptRight34;

    private int attemptLeft35;
    private int attemptRight35;

    private int attemptLeft36;
    private int attemptRight36;

    private int attemptLeft37;
    private int attemptRight37;

    private int attemptLeft38;
    private int attemptRight38;

    private int attemptLeft39;
    private int attemptRight39;

    private int attemptLeft40;
    private int attemptRight40;

    private int attemptLeft41;
    private int attemptRight41;

    private int attemptLeft42;
    private int attemptRight42;

    private int attemptLeft43;
    private int attemptRight43;

    private int attemptLeft44;
    private int attemptRight44;

    private int attemptLeft45;
    private int attemptRight45;


    #endregion

    void Awake()
    {
        floors = GameObject.FindGameObjectsWithTag("floors");
    }

    void Start() { SetValues(); }

    void LateUpdate()
    {
        HandleFloors(floors);
    }

    private void HandleFloors(GameObject[] _floors)
    {
        foreach(GameObject floor in _floors)
        {
            #region Left Floors
            if(Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 2)
            {
                if(floor.gameObject.name.Contains("1") && floor.gameObject.name.Contains("Left") && attemptLeft == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft++;
                }
            }
            else if(Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 3)
            {
                if (floor.gameObject.name.Contains("2") && floor.gameObject.name.Contains("Left") && attemptLeft1 == 0)
                {

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft1++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 4)
            {
                if (floor.gameObject.name.Contains("3") && floor.gameObject.name.Contains("Left") && attemptLeft2 == 0)
                {

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft2++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 5)
            {
                if (floor.gameObject.name.Contains("4") && floor.gameObject.name.Contains("Left") && attemptLeft3 == 0)
                {

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft3++;

                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 6)
            {
                if (floor.gameObject.name.Contains("5") && floor.gameObject.name.Contains("Left") && attemptLeft4 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft4++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 7)
            {

                if (floor.gameObject.name.Contains("6") && floor.gameObject.name.Contains("Left") && attemptLeft5 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft5++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 8)
            {

                if (floor.gameObject.name.Contains("7") && floor.gameObject.name.Contains("Left") && attemptLeft6 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft6++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 9)
            {

                if (floor.gameObject.name.Contains("8") && floor.gameObject.name.Contains("Left") && attemptLeft7 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft7++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 10)
            {

                if (floor.gameObject.name.Contains("9") && floor.gameObject.name.Contains("Left") && attemptLeft8 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft8++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 11)
            {

                if (floor.gameObject.name.Contains("10") && floor.gameObject.name.Contains("Left") && attemptLeft9 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft9++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 12)
            {

                if (floor.gameObject.name.Contains("11") && floor.gameObject.name.Contains("Left") && attemptLeft10 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft10++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 13)
            {

                if (floor.gameObject.name.Contains("12") && floor.gameObject.name.Contains("Left") && attemptLeft11 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft11++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 14)
            {

                if (floor.gameObject.name.Contains("13") && floor.gameObject.name.Contains("Left") && attemptLeft12 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft12++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 15)
            {

                if (floor.gameObject.name.Contains("14") && floor.gameObject.name.Contains("Left") && attemptLeft13 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft13++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 16)
            {

                if (floor.gameObject.name.Contains("15") && floor.gameObject.name.Contains("Left") && attemptLeft14 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft14++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 17)
            {

                if (floor.gameObject.name.Contains("16") && floor.gameObject.name.Contains("Left") && attemptLeft15 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft15++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 18)
            {

                if (floor.gameObject.name.Contains("17") && floor.gameObject.name.Contains("Left") && attemptLeft16 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft16++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 19)
            {

                if (floor.gameObject.name.Contains("18") && floor.gameObject.name.Contains("Left") && attemptLeft17 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft17++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 20)
            {

                if (floor.gameObject.name.Contains("19") && floor.gameObject.name.Contains("Left") && attemptLeft18 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft18++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 21)
            {

                if (floor.gameObject.name.Contains("20") && floor.gameObject.name.Contains("Left") && attemptLeft19 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft19++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 22)
            {

                if (floor.gameObject.name.Contains("21") && floor.gameObject.name.Contains("Left") && attemptLeft20 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft20++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 23)
            {

                if (floor.gameObject.name.Contains("22") && floor.gameObject.name.Contains("Left") && attemptLeft21 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft21++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 24)
            {

                if (floor.gameObject.name.Contains("23") && floor.gameObject.name.Contains("Left") && attemptLeft22 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft22++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 25)
            {

                if (floor.gameObject.name.Contains("24") && floor.gameObject.name.Contains("Left") && attemptLeft23 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft23++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 26)
            {

                if (floor.gameObject.name.Contains("25") && floor.gameObject.name.Contains("Left") && attemptLeft24 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft24++;
                }
            }

            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 27)
            {

                if (floor.gameObject.name.Contains("26") && floor.gameObject.name.Contains("Left") && attemptLeft25 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft25++;
                }
            }

            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 28)
            {

                if (floor.gameObject.name.Contains("27") && floor.gameObject.name.Contains("Left") && attemptLeft26 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft26++;
                }
            }

            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 29)
            {

                if (floor.gameObject.name.Contains("28") && floor.gameObject.name.Contains("Left") && attemptLeft27 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft27++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 30)
            {

                if (floor.gameObject.name.Contains("29") && floor.gameObject.name.Contains("Left") && attemptLeft28 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft28++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 31)
            {


                if (floor.gameObject.name.Contains("30") && floor.gameObject.name.Contains("Left") && attemptLeft29 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft29++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 32)
            {

                if (floor.gameObject.name.Contains("31") && floor.gameObject.name.Contains("Left") && attemptLeft30 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft30++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 33)
            {

                if (floor.gameObject.name.Contains("32") && floor.gameObject.name.Contains("Left") && attemptLeft31 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft31++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 34)
            {

                if (floor.gameObject.name.Contains("33") && floor.gameObject.name.Contains("Left") && attemptLeft32 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft32++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 35)
            {

                if (floor.gameObject.name.Contains("34") && floor.gameObject.name.Contains("Left") && attemptLeft33 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft33++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 36)
            {

                if (floor.gameObject.name.Contains("35") && floor.gameObject.name.Contains("Left") && attemptLeft34 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft34++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 37)
            {

                if (floor.gameObject.name.Contains("36") && floor.gameObject.name.Contains("Left") && attemptLeft35 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft35++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 38)
            {

                if (floor.gameObject.name.Contains("37") && floor.gameObject.name.Contains("Left") && attemptLeft36 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft36++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 39)
            {

                if (floor.gameObject.name.Contains("38") && floor.gameObject.name.Contains("Left") && attemptLeft37 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft36++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 40)
            {

                if (floor.gameObject.name.Contains("39") && floor.gameObject.name.Contains("Left") && attemptLeft38 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft38++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 41)
            {

                if (floor.gameObject.name.Contains("40") && floor.gameObject.name.Contains("Left") && attemptLeft39 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft39++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 42)
            {

                if (floor.gameObject.name.Contains("41") && floor.gameObject.name.Contains("Left") && attemptLeft40 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft40++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 43)
            {

                if (floor.gameObject.name.Contains("42") && floor.gameObject.name.Contains("Left") && attemptLeft41 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft41++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 44)
            {

                if (floor.gameObject.name.Contains("43") && floor.gameObject.name.Contains("Left") && attemptLeft42 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft42++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 45)
            {

                if (floor.gameObject.name.Contains("44") && floor.gameObject.name.Contains("Left") && attemptLeft43 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft43++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 46)
            {

                if (floor.gameObject.name.Contains("45") && floor.gameObject.name.Contains("Left") && attemptLeft44 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft44++;
                }
            }
            else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 47)
            {

                if (floor.gameObject.name.Contains("46") && floor.gameObject.name.Contains("Left") && attemptLeft45 == 0)
                {
                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptLeft45++;
                }
            }
            #endregion

            #region Right Floors

            if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 2)
            {
                if (floor.gameObject.name.Contains("1") && floor.gameObject.name.Contains("Right") && attemptRight == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 3)
            {
                if (floor.gameObject.name.Contains("2") && floor.gameObject.name.Contains("Right") && attemptRight1 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight1++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 4)
            {
                if (floor.gameObject.name.Contains("3") && floor.gameObject.name.Contains("Right") && attemptRight2 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight2++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 5)
            {
                if (floor.gameObject.name.Contains("4") && floor.gameObject.name.Contains("Right") && attemptRight3 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight3++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 6)
            {
                if (floor.gameObject.name.Contains("5") && floor.gameObject.name.Contains("Right") && attemptRight4 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight4++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 7)
            {
                if (floor.gameObject.name.Contains("6") && floor.gameObject.name.Contains("Right") && attemptRight5 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight5++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 8)
            {
                if (floor.gameObject.name.Contains("7") && floor.gameObject.name.Contains("Right") && attemptRight6 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight6++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 9)
            {
                if (floor.gameObject.name.Contains("8") && floor.gameObject.name.Contains("Right") && attemptRight7 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight7++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 10)
            {
                if (floor.gameObject.name.Contains("9") && floor.gameObject.name.Contains("Right") && attemptRight8 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight8++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 11)
            {
                if (floor.gameObject.name.Contains("10") && floor.gameObject.name.Contains("Right") && attemptRight9 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight9++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 12)
            {
                if (floor.gameObject.name.Contains("11") && floor.gameObject.name.Contains("Right") && attemptRight10 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight10++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 13)
            {
                if (floor.gameObject.name.Contains("12") && floor.gameObject.name.Contains("Right") && attemptRight11 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight11++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 14)
            {
                if (floor.gameObject.name.Contains("13") && floor.gameObject.name.Contains("Right") && attemptRight12 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight12++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 15)
            {
                if (floor.gameObject.name.Contains("14") && floor.gameObject.name.Contains("Right") && attemptRight13 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight13++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 16)
            {
                if (floor.gameObject.name.Contains("15") && floor.gameObject.name.Contains("Right") && attemptRight14 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight14++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 17)
            {
                if (floor.gameObject.name.Contains("16") && floor.gameObject.name.Contains("Right") && attemptRight15 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight15++;
                }
            }

            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 18)
            {
                if (floor.gameObject.name.Contains("17") && floor.gameObject.name.Contains("Right") && attemptRight16 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight16++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 19)
            {
                if (floor.gameObject.name.Contains("18") && floor.gameObject.name.Contains("Right") && attemptRight17 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight17++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 20)
            {
                if (floor.gameObject.name.Contains("19") && floor.gameObject.name.Contains("Right") && attemptRight18 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight18++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 21)
            {
                if (floor.gameObject.name.Contains("20") && floor.gameObject.name.Contains("Right") && attemptRight19 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight19++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 22)
            {
                if (floor.gameObject.name.Contains("21") && floor.gameObject.name.Contains("Right") && attemptRight20 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight20++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 23)
            {
                if (floor.gameObject.name.Contains("22") && floor.gameObject.name.Contains("Right") && attemptRight21 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight21++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 24)
            {
                if (floor.gameObject.name.Contains("23") && floor.gameObject.name.Contains("Right") && attemptRight22 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight22++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 25)
            {
                if (floor.gameObject.name.Contains("24") && floor.gameObject.name.Contains("Right") && attemptRight23 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight23++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 26)
            {
                if (floor.gameObject.name.Contains("25") && floor.gameObject.name.Contains("Right") && attemptRight24 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight24++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 27)
            {
                if (floor.gameObject.name.Contains("26") && floor.gameObject.name.Contains("Right") && attemptRight25 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight25++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 28)
            {
                if (floor.gameObject.name.Contains("27") && floor.gameObject.name.Contains("Right") && attemptRight26 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight26++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 29)
            {
                if (floor.gameObject.name.Contains("28") && floor.gameObject.name.Contains("Right") && attemptRight27 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight27++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 30)
            {
                if (floor.gameObject.name.Contains("29") && floor.gameObject.name.Contains("Right") && attemptRight28 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight28++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 31)
            {
                if (floor.gameObject.name.Contains("30") && floor.gameObject.name.Contains("Right") && attemptRight29 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight29++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 32)
            {
                if (floor.gameObject.name.Contains("31") && floor.gameObject.name.Contains("Right") && attemptRight30 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight30++;
                }
            }

            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 33)
            {
                if (floor.gameObject.name.Contains("32") && floor.gameObject.name.Contains("Right") && attemptRight31 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight31++;
                }
            }

            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 34)
            {
                if (floor.gameObject.name.Contains("33") && floor.gameObject.name.Contains("Right") && attemptRight32 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight32++;
                }
            }

            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 35)
            {
                if (floor.gameObject.name.Contains("34") && floor.gameObject.name.Contains("Right") && attemptRight33 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight33++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 36)
            {
                if (floor.gameObject.name.Contains("35") && floor.gameObject.name.Contains("Right") && attemptRight34 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight34++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 37)
            {
                if (floor.gameObject.name.Contains("36") && floor.gameObject.name.Contains("Right") && attemptRight35 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight35++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 38)
            {
                if (floor.gameObject.name.Contains("37") && floor.gameObject.name.Contains("Right") && attemptRight36 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight36++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 39)
            {
                if (floor.gameObject.name.Contains("38") && floor.gameObject.name.Contains("Right") && attemptRight37 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight37++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 40)
            {
                if (floor.gameObject.name.Contains("39") && floor.gameObject.name.Contains("Right") && attemptRight38 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight38++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 41)
            {
                if (floor.gameObject.name.Contains("40") && floor.gameObject.name.Contains("Right") && attemptRight39 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight39++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 42)
            {
                if (floor.gameObject.name.Contains("41") && floor.gameObject.name.Contains("Right") && attemptRight40 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight40++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 43)
            {
                if (floor.gameObject.name.Contains("42") && floor.gameObject.name.Contains("Right") && attemptRight41 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight41++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 44)
            {
                if (floor.gameObject.name.Contains("43") && floor.gameObject.name.Contains("Right") && attemptRight42 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight42++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 45)
            {
                if (floor.gameObject.name.Contains("44") && floor.gameObject.name.Contains("Right") && attemptRight43 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight43++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 46)
            {
                if (floor.gameObject.name.Contains("45") && floor.gameObject.name.Contains("Right") && attemptRight44 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight44++;
                }
            }
            else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 47)
            {
                if (floor.gameObject.name.Contains("46") && floor.gameObject.name.Contains("Right") && attemptRight45 == 0)
                {
                    Debug.Log("missed right shots: " + Shoot.missedRightShots + "   missed left shots: " + MoveUpwards.FloorNum);

                    Animator anime = floor.GetComponent<Animator>();
                    anime.SetTrigger("moveFloor");
                    attemptRight45++;
                }
            }

            #endregion
        }
    }

   
    private void SetValues()
    {
        attemptLeft = 0;
        attemptRight = 0;

        attemptLeft1 = 0;
        attemptRight1 = 0;

        attemptLeft2 = 0;
        attemptRight2 = 0;

        attemptLeft3 = 0;
        attemptRight3 = 0;

        attemptLeft4 = 0;
        attemptRight4 = 0;

        attemptLeft5 = 0;
        attemptRight5 = 0;

        attemptLeft6 = 0;
        attemptRight6 = 0;

        attemptLeft7 = 0;
        attemptRight7 = 0;

        attemptLeft8 = 0;
        attemptRight8 = 0;

        attemptLeft9 = 0;
        attemptRight9 = 0;

        attemptLeft10 = 0;
        attemptRight10 = 0;

        attemptLeft11 = 0;
        attemptRight11 = 0;

        attemptLeft12 = 0;
        attemptRight12 = 0;

        attemptLeft13 = 0;
        attemptRight13 = 0;

        attemptLeft14 = 0;
        attemptRight14 = 0;

        attemptLeft15 = 0;
        attemptRight15 = 0;

        attemptLeft16 = 0;
        attemptRight16 = 0;

        attemptLeft17 = 0;
        attemptRight17 = 0;

        attemptLeft18 = 0;
        attemptRight18 = 0;

        attemptLeft19 = 0;
        attemptRight19 = 0;

        attemptLeft20 = 0;
        attemptRight20 = 0;

        attemptLeft21 = 0;
        attemptRight21 = 0;

        attemptLeft22 = 0;
        attemptRight22 = 0;

        attemptLeft23 = 0;
        attemptRight23 = 0;

        attemptLeft24 = 0;
        attemptRight24 = 0;

        attemptLeft25 = 0;
        attemptRight25 = 0;

        attemptLeft26 = 0;
        attemptRight26 = 0;

        attemptLeft27 = 0;
        attemptRight27 = 0;

        attemptLeft28 = 0;
        attemptRight28 = 0;

        attemptLeft29 = 0;
        attemptRight29 = 0;

        attemptLeft30 = 0;
        attemptRight30 = 0;

        attemptLeft31 = 0;
        attemptRight31 = 0;

        attemptLeft32 = 0;
        attemptRight32 = 0;

        attemptLeft33 = 0;
        attemptRight33 = 0;

        attemptLeft34 = 0;
        attemptRight34 = 0;

        attemptLeft35 = 0;
        attemptRight35 = 0;

        attemptLeft36 = 0;
        attemptRight36 = 0;

        attemptLeft37 = 0;
        attemptRight37 = 0;

        attemptLeft38 = 0;
        attemptRight38 = 0;

        attemptLeft39 = 0;
        attemptRight39 = 0;

        attemptLeft40 = 0;
        attemptRight40 = 0;

        attemptLeft41 = 0;
        attemptRight41 = 0;

        attemptLeft42 = 0;
        attemptRight42 = 0;

        attemptLeft43 = 0;
        attemptRight43 = 0;

        attemptLeft44 = 0;
        attemptLeft44 = 0;

        attemptRight45 = 0;
        attemptRight45 = 0;
    }

}
