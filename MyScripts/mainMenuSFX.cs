using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuSFX : MonoBehaviour
{
    private AudioSource aSource_Canvas;
    public AudioClip aClip_SFX;

    void Start() { aSource_Canvas = GetComponent<AudioSource>(); }

    public void PlaySFX()
    {
        aSource_Canvas.PlayOneShot(aClip_SFX);
    }

    public void ShopSFX()
    {
        mainMenuSoundManager.play_Click = true;
    }

    public void AdSFX()
    {
        mainMenuSoundManager.back_Click = true;
    }
}
