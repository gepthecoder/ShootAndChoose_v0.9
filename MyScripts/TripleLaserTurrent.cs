using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleLaserTurrent : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint1;
    public Transform firePoint2;

    public GameObject missile;
    public GameObject impactEffectOther;

    private float timer;
    private float fireRate = 0.5f;


    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            FireCanonBlast(firePoint);
            FireCanonBlast1(firePoint1);
            FireCanonBlast2(firePoint2);
            timer = 0;
        }
    }

  

    void FireCanonBlast(Transform gunEndPoint)
    {
        Vector3 fwd = gunEndPoint.TransformDirection(Vector3.forward); //forward direction
        Ray ray = new Ray(gunEndPoint.position, fwd);
        RaycastHit hit;

        Debug.DrawRay(gunEndPoint.position, ray.direction * 100, Color.green, 1f);
       
        if (Physics.Raycast(ray, out hit, 100))
        {           
            //StartCoroutine(shootEffectsLaser(hit));
            Debug.Log("I've hitted : " + hit.collider.name);
            StartCoroutine(InstantiateMissle(hit, gunEndPoint));
            InstantiateImpactEffectOther(hit);
        }
    }

    void FireCanonBlast1(Transform gunEndPoint)
    {
        Vector3 fwd = gunEndPoint.TransformDirection(Vector3.forward); //forward direction
        Ray ray = new Ray(gunEndPoint.position, fwd);
        RaycastHit hit;

        Debug.DrawRay(gunEndPoint.position, ray.direction * 100, Color.green, 1f);

        if (Physics.Raycast(ray, out hit, 100))
        {
            //StartCoroutine(shootEffectsLaser(hit));
            Debug.Log("I've hitted : " + hit.collider.name);
            StartCoroutine(InstantiateMissle(hit, gunEndPoint));
            InstantiateImpactEffectOther(hit);
        }
    }

    void FireCanonBlast2(Transform gunEndPoint)
    {
        Vector3 fwd = gunEndPoint.TransformDirection(Vector3.forward); //forward direction
        Ray ray = new Ray(gunEndPoint.position, fwd);
        RaycastHit hit;

        Debug.DrawRay(gunEndPoint.position, ray.direction * 100, Color.green, 1f);

        if (Physics.Raycast(ray, out hit, 100))
        {
            //StartCoroutine(shootEffectsLaser(hit));
            Debug.Log("I've hitted : " + hit.collider.name);
            StartCoroutine(InstantiateMissle(hit, gunEndPoint));
            InstantiateImpactEffectOther(hit);
        }
    }

    private IEnumerator InstantiateMissle(RaycastHit hitInfo, Transform gunEndPoint)
    {
        Vector3 scale = new Vector3(missile.transform.localScale.x + 0.1f, missile.transform.localScale.y + 0.1f, missile.transform.localScale.z + 0.1f);
        missile.transform.position.Scale(scale);
        GameObject missle = Instantiate(missile, gunEndPoint.position, gunEndPoint.rotation) as GameObject;
        Destroy(missle, 2f);
        yield return new WaitForSeconds(1f);
    }

    private void InstantiateImpactEffectOther(RaycastHit hitInfo)
    {
        GameObject ImpactGO1 = Instantiate(impactEffectOther, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
        Destroy(ImpactGO1, 4f);
    }

   
}
