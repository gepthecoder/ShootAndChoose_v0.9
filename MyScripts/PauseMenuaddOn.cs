using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuaddOn : MonoBehaviour
{
    public void SetTimeScaleFreez()
    {
        Time.timeScale = 0f;
    }

    public void SetTimeScaleAction()
    {
        Time.timeScale = 1f;
    }
}
