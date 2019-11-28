using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using EZCameraShake;

public class Shoot : MonoBehaviour
{
    public static bool playerMissedShot;
    public static bool playerMissedLastShots;

    public static int killStreak;
    public string killStreakName;
    private Animator killStreakAnime;

    public static int valueForStars;

    public static int missedShotsAttemps;
    public static int missedLeftShots;
    public static int missedRightShots;

    public static bool LeftShotHit;
    public static bool RightShotHit;

    #region Lasers
    public GameObject laserBeaaamRed;
    public GameObject laserBeaaamGreen;
    public GameObject laserBeaaamBlue;
    public GameObject laserBeaaamPurple;
    public GameObject laserBeaaamGold;

    private GameObject laserToUse;
    #endregion

    #region Weapons
    public GameObject atomicMissileLauncher;
    public Transform gunEndPoint;

    public GameObject tripleThreadMissileLauncher;
    public Transform gunEndPoint1;
    public Transform gunEndPoint2;
    public Transform gunEndPoint3;

    public GameObject superSonicMissileLauncher;
    public Transform gunEndPoint4;

    private GameObject missileLauncherToUse;
    #endregion

    #region Characters

    public GameObject character_SoldierBoy;
    public GameObject character_Cyborg;
    public GameObject character_ChanLee;

    private GameObject character_ToUse; 
    #endregion

    public int missedLshots;
    public int missedRshots;

    public static bool LeftSide;
    public static bool RightSide;

    public float fireRate = 1f;

    private float timer;
    private float speedOfMissle = 20f;

    private int hitDamagelvl1 = 100;
    private int hitDamagelvl2 = 100;
    private int damageToUse;
    private int hitDamageTripleTwo = 40;
    private int hitDamageTripleThree = 40;


    public static int scorePoints;


    private int weaponRange = 100;
    private bool canonIsMoving;


    public GameObject impactEffectEnemy_Red;
    public GameObject impactEffectEnemy_Green;
    public GameObject impactEffectEnemy_Blue;

    public GameObject impactEffectEnemy_Purple;
    public GameObject impactEffectEnemy_Golden;

    public GameObject impactEffectOther;
    public GameObject impactEffectExplosion;
    public GameObject impactEffectBoss;

    public GameObject Missle;   

    private LineRenderer laserLine;
    public bool UseLaser;

    private Animator anime;
    private AudioSource audioSource;


    public AudioClip laserSound;
    public AudioClip laserSound1;
    public AudioClip hitSoundEnemy;
    public AudioClip hitSoundOther;

    public Rect shootArea;

    public GameObject player;

    public static int LeftEnemyCount;
    public static int RightEnemyCount;

    private bool dead;
    public static int enemiesDied;

    public GameObject bossLeft;
    public GameObject bossRight;

    public Text killStreakText;

    public static bool enemyIsNotMoving;

    public int lastFloor;

    public RippleEffectScript ripple;

    public static bool IncreaseSpeedOfLauncher;
    private float increaseValue = 0.08f;
    float animeSpeed = 1;

    public static bool diffSoundEffect;

    private Animator anime_Solider;

    private void SetupAnimes()
    {
        anime_Solider = character_SoldierBoy.GetComponent<Animator>();
    }

    public static bool enemyDiedShootGoAhead;

    private GameObject color_effect_to_use;

    private AudioClip aClip_SoundHIT;

    private Image outline_color;

    private GameObject OUTLINE;

    private bool youCanShoot = false;


    void Awake()
    {
        SetLaserBeaam();
        SetMissileLauncher();
        SetCharacter();
        SetLastFloor();
        SetShootAttempts();

        SetupAnimes();

        anime = GetComponent<Animator>();
        laserLine = GetComponent<LineRenderer>();
        audioSource = GetComponent<AudioSource>();
        OUTLINE = GameObject.FindGameObjectWithTag("outline");
        outline_color = OUTLINE.GetComponent<Image>();

    }

    void Start()
    {
      
        ManageScorePoints();

        killStreak = 0;
        valueForStars = 0;
       

        canonIsMoving = true;
        enemyIsNotMoving = true;

        shootArea = new Rect(0, 0, Screen.width, Screen.height / 1.2f);
        setDiffSoundEffect();

        enemyDiedShootGoAhead = false;

        setOutlineColor();
        Begining_FillAmount();
    }


    void Update()
    {
        missedLshots = missedLeftShots;
        missedRshots = missedRightShots;

        timer += Time.deltaTime;

        ManageOutLineFill_Increase();

        if (timer >= fireRate /*&& enemyIsNotMoving*/)
        {
            #region Mobile Inputs
            if (Input.touchCount > 0)
            {
                var touchPos = Input.GetTouch(0).position;

                Touch touch = Input.GetTouch(0);
                //Ray ray = Camera.main.ScreenPointToRay(touch.position);
                //RaycastHit hit;
                if (shootArea.Contains(touchPos))
                {
                    timer = 0f;
                    Handheld.Vibrate();
                    Shootas();
                    enemyDiedShootGoAhead = false;
                    youCanShoot = false;
                    Begining_FillAmount();

                }
            }
            #endregion

            youCanShoot = true;
          

            #region Computer Test Inputs
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Debug.Log("shot");
                timer = 0f;
                Shootas();
                enemyDiedShootGoAhead = false;
                youCanShoot = false;
                Begining_FillAmount();
            }
            #endregion
        }


        if (UseLaser) { laserLine.enabled = true; }
        else { laserLine.enabled = false; }

        if (canonIsMoving)
        {
            anime.SetBool("RotateMissile", true);
           
            if (IncreaseSpeedOfLauncher)
            {
                animeSpeed += increaseValue;            
                IncreaseSpeedOfLauncher = false;
            }

            anime.speed = animeSpeed;

            if(killStreak == 0) { anime.speed = 1; }

            //Debug.Log(anime.speed);
        }
        else
        {
            anime.SetBool("RotateMissile", false);
        }

        LeftyRighty(transform);

        if (dead)
        {
            enemiesDied += 1;
            dead = false;
        }

        SetKillStreakName();
        DisplayKillStreakAnime();
    }


    private int atomicDamage;
    private int tripleDamage;
    private int sonicDamage;

    public void ManageScorePoints()
    {
        if (currentWeapon == "atomicLauncher") {
            if (PlayerPrefs.HasKey("atomicDamage")) {  atomicDamage = PlayerPrefs.GetInt("atomicDamage"); }
            else {
                PlayerPrefs.SetInt("atomicDamage", 10);
                atomicDamage = PlayerPrefs.GetInt("atomicDamage");
            }
            scorePoints = atomicDamage;
        }
        else if (currentWeapon == "TripleLauncher") {
            if (PlayerPrefs.HasKey("tripleDamage")) { tripleDamage = PlayerPrefs.GetInt("tripleDamage"); }
            else
            {
                PlayerPrefs.SetInt("tripleDamage", 60);
                tripleDamage = PlayerPrefs.GetInt("tripleDamage");
            }
            scorePoints = tripleDamage;
        }
        else if (currentWeapon == "SonicLauncher") {
            if (PlayerPrefs.HasKey("sonicDamage")) { sonicDamage = PlayerPrefs.GetInt("sonicDamage"); }
            else
            {
                PlayerPrefs.SetInt("sonicDamage", 100);
                sonicDamage = PlayerPrefs.GetInt("sonicDamage");
            }
            scorePoints = sonicDamage;
        }
    }

    public void Shootas()
    {
        if (missileLauncherToUse == atomicMissileLauncher)
        {
            FireAtomicCanonBlast(gunEndPoint);

        }
        else if (missileLauncherToUse == tripleThreadMissileLauncher)
        {
            StartCoroutine(TripleShot());

        }
        else if (missileLauncherToUse == superSonicMissileLauncher)
        {
            FireSuperSonicCanonBlast(gunEndPoint4);
        }
    }

    public IEnumerator TripleShot()
    {
        FireTripleCanonBlast(gunEndPoint1);
        yield return new WaitForSeconds(0.1f);
        FireTripleCanonBlast1(gunEndPoint2);
        yield return new WaitForSeconds(0.1f);
        FireTripleCanonBlast2(gunEndPoint3);
    }

    private static void LeftyRighty(Transform Missile)
    {
        if (Missile.rotation.z > 0)
        {
            LeftSide = true;
            RightSide = false;
        }
        else
        {
            RightSide = true;
            LeftSide = false;
        }
    }


    void FireAtomicCanonBlast(Transform gunEndPoint)
    {
        
        audioSource.PlayOneShot(laserSound);
             
        Vector3 fwd = gunEndPoint.TransformDirection(Vector3.forward); //forward direction
        Ray ray = new Ray(gunEndPoint.position, fwd);
        RaycastHit hit;

        Debug.DrawRay(gunEndPoint.position, ray.direction * weaponRange, Color.green, 1f);

        if (Physics.Raycast(ray, out hit, 100))
        {
            StartCoroutine(InstantiateMissle(hit, gunEndPoint));
            //StartCoroutine(shootEffectsLaser(hit));
            //Debug.Log("I've hitted : " + hit.collider.gameObject.tag);

            if (hit.collider.gameObject.tag == "Enemy")
            {
                EnemyHealthScript health = hit.collider.GetComponent<EnemyHealthScript>();
                #region Enemy
                if (health != null)
                {
                    //Debug.Log("enemy");
                    InstantiateImpactEffectEnemy(hit);
                    InstatiateExplosion(hit);
                    audioSource.PlayOneShot(EffectSoundHit());

                    CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);

                    if (health.health > 0)
                    {
                        playerMissedShot = false;

                        if (MoveUpwards.FloorNum == lastFloor) { playerMissedLastShots = false; }

                        PlayerPrefs.SetInt("totalHits", PlayerPrefs.GetInt("totalHits") + 1);
                        health.ApplyDamage(hitDamagelvl1);

                        if (health.health <= 0)
                        {
                            MoveUpwards.killConfirmed = true;
                            Manager.scoreValue += scorePoints;

                            SpecialAttack(hit); //17102019 20:36

                            killStreak++;
                            missedShotsAttemps = 0;

                            dead = true;
                            enemyDiedShootGoAhead = true;

                            if (LeftSide)
                            {
                                missedLeftShots = 0;
                                LeftShotHit = true;
                                LeftEnemyCount++;
                            }
                            else if (RightSide)
                            {
                                missedRightShots = 0;
                                RightShotHit = true;
                                RightEnemyCount++;
                            }
                        }
                    }
                }

                #endregion
            }
            else if (hit.collider.gameObject.tag == "boss")
            {
                BossAI health_boss = hit.collider.GetComponent<BossAI>();
                #region Boss
                if (MoveUpwards.FloorNum == lastFloor)
                {
                    if (LeftSide)
                    {
                        var name = hit.collider.gameObject.name;

                        if (name == bossLeft.name)
                        {
                            if (health_boss != null)
                            {
                                //Debug.Log("bossLeft");
                                InstantiateImpactEffectEnemy(hit);
                                InstatiateExplosion(hit);
                                audioSource.PlayOneShot(hitSoundOther);
                                CameraShaker.Instance.ShakeOnce(3f, 3f, .1f, 1f);

                                if (health_boss.bossHealth > 0)
                                {
                                    ///*Debug*/.Log("Boss damaged --> Shoot");
                                    health_boss.ApplyBossDamage();

                                    if (health_boss.bossHealth <= 0)
                                    {
                                        //boss dies
                                        //Debug.Log("Boss died --> Shoot");
                                        MoveUpwards.bossKillConfirmed = true;
                                        Manager.scoreValue += scorePoints;

                                        killStreak++;
                                    }
                                }
                            }
                        }
                    }               

                    if (RightSide)
                    {
                        var name = hit.collider.gameObject.name;

                        if (name == bossRight.name)
                        {
                            if (health_boss != null)
                            {
                                //Debug.Log("bossRight");
                                InstantiateImpactEffectEnemy(hit);
                                InstatiateExplosion(hit);
                                audioSource.PlayOneShot(hitSoundOther);
                                CameraShaker.Instance.ShakeOnce(3f, 3f, .1f, 1f);

                                if (health_boss.bossHealth > 0)
                                {
                                    health_boss.ApplyBossDamage();

                                    if (health_boss.bossHealth <= 0)
                                    {
                                        //boss dies
                                        MoveUpwards.bossKillConfirmed = true;
                                        Manager.scoreValue += scorePoints;

                                        killStreak++;
                                    }
                                }
                            }
                        }
                }

            }

                #endregion
            }
            else 
            {
                #region Missed Shoot
                //Debug.Log("noting --> player missed shoot");
                InstantiateImpactEffectOther(hit);
                InstatiateExplosion(hit);
                playerMissedShot = true;
                CameraShaker.Instance.ShakeOnce(1f, 1f, .08f, 2f);


                if (MoveUpwards.FloorNum == lastFloor) { playerMissedLastShots = true; }


                missedShotsAttemps++;
                valueForStars++;
                ManageScorePoints();

                PlayerPrefs.SetInt("totalMisses", PlayerPrefs.GetInt("totalMisses") + 1);

                killStreak = 0;
               

                if (LeftSide)
                {
                    missedLeftShots++;
                }
                else if (RightSide)
                {
                    missedRightShots++;
                }

                audioSource.PlayOneShot(hitSoundOther);
                #endregion
            }
           
        }
    }

    void FireTripleCanonBlast(Transform gunEndPoint1)
    {
        
        audioSource.PlayOneShot(laserSound);
        //audioSource.PlayOneShot(laserSound1);       

        Vector3 fwd = gunEndPoint1.TransformDirection(Vector3.forward); //forward direction
        Ray ray = new Ray(gunEndPoint1.position, fwd);
        RaycastHit hit;

        Debug.DrawRay(gunEndPoint1.position, ray.direction * weaponRange, Color.green, 1f);

        if (Physics.Raycast(ray, out hit, 100))
        {
            StartCoroutine(InstantiateMissle(hit, gunEndPoint1));
            //StartCoroutine(shootEffectsLaser(hit));
            //Debug.Log("I've hitted : " + hit.collider.gameObject.tag);

            if (hit.collider.gameObject.tag == "Enemy")
            {
                EnemyHealthScript health = hit.collider.GetComponent<EnemyHealthScript>();
                #region Enemy
                if (health != null)
                {
                    //Debug.Log("enemy");
                    //InstantiateImpactEffectEnemy(hit);
                    InstatiateExplosion(hit);
                    audioSource.PlayOneShot(EffectSoundHit());
                    SpecialAttack(hit);


                    if (health.health > 0)
                    {
                        playerMissedShot = false;

                        if (MoveUpwards.FloorNum == lastFloor) { playerMissedLastShots = false;
                        }
                        PlayerPrefs.SetInt("totalHits", PlayerPrefs.GetInt("totalHits",0) + 1);
                        health.ApplyDamage(hitDamagelvl1);
                        CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, .5f);

                        if (health.health <= 0)
                        {
                            MoveUpwards.killConfirmed = true;
                            Manager.scoreValue += scorePoints;

                            killStreak++;
                            missedShotsAttemps = 0;
                            dead = true;

                            if (LeftSide)
                            {
                                missedLeftShots = 0;
                                LeftShotHit = true;
                                LeftEnemyCount++;
                            }
                            else if (RightSide)
                            {
                                missedRightShots = 0;
                                RightShotHit = true;
                                RightEnemyCount++;
                            }
                        }
                    }
                }

                #endregion
            }
            else if (hit.collider.gameObject.tag == "boss")
            {
                BossAI health_boss = hit.collider.GetComponent<BossAI>();
                #region Boss
                if (MoveUpwards.FloorNum == lastFloor)
                {
                    if (LeftSide)
                    {
                        var name = hit.collider.gameObject.name;

                        if (name == bossLeft.name)
                        {
                            if (health_boss != null)
                            {
                                //Debug.Log("bossLeft");
                                InstantiateImpactEffectEnemy(hit);
                                InstatiateExplosion(hit);
                                audioSource.PlayOneShot(hitSoundEnemy);
                                CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 0.5f);

                                if (health_boss.bossHealth > 0)
                                {
                                    health_boss.ApplyBossDamage();

                                    if (health_boss.bossHealth <= 0)
                                    {
                                        //boss dies
                                        //Debug.Log("Boss died --> Shoot");
                                        MoveUpwards.bossKillConfirmed = true;
                                        Manager.scoreValue += scorePoints;

                                        killStreak++;
                                    }
                                }
                            }
                        }
                    }

                    if (RightSide)
                    {
                        var name = hit.collider.gameObject.name;

                        if (name == bossRight.name)
                        {
                            if (health_boss != null)
                            {
                                //Debug.Log("bossRight");
                                InstantiateImpactEffectEnemy(hit);
                                InstatiateExplosion(hit);
                                audioSource.PlayOneShot(hitSoundEnemy);
                                CameraShaker.Instance.ShakeOnce(4f, 4f, .2f, 0.5f);

                                if (health_boss.bossHealth > 0)
                                {
                                    health_boss.ApplyBossDamage();

                                    if (health_boss.bossHealth <= 0)
                                    {
                                        //boss dies
                                        MoveUpwards.bossKillConfirmed = true;
                                        Manager.scoreValue += scorePoints;

                                        killStreak++;
                                    }
                                }
                            }
                        }
                    }
                }
                



                #endregion
            }
            else
            {
                #region Missed Shoot
                //Debug.Log("noting");
                InstantiateImpactEffectOther(hit);
                InstatiateExplosion(hit);
                playerMissedShot = true;
                CameraShaker.Instance.ShakeOnce(2f, 2f, .13f, 0.5f);


                if (MoveUpwards.FloorNum == 5) { playerMissedLastShots = true; }


                missedShotsAttemps++;
                valueForStars++;
                ManageScorePoints();

                killStreak = 0;

                if (LeftSide)
                {
                    missedLeftShots++;
                }
                else if (RightSide)
                {
                    missedRightShots++;
                }

                audioSource.PlayOneShot(hitSoundOther);
                #endregion
            }

        }

        #region Snippet Shoot Example
        //audioSource.PlayOneShot(laserSound);
        //audioSource.PlayOneShot(laserSound1);

        //Vector3 fwd = gunEndPoint3.TransformDirection(Vector3.forward); //forward direction
        //Ray ray = new Ray(gunEndPoint3.position, fwd);
        //RaycastHit hit;

        //Debug.DrawRay(gunEndPoint3.position, ray.direction * weaponRange, Color.green, 1f);

        //if (Physics.Raycast(ray, out hit, 100))
        //{
        //    StartCoroutine(InstantiateMissle(hit, gunEndPoint3));
        //    //StartCoroutine(shootEffectsLaser(hit));
        //    Debug.Log("I've hitted : " + hit.collider.name);

        //    EnemyHealthScript health = hit.collider.GetComponent<EnemyHealthScript>();

        //    if (health != null)
        //    {
        //        InstantiateImpactEffectEnemy(hit);
        //        InstatiateExplosion(hit);
        //        audioSource.PlayOneShot(hitSoundEnemy);

        //        if (health.health > 0)
        //        {
        //            playerMissedShot = false;
        //            health.ApplyDamage(hitDamagelvl1);

        //            if (health.health <= 0)
        //            {
        //                MoveUpwards.killConfirmed = true;
        //                Manager.scoreValue += scorePoints;

        //                killStreak++;
        //                missedShotsAttemps = 0;

        //                if (LeftSide)
        //                {
        //                    missedLeftShots = 0;
        //                    LeftShotHit = true;
        //                    LeftEnemyCount++;
        //                }
        //                else if (RightSide)
        //                {
        //                    missedRightShots = 0;
        //                    RightShotHit = true;
        //                    RightEnemyCount++;
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {

        //        InstantiateImpactEffectOther(hit);
        //        InstatiateExplosion(hit);

        //        playerMissedShot = true;

        //        missedShotsAttemps++;
        //        valueForStars++;
        //        ManageScorePoints();

        //        killStreak = 0;

        //        if (LeftSide)
        //        {
        //            missedLeftShots++;
        //        }
        //        else if (RightSide)
        //        {
        //            missedRightShots++;
        //        }

        //        audioSource.PlayOneShot(hitSoundOther);
        //    }
        //}
        #endregion
    }

    void FireTripleCanonBlast1(Transform gunEndPoint2)
    {

        audioSource.PlayOneShot(laserSound);

        Vector3 fwd = gunEndPoint2.TransformDirection(Vector3.forward); //forward direction
        Ray ray = new Ray(gunEndPoint2.position, fwd);
        RaycastHit hit;

        Debug.DrawRay(gunEndPoint2.position, ray.direction * weaponRange, Color.green, 1f);
        CameraShaker.Instance.ShakeOnce(1f, 1f, .1f, 0.5f);

        if (Physics.Raycast(ray, out hit, 100))
        {
            StartCoroutine(InstantiateMissle(hit, gunEndPoint2));
            //StartCoroutine(shootEffectsLaser(hit));
            //Debug.Log("I've hitted : " + hit.collider.name);

            if (hit.collider.gameObject.tag == "Enemy")
            {
                EnemyHealthScript health = hit.collider.GetComponent<EnemyHealthScript>();
                #region Enemy
                if (health != null)
                {
                    //Debug.Log("enemy");

                    if (health.health > 0)
                    {
   
                        PlayerPrefs.SetInt("totalHits", PlayerPrefs.GetInt("totalHits", 0) + 1);
                        health.ApplyDamage(hitDamageTripleTwo);

                        if (health.health <= 0)
                        {
                            MoveUpwards.killConfirmed = true;
                            Manager.scoreValue += scorePoints;

                            killStreak++;
                            missedShotsAttemps = 0;
                            dead = true;

                            if (LeftSide)
                            {
                                missedLeftShots = 0;
                                LeftShotHit = true;
                                LeftEnemyCount++;
                            }
                            else if (RightSide)
                            {
                                missedRightShots = 0;
                                RightShotHit = true;
                                RightEnemyCount++;
                            }
                        }
                    }
                }
                #endregion
            }
        }
    }
    void FireTripleCanonBlast2(Transform gunEndPoint3)
    {
        audioSource.PlayOneShot(laserSound);

        Vector3 fwd = gunEndPoint1.TransformDirection(Vector3.forward); //forward direction
        Ray ray = new Ray(gunEndPoint1.position, fwd);
        RaycastHit hit;

        Debug.DrawRay(gunEndPoint1.position, ray.direction * weaponRange, Color.green, 1f);
        CameraShaker.Instance.ShakeOnce(1f, 1f, .1f, 0.5f);

        if (Physics.Raycast(ray, out hit, 100))
        {
            StartCoroutine(InstantiateMissle(hit, gunEndPoint1));
            //StartCoroutine(shootEffectsLaser(hit));
            //Debug.Log("I've hitted : " + hit.collider.name);

            if (hit.collider.gameObject.tag == "Enemy")
            {
                EnemyHealthScript health = hit.collider.GetComponent<EnemyHealthScript>();
                #region Enemy
                if (health != null)
                {
                    //Debug.Log("enemy");

                    if (health.health > 0)
                    {

                        PlayerPrefs.SetInt("totalHits", PlayerPrefs.GetInt("totalHits", 0) + 1);
                        health.ApplyDamage(hitDamageTripleThree);

                        if (health.health <= 0)
                        {
                            MoveUpwards.killConfirmed = true;
                            Manager.scoreValue += scorePoints;

                            killStreak++;
                            missedShotsAttemps = 0;
                            dead = true;

                            if (LeftSide)
                            {
                                missedLeftShots = 0;
                                LeftShotHit = true;
                                LeftEnemyCount++;
                            }
                            else if (RightSide)
                            {
                                missedRightShots = 0;
                                RightShotHit = true;
                                RightEnemyCount++;
                            }
                        }
                    }
                }
                #endregion
            }

        }
    }

    void FireSuperSonicCanonBlast(Transform gunEndPoint4)
    {
       
        audioSource.PlayOneShot(ripple.deepHIT_SuperSonic);            
        audioSource.PlayOneShot(laserSound);
        //audioSource.PlayOneShot(laserSound1);
        
        Vector3 fwd = gunEndPoint4.TransformDirection(Vector3.forward); //forward direction
        Ray ray = new Ray(gunEndPoint4.position, fwd);
        RaycastHit hit;

        Debug.DrawRay(gunEndPoint4.position, ray.direction * weaponRange, Color.green, 1f);

        if (Physics.Raycast(ray, out hit, 100))
        {
            StartCoroutine(InstantiateMissle(hit, gunEndPoint4));
            //StartCoroutine(shootEffectsLaser(hit));
            //Debug.Log("I've hitted : " + hit.collider.gameObject.tag);

            if (hit.collider.gameObject.tag == "Enemy")
            {
                EnemyHealthScript health = hit.collider.GetComponent<EnemyHealthScript>();
                #region Enemy
                if (health != null)
                {
                    //Debug.Log("enemy");
                    InstantiateImpactEffectEnemy(hit);
                    InstatiateExplosion(hit);
                    if (diffSoundEffect)
                    {
                        audioSource.PlayOneShot(EffectSoundHit());
                        diffSoundEffect = false;
                    }

                    CameraShaker.Instance.ShakeOnce(5f, 5f, .15f, 1.3f);
                    SpecialAttack(hit);

                    if (health.health > 0)
                    {
                        playerMissedShot = false;

                        if (MoveUpwards.FloorNum == lastFloor) { playerMissedLastShots = false; }

                        PlayerPrefs.SetInt("totalHits", PlayerPrefs.GetInt("totalHits", 0) + 1);
                        health.ApplyDamage(hitDamagelvl1);

                        if (health.health <= 0)
                        {
                            MoveUpwards.killConfirmed = true;
                            Manager.scoreValue += scorePoints;

                            killStreak++;
                            missedShotsAttemps = 0;
                            dead = true;

                            if (LeftSide)
                            {
                                missedLeftShots = 0;
                                LeftShotHit = true;
                                LeftEnemyCount++;
                            }
                            else if (RightSide)
                            {
                                missedRightShots = 0;
                                RightShotHit = true;
                                RightEnemyCount++;
                            }
                        }
                    }
                }

                #endregion
            }
            else if (hit.collider.gameObject.tag == "boss")
            {
                BossAI health_boss = hit.collider.GetComponent<BossAI>();
                #region Boss
                if(MoveUpwards.FloorNum == lastFloor)
                {
                    if (LeftSide)
                    {
                        var name = hit.collider.gameObject.name;

                        if (name == bossLeft.name)
                        {
                            if (health_boss != null)
                            {
                                //Debug.Log("bossLeft");
                                InstantiateImpactEffectEnemy(hit);
                                InstatiateExplosion(hit);
                                audioSource.PlayOneShot(hitSoundEnemy);
                                CameraShaker.Instance.ShakeOnce(6f, 6f, .1f, 1.2f);

                                if (health_boss.bossHealth > 0)
                                {
                                    health_boss.ApplyBossDamage();

                                    if (health_boss.bossHealth <= 0)
                                    {
                                        //boss dies
                                        //Debug.Log("Boss died --> Shoot");
                                        MoveUpwards.bossKillConfirmed = true;
                                        Manager.scoreValue += scorePoints;

                                        killStreak++;
                                    }
                                }
                            }
                        }
                    }

                    if (RightSide)
                    {
                        var name = hit.collider.gameObject.name;

                        if (name == bossRight.name)
                        {
                            if (health_boss != null)
                            {
                                ///*Debug*/.Log("bossRight");
                                InstantiateImpactEffectEnemy(hit);
                                InstatiateExplosion(hit);
                                audioSource.PlayOneShot(hitSoundEnemy);
                                CameraShaker.Instance.ShakeOnce(6f, 6f, .1f, 1.2f);

                                if (health_boss.bossHealth > 0)
                                {
                                    health_boss.ApplyBossDamage();

                                    if (health_boss.bossHealth <= 0)
                                    {
                                        //boss dies
                                        MoveUpwards.bossKillConfirmed = true;
                                        Manager.scoreValue += scorePoints;

                                        killStreak++;
                                    }
                                }
                            }
                        }
                    }
                }
             



                #endregion
            }
            else
            {
                #region Missed Shoot
                //Debug./*Log*/("noting");
                InstantiateImpactEffectOther(hit);
                InstatiateExplosion(hit);
                playerMissedShot = true;
                CameraShaker.Instance.ShakeOnce(6f, 6f, .1f, 1.2f);


                if (MoveUpwards.FloorNum == 5) { playerMissedLastShots = true; }


                missedShotsAttemps++;
                valueForStars++;
                ManageScorePoints();

                killStreak = 0;

                if (LeftSide)
                {
                    missedLeftShots++;
                }
                else if (RightSide)
                {
                    missedRightShots++;
                }

                audioSource.PlayOneShot(hitSoundOther);
                #endregion
            }
        }
    }


    private void Laser(RaycastHit hit)
    {
        UseLaser = true;
        laserLine.SetPosition(0, gunEndPoint.position); //start position of laser
        laserLine.SetPosition(1, hit.point);
    }

    private string setImpactEffect_Color()
    {
        string color = "";

        //RED
        if (PlayerPrefs.GetInt("CurrentLaser", 0) == 0) { color = "RED"; }

        //GREEN
        if (PlayerPrefs.GetInt("CurrentLaser", 0) == 1) { color = "GREEN"; }

        //BLUE
        if (PlayerPrefs.GetInt("CurrentLaser", 0) == 2) { color = "BLUE"; }

        //PURPLE
        if (PlayerPrefs.GetInt("CurrentLaser", 0) == 3) { color = "PURPLE"; }

        //GOLDEN
        if (PlayerPrefs.GetInt("CurrentLaser", 0) == 4) { color = "GOLDEN"; }

        return color;
    }

    public GameObject IMPACT_EFFECT()
    {

        if(setImpactEffect_Color() == "RED") { color_effect_to_use = impactEffectEnemy_Red; }
        if (setImpactEffect_Color() == "GREEN") { color_effect_to_use = impactEffectEnemy_Green; }
        if (setImpactEffect_Color() == "BLUE") { color_effect_to_use = impactEffectEnemy_Blue; }

        if (setImpactEffect_Color() == "PURPLE") { color_effect_to_use = impactEffectEnemy_Purple; }
        if (setImpactEffect_Color() == "GOLDEN") { color_effect_to_use = impactEffectEnemy_Golden; }

        //Debug.Log("effect color: " + setImpactEffect_Color());
        return color_effect_to_use;
    }

    private void SpawnPurpleEffect(RaycastHit hit)
    {
        GameObject go = Instantiate(ripple.SkullEffect_Purple, hit.point, Quaternion.identity);
        Destroy(go, 3f);
    }

    private void SpawnGreenEffect(RaycastHit hit)
    {
        GameObject go = Instantiate(ripple.Virus_GreenDeath, hit.point, Quaternion.identity);
        Destroy(go, 3f);
    }

    private void SpawnBlueEffect(RaycastHit hit)
    {
        GameObject go = Instantiate(ripple.ElectricEffect_Blue, hit.point, Quaternion.identity);
        Destroy(go, 3f);
    }

    private void SpawnRedEffect(RaycastHit hit)
    {
        GameObject go = Instantiate(ripple.SkullExplosion_WhiteRed, hit.point, Quaternion.identity);
        Destroy(go, 3f);
    }

    private void SpawnGoldenEffect(RaycastHit hit)
    {
        GameObject go = Instantiate(ripple.MagicHit_Golden, hit.point, Quaternion.identity);
        Destroy(go, 3f);
    }

    private void CheckIfPurple(RaycastHit hit)
    {
        if(setImpactEffect_Color() == "PURPLE")
        {
            SpawnPurpleEffect(hit);
        }
    }

    private void CheckIfGreen(RaycastHit hit)
    {
        if (setImpactEffect_Color() == "GREEN")
        {
            SpawnGreenEffect(hit);
        }
    }

    private void CheckIfBlue(RaycastHit hit)
    {
        if (setImpactEffect_Color() == "BLUE")
        {
            SpawnBlueEffect(hit);
        }
    }

    private void CheckIfRed(RaycastHit hit)
    {
        if (setImpactEffect_Color() == "RED")
        {
            SpawnRedEffect(hit);
        }
    }

    private void CheckIfGolden(RaycastHit hit)
    {

        if(setImpactEffect_Color() == "GOLDEN")
        {
            SpawnGoldenEffect(hit);
        }
    } 

    private void SpecialAttack(RaycastHit hit)
    {
        CheckIfRed(hit);
        CheckIfGreen(hit);
        CheckIfBlue(hit);
        CheckIfPurple(hit);
        CheckIfGolden(hit);

    }

    private AudioClip EffectSoundHit()
    {

        if(setImpactEffect_Color() == "BLUE")
        {
            aClip_SoundHIT = ripple.electricSpark_Blue;           
        }
        else if(setImpactEffect_Color() == "PURPLE" )
        {
            aClip_SoundHIT = ripple.spellSound_Purple;
        }
        else { aClip_SoundHIT = hitSoundEnemy; }

        //Debug.Log(aClip_SoundHIT + "  sound HIT");
        return aClip_SoundHIT;
    }

    private void setOutlineColor()
    {
        if(setImpactEffect_Color() == "RED")
        {
            Color RED = new Color(176, 0, 0, 255);
            outline_color.color = new Color(RED.r, RED.g, RED.b);
            ///*Debug*/.Log("RED");

        }
        else if(setImpactEffect_Color() == "GREEN")
        {
            Color GREEN = new Color(0,176,0,255);
            outline_color.color = new Color(GREEN.r, GREEN.g, GREEN.b);
            //Debug.Log("GREEN");
        }
        else if (setImpactEffect_Color() == "BLUE")
        {
            Color BLUE = new Color(0, 80, 176, 255);
            outline_color.color = new Color(BLUE.r, BLUE.g, BLUE.b);
            //Debug.Log("BLUE");
        }

        else if (setImpactEffect_Color() == "PURPLE")
        {
            Color PURPLE = new Color(134, 0, 176, 255);
            outline_color.color = new Color(PURPLE.r, PURPLE.g, PURPLE.b);
            //Debug.Log("PURPLE");
        }
        else if (setImpactEffect_Color() == "GOLDEN")
        {
            Color GOLD = new Color(176, 174, 0, 255);
            outline_color.color = new Color(GOLD.r, GOLD.g, GOLD.b);
            //Debug.Log("GOLD");
        }
    }

    private IEnumerator SpawnSuperSonicEffect(RaycastHit hit)
    {
        float waitTime = .5f;
        yield return new WaitForSeconds(waitTime);
        GameObject go = Instantiate(ripple.superSonic_EffectBoom, hit.point, Quaternion.identity);
        Destroy(go, 3f);
    }

    private bool SuperSonicBlast_use()
    {
        int superSonicIndex = 2;

        if(PlayerPrefs.GetInt("currentWeaponIndex", 0) == superSonicIndex)
        {
            return true;
        }
        else { return false; }
    }

    private void SetSuperSonicEffect(RaycastHit hit)
    {
        if (SuperSonicBlast_use())
        {
            StartCoroutine(SpawnSuperSonicEffect(hit));
        }
    }

    private void InstantiateImpactEffectEnemy(RaycastHit hitInfo)
    {

        GameObject ImpactGO = Instantiate(IMPACT_EFFECT(), hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
        Destroy(ImpactGO, 4f);
    }

    private void InstantiateImpactEffectBoss(RaycastHit hitInfo)
    {
        GameObject ImpactGO = Instantiate(impactEffectBoss, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
        Destroy(ImpactGO, 4f);
    }

    private void InstantiateImpactEffectOther(RaycastHit hitInfo)
    {
        GameObject ImpactGO1 = Instantiate(impactEffectOther, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
        Destroy(ImpactGO1, 4f);
    }

    private GameObject eXplosion;
    private GameObject explosionToUse()
    {
        if(PlayerPrefs.GetInt("currentWeaponIndex") == 2)
        {
            eXplosion = ripple.superSonic_EffectBoom;
        }
        else { eXplosion = impactEffectExplosion; }

        return eXplosion;
    }

    private void InstatiateExplosion(RaycastHit hitInfo)
    {
        GameObject ImpactGO2 = Instantiate(explosionToUse(), hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
        Destroy(ImpactGO2, 4f);
    }

    private void StopCanonAnime() { anime.speed = 0; }
    private void StartCanonAnime() { anime.speed = 1; }

    private IEnumerator shootEffectsLaser(RaycastHit hit)
    {
        StopCanonAnime();
        Laser(hit);
        yield return new WaitForSeconds(1f);
        UseLaser = false;
        StartCanonAnime();
    }

    private IEnumerator InstantiateMissle(RaycastHit hitInfo, Transform gunEndPointPosition)
    {
        StopCanonAnime();
        GameObject missle = Instantiate(laserToUse, gunEndPointPosition.position, gunEndPointPosition.rotation) as GameObject;
        Destroy(missle, 2f);
        yield return new WaitForSeconds(1f);
        StartCanonAnime();

    }

    private void CheckForDamageToUse()
    {
        //if (canon.tag == "canonlv2")
        //{
        //    damageToUse = hitDamagelvl2;
        //}
        //else if (canon.tag == "canon")
        //{
        //    damageToUse = hitDamagelvl1;
        //}
    }

    public void setDiffSoundEffect()
    {
        diffSoundEffect = false;
    }

    public void SetLastFloor()
    {
        if (SceneManager.GetActiveScene().name == "Level1") { lastFloor = 5; }
        else if (SceneManager.GetActiveScene().name == "Level2") { lastFloor = 7; }
        else if (SceneManager.GetActiveScene().name == "Level3") { lastFloor = 9; }
        else if (SceneManager.GetActiveScene().name == "Level4") { lastFloor = 12; }
        else if (SceneManager.GetActiveScene().name == "Level5") { lastFloor = 15; }
        else if (SceneManager.GetActiveScene().name == "Level6") { lastFloor = 17; }
        else if (SceneManager.GetActiveScene().name == "Level7") { lastFloor = 20; }
        else if (SceneManager.GetActiveScene().name == "Level8") { lastFloor = 21; }
        else if (SceneManager.GetActiveScene().name == "Level9") { lastFloor = 23; }
        else if (SceneManager.GetActiveScene().name == "Level10") { lastFloor = 26; }
        else if (SceneManager.GetActiveScene().name == "Level11") { lastFloor = 29; }
        else if (SceneManager.GetActiveScene().name == "Level12") { lastFloor = 32; }
        else if (SceneManager.GetActiveScene().name == "Level13") { lastFloor = 35; }
        else if (SceneManager.GetActiveScene().name == "Level14") { lastFloor = 38; }
        else if (SceneManager.GetActiveScene().name == "Level15") { lastFloor = 39; }
        else if (SceneManager.GetActiveScene().name == "Level16") { lastFloor = 40; }
        else if (SceneManager.GetActiveScene().name == "Level17") { lastFloor = 41; }
        else if (SceneManager.GetActiveScene().name == "Level18") { lastFloor = 43; }
        else if (SceneManager.GetActiveScene().name == "Level19") { lastFloor = 45; }
        else if (SceneManager.GetActiveScene().name == "Level20") { lastFloor = 46; }
        else if (SceneManager.GetActiveScene().name == "Level21") { lastFloor = 47; }

        //Debug.Log("last floor: " + lastFloor);
    }

    public void SetShootAttempts()
    {
        missedLeftShots = 0;
        missedRightShots = 0;
        missedShotsAttemps = 0;
    }

    public void SetLaserBeaam()
    {
        if (PlayerPrefs.GetInt("CurrentLaser") == 0) { laserToUse = laserBeaaamRed; }
        else if (PlayerPrefs.GetInt("CurrentLaser") == 1) { laserToUse = laserBeaaamGreen; }
        else if (PlayerPrefs.GetInt("CurrentLaser") == 2) { laserToUse = laserBeaaamBlue; }
        else if (PlayerPrefs.GetInt("CurrentLaser") == 3) { laserToUse = laserBeaaamPurple; }
        else if (PlayerPrefs.GetInt("CurrentLaser") == 4) { laserToUse = laserBeaaamGold; }

    }

    public static string currentWeapon;

    private void SetMissileLauncher()
    {
        if (PlayerPrefs.GetInt("currentWeaponIndex") == 0)
        {
            missileLauncherToUse = atomicMissileLauncher;
            atomicMissileLauncher.SetActive(true);
            currentWeapon = "atomicLauncher";

        }
        else { atomicMissileLauncher.SetActive(false); }

        if (PlayerPrefs.GetInt("currentWeaponIndex") == 1)
        {

            missileLauncherToUse = tripleThreadMissileLauncher;
            tripleThreadMissileLauncher.SetActive(true);
            currentWeapon = "TripleLauncher";

        }
        else { tripleThreadMissileLauncher.SetActive(false); }

        if (PlayerPrefs.GetInt("currentWeaponIndex") == 2)
        {

            missileLauncherToUse = superSonicMissileLauncher;
            superSonicMissileLauncher.SetActive(true);
            currentWeapon = "SonicLauncher";

        }
        else { superSonicMissileLauncher.SetActive(false); }

    }

    private void SetCharacter()
    {
        if (PlayerPrefs.GetInt("characterIndex", 0) == 0)
        {
            character_ToUse = character_SoldierBoy;
            character_SoldierBoy.SetActive(true);

        }
        else { character_SoldierBoy.SetActive(false); }

        if (PlayerPrefs.GetInt("characterIndex", 0) == 1)
        {
            character_ToUse = character_Cyborg;
            character_Cyborg.SetActive(true);

        }
        else { character_Cyborg.SetActive(false); }

        if (PlayerPrefs.GetInt("characterIndex", 0) == 2)
        {
            character_ToUse = character_ChanLee;
            character_ChanLee.SetActive(true);

        }
        else { character_ChanLee.SetActive(false); }

        //Debug.Log(character_ToUse.name + " <-- using character");
    }

    public string NameOFKillStreak()
    {
        if(killStreak == 1) { killStreakName = "FIRST BLOOD!"; }
            else if(killStreak == 2) { killStreakName = "DOUBLE KILL!"; }
                else if(killStreak == 3) { killStreakName = "TRIPLE KILL!"; }
                    else if (killStreak == 4) { killStreakName = "ULTRA KILL!"; }
                        else if (killStreak == 5) { killStreakName = "RAMPAGE!"; }
                            else if (killStreak == 6) { killStreakName = "KILLING SPREE!"; }
                                else if (killStreak == 7) { killStreakName = "DOMINATING!"; }
                                    else if (killStreak == 8) { killStreakName = "MEGA KILL!"; }
                                        else if (killStreak == 9) { killStreakName = "UNSTOPABBLE!"; }
                                             else if (killStreak == 10) { killStreakName = "WICKED SICK!"; }
                                                 else if (killStreak == 11) { killStreakName = "MONSTER KILL!"; }
                                                    else if (killStreak == 12) { killStreakName = "GODLIKE!"; }
                                                        else if (killStreak == 13) { killStreakName = "BEYOND GODLIKE!"; }
                                                            else if (killStreak == 14) { killStreakName = "BOYAKAAA!"; }
                                                                else if (killStreak == 15) { killStreakName = "THIS IS MADNESS!"; }
                                                                    else if (killStreak == 16) { killStreakName = "CRAZY MOTHER F*****!"; }
                                                                        else if (killStreak >= 17) { killStreakName = "SAY WHAT..."; }
        return killStreakName;
    }

    public void SetKillStreakName()
    {
        killStreakText.text = NameOFKillStreak();
    }

    public void DisplayKillStreakAnime()
    {
        if (MoveUpwards.killConfirmed)
        {
            killStreakAnime = killStreakText.GetComponent<Animator>();
            killStreakAnime.SetTrigger("displayKillStreak");
        }
    }

    private float fill_value = 0;
    private float fill_Startvalue = 0;
    private float fill_Time = 0;

    private void Begining_FillAmount()
    {
        outline_color.fillAmount = fill_Startvalue;
    }

    private void ManageOutLineFill_Increase()
    {
        fill_Time += Time.deltaTime;
        outline_color.fillAmount += (fill_Time / 18);
        if (fill_Time >= 1)
        {
            fill_Time = 1;
        }
    }

}
