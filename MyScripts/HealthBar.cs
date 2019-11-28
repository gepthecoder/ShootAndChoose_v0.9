using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Animator anime;

    public Image foreGroundImage;

    public float updateSpeedSeconds = 0.5f;

    private EnemyHealthScript health;

    private void Start()
    {
        health = GetComponentInParent<EnemyHealthScript>();
        if (!health.isActiveAndEnabled)
            health.enabled = true;
    }

    private void Awake()
    {
        GetComponentInParent<EnemyHealthScript>().OnHealthPctChanged += HealthBar_OnHealthPctChanged;

        anime = GetComponent<Animator>();
    }

    private void HealthBar_OnHealthPctChanged(float pct)
    {
        StartCoroutine(ChangeToPct(pct));
    }

    private IEnumerator ChangeToPct(float pct)
    {
        float preChangePct = foreGroundImage.fillAmount;
        float elapsed = 0f;

        while(elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            foreGroundImage.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / updateSpeedSeconds); //Interpelate between two values
            yield return null;
        }

        foreGroundImage.fillAmount = pct;
    }

    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
        transform.localScale = new Vector3(0.007f, 0.01f, 0.01f);
    }

    private void Update()
    {
        if (health.currentHealth <= 0)
        {
            StartCoroutine(wAITandColapse());
        }

    }

    private IEnumerator wAITandColapse()
    {
        anime.SetTrigger("deadBar");
        yield return new WaitForSeconds(1f);
        Debug.Log("waaaait And Colapseee");

        Destroy(gameObject);

    }
}
