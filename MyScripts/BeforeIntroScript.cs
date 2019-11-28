using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeforeIntroScript : MonoBehaviour
{
    public GameObject Missile;

    public GameObject C1;
    public GameObject C2;

    public GameObject InfoUI;

    private Animator A1;
    private Animator A2;

    private Animator mainAnime;
    public bool InfoIsOpen;

    void Awake()
    {
        A1 = C1.GetComponent<Animator>();
        A2 = C2.GetComponent<Animator>();

        mainAnime = GetComponent<Animator>();

        Missile.GetComponent<Animator>().SetBool("RotateMissile", true);

        InfoIsOpen = false;
    }

    void Update() {

        A1.SetBool("Fight", true);
        A2.SetBool("Fight", true); 

    }

    public void InfoPressed() {

        if(mainAnime != null) {
            if (InfoIsOpen) {
                mainAnime.SetTrigger("FlyOut");
                InfoIsOpen = false;
            }
            else { mainAnime.SetTrigger("FlyIn"); }
                
            

        }
    }

    public void SetToFalseWhenAnimeEnds() {
        InfoIsOpen = true;
    }
}
