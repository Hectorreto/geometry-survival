using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CombatManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] private int health;
    public event EventHandler PlayerDeath;


    private void Update()
    {
        print(health);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        DestroyEnemies();

        if (health <= 0)
        {
            //PlayerDeath?.Invoke(this, EventArgs.Empty);
            gameOverMenu.SetActive(true);
            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }

    private void DestroyEnemies()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 8.0f);
        foreach (var rangeEnemies in colliders)
        {
            if (rangeEnemies.gameObject.CompareTag("Enemy"))
            {
                rangeEnemies.GetComponent<BasicEnemy>().Explosion();
            }
        }
    }



}
