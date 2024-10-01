using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public ParticleSystem ps;
    [SerializeField] private int damageToPlayer = 1;
    [SerializeField] private int scoreToAdd;
    [SerializeField] private GameObject heartItem;
    [SerializeField] private int dropHearthProbability;
    private GameManager gameManager;

    // This is used so scripts can know when an enemy is destroyed
    public Action OnDestroy = () => {};

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<CombatManager>().TakeDamage(damageToPlayer);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Bullet":
                gameManager.UpdateScore(scoreToAdd);
                Explosion();
                DropHealth();
                Destroy(collision.gameObject);
                break;

            case "DashShield":
                gameManager.UpdateScore(scoreToAdd);
                Explosion();
                DropHealth();
                break;

            case "BubbleShield":
                gameManager.UpdateScore(scoreToAdd);
                Explosion();
                DropHealth();
                collision.gameObject.SetActive(false);
                break;

            case "Player":
                collision.gameObject.GetComponent<CombatManager>().TakeDamage(damageToPlayer);
                break;
        }
    }

    public void Explosion()
    {
        Instantiate(ps, transform.position, Quaternion.identity);
        Destroy(gameObject);
        OnDestroy();
    }

    private void DropHealth()
    {
        if (heartItem == null) return;

        int randomNumber = UnityEngine.Random.Range(0, 100);

        if (randomNumber < dropHearthProbability)
        {
            Instantiate(heartItem, transform.position, Quaternion.identity);
            print("drop health");
        }
    }
}
