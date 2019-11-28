using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftAttack : MonoBehaviour
{
    public static bool IamDeadCanYouHelp;

    public GameObject Player;

    public GameObject laserBeaam;
    public GameObject impactEffectBoss;
    public GameObject explosionHit;

    public Transform gunEndPoint;
    private Animator anime;
    public Animator attckAnime;

    private AudioSource audioSource;
    public AudioClip laserSound;

    private Vector3 startPos;

    private float weaponRange;
    private float time;
    private float timer;

    private BossAI bossAI;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        weaponRange = 30f;
        startPos = transform.position;
        bossAI = GetComponent<BossAI>();
      
    }

    // Update is called once per frame
    void Update()
    {
        
        time += Time.deltaTime;

        if (BossAI.canAttckLeft == true || RightAttack.IamDeadCanYouHelp)
        {
            BossAI health = GetComponent<BossAI>();

            if(health.bossHealth > 0)
            {
                if (time > 5f)
                {
                    time = 0;
                    RightAttack.IamDeadCanYouHelp = false;
                    StartCoroutine(BossAttackCombo());
                }
            }              
            else { IamDeadCanYouHelp = true; }
               
        }

        if (MoveUpwards.FloorNum >= bossAI.shoot.lastFloor - 1)
        {

            LockOnTarget();

        }

    }
    
    private IEnumerator WaitAndDisableAnime()
    {
        yield return new WaitForSeconds(1f);
        anime.enabled = false;
    }

    private void LockOnTarget()
    {
        transform.LookAt(Player.transform);
        //transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void FireLaser(Transform gunEndPoint)
    {

        audioSource.PlayOneShot(laserSound);

        Vector3 fwd = gunEndPoint.TransformDirection(Vector3.forward); //forward direction
        Ray ray = new Ray(gunEndPoint.position, fwd);
        RaycastHit hit;

        Debug.DrawRay(gunEndPoint.position, ray.direction * weaponRange, Color.green, 5f);

        if (Physics.Raycast(ray, out hit, 20))
        {
            StartCoroutine(InstantiateMissle(hit, gunEndPoint));
            //StartCoroutine(shootEffectsLaser(hit));
            Debug.Log("I " + gameObject.name + " have hitted : " + hit.collider.name);

            if (hit.collider.gameObject.tag == "targetPlayer" || hit.collider.gameObject.tag == "Platform")
            {

                PlayerHealth.Instance.TakeDamage(1, 1);
                InstantiateImpactEffectBoss(hit);
                InstatiateExplosion(hit);                  
            }
            else
            {
                //Shoudnt happen.. just in case
                InstantiateImpactEffectBoss(hit);
                InstatiateExplosion(hit);
            }
        }

        #region Snippet 01
        //PlayerHealth playerHealth = hit.collider.GetComponent<PlayerHealth>();

        //if (playerHealth != null)
        //{
        //    //AI hit player
        //    InstantiateImpactEffectBoss(hit);
        //    InstatiateExplosion(hit);
        //    playerHealth.playerHealth -= damageToTake;
        //}
        #endregion

    }

    private IEnumerator BossAttackCombo()
    {
        yield return new WaitForSeconds(1.0f);

        FireLaser(gunEndPoint);

        BossAI.canAttckLeft = false;

    }

    public void DisableAnime()
    {
        anime.enabled = false;
    }

    private IEnumerator InstantiateMissle(RaycastHit hitInfo, Transform gunEndPointPosition)
    {
        GameObject missle = Instantiate(laserBeaam, gunEndPointPosition.position, gunEndPointPosition.rotation) as GameObject;
        Destroy(missle, 2f);
        yield return new WaitForSeconds(1f);
    }

    private void InstantiateImpactEffectBoss(RaycastHit hitInfo)
    {
        GameObject ImpactGO = Instantiate(impactEffectBoss, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
        Destroy(ImpactGO, 4f);
    }
    private void InstatiateExplosion(RaycastHit hitInfo)
    {
        GameObject ImpactGO2 = Instantiate(explosionHit, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
        Destroy(ImpactGO2, 4f);
    }
}
