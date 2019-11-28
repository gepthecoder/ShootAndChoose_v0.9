using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public GameObject Player;
    private Rigidbody bossRB;

    public GameObject laserBeam;
    public GameObject explosionHit;
    public GameObject impactEffectBoss;

    public GameObject leftBoss;
    public GameObject rightBoss;

    public int damageToTake = 100;

    //public Transform gunEndPoint;

    private float speed = 2.0f;
    private float weaponRange = 10f;

    private AudioSource audioSource;
    public AudioClip laserSound;

    public static bool canAttckLeft;
    public static bool canAttckRight;

    //Health
    public bool deadBoss;

    public int bossHealth;
    private int startHealth = 100;
    public int bossCount;

    //Death Effect
    private int power = 10;
    private float radius = 15.0f;

    private float time;
    private float attackRate = 3.0f;

    //Anime
    private Animator anime;

    //player --> Shoot script
    public Shoot shoot;
    private int lastFloorNum;

    //take life animation
    public GameObject loseLifePoint;

    Vector3 startLPos;
    Vector3 startRPos;

    void Awake()
    {
        bossRB = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        anime = GetComponent<Animator>();
    }

    void Start()
    {
        deadBoss = false;
        bossHealth = startHealth;
        damageToTake = 100;
        bossCount = 0;

        canAttckLeft = false;
        canAttckRight = false;

        lastFloorNum = shoot.lastFloor;
        Debug.Log(lastFloorNum);

        if (gameObject.name.Contains("left"))
        {
            startLPos = new Vector3(
            transform.position.x,
            transform.position.y,
            transform.position.z);
        }else if (gameObject.name.Contains("right"))
        {
            startRPos = new Vector3(
            transform.position.x,
            transform.position.y,
            transform.position.z);
        }
     

    }

    void Update()
    {

        #region Attack Behaviour

        CheckAttack();            
                  
        #endregion

        #region BossHealth Check
        //health
        if(bossHealth <= 0 || deadBoss)
        {
            //its dead
            bossDead();
        }

        #endregion

        #region StayAtStartPositions

        if (gameObject.name.Contains("left"))
        {
            transform.position = startLPos;
        }else if (gameObject.name.Contains("right"))
        {
            transform.position = startRPos;
        }

        #endregion // 5.9.2019 12:25

    }

    private void LockOnTarget()
    {
        transform.LookAt(Player.transform);
        //transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void CheckAttack()
    {
        if (MoveUpwards.FloorNum == lastFloorNum)
        {

            if (Shoot.playerMissedLastShots)
            {
                if (Shoot.LeftSide)
                {
                    canAttckLeft = true;  
                }
                if(Shoot.RightSide)
                {
                    canAttckRight = true;                 
                }

                Shoot.playerMissedLastShots = false;
            }
        }                   
    }

       public bool BossDead()
        {
            return deadBoss;
        }

    
       public void ApplyBossDamage()
        {
            if (deadBoss) { return; }

            bossHealth -= damageToTake;

            if (bossHealth <= 0)
            {
                bossDead();
            }
        }
     
       void bossDead()
        {
            deadBoss = true;
            StartCoroutine(WaitAndDieBoss());
        }


      IEnumerator WaitAndDieBoss()
        {
            yield return new WaitForSeconds(0.1F);

            if (bossRB != null)
            {
                bossRB.AddExplosionForce(power*100, transform.position, radius, 2.0F);

                yield return new WaitForSeconds(2F);
                bossCount += 1;
                Destroy(gameObject);
            }


        }
     
}
