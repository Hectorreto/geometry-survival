using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{

    // public AudioClip dieSoundClip;
    // private AudioSource dieAudioSource;
    public ParticleSystem ps;

    [SerializeField] int damageToPlayer;

    // This is used so scripts can know when an enemy is destroyed
    public Action OnDestroy = () => {};

    // Start is called before the first frame update
    void Start()
    {
        // dieAudioSource = GetComponent<AudioSource>();
        // dieAudioSource.clip = dieSoundClip;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Explosion();
            Destroy(other.gameObject);
        }

        //if (other.gameObject.tag == "Player")
        //{
        //    other.GetComponent<CombatManager>().TakeDamage(damageToPlayer);
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag ("Player"))
        {
            print("Si detecto colision");
            collision.gameObject.GetComponent<CombatManager>().TakeDamage(damageToPlayer);
        }
    }

    public void Explosion()
    {
        Instantiate(ps, transform.position, Quaternion.identity);
        Destroy(gameObject);
        OnDestroy();
    }
}
