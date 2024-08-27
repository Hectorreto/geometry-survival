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
    //[SerializeField]private Image[] healthSprites;
    // public event EventHandler PlayerDeath;

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
        currentHealth -= damage;
        DestroyEnemies();

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            //PlayerDeath?.Invoke(this, EventArgs.Empty);
            gameOverMenu.SetActive(true);
            Destroy(gameObject);
            Time.timeScale = 0;
        }
        playerHealthUI.UpdateHealthUI(currentHealth);
    }

    private void DestroyEnemies()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 8.0f);
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



}
