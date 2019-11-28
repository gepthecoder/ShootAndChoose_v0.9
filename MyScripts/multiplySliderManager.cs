using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiplySliderManager : MonoBehaviour
{
    public Animator addOnsAnimator;

    //function calls within animation clip
    public void ActivateAnimator()
    {
        addOnsAnimator.SetTrigger("addOns");
    }
}
