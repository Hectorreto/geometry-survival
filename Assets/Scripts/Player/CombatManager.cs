using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] private int maxHealth;
    private int currentHealth;
    public PlayerHealth playerHealthUI;
    public bool hasShield = false;
    //[SerializeField]private Image[] healthSprites;
    // public event EventHandler PlayerDeath;
    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        currentHealth = maxHealth;
        playerHealthUI.UpdateHealthUI(currentHealth);
    }


    private void Update()
    {
        // print(health);
    }

    public void TakeDamage(int damage)
    {
        DestroyEnemies();
        if (hasShield) return;
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            this.gameObject.GetComponent<EmbededSyntax>().gameObject.SetActive(false);
            Invoke("BeforeGameOver", 1f);
        }
        playerHealthUI.UpdateHealthUI(currentHealth);
    }

    private void DestroyEnemies()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 6.0f);
        foreach (var rangeEnemies in colliders)
        {
            if (rangeEnemies.gameObject.CompareTag("Enemy"))
            {
                BasicEnemy basicEnemy = rangeEnemies.GetComponent<BasicEnemy>();
                if (basicEnemy != null)
                {
                    basicEnemy.Explosion();
                }
            }
        }
    }

    void BeforeGameOver()
    {
        currentHealth = 0;
        //PlayerDeath?.Invoke(this, EventArgs.Empty);
        gameOverMenu.SetActive(true);
        Destroy(gameObject);
        Time.timeScale = 0;
    }

    public void AddHealth(int health, int score)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += health;
        } else
        {
            gameManager.UpdateScore(score);
        }

        playerHealthUI.UpdateHealthUI(currentHealth);
    }
}
