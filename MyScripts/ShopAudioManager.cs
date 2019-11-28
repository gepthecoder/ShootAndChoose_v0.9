using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopAudioManager : MonoBehaviour
{
    #region BG Music
    public AudioSource aSource_BG_Music;
    public AudioClip aClip_BG_Music;

    private void PlayBGMusic()
    {
        aSource_BG_Music.PlayOneShot(aClip_BG_Music);
    }
    #endregion

    #region SFX
    public AudioSource aSource_ClickEvents;

    //CLICK EVENTS
    public AudioClip aClip_ClickSound_other;

    public static bool playClickSound_other;

    public void setPlayClickSound_other()
    {
        playClickSound_other = false;
    }

    public void ManageClickSound_other()
    {
        if (playClickSound_other)
        {
            aSource_ClickEvents.PlayOneShot(aClip_ClickSound_other);
            setPlayClickSound_other();
        }
    }

    public void GoToPurchaseShopSound()
    {
        aSource_ClickEvents.PlayOneShot(aClip_ClickSound_other);
    }

    //BuySound
    public AudioClip aClip_buy_upgrade_click;

    public static bool playBuyUpgradeClickSound;

    public void setBuyUpgradeClickSound() { playBuyUpgradeClickSound = false; }

    public void ManageBuyUpgradeClickSound()
    {
        if (playBuyUpgradeClickSound)
        {
            aSource_ClickEvents.PlayOneShot(aClip_buy_upgrade_click);
            setBuyUpgradeClickSound();
        }
    }

    //deniedBuy
    public AudioClip aClip_deny_buy_upgrade_click;

    public static bool playDenyBuyUpgradeClickSound;

    public void setDenyBuyUpgradeClickSound() { playDenyBuyUpgradeClickSound = false; }

    public void ManageDenyBuyUpgradeClickSound()
    {
        if (playDenyBuyUpgradeClickSound)
        {
            aSource_ClickEvents.PlayOneShot(aClip_deny_buy_upgrade_click);
            setDenyBuyUpgradeClickSound();
        }
    }

    public void Denieeeed()
    {
        aSource_ClickEvents.PlayOneShot(aClip_deny_buy_upgrade_click);
    }

    //Transition
    public AudioClip aClip_Swish;

    public static bool playSwishSound;

    public void setSwishSound()
    {
        playSwishSound = false;
    }

    public void ManageSwishSound()
    {
        if (playSwishSound)
        {
            aSource_ClickEvents.PlayOneShot(aClip_Swish);
            setSwishSound();
        }
    }

    public void SWIIIIIISH()
    {
        aSource_ClickEvents.PlayOneShot(aClip_Swish);
    }

    //Select 
    public AudioClip aClip_Select;

    public static bool playSelectSound;

    public void setSelectSound()
    {
        playSelectSound = false;
    }

    public void ManageSelectSound()
    {
        if (playSelectSound)
        {
            aSource_ClickEvents.PlayOneShot(aClip_Select);
            setSelectSound();
        }
    }

    public void SelectSound_audio()
    {
        aSource_ClickEvents.PlayOneShot(aClip_Select);
    }

    //Purchase shop buy/notEnoughMoney --> sounds

    public static bool buy_sound;
    public AudioClip buySound;

    public static bool notEnoughMoney_sound;
    public AudioClip notEnoughMoneySound;

    private void CheckOnThemSounds_IAP()
    {
        if (buy_sound)
        {
            aSource_ClickEvents.PlayOneShot(buySound);
            SetBuy_sound();
        }

        if (notEnoughMoney_sound)
        {
            aSource_ClickEvents.PlayOneShot(notEnoughMoneySound);
            SetNotEnoughMoney_sound();
        }
    }

    private void SetNotEnoughMoney_sound()
    {
        notEnoughMoney_sound = false;
    }

    private void SetBuy_sound()
    {
        buy_sound = false;
    }

    #endregion

    void OnEnable()
    {
        setPlayClickSound_other();
        setBuyUpgradeClickSound();
        setSwishSound();
        setSelectSound();
        setDenyBuyUpgradeClickSound();
        SetNotEnoughMoney_sound();
        SetBuy_sound();
    }

    void Start()
    {
        PlayBGMusic();
    }

    void Update()
    {
        ManageClickSound_other();
        ManageBuyUpgradeClickSound();
        ManageSwishSound();
        ManageSelectSound();
        ManageDenyBuyUpgradeClickSound();
        CheckOnThemSounds_IAP();
    }


}
