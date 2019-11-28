using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Specials : MonoBehaviour
{
    //SPAWN VFX PARTICLE SYSTEMS INTO GAMEPLAY

    //PLAYER PLATFORM APPERANCE
    public GameObject platform_Apperance;

    private void PlayApperanceVFX()
    {
        Instantiate(platform_Apperance, new Vector3(0, 0, 0), platform_Apperance.transform.rotation);
    }

    void Start()
    {
        //Game Starts
        PlayApperanceVFX();
    }
}
