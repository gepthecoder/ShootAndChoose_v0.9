using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleEffectScript : MonoBehaviour
{
    //LASER COLOR EFFECTS
    public GameObject Virus_GreenDeath;
    public GameObject SkullEffect_Purple;
    public GameObject ElectricEffect_Blue;
    public GameObject SkullExplosion_WhiteRed;
    public GameObject MagicHit_Golden;

    //LASER AUDIO EFFECTS
    public AudioClip deepHIT_SuperSonic;

    public AudioClip electricSpark_Blue;
    public AudioClip spellSound_Purple;

    //SUPER SONIC WEAPON EFFECT
    public GameObject superSonic_EffectBoom;


    public GameObject DarkVortex;
    public GameObject cubeTest;

    private float time;
    private float Counter = 3;

    #region Touch Effect
    //void Update()
    //{
    //    //time += Time.deltaTime;

    //    //if(time >= Counter)
    //    //{
    //    //    if(Input.touchCount > 0)
    //    //    {
    //    //        Touch touch = Input.GetTouch(0);
    //    //        if (touch.phase == TouchPhase.Began)
    //    //        {
    //    //            time = 0;
    //    //            GameObject go = Instantiate(cubeTest, touch.position, Quaternion.identity);
    //    //            Destroy(go, 4);
    //    //        }

    //    //    }

    //    //}

    //}
    #endregion

    public void SpawnRippleEffect(Touch touch)
    {
        Debug.Log("Ripple Spawned");
        GameObject go = Instantiate(Virus_GreenDeath, touch.position, Quaternion.identity);
        Destroy(go, 5f);
    }

    public void SpawnPurpleSkullEffect(Vector2 touchPos)
    {
        GameObject go = Instantiate(SkullEffect_Purple, touchPos, SkullEffect_Purple.transform.rotation) as GameObject;
        Destroy(go, 5f);
    }

}
