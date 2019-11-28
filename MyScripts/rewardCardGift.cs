using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rewardCardGift : MonoBehaviour
{
    public Animator anime_reward;

    public void RevealReward()
    {
        anime_reward.SetTrigger("revealReward");
    }

    public Animator anime_rewardCard;

    public void RevealRewardCard()
    {
        anime_rewardCard.SetTrigger("revealRewardCard");
    }

    public void goodbyeRewardCard()
    {
        anime_rewardCard.SetTrigger("goodbyeRewardCard");
    }

  
    
}
