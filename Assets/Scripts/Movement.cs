using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

public class Movement : MonoBehaviour
{
    public float speed = 5.0f;
    public float bulletSpeed = 12.0f;
    public GameObject bulletPrefab;
    public int health = 3;
    //public event EventHandler PlayerDeath;

    void Update()
    {
        // move the player ignoring where it is facing
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        GetComponent<Rigidbody2D>().velocity = movement * speed;

        // rotate to face the mouse
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPos = transform.position;
        float angle = Mathf.Atan2(mousePos.y - playerPos.y, mousePos.x - playerPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // shot a bullet when click mouse
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;

            // destroy the bullet after 5 seconds
            Destroy(bullet, 5.0f);
        }


        //CheckHealth();
    }

    //public void CheckHealth()
    //{
    //    if (health <= 0)
    //    {
    //        PlayerDeath?.Invoke(this, EventArgs.Empty);
    //        Destroy(gameObject);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            health -= 1;
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {   
            DestroyEnemies();
            health -= 1;

            //if (health <= 0)
            //{
            //    PlayerDeath?.Invoke(this, EventArgs.Empty);
            //    Destroy(gameObject);
            //}
        }
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
