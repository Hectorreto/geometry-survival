using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField] private int damageToPlayer = 1;
    [SerializeField] private float damageCooldown = 2f;
    private float nextDamageTime;
    private BoxCollider2D boxCollider2D;
    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Cooldown())
        {
            boxCollider2D.enabled = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(Cooldown())
            {
                collision.gameObject.GetComponent<CombatManager>().TakeDamage(damageToPlayer);
                nextDamageTime = Time.time + damageCooldown;
                boxCollider2D.enabled = false;
            }
        }
    }

    private bool Cooldown()
    {
        if(Time.time > nextDamageTime)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
