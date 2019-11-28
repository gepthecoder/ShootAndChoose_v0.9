using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour
{
    float rotationSpeed = 2.0f;

    private void Update()
    {
        StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 100), Time.deltaTime * rotationSpeed);
        yield return new WaitForSeconds(1f);
    }



}
