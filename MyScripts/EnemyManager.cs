using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (other.GetComponent<EnemyHealthScript>() != null)
            {
                Debug.Log("Trigger ---> Enemy hit by launcher");
                EnemyHealthScript enemy = other.GetComponent<EnemyHealthScript>();

                if (enemy.gameObject.name.Contains("left"))
                {
                    if(enemy.currentHealth > 0)
                    {
                        MoveUpwards.killConfirmed = true;
                        Shoot.missedShotsAttemps = 0;
                        Shoot.missedLeftShots = 0;
                        Shoot.LeftShotHit = true;
                        Shoot.LeftEnemyCount += 1;
                        enemy.ApplyDamage(enemy.maxHealth);
                    }
                   

                }
                else if (enemy.gameObject.name.Contains("right"))
                {
                    if(enemy.currentHealth > 0)
                    {
                        MoveUpwards.killConfirmed = true;
                        Shoot.missedShotsAttemps = 0;
                        Shoot.missedRightShots = 0;
                        Shoot.RightShotHit = true;
                        Shoot.RightEnemyCount += 1;
                        enemy.ApplyDamage(enemy.maxHealth);
                    }
                 

                }

            }
        }
    }
}
