using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class ExplosionScript : MonoBehaviour
{
    public GameObject explosion;

    public int damage = 1;
    public float force;

    private GameObject player;
    private PlayerHealth health_player;

    private EnemyHealthScript health_enemy;

    private bool takeDamage;

    //private AudioSource audioSource;
    //public AudioClip explosionSound;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        health_player = player.GetComponent<PlayerHealth>();
        //audioSource = GetComponent<AudioSource>();
        takeDamage = false;
    }

    //void Update()
    //{
    //    if (takeDamage)
    //    {
            

    //        takeDamage = false;
    //    }
    //}

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Boom");
      
        //take damage
        health_enemy = other.GetComponent<EnemyHealthScript>();
        //disable enemyAttck
        other.GetComponent<EnemyAttck>().enabled = false;
        
        //take damage to player
        health_player.TakeDamage(1, 1);
        //take damage to enemy
        if (health_enemy != null)
            health_enemy.ApplyDamage(100);

        Instantiate(explosion, player.transform.position, Quaternion.identity);
        CameraShaker.Instance.ShakeOnce(1f, 1f, .05f, 1.2f);
    }
}
