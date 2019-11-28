using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePopUpTxt : MonoBehaviour
{
    public GameObject parent;

    public void DisableGO()
    {
        parent.SetActive(false);
    }
}
