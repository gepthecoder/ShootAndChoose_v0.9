using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySelfDestruction : MonoBehaviour
{
    public GameObject explosion;

    private EnemyHealthScript _enemeyHealth;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            StartCoroutine(aboutToHit());
        }

    }

  public IEnumerator aboutToHit()
    {
        yield return new WaitForSeconds(0.3f);
        EnemyAttck._enemyAboutToHitBase = true;
    }


    #region BlastOff

    /*
     *  other.gameObject.GetComponent<Animator>().enabled = false;
        // how much the character should be knocked back
        var magnitude = 100;
        // calculate force vector
        var force = other.transform.position - transform.position;
        // normalize force vector to get direction only and trim magnitude
        force.Normalize();
        other.gameObject.GetComponent<Rigidbody>().AddForce(force * magnitude);
        other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;

        other.gameObject.GetComponent<EnemyAttck>().enabled = false;

    
        */


    #endregion
}


/*
 
      if (canPullEnemey)
        {
            // how much the character should be knocked back
            var magnitude = 50;
            // calculate force vector
            var force = other.transform.position - transform.position;
            // normalize force vector to get direction only and trim magnitude
            force.Normalize();
            other.gameObject.GetComponent<Rigidbody>().AddForce(force * magnitude);
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            other.gameObject.GetComponent<EnemyAttck>().enabled = false;           
        }
     
     
     
      if (canExplode)
        {
           
            
        }
       
        _enemeyHealth = other.GetComponent<EnemyHealthScript>();

        if (_enemeyHealth.gameObject.name.Contains("left"))
        {
            MoveUpwards.killConfirmed = true;
            Shoot.missedShotsAttemps = 0;
            Shoot.missedLeftShots = 0;
            Shoot.LeftShotHit = true;
            Shoot.LeftEnemyCount += 1;
            _enemeyHealth.ApplyDamage(_enemeyHealth.maxHealth);
            Debug.Log("KABOOOOOOOOM ENEMY EXPODED!!!!!!!!!!!!!!!!!!!!!!!");

        }
        else if (_enemeyHealth.gameObject.name.Contains("right"))
        {
            MoveUpwards.killConfirmed = true;
            Shoot.missedShotsAttemps = 0;
            Shoot.missedRightShots = 0;
            Shoot.RightShotHit = true;
            Shoot.RightEnemyCount += 1;
            _enemeyHealth.ApplyDamage(_enemeyHealth.maxHealth);
            Debug.Log("KABOOOOOOOOM ENEMY EXPODED!!!!!!!!!!!!!!!!!!!!!!!");

        }

     
     
     
     */
