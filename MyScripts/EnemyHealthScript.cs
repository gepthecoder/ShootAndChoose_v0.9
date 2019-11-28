using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    public static bool theCactussWasMurdered;

    public int health = 100;
    public string nameOfTheToten;

    private bool isDead;

    private Animator anime;
    private Rigidbody rb;

    public float power = 13.0F;
    public float radius = 5.0F;

    public int maxHealth = 100;
    public int currentHealth;

    public event Action<float> OnHealthPctChanged = delegate { }; // takes float --> way to avoid null check

    private RippleEffectScript ripple;

    void OnEnable()
    {
        currentHealth = maxHealth;
    }

    void Awake()
    {
        anime = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        ripple = GameObject.FindGameObjectWithTag("GameManager").GetComponent<RippleEffectScript>();

        isDead = false;
    }

    void Update()
    {
        currentHealth = health;

        if (health <= 0)
        {
            Dead();
        }
    }

    public bool EnemyDead()
    {
        return isDead;
    }


    public void ApplyDamage(int damageToTake)
    {
        
        if (isDead) { return; }

        anime.SetTrigger("GetHit");
        //TO:DO play sound for getin hurt

        health -= damageToTake;
        ModifyHealth(-damageToTake);

        if (health <= 0)
        {
            Dead();
        }
             
    } 

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;

        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);
    }

    void Dead()
    {
        isDead = true;
        EnemyAttck attck = GetComponent<EnemyAttck>();
        attck.onlyOnce = 0;
        nameOfTheToten = name;
        anime.SetTrigger("IsDead");
        theCactussWasMurdered = true;
        StartCoroutine(WaitAndDie());
    }

    IEnumerator WaitAndDie()
    {
        //Spawn_DarkVortex();
        yield return new WaitForSeconds(1F);

        if (rb != null)
        {
            rb.AddExplosionForce(power, transform.position, radius, 3.0F);
            yield return new WaitForSeconds(3F);
            Destroy(gameObject);
        }
    }

    private void Spawn_DarkVortex()
    {
        GameObject vortex = Instantiate(ripple.DarkVortex, transform.position, transform.rotation);
        Destroy(vortex, 1f);
    }

   

  

}
