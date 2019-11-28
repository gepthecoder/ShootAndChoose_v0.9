using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public GameObject smokeBlueish;
    public GameObject smokeGoldish;


    void Update() { StartCoroutine(ChangeColors()); }

    void SetBlueishtColors() {

        ParticleSystem.MainModule settings = smokeBlueish.GetComponent<ParticleSystem>().main;
        settings.startColor = new ParticleSystem.MinMaxGradient(new Color(77,Random.Range(127,157),156));
    }

    void SetGoldishColors() {

        ParticleSystem.MainModule settings = smokeGoldish.GetComponent<ParticleSystem>().main;
        settings.startColor = new ParticleSystem.MinMaxGradient(new Color(166,Random.Range(140, 171), 8));
    }


    private IEnumerator ChangeColors() {

        SetBlueishtColors();
        SetGoldishColors();

        yield return new WaitForSeconds(2f);

        SetBlueishtColors();
        SetGoldishColors();

        yield return new WaitForSeconds(2f);

        SetBlueishtColors();
        SetGoldishColors();

        yield break;
    }
}
