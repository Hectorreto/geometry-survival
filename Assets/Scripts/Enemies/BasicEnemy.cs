using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public ParticleSystem ps;
    [SerializeField] int damageToPlayer = 1;

    // This is used so scripts can know when an enemy is destroyed
    public Action OnDestroy = () => {};

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<CombatManager>().TakeDamage(damageToPlayer);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Player bullet
        if (collision.gameObject.tag == "Bullet")
        {
            Explosion();
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.CompareTag("Player"))
        {
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
