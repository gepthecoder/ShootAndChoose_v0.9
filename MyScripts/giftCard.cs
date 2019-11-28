using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giftCard : MonoBehaviour
{
    public Animator anime_GiftCard;
    public AudioSource aSource_closeGiftCard;
    public AudioClip aClip_closeGiftCard;

    public void byebyeGiftCard()
    {
        aSource_closeGiftCard.PlayOneShot(aClip_closeGiftCard);
        anime_GiftCard.SetTrigger("byebyeGiftCard");
    }
}
