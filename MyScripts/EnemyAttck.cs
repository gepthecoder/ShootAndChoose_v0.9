using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttck : MonoBehaviour
{
    public static bool _enemyAboutToHitBase;

    private float attackRefreshRate = 3.5f;

    private GameObject player;
    private PlayerHealth playerHealth;

    public bool enemyIsAlive;
    private bool playerIsAlive;

    public int AttackDamage = 1;
    private bool moveCloser;
    private float distance;

    private float attackDistance = 0.1f;

    private float attackTimer;

    private Animator anime;
    private EnemyHealthScript health;

    public bool inRangeToAttack;

    private Vector3 defaultPosition;
    private Quaternion defaultRotation;

    private float DistanceToMove = 1.3f;

    private float xPosition;
    private Vector3 XpositionX;

    private GameObject potentialEnemyTarget;

    private Vector3 a;
    private Vector3 b;

    public float moveSpeedAnime;
    public float Distance;

    private AudioSource audioSource;
    public AudioClip smashSound;
    //public AudioClip hoopSound;

    public int onlyOnce = 1;

    private int enemyStrenght = 1;

    private static string attckFromWhere;
    public static string AttckFromWhere { get { return attckFromWhere; } set { attckFromWhere = value; } }

    public static EnemyAttck enemyAttck { get; set; }

    public bool canMoveEnemyWithDelay;

    public AudioClip jump_sound;

    public void Jump()
    {
        audioSource.PlayOneShot(jump_sound);
    }

    void Awake()
    {
        anime = GetComponent<Animator>();
        health = GetComponent<EnemyHealthScript>();
        audioSource = GetComponent<AudioSource>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

        SetDefaultPosAndRot();
        xPosition = transform.position.x + DistanceToMove;

        moveSpeedAnime = 0;
        //a = player.transform.position;

        enemyAttck = this;
        canMoveEnemyWithDelay = false;

    }

    void Start()
    {
        StartCoroutine(ActivateMovementOfEnemies(2f));
    }


    private IEnumerator ActivateMovementOfEnemies(float delay)
    {
        yield return new WaitForSeconds(delay);
        canMoveEnemyWithDelay = true;
    }

    void Update()
    {
        CheckEnemyHealth();
        CheckPlayersHealth();

        if (enemyIsAlive)
        {
            CheckAttack();

            attackTimer += Time.deltaTime;

            if (attackTimer >= attackRefreshRate)
                if (playerIsAlive)
                    if (inRangeToAttack) {
                        Debug.Log("Attack happend");
                        AttackPlayer();
                    }
        }

        if (Shoot.playerMissedShot)
        {
            if (enemyIsAlive && playerIsAlive && canMoveEnemyWithDelay)
                moveCloser = true;           
        }

        if (moveCloser)
        {           
            //distance = (CheckLeftRight() == "left") ? DistanceToMove : -DistanceToMove;
            if(CheckLeftRight() == "left")
            {
                if (Shoot.LeftEnemyCount == 1)
                {
                    distance = -DistanceToMove;
                }
                else { distance = DistanceToMove; }
            }
            else
            {
                if(Shoot.RightEnemyCount == 1)
                {
                    distance = DistanceToMove;
                }
                else { distance = -DistanceToMove; }
            }
          

            if (potentialEnemy() != null)
            {
                Vector3 xPos = new Vector3(potentialEnemy().transform.position.x + distance, potentialEnemy().transform.position.y, potentialEnemy().transform.position.z);

                StartCoroutine(_moveENEMY(potentialEnemy(), xPos, 2f));
                Debug.Log("move enemy move!! " + potentialEnemy().gameObject.name + " Distance:  " + distance);
                Animator jumpAnime = potentialEnemy().GetComponent<Animator>();             

                if (jumpAnime != null)
                {
                    jumpAnime.SetFloat("moveSpeed", 1);
                }
                moveCloser = false;
                Shoot.playerMissedShot = false;
            }   

           

        }

        if (_enemyAboutToHitBase)
        {
            //set new target
            float dis = 0f;
            if (potentialEnemy().transform.position.x > 0) { dis = -2.1f; } else { dis = +2.1f; }
            Vector3 posX = new Vector3(potentialEnemy().transform.position.x + dis, potentialEnemy().transform.position.y, potentialEnemy().transform.position.z);
            StartCoroutine(_moveENEMY(potentialEnemy(), posX, 2f));
            _enemyAboutToHitBase = false;
            Debug.Log("Enemy hits the base!! " + potentialEnemy().name
                                               + " distance: " + dis);


        }

    }

    private string CheckLeftRight()
    {
        string side = "";

        if(Shoot.LeftSide == true)
        {
            side += "left";
        }
        else if (Shoot.RightSide == true) { side += "right"; }

        return side;
    }

    private void RotateToPlayer()
    {
        Quaternion from = transform.rotation;
        Quaternion to = new Quaternion(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z, player.transform.rotation.w);

        transform.rotation = Quaternion.RotateTowards(from, to, 3f);
    }

    private void ReturnToDefaultPosition()
    {
        transform.position = Vector3.Lerp(transform.position, defaultPosition, 3f);
    }

    private void SetMoveSpeedForAnime()
    {
        if (Shoot.playerMissedShot)
        {
            moveSpeedAnime = 1;
        }
        else { moveSpeedAnime = 0; }
    }

    private void SetDefaultPosAndRot()
    {
        defaultPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        defaultRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
    }



    private void CheckAttack()
    {
        if (potentialEnemy() != null)
        {
            Distance = Vector3.Distance(potentialEnemy().transform.position, player.transform.position);
            
            if (MoveUpwards.FloorNum == 1)
            {              
                if (Distance <= 0.7f) 
                {
                    inRangeToAttack = true;
                }
                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 2)
            {
                if (Distance <= 1.6f) { inRangeToAttack = true; }
                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 3)
            {
                if (Distance <= 3.5f) { inRangeToAttack = true; }
                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 4)
            {
                if (Distance <= 5.4f) { inRangeToAttack = true; }
                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 5)
            {
                if (Distance <= 7.4f) { inRangeToAttack = true; }
                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 6)
            {
                if (Distance <= 9.37f) { inRangeToAttack = true; }
                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 7)
            {
                if (Distance <= 11.40f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 11.32f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }
                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 8)
            {
                if (Distance <= 13.41f) { inRangeToAttack = true; }
                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 9)
            {
                if (Distance <= 15.40f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 15.45f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }
                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 10)
            {
                if (Distance <= 17.385f) { inRangeToAttack = true; }
                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 11)
            {
                if (Distance <= 19.41f) { inRangeToAttack = true; }
                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 12)
            {
                if (Distance <= 21.375f) { inRangeToAttack = true; }
                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 13)
            {
                if (Distance <= 23.368f) { inRangeToAttack = true; }
                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 14)
            {
                if (Distance <= 25.33f && potentialEnemy().name.Contains("left")) {
                    inRangeToAttack = true;
                    Debug.Log("LEFT ATTACKED WITHIN RANGE");
                }
                else if (Distance <= 25.376f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; } 
                else { inRangeToAttack = false; }
                
            }
            else if (MoveUpwards.FloorNum == 15)
            {
                if (Distance <= 27.41f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 27.376f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 16)
            {
                if (Distance <= 29.374f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 29.38f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 17)
            {
                if (Distance <= 31.372f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 31.399f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 18)
            {
                if (Distance <= 33.4f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 33.39f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 19)
            {
                if (Distance <= 35.34f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 35.35f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 20)
            {
                if (Distance <= 37.345f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 37.39f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 21)
            {
                if (Distance <= 39.33f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 39.42f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 22)
            {
                if (Distance <= 41.38f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 41.43f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }

            }
            else if (MoveUpwards.FloorNum == 23)
            {
                if (Distance <= 41.23f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 38.19f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 24)
            {
                if (Distance <= 42.23f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 40.19f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 25)
            {
                if (Distance <= 47.16f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 47.16f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 26)
            {
                if (Distance <= 49.18f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 49.17f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 27)
            {
                if (Distance <= 51.19f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 51.18f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 28)
            {
                if (Distance <= 52.85f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 54.745f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }
                
                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 29)
            {
                if (Distance <= 56.84f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 54.75f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 30)
            {
                if (Distance <= 56.83f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 56.67f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 31)
            {
                if (Distance <= 58.84f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 58.68f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 32)
            {
                if (Distance <= 60.9f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 60f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 33)
            {
                if (Distance <= 62.78f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 62.19f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 34)
            {
                if (Distance <= 64.76f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 64.19f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 35)
            {
                if (Distance <= 66.80f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 66.75f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 36)
            {
                if (Distance <= 68.83f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 68.815f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 37)
            {
                if (Distance <= 70.84f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 70.805f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 38)
            {
                if (Distance <= 72.8f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 72.19f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 39)
            {
                if (Distance <= 74.70f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 74.70f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 40)
            {
                if (Distance <= 76.74f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 76.695f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 41)
            {
                if (Distance <= 78.735f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 78.72f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 42)
            {
                if (Distance <= 80.725f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 80.73f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 43)
            {
                if (Distance <= 82.84f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 83f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 44)
            {
                if (Distance <= 85.01f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 85.11f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 45)
            {
                if (Distance <= 87.195f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 87.195f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 46)
            {
                if (Distance <= 89.265f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 89.27f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }
            }
            else if (MoveUpwards.FloorNum == 47)
            {
                if (Distance <= 91.16f && potentialEnemy().name.Contains("left")) { inRangeToAttack = true; }
                else if (Distance <= 91.17f && potentialEnemy().name.Contains("right")) { inRangeToAttack = true; }

                else { inRangeToAttack = false; }
            }
        }
       
    }

    private void CheckPlayersHealth()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
        if(playerHealth.playerHealth <= 0)
        {
            playerIsAlive = false;
        } else { playerIsAlive = true; }
    }

    private void TakeDamageToPlayer(int damage)
    {
        if (!playerIsAlive) { return; }

        PlayerHealth.Instance.playerHealth -= damage;
    }

    
    private void AttackPlayer()
    {
     
        if(gameObject.name == potentialEnemy().name)
        {
            attackTimer = 0;
            anime = potentialEnemy().GetComponent<Animator>();
            string name = potentialEnemy().name;

            Debug.Log("before attack:   " + playerHealth.playerHealth + "     enemies Dead: " + Shoot.enemiesDied + " name: " + name);
            playerHealth.TakeDamage(AttackDamage, enemyStrenght);
            Debug.Log("after attack:   " + playerHealth.playerHealth);

            anime.SetTrigger("Attack");
            audioSource = potentialEnemy().GetComponent<AudioSource>();
            if(audioSource != null)
                audioSource.PlayOneShot(smashSound);


            StartCoroutine(goBack(potentialEnemy()));

            string side = CheckLeftRight();
            attckFromWhere = side;
        }    
    
    }

    

    private IEnumerator goBack(GameObject enemy) {

        yield return new WaitForSeconds(2f);

        if (enemy.name.Contains(MoveUpwards.FloorNum.ToString()))
        {
            enemy.GetComponent<Animator>().SetFloat("moveSpeed", 1);

            Debug.Log("GO BACK");
            if (attckFromWhere == "left" && Shoot.LeftEnemyCount == 0) { XpositionX = new Vector3(enemy.transform.position.x - DistanceToMove, enemy.transform.position.y, enemy.transform.position.z); }
            else if (attckFromWhere == "right" && Shoot.RightEnemyCount == 0) { XpositionX = new Vector3(enemy.transform.position.x + DistanceToMove, enemy.transform.position.y, enemy.transform.position.z); }
            Debug.Log("GO BACK --> " + XpositionX);
            if(XpositionX == Vector3.zero)
            {
                XpositionX = new Vector3(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z);
                Debug.Log("NEW POSITION --> " + XpositionX);

            }

            StartCoroutine(_moveENEMY(enemy, XpositionX, 2f));
        }
        
       
    }

    private void RotateEnemy(float x)
    {
        //default 110 to 90
        if (x == 0)
        {
            Quaternion from = transform.rotation;
            Quaternion to = new Quaternion(0, 90f, 0, 3f);
            transform.rotation = Quaternion.RotateTowards(from, to, 2f);
        }

        // 110 to 90
        else if (x == 1)
        {
            Quaternion from = transform.rotation;
            Quaternion to = new Quaternion(0, 110f, 0, 3f);
            transform.rotation = Quaternion.RotateTowards(from, to, 2f);
        }
    }

    private void MoveEnemyForward()
    {
        //RotateEnemy(0);
        xPosition = transform.position.x;
        Vector3 b = new Vector3(xPosition, transform.position.y, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, b, 2f);

        anime.SetTrigger("MoveForward");
    }

    public GameObject potentialEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject enemy in enemies)
        {
            if(CheckLeftRight() == "left")
            {
                if (enemy.name.Contains(MoveUpwards.FloorNum.ToString() + "left"))
                {
                    if(enemy.name == "Cactus" + MoveUpwards.FloorNum.ToString() + "left")
                    {
                        if (enemy != null)
                            potentialEnemyTarget = enemy;
                    }                 
                        
                }
            }
            if(CheckLeftRight() == "right")
            {
                if (enemy.name.Contains(MoveUpwards.FloorNum.ToString() + "right"))
                {
                    if (enemy.name == "Cactus" + MoveUpwards.FloorNum.ToString() + "right")
                    {
                        if (enemy != null)
                            potentialEnemyTarget = enemy;
                    }                           
                }
            }    
        }




        return potentialEnemyTarget;
    }


    Transform GetClosestEnemy(List<Transform> enemies)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Transform t in enemies)
        {
            float dist = Vector3.Distance(t.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }

    public IEnumerator _moveENEMY(GameObject objectToMove, Vector3 end, float seconds)
    {

       if(objectToMove != null)
        {
            Animator moveAnime = objectToMove.GetComponent<Animator>();

            float elapsedTime = 0;
            Vector3 startingPos = objectToMove.transform.position;
            while (elapsedTime < seconds)
            {
                //Shoot.enemyIsNotMoving = false;
                //add null check and condition
                if(objectToMove != null)
                {
                    objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
                    elapsedTime += Time.deltaTime;
                    yield return new WaitForEndOfFrame();
                }        
                
            }
            objectToMove.transform.position = end;
            moveAnime.SetFloat("moveSpeed", 0);
            //Shoot.enemyIsNotMoving = true;
        }
       
    }

    private void CheckEnemyHealth()
    {
        if(health.health <= 0)
        {
            enemyIsAlive = false;
        }
        else
        {
            enemyIsAlive = true;
        }
       
    }

    private int GetCurrentHealth()
    {
        int health = GetComponent<EnemyHealthScript>().health;
        return health;
    }

}
