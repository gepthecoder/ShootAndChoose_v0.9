using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //[SerializeField]
    //[Range(0.1f, 1.5f)]
    //private float fireRate = 1f;

    //[SerializeField]
    //[Range(1, 10)]
    //private int damage = 1;

    //[SerializeField]
    //private ParticleSystem muzzleParticle;

    //[SerializeField]
    //private AudioSource gunSound;

    //[SerializeField]
    //private GameObject impactEffectOther;

    //[SerializeField]
    //private GameObject impactEffectEnemy;

    //[SerializeField]
    //private GameObject impactEffectExplosion;

    //public AudioClip explosionSound;

    //private float timer;

    //public Transform GunEndPoint;
    //public GameObject effectToSpawn;

    //public AudioClip noAmmoClip;

    //// Update is called once per frame
    //void Update()
    //{
    //    timer += Time.deltaTime;
    //    if (timer >= fireRate)
    //    {
    //        if (Input.GetButton("Fire1"))
    //        {
    //            if (AmmoManagerScript.bulletToggelBool)
    //            {
    //                if (AmmoManagerScript.HasBulletsInMagazin)
    //                {
    //                    timer = 0f;
    //                    FireGun();
    //                    AmmoManagerScript.CurrentBulletsInMag--;
    //                }
    //                else
    //                {
    //                    timer = 0f;
    //                    gunSound.PlayOneShot(noAmmoClip);
    //                }
    //            }
    //            else
    //            {

    //                if (AmmoManagerScript.HasExplosiveBulletsInMagazin)
    //                {
    //                    timer = 0f;
    //                    FireGun();
    //                    AmmoManagerScript.CurrentExplosiveBulletsInMag--;
    //                }
    //                else
    //                {
    //                    timer = 0f;
    //                    gunSound.PlayOneShot(noAmmoClip);
    //                }
    //            }

    //        }
    //    }
    //}

    //private void FireGun()
    //{
    //    muzzleParticle.Play();
    //    gunSound.Play();

    //    Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);

    //    Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);

    //    Debug.DrawRay(GunEndPoint.position, ray.direction * 100, Color.green, 1f);

    //    RaycastHit hitInfo;

    //    if (Physics.Raycast(ray, out hitInfo, 100))
    //    {

    //        EnemyHealthScript health = hitInfo.collider.GetComponent<EnemyHealthScript>();

    //        if (health != null)
    //        {
    //            if (AmmoManagerScript.bulletToggelBool)
    //            {
    //                InstantiateImpactEffectEnemy(hitInfo);
    //            }
    //            else
    //            {
    //                gunSound.PlayOneShot(explosionSound);
    //                InstantiateImpactExplosion(hitInfo);
    //            }

    //            if (health.currentHealth > 0)
    //            {
    //                health.TakeDamage(damage/*, hitInfo.point*/);

    //            }
    //        }
    //        else
    //        {
    //            if (AmmoManagerScript.bulletToggelBool) { InstantiateImpactEffectOther(hitInfo); }

    //            else { InstantiateImpactExplosion(hitInfo); }

    //        }

    //    }

    //}

    //private void InstantiateImpactEffectEnemy(RaycastHit hitInfo)
    //{
    //    GameObject ImpactGO = Instantiate(impactEffectEnemy, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
    //    Destroy(ImpactGO, 4f);
    //}

    //private void InstantiateImpactEffectOther(RaycastHit hitInfo)
    //{
    //    GameObject ImpactGO1 = Instantiate(impactEffectOther, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
    //    Destroy(ImpactGO1, 4f);
    //}

    //private void InstantiateImpactExplosion(RaycastHit hitInfo)
    //{
    //    GameObject ImpactGO2 = Instantiate(impactEffectExplosion, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
    //    Destroy(ImpactGO2, 4f);
    //}

}
