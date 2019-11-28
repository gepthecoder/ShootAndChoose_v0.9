using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimationsFloors : MonoBehaviour
{
    private Animator anime;
    private AudioSource audioSource;

    public AudioClip movingPlatformClip;

    public int attemptLeft;
    public int attemptRight;
    
    public int attemptLeft1;
    public int attemptRight1;
    
    public int attemptLeft2;
    public int attemptRight2;
    
    public int attemptLeft3;
    public int attemptRight3;


    private void SetValues()
    {
        attemptLeft = 0;
        attemptRight = 0;

        attemptLeft1 = 0;
        attemptRight1 = 0;

        attemptLeft2 = 0;
        attemptRight2 = 0;

        attemptLeft3 = 0;
        attemptRight3 = 0;

    }

    private void Awake()
    {
        anime = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        SetValues();

    }

    private void Start()
    {
        anime.SetTrigger("SecondStairs");
    }

    private void Update()
    {

        HandleThirdPathwayLeft();
        HandleThirdPathwayRight();

    }

    IEnumerator Resetfail()
    {
        yield return new WaitForSeconds(10f);
        SetValues();
    }
    private void HandleThirdPathwayLeft()
    {
        if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 2 && attemptLeft == 0)
        {
            anime.SetTrigger("SecondAttemptFailLeft1");
            attemptLeft++;
            StartCoroutine(Resetfail());
        }

        else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 3 && attemptLeft1 == 0)
        {
            anime.SetTrigger("SecondAttemptFailLeft2");
            attemptLeft1++;
            StartCoroutine(Resetfail());
        }

        else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 4 && attemptLeft2 == 0)
        {
            anime.SetTrigger("SecondAttemptFailLeft3");
            StartCoroutine(Resetfail());
        }

        else if (Shoot.missedLeftShots >= 2 && MoveUpwards.FloorNum == 5 && attemptLeft3 == 0)
        {
            anime.SetTrigger("SecondAttemptFailLeft4");
            attemptLeft3++;
            StartCoroutine(Resetfail());
        }
    }


    private void HandleThirdPathwayRight()
    {
        if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 2 && attemptRight == 0)
        {
            attemptRight++;
            anime.SetTrigger("SecondAttemptFailRight1");
            StartCoroutine(Resetfail());

        }

        else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 3 && attemptRight1 == 0)
        {
            anime.SetTrigger("SecondAttemptFailRight2");
            attemptRight1++;
            StartCoroutine(Resetfail());

        }

        else if (Shoot.missedRightShots >= 2 && MoveUpwards.FloorNum == 4 && attemptRight2 == 0)
        {
            anime.SetTrigger("SecondAttemptFailRight3");
            attemptRight2++;
            StartCoroutine(Resetfail());

        }

        else if (Shoot.missedRightShots == 2 && MoveUpwards.FloorNum == 5 && attemptRight3 == 0)
        {
            anime.SetTrigger("SecondAttemptFailRight4");
            attemptRight3++;
            StartCoroutine(Resetfail());

        }
    }

    public void PlaySound()
    {
        audioSource.PlayOneShot(movingPlatformClip);
    }

}
