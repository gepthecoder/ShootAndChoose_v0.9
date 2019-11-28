using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    //PlaySoundForElevatorMovement

    private AudioSource audioSource;
    public AudioClip LiftSoundClip;


    #region Sound Attempts
    //level1
    public static bool playSoundAttempt1;
    public static bool playSoundAttempt2;
    public static bool playSoundAttempt3;
    public static bool playSoundAttempt4;
    //
    //level2
    public static bool playSoundAttempt5;
    public static bool playSoundAttempt6;
    //
    //level3
    public static bool playSoundAttempt7;
    public static bool playSoundAttempt8;
    //
    //level4
    public static bool playSoundAttempt9;
    public static bool playSoundAttempt10;
    public static bool playSoundAttempt11;
    //
    //level5
    public static bool playSoundAttempt12;
    public static bool playSoundAttempt13;
    public static bool playSoundAttempt14;
    //
    //level6
    public static bool playSoundAttempt15;
    public static bool playSoundAttempt16;
    //
    //level7
    public static bool playSoundAttempt17;
    public static bool playSoundAttempt18;
    public static bool playSoundAttempt19;
    //
    //level8
    public static bool playSoundAttempt20;
    //
    //level9
    public static bool playSoundAttempt21;
    public static bool playSoundAttempt22;
    //
    //level10
    public static bool playSoundAttempt23;
    public static bool playSoundAttempt24;
    public static bool playSoundAttempt25;
    //
    //level11
    public static bool playSoundAttempt26;
    public static bool playSoundAttempt27;
    public static bool playSoundAttempt28;
    //
    //level12
    public static bool playSoundAttempt29;
    public static bool playSoundAttempt30;
    public static bool playSoundAttempt31;
    //
    //level13
    public static bool playSoundAttempt32;
    public static bool playSoundAttempt33;
    public static bool playSoundAttempt34;
    //
    //level14
    public static bool playSoundAttempt35;
    public static bool playSoundAttempt36;
    public static bool playSoundAttempt37;
    //
    //level15
    public static bool playSoundAttempt38;
    //
    //level16
    public static bool playSoundAttempt39;
    //
    //level17
    public static bool playSoundAttempt40;
    //
    //level18
    public static bool playSoundAttempt41;
    public static bool playSoundAttempt42;
    //
    //level19
    public static bool playSoundAttempt43;
    public static bool playSoundAttempt44;
    //
    //level20
    public static bool playSoundAttempt45;
    //
    //level21
    public static bool playSoundAttempt46;
    #endregion


    #region One Time Attempt
    public int attempt1;
    public int attempt2;
    public int attempt3;
    public int attempt4;

    public int attempt5;
    public int attempt6;

    public int attempt7;
    public int attempt8;
    public int attempt9;
    public int attempt10;

    public int attempt11;
    public int attempt12;

    public int attempt13;
    public int attempt14;
    public int attempt15;
    public int attempt16;

    public int attempt17;
    public int attempt18;

    public int attempt19;

    public int attempt20;
    public int attempt21;

    public int attempt22;
    public int attempt23;
    public int attempt24;
    public int attempt25;

    public int attempt26;
    public int attempt27;

    public int attempt28;
    public int attempt29;
    public int attempt30;
    public int attempt31;

    public int attempt32;
    public int attempt33;

    public int attempt34;
    public int attempt35;
    public int attempt36;
    public int attempt37;

    public int attempt38;
    public int attempt39;

    public int attempt40;

    public int attempt41;
    public int attempt42;

    public int attempt43;
    public int attempt44;

    public int attempt45;

    public int attempt46;
    public int attempt47;
    #endregion


    public Animator Anime;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        SetValues();
    }

    void Update()
    {
        PlayElevatorSound();
    }

    private void PlayElevatorSound()
    {
        if (playSoundAttempt1 && attempt1 == 0)
        {
            PlaySoundClip1();
            playSoundAttempt1 = false;
        }
        else if (playSoundAttempt2 && attempt2 == 0)
        {
            PlaySoundClip2();
            playSoundAttempt2 = false;
        }
        else if (playSoundAttempt3 && attempt3 == 0)
        {
            PlaySoundClip3();
            playSoundAttempt3 = false;
        }
        else if (playSoundAttempt4 && attempt4 == 0)
        {
            PlaySoundClip4();
            playSoundAttempt4 = false;
        }
        else if (playSoundAttempt5 && attempt5 == 0)
        {
            PlaySoundClip5();
            playSoundAttempt5 = false;
        }
        else if (playSoundAttempt6 && attempt6 == 0)
        {
            PlaySoundClip6();
            playSoundAttempt6 = false;
        }
        else if (playSoundAttempt7 && attempt7 == 0)
        {
            PlaySoundClip7();
            playSoundAttempt7 = false;
        }
        else if (playSoundAttempt8 && attempt8 == 0)
        {
            PlaySoundClip8();
            playSoundAttempt8 = false;
        }
        else if (playSoundAttempt9 && attempt9 == 0)
        {
            PlaySoundClip9();
            playSoundAttempt9 = false;
        }
        else if (playSoundAttempt10 && attempt10 == 0)
        {
            PlaySoundClip10();
            playSoundAttempt10 = false;
        }
        else if (playSoundAttempt11 && attempt11 == 0)
        {
            PlaySoundClip11();
            playSoundAttempt11 = false;
        }
        else if (playSoundAttempt12 && attempt12 == 0)
        {
            PlaySoundClip12();
            playSoundAttempt12 = false;
        }
        else if (playSoundAttempt13 && attempt13 == 0)
        {
            PlaySoundClip13();
            playSoundAttempt13 = false;
        }
        else if (playSoundAttempt14 && attempt14 == 0)
        {
            PlaySoundClip14();
            playSoundAttempt14 = false;
        }
        else if (playSoundAttempt15 && attempt15 == 0)
        {
            PlaySoundClip15();
            playSoundAttempt15 = false;
        }
        else if (playSoundAttempt16 && attempt16 == 0)
        {
            PlaySoundClip16();
            playSoundAttempt16 = false;
        }
        else if (playSoundAttempt17 && attempt17 == 0)
        {
            PlaySoundClip17();
            playSoundAttempt17 = false;
        }
        else if (playSoundAttempt18 && attempt18 == 0)
        {
            PlaySoundClip18();
            playSoundAttempt18 = false;
        }
        else if (playSoundAttempt19 && attempt19 == 0)
        {
            PlaySoundClip19();
            playSoundAttempt19 = false;
        }
        else if (playSoundAttempt20 && attempt20 == 0)
        {
            PlaySoundClip20();
            playSoundAttempt20 = false;
        }
        else if (playSoundAttempt21 && attempt21 == 0)
        {
            PlaySoundClip21();
            playSoundAttempt21 = false;
        }
        else if (playSoundAttempt22 && attempt22 == 0)
        {
            PlaySoundClip22();
            playSoundAttempt22 = false;
        }
        else if (playSoundAttempt23 && attempt23 == 0)
        {
            PlaySoundClip23();
            playSoundAttempt23 = false;
        }
        else if (playSoundAttempt24 && attempt24 == 0)
        {
            PlaySoundClip24();
            playSoundAttempt24 = false;
        }
        else if (playSoundAttempt25 && attempt25 == 0)
        {
            PlaySoundClip25();
            playSoundAttempt25 = false;
        }
        else if (playSoundAttempt26 && attempt26 == 0)
        {
            PlaySoundClip26();
            playSoundAttempt26 = false;
        }
        else if (playSoundAttempt27 && attempt27 == 0)
        {
            PlaySoundClip27();
            playSoundAttempt27 = false;
        }
        else if (playSoundAttempt28 && attempt28 == 0)
        {
            PlaySoundClip28();
            playSoundAttempt28 = false;
        }
        else if (playSoundAttempt29 && attempt29 == 0)
        {
            PlaySoundClip29();
            playSoundAttempt29 = false;
        }
        else if (playSoundAttempt30 && attempt30 == 0)
        {
            PlaySoundClip30();
            playSoundAttempt30 = false;
        }
        else if (playSoundAttempt31 && attempt31 == 0)
        {
            PlaySoundClip31();
            playSoundAttempt31 = false;
        }
        else if (playSoundAttempt32 && attempt32 == 0)
        {
            PlaySoundClip32();
            playSoundAttempt32 = false;
        }
        else if (playSoundAttempt33 && attempt33 == 0)
        {
            PlaySoundClip33();
            playSoundAttempt33 = false;
        }
        else if (playSoundAttempt34 && attempt34 == 0)
        {
            PlaySoundClip34();
            playSoundAttempt34 = false;
        }
        else if (playSoundAttempt35 && attempt35 == 0)
        {
            PlaySoundClip35();
            playSoundAttempt35 = false;
        }
        else if (playSoundAttempt36 && attempt36 == 0)
        {
            PlaySoundClip36();
            playSoundAttempt36 = false;
        }
        else if (playSoundAttempt37 && attempt37 == 0)
        {
            PlaySoundClip37();
            playSoundAttempt37 = false;
        }
        else if (playSoundAttempt38 && attempt38 == 0)
        {
            PlaySoundClip38();
            playSoundAttempt38 = false;
        }
        else if (playSoundAttempt39 && attempt39 == 0)
        {
            PlaySoundClip39();
            playSoundAttempt39 = false;
        }
        else if (playSoundAttempt40 && attempt40 == 0)
        {
            PlaySoundClip40();
            playSoundAttempt40 = false;
        }
        else if (playSoundAttempt41 && attempt41 == 0)
        {
            PlaySoundClip41();
            playSoundAttempt41 = false;
        }
        else if (playSoundAttempt42 && attempt42 == 0)
        {
            PlaySoundClip42();
            playSoundAttempt42 = false;
        }
        else if (playSoundAttempt43 && attempt43 == 0)
        {
            PlaySoundClip43();
            playSoundAttempt43 = false;
        }
        else if (playSoundAttempt44 && attempt44 == 0)
        {
            PlaySoundClip44();
            playSoundAttempt44 = false;
        }
        else if (playSoundAttempt45 && attempt45 == 0)
        {
            PlaySoundClip45();
            playSoundAttempt45 = false;
        }
        else if (playSoundAttempt46 && attempt46 == 0)
        {
            PlaySoundClip46();
            playSoundAttempt46 = false;
        }
      
    }
    private void SetValues()
    {
        attempt1 = 0;
        attempt2 = 0;
        attempt3 = 0;
        attempt4 = 0;
        attempt5 = 0;
        attempt6 = 0;
        attempt7 = 0;
        attempt8 = 0;
        attempt9 = 0;
        attempt10 = 0;

        attempt11 = 0;
        attempt12 = 0;

        attempt13 = 0;
        attempt14 = 0;
        attempt15 = 0;
        attempt16 = 0;

        attempt17 = 0;
        attempt18 = 0;

        attempt19 = 0;

        attempt20 = 0;
        attempt21 = 0;

        attempt22 = 0;
        attempt23 = 0;
        attempt24 = 0;
        attempt25 = 0;

        attempt26 = 0;
        attempt27 = 0;
        attempt28 = 0;
        attempt29 = 0;
        attempt30 = 0;
        attempt31 = 0;
        attempt32 = 0;
        attempt33 = 0;
        attempt34 = 0;
        attempt35 = 0;
        attempt36 = 0;
        attempt37 = 0;
        attempt38 = 0;
        attempt39 = 0;
        attempt40 = 0;
        attempt41 = 0;
        attempt42 = 0;
        attempt43 = 0;
        attempt44 = 0;
        attempt45 = 0;

        attempt46 = 0;
        attempt47 = 0;
    }

    private void PlaySoundClip1()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt1++;
    }
    private void PlaySoundClip2()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt2++;
    }
    private void PlaySoundClip3()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt3++;
    }
    private void PlaySoundClip4()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt4++;
    }

    private void PlaySoundClip5()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt5++;
    }
    private void PlaySoundClip6()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt6++;
    }

    private void PlaySoundClip7()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt7++;
    }
    private void PlaySoundClip8()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt8++;
    }
    private void PlaySoundClip9()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt9++;
    }
    private void PlaySoundClip10()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt10++;
    }
    private void PlaySoundClip11()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt11++;
    }
    private void PlaySoundClip12()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt12++;
    }
    private void PlaySoundClip13()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt13++;
    }
    private void PlaySoundClip14()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt14++;
    }
    private void PlaySoundClip15()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt15++;
    }
    private void PlaySoundClip16()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt16++;
    }
    private void PlaySoundClip17()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt17++;
    }
    private void PlaySoundClip18()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt18++;
    }
    private void PlaySoundClip19()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt19++;
    }
    private void PlaySoundClip20()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt20++;
    }
    private void PlaySoundClip21()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt21++;
    }
    private void PlaySoundClip22()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt22++;
    }
    private void PlaySoundClip23()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt23++;
    }
    private void PlaySoundClip24()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt24++;
    }
    private void PlaySoundClip25()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt25++;
    }
    private void PlaySoundClip26()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt26++;
    }
    private void PlaySoundClip27()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt27++;
    }
    private void PlaySoundClip28()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt28++;
    }
    private void PlaySoundClip29()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt29++;
    }
    private void PlaySoundClip30()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt30++;
    }
    private void PlaySoundClip31()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt31++;
    }
    private void PlaySoundClip32()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt32++;
    }
    private void PlaySoundClip33()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt33++;
    }
    private void PlaySoundClip34()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt34++;
    }
    private void PlaySoundClip35()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt35++;
    }
    private void PlaySoundClip36()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt36++;
    }
    private void PlaySoundClip37()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt37++;
    }
    private void PlaySoundClip38()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt38++;
    }
    private void PlaySoundClip39()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt39++;
    }
    private void PlaySoundClip40()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt40++;
    }
    private void PlaySoundClip41()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt41++;
    }
    private void PlaySoundClip42()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt42++;
    }
    private void PlaySoundClip43()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt43++;
    }
    private void PlaySoundClip44()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt44++;
    }
    private void PlaySoundClip45()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt45++;
    }
    private void PlaySoundClip46()
    {
        audioSource.PlayOneShot(LiftSoundClip);
        attempt46++;
    }


}
