using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    private float cooldown = 12.0f;
    private float bulletSpeed = 2f;
    
    private float lastTimeShot = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastTimeShot > cooldown)
        {
            if (bulletPrefab != null)
            {
                // shot the bullet
                GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
                lastTimeShot = Time.time;

                // destroy the bullet after 10 seconds
                Destroy(bullet, 20.0f);
            }
        }
    }
}
