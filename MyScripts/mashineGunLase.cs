using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mashineGunLase : MonoBehaviour
{
    public Transform gunEndPoint;

    public GameObject impactEffectOther;
    public GameObject laserBeaaam;
    private int weaponRange = 50;

    public float fireRate = 0.3f;
    public float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > fireRate)
            ShootLaser();
    }

    private void ShootLaser()
    {
        Vector3 fwd = gunEndPoint.TransformDirection(Vector3.forward); //forward direction
        Ray ray = new Ray(gunEndPoint.position, fwd);
        RaycastHit hit;

        Debug.DrawRay(gunEndPoint.position, ray.direction * weaponRange, Color.green, 1f);

        if (Physics.Raycast(ray, out hit, 100))
        {
            StartCoroutine(InstantiateMissle(hit));
            InstantiateImpactEffectOther(hit);
            timer = 0;
        }
    }

    private IEnumerator InstantiateMissle(RaycastHit hitInfo)
    {
        laserBeaaam.transform.localScale = new Vector3(.08f,.08f, .08f);
        GameObject missle = Instantiate(laserBeaaam, gunEndPoint.position, gunEndPoint.rotation) as GameObject;
        Destroy(missle, 2f);
        yield return new WaitForSeconds(1f);
    }

    private void InstantiateImpactEffectOther(RaycastHit hitInfo)
    {
        GameObject ImpactGO1 = Instantiate(impactEffectOther, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
        Destroy(ImpactGO1, 4f);
    }
}
