using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class ExtraLifeEnd : MonoBehaviour
{

    public GoPlay fader;

    public void NextLevelSir()
    {
        if (MoveUpwards.levelCompleted == true)
        {
            PlayAds_levelComplited();
            MoveUpwards.levelCompleted = false;
        }
    }

    public void PlayAds_levelComplited()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResult });

        }
    }

    private void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                fader.OpenLevels();
                break;
            case ShowResult.Skipped:
                fader.OpenLevels();
                break;
            case ShowResult.Failed:
                Debug.Log("Ad failed to load! Check internet connection!");
                break;
        }
    }
}
