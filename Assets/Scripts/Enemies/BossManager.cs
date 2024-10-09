using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    #region DamagetoPlayer
    [SerializeField] private int damageToPlayer = 1;
    [SerializeField] private float damageCooldown = 2f;
    private float nextDamageTime;
    #endregion
    private CircleCollider2D circleCollider2D;

    [SerializeField] private int health = 50;

    //Receive damage
    private GameManager gameManager;
    private int damageReceived = 1;


    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        CheckBossHealth();
        if (IsDamageOnCooldown())
        {
            circleCollider2D.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Bullet":
                TakeDamage(damageReceived);
                Destroy(collision.gameObject);
                break;

            case "DashShield":
                TakeDamage(damageReceived);
                break;

            case "BubbleShield":
                TakeDamage(damageReceived);
                collision.gameObject.SetActive(false);
                break;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            if(IsDamageOnCooldown())
            {
                collision.gameObject.GetComponent<CombatManager>().TakeDamage(damageToPlayer);
                nextDamageTime = Time.time + damageCooldown;
                circleCollider2D.enabled = false;
            }
        }
    }

    private bool IsDamageOnCooldown()
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

    public void TakeDamage(int damageReceived)
    {
        health -= damageReceived;
        print("Vida del boss: " + health);
    }

    public void CheckBossHealth()
    {
        if(health <= 0)
        {
            print("Congratulations you won the game!");
            Destroy(this.gameObject);
        }
    }
}
