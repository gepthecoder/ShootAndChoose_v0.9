using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAudioManager : MonoBehaviour
{
    private AudioSource aSource_bg;
    public AudioSource aSource_clicks;
    // CHALLANGES
    public AudioSource aSource_Challanges;

    public AudioClip aClip_bg;
    public AudioClip aClip_SelectLevel;
    public AudioClip aClip_other;
    public AudioClip aClip_BackExit;
    // CHALLANGES
    public AudioClip aClip_GET_REWARD_SOUND;
    public AudioClip aClip_CloseOpenUI_SOUND;
    public AudioClip aClip_CollectAll_SOUND;
    public AudioClip aClip_GetCoins_SOUND;
    
    private void Awake()
    {
        aSource_bg = GetComponent<AudioSource>();
    }
    private void Start()
    {
        aSource_bg.clip = aClip_bg;
        aSource_bg.Play();
    }

    public void PLAY_SOUND_SelectLevel()
    {
        aSource_clicks.PlayOneShot(aClip_SelectLevel);
    }

    public void PLAY_SOUND_Other()
    {
        aSource_clicks.PlayOneShot(aClip_other);
    }

    public void PLAY_SOUND_BackExit()
    {
        aSource_clicks.PlayOneShot(aClip_BackExit);
    }

    // CHALLANGES

    public void CHALLANGES_SOUNDS_GetReward()
    {
        aSource_Challanges.PlayOneShot(aClip_GET_REWARD_SOUND);
    }

    public void CHALLANGES_SOUNDS_CloseOpenUI()
    {
        aSource_Challanges.PlayOneShot(aClip_CloseOpenUI_SOUND);
    }

    public void CHALLANGES_SOUNDS_CollectAll()
    {
        aSource_Challanges.PlayOneShot(aClip_CollectAll_SOUND);
    }

    public void CHALLANGES_SOUNDS_GetCoins()
    {
        aSource_Challanges.PlayOneShot(aClip_GetCoins_SOUND);
    }
}
